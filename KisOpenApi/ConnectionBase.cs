using System.Net.WebSockets;
using System.Text.Json;
using KisOpenApi.Models;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;
using Websocket.Client;

namespace KisOpenApi;
public class ConnectionBase
{
    internal readonly string host = "https://openapi.koreainvestment.com:9443";
    internal readonly string hostSocket = "ws://ops.koreainvestment.com:21000";
    internal readonly string grant_type = "client_credentials";

	public KeyPack KeyInfo { get => _keyInfo; }
	private KeyPack _keyInfo = new KeyPack();
	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;

	public Account AccountInfo { get => _accountInfo; }
	private Account _accountInfo = new Account();
	public void SetAccount(Account account) => _accountInfo = account;

	public BankAccount BankAccountInfo { get => _bankAccountInfo; }
	private BankAccount _bankAccountInfo = new BankAccount();
	public void SetBankAccount(BankAccount bankAccount) => _bankAccountInfo = bankAccount;

	public bool IsConnected { get => _connected; }
	private bool _connected = false;
	protected void SetConnect(bool connecting = true) => _connected = connecting;

	public required EventHandler<ResponseCore> Message { get; set; }

	protected IWebsocketClient? Client;

	protected string _iv = string.Empty;
	protected string _key = string.Empty;

	private Dictionary<string, SubscriptionPack> _subscriptions = new();

	private List<Request> Requests = [];

	#region Request Access Token using appkey & secret
	/// <summary>
	/// Request Access Token using appkey & secret
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="appsecret"></param>
	/// <returns></returns>
	public async Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret)
	{
		var body = new
		{
			grant_type,
			appkey,
			appsecret
		};

		try
		{
			var client = new RestClient($"{host}/oauth2/tokenP");
			var request = new RestRequest()
				.AddHeaders(new Dictionary<string, string>
				{
					{ "Content-Type", "application/json; charset=UTF-8" },
				})
				.AddJsonBody(body);
			var response = await client.PostAsync<AccessTokenResponse>(request);

			if (response is null) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response is null"
			};

			if (string.IsNullOrEmpty(response.AccessToken)) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.UNAUTHORIZED,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = response.ReturnCode
			};

			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.SUCCESS,
				Info = new KeyPack
				{
					AccessToken = response.AccessToken,
					AccessTokenExpired = response.DateExpired
				},
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"catch error: {ex.Message}"
			};
		}
	}
	#endregion

	#region Request Websocket Code using appkey, secret & access token
	/// <summary>
	/// Request Websocket Code using appkey, secret & access token
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="secretkey"></param>
	/// <param name="token"></param>
	/// <returns></returns>
	public async Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey)
	{
		var body = new
		{
			grant_type,
			appkey,
			secretkey
		};

		try
		{
			var client = new RestClient($"{host}/oauth2/Approval");
			var request = new RestRequest()
				.AddHeaders(new Dictionary<string, string>
				{
					{ "Content-Type", "application/json; charset=UTF-8" },
				})
				.AddJsonBody(body);
			var response = await client.PostAsync<ApprovalKeyResponse>(request);

			if (response is null) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "/auth2/approval: response is null",
			};

			if (string.IsNullOrEmpty(response.ApprovalKey)) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.UNAUTHORIZED,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = response.ReturnCode
			};

			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.SUCCESS,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = response.ReturnCode,
				Info = new KeyPack { WebsocketCode = response.ApprovalKey },
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"catch error from /oauth2/Approval: ${ex.Message}"
			};
		}
	}
	#endregion

	#region Connect/disconnect Websocket
	/// <summary>
	/// Connect Websocket & subscribe Order/Contract
	/// </summary>
	/// <returns></returns>
	public async Task<ResponseCore> ConnectAsync()
	{
		try
		{
			var options = new Func<ClientWebSocket>(() => new ClientWebSocket
			{
				Options = { KeepAliveInterval = TimeSpan.Zero }
			});

			Client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "KIS",
				ReconnectTimeout = TimeSpan.FromSeconds(20),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
			};

			Client.MessageReceived.Subscribe(message => SubscribeCallback(message));
			Client.ReconnectionHappened.Subscribe(async info => await ReconnectCallback(info));
			await Client.Start();

			SetConnect();

			foreach (KeyValuePair<string, SubscriptionPack> subscription in _subscriptions)
			{
				await SubscribeAsync("RECONNECTION", subscription.Key, subscription.Value.Key);
			}

			return new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Message = "Connected"
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				Remark = "during connect websocket"
			};
		}
	}

	public async Task<ResponseCore> DisconnectAsync()
	{
		if (Client is null) return new ResponseCore
		{
			Code = "NOCONNECTION",
			Message = "no connection to disconnect or already disconnected"
		};

		await Client.Stop(WebSocketCloseStatus.NormalClosure, "");
		Client.Dispose();
		SetConnect(false);

		foreach (KeyValuePair<string, SubscriptionPack> subscription in _subscriptions)
		{
			await SubscribeAsync("SYS", subscription.Key, subscription.Value.Key, false);
		}

		return new ResponseCore
		{
			Message = "disconnected"
		};
	}
	#endregion

	#region Subscribe / Unsubscribe
	protected async Task<ResponseCore> SubscribeAsync(string subscriber, string trCode, string key, bool connecting = true)
	{
		if (Client is null) return new ResponseCore
		{
			Code = "NULLERR",
			Message = "Client is null",
			Remark = subscriber
		};

		string GenerateSubscriptionRequest(string id, string key = "", bool connecting = true)
		{
			if (string.IsNullOrWhiteSpace(key)) key = AccountInfo.ID;

			return JsonSerializer.Serialize(new KisSubscriptionRequest(KeyInfo.WebsocketCode, id, key, connecting));
		}

		try
		{
			var needsAction = false;
			var message = string.Empty;

			if (connecting)
			{
				if (subscriber == "RECONNECTION")
				{
					needsAction = true;
				}
				else if (_subscriptions.ContainsKey($"{trCode}-{key}"))
				{
					if (_subscriptions[$"{trCode}-{key}"].Subscriber.Contains(subscriber))
					{
						message = "already subscribing!";
					}
					else
					{
						_subscriptions[$"{trCode}-{key}"].Subscriber.Add(subscriber);
					}
				}
				else
				{
					_subscriptions.Add($"{trCode}-{key}", new SubscriptionPack
					{
						TrCode = trCode,
						Key = key,
						Subscriber = new List<string> { subscriber }
					});
					needsAction = true;
				}
			}
			else
			{
				if (_subscriptions.ContainsKey($"{trCode}-{key}"))
				{
					if (subscriber == "SYS")
					{
						needsAction = true;
						_subscriptions.Remove($"{trCode}-{key}");
					}
					else if (_subscriptions[$"{trCode}-{key}"].Subscriber.Contains(subscriber))
					{
						_subscriptions[$"{trCode}-{key}"].Subscriber.Remove(subscriber);
						if (!_subscriptions[$"{trCode}-{key}"].Subscriber.Any())
						{
							_subscriptions.Remove($"{trCode}-{key}");
							needsAction = true;
						}
					}
					else
					{
						message = "not subscribing";
					}
				}
			}

			if (!needsAction) return new ResponseCore
			{
				Typ = MessageType.SUB,
				StatusCode = Status.SUCCESS,
				Code = "NOACTION",
				Message = message
			};

			var result = await Task.Run(() => Client.Send(GenerateSubscriptionRequest(trCode, key, connecting)));

			Message(this, new ResponseCore
			{
				Typ = MessageType.SUB,
				Code = $"{trCode}({key})",
				Message = $"Sent {(connecting ? "subscribe" : "unsubscribe")} request.",
			});

			return new ResponseCore
			{
				StatusCode = result ? Status.SUCCESS : Status.ERROR_OPEN_API,
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"catch error : {ex.Message}",
				Remark = $"from {System.Reflection.MethodBase.GetCurrentMethod()?.Name} connecting is {connecting}"
			};
		};
	} 
	#endregion

	#region Websocket Callback
	/// <summary>
	/// Websocket Callback
	/// </summary>
	/// <param name="message"></param>
	protected void SubscribeCallback(ResponseMessage message)
	{
		if (message is null || message.MessageType != WebSocketMessageType.Text)
		{
			Message(this, new ResponseCore
			{
				Typ = MessageType.SYSERR,
				Code = "BINARY",
				Message = "binary message type"
			});
			return;
		}

		if (message.Text is null)
		{
			Message(this, new ResponseCore
			{
				Typ = MessageType.SYSERR,
				Code = "TEXTNULL",
				Message = "message.Text is null"
			});
			return;
		}

		if (message.Text.StartsWith("{")) ParseCallbackMessage(message.Text);
		else if (new string[] { "0", "1" }.Contains(message.Text.Substring(0, 1))) ParseCallbackResponse(message.Text);
		else
		{
			Message(this, new ResponseCore
			{
				Typ = MessageType.SYSERR,
				Code = "WEIRD_MESSAGE",
				Message = "message format is weird",
				Remark = message.Text
			});
		}
	}

	protected async Task ReconnectCallback(ReconnectionInfo info)
	{
		if (info.Type is ReconnectionType.Initial) return;

		foreach (var subscirption in _subscriptions)
		{
			var response = await SubscribeAsync("RECONNECTION", subscirption.Key, subscirption.Value.Key);
			if (response is null || response.StatusCode != Status.SUCCESS)
			{
				Message(this, new ResponseCore
				{
					Typ = MessageType.SYSERR,
					Code = "RECON-FAIL",
					Message = $"subscription {subscirption.Key} failed during reconnection",
					Remark = subscirption.Value.Key
				});
			}
		}

		Message(this, new ResponseCore
		{
			Typ = MessageType.SYS,
			Code = "Reconnected",
			Message = info.Type.ToString(),
		});
	}

	#endregion

	#region Parse Callback Message / Response Data
	/// <summary>
	/// Parse Callback Message
	/// </summary>
	/// <param name="callbackTxt"></param>
	protected void ParseCallbackMessage(string callbackTxt)
	{
		try
		{
			var messageInfo = JsonSerializer.Deserialize<KisSubscriptionResponse>(callbackTxt);
			if (messageInfo is null || messageInfo.Header is null || messageInfo.Header.ID is null)
			{
				Message(this, new ResponseCore
				{
					Typ= MessageType.SYSERR,
					Code = "JSON_PARSING_ERR",
					Message = $"messageInfo is null",
					Remark = "from ParseCallbackMessage during message deserializing"
				});
				return;
			};

			switch (messageInfo.Header.ID)
			{
				case "PINGPONG":
					Client?.Send(callbackTxt);
					return;
				case nameof(HDFFF1C0):
				case nameof(HDFFF2C0):
				case nameof(H0STCNI0):
					_iv = messageInfo.Body.Output.IV;
					_key = messageInfo.Body.Output.Key;
					break;
				default:
					break;
			}

			Message(this, new ResponseCore
			{
				Typ = MessageType.SUB,
				Code = $"{messageInfo.Body.ResultCode}.{messageInfo.Body.MessageCode}",
				Message = messageInfo.Body.Message,
				Remark = $"{messageInfo.Header.ID}: {messageInfo.Header.Key}"
			});

		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Typ = MessageType.SYSERR,
				Code = "JSON_PARSING_ERR",
				Message = $"catch err: ${ex.Message}",
				Remark = "from ParseCallbackMessage"
			});
		}
	}

	/// <summary>
	/// Parse Callback Response Data
	/// </summary>
	/// <param name="callbackTxt"></param>
	protected virtual void ParseCallbackResponse(string callbackTxt) { }
	#endregion

	#region Generate Parameters
	/// <summary>
	/// Generate Parameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string?> GenerateParameters(Dictionary<string, string?> additionalOption, bool needsAccountInfo = false)
	{
		var parameters = new Dictionary<string, string?>();
		if (needsAccountInfo && !string.IsNullOrEmpty(BankAccountInfo.AccountNumber))
		{
			var accountInfo = new
			{
				CANO = BankAccountInfo.AccountNumber.Substring(0, 8),
				ACNT_PRDT_CD = BankAccountInfo.AccountNumber.Substring(8),
			};

			parameters = accountInfo.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(accountInfo, null)?.ToString());
		}

		foreach (var parameter in additionalOption)
		{
			parameters.Add(parameter.Key, parameter.Value?.ToString());
		}

		return parameters ?? new Dictionary<string, string?>();
	}

	/// <summary>
	/// Generate QueryParameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string?> GenerateParameters(object additionalOption, bool needsAccountInfo = false) =>
		GenerateParameters(additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()), needsAccountInfo);
	#endregion

	#region Generate Headers
	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr, Dictionary<string, string?>? additionalOption)
	{
		var headers = GenerateHeaders(tr);

		if (additionalOption is not null)
		{
			foreach (var header in additionalOption)
			{
				headers.Add(header.Key, header.Value ?? string.Empty);
			}
		}

		return headers;
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr)
	{
		return new Dictionary<string, string>
		{
			{ "content-type", "application/json" },
			{ "authorization", $"Bearer {KeyInfo.AccessToken}"},
			{ "appkey", KeyInfo.AppKey },
			{ "appsecret", KeyInfo.SecretKey},
			{ "tr_id", tr},
			{ "custtype", "P" }
		};
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr, object additionalOption) =>
		GenerateHeaders(tr, additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
	#endregion

	#region Delay Request
	protected bool DelayRequest(string trCode, bool needsMessage = true)
	{
		var requestsOld = Requests.Where(w => w.RequestTime < DateTime.UtcNow.AddSeconds(-1));
		try
		{
			foreach (var request in requestsOld)
			{
				Requests.Remove(request);
			}
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Code = "OPENAPI_ERR",
				Message = $"{ex.Message}",
			});

			return false;
		}

		if (Requests.Count() < 20)
		{
			Requests.Add(new Request { TrCode = trCode });
			return true;
		}

		var delaying = Requests[0].RequestTime.Subtract(DateTime.UtcNow.AddMilliseconds(-1001));

		if (needsMessage)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Code = trCode,
				Message = $"request to KIS forcely delayed {(delaying.TotalMilliseconds * 0.001).ToString("N3")} sec."
			});
		}

		Thread.Sleep(delaying);
		Requests.Add(new Request { TrCode = trCode });

		return true;
	}
	#endregion

	#region Request Standard
	internal async Task<T> RequestStandardAsync<T>(string endpoint, Dictionary<string, string?> parameters) where T : KisResponseBase
	{
		var delaying = DelayRequest(typeof(T).Name);
		if (!delaying)
		{
			return (T)new KisResponseBase
			{
				ReturnCode = "ERR",
				MessageCode = $"{typeof(T).Name}-ERR",
				Message = "delaying calculation failed",
			};
		}

		var client = new RestClient($"{host}/{endpoint}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name));
		foreach (var parameter in parameters)
		{
			request.AddQueryParameter(parameter.Key, parameter.Value?.ToString());
		}

		var response = await client.GetAsync<T>(request) ?? (T)new KisResponseBase();
		if (response is null) return (T)new KisResponseBase
		{
			ReturnCode = "ERR",
			MessageCode = $"{typeof(T).Name}-ERR",
			Message = "failed to response",
		};

		return response;
	}
	
	internal async Task<T> RequestStandardAsync<T>(EndpointPack ep, Dictionary<string, string?> parameters) where T : KisResponseBase
	{
		var delaying = DelayRequest(typeof(T).Name);
		if (!delaying)
		{
			return (T)new KisResponseBase
			{
				ReturnCode = "ERR",
				MessageCode = $"{typeof(T).Name}-ERR",
				Message = "delaying calculation failed",
			};
		}

		var client = new RestClient($"{host}/uapi/{ep.Prefix.ToDescription()}/{ep.Type.ToDescription()}/{ep.Endpoint}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name));
		foreach (var parameter in parameters)
		{
			request.AddQueryParameter(parameter.Key, parameter.Value?.ToString());
		}
		var responseRaw = await client.ExecuteAsync<T>(request, ep.HttpMethod);
		if (responseRaw is null || !responseRaw.IsSuccessful) return (T)new KisResponseBase
		{
			ReturnCode = "ERR",
			MessageCode = $"{typeof(T).Name}-ERR",
			Message = "failed to response",
		};

		var response = client.Serializers.DeserializeContent<T>(responseRaw);
		if (response is null) return (T)new KisResponseBase
		{
			ReturnCode = "ERR",
			MessageCode = $"{typeof(T).Name}-ERR",
			Message = "failed to serialize",
		};

		return response;
	}
	#endregion
}
