using System.Net.WebSockets;
using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using RestSharp;
using Websocket.Client;

namespace LsOpenApi;
public class ConnectionBase
{
	internal readonly string host = "https://openapi.ls-sec.co.kr:8080";
	internal readonly string hostSocket = "wss://openapi.ls-sec.co.kr:9443/websocket";
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

	private List<Request> Requests = new();

	private Dictionary<string, SubscriptionPack> _subscriptions = new()
	{
		{ "JIF", new SubscriptionPack{ TrCode = "JIF", Key = "0", Subscriber = new List<string>(){ "INIT" }} },
	};

	public async Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret)
	{
		var client = new RestClient($"{host}/oauth2/token");

		var queryParameters = GenerateParameters(new
		{
			grant_type,
			appkey,
			appsecretkey = appsecret,
			scope = "oob",
		});
		var request = new RestRequest()
			.AddHeaders(new Dictionary<string, string>
			{
				{ "content-type", "application/x-www-form-urlencoded" },
			});

		foreach (var param in queryParameters)
		{
			request.AddQueryParameter(param.Key, param.Value);
		}

		try
		{
			var response = await client.PostAsync<AccessTokenResponse>(request);

			if (response is null) return new ResponseResult<KeyPack>
			{
				Typ = MessageType.SYSERR,
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response is null"
			};

			if (string.IsNullOrEmpty(response.AccessToken)) return new ResponseResult<KeyPack>
			{
				Typ = MessageType.SYSERR,
				StatusCode = Status.UNAUTHORIZED,
				Message = "no token",
			};

			SetKeyPack(new KeyPack
			{
				AppKey = appkey,
				SecretKey = appsecret,
				AccessToken = response.AccessToken,
				AccessTokenExpired = response.DateExpired,
			});

			return new ResponseResult<KeyPack>
			{
				Info = new KeyPack
				{
					AccessToken = response.AccessToken,
					AccessTokenExpired = response.DateExpired
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<KeyPack>
			{
				Typ = MessageType.SYSERR,
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "error catch"
			};
		}
	}

	#region Connect/disconnect Websocket
	/// <summary>
	/// Connect Websocket & subscribe Order/Contract
	/// </summary>
	/// <returns></returns>
	protected async Task<ResponseCore> ConnectAsync(Action<ResponseMessage> callback)
	{
		try
		{
			var options = new Func<ClientWebSocket>(() => new ClientWebSocket
			{
				Options = { KeepAliveInterval = TimeSpan.Zero }
			});

			Client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "LS",
				ReconnectTimeout = TimeSpan.FromSeconds(20),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
			};

			Client.MessageReceived.Subscribe(message => callback(message));
			Client.ReconnectionHappened.Subscribe(async info => await ReconnectCallback(info));
			Client.IsReconnectionEnabled = true;
			await Client.Start();

			SetConnect();

			foreach (var subscription in _subscriptions)
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
				Typ = MessageType.SYSERR,
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

		foreach (var subscription in _subscriptions)
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
	public async Task<ResponseCore> SubscribeAsync(string subscriber, string trCode, string key = "", bool connecting = true)
	{
		if (string.IsNullOrWhiteSpace(trCode)) return new ResponseCore
		{
			StatusCode = Status.BAD_REQUEST,
			Code = "NOTRCODE",
			Remark = subscriber
		};

		string GenerateSubscriptionRequest(string id, string key = "", bool connecting = true)
		{
			if (string.IsNullOrWhiteSpace(key)) key = AccountInfo.ID;

			return JsonSerializer.Serialize(new LsSubscriptionRequest(KeyInfo.AccessToken, id, key, connecting));
		}

		if (Client is null) return new ResponseCore
		{
			Typ = MessageType.SYSERR,
			StatusCode = Status.ERROR_OPEN_API,
			Code = "NOCONNECTION",
			Message = "client is null"
		};

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
				Typ = MessageType.SYSERR,
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

		var document = JsonDocument.Parse(message.Text);
		var root = document.RootElement;

		if (root.GetProperty("body").GetType() is null) return;
		var trCode = root.GetProperty("header").GetProperty("tr_cd").GetString();
		if (trCode is null)
		{
			Message(this, new ResponseCore
			{
				Typ = MessageType.SYSERR,
				Code = "TRCODEERR",
				Message = "failed to parse TR code"
			});

			return;
		}

		ParseCallbackMessage(trCode, message.Text);
	}

	protected async Task ReconnectCallback(ReconnectionInfo info)
	{
		if (info.Type == ReconnectionType.Initial) return;

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
				return;
			}
		}

		Message(this, new ResponseCore
		{
			Code = "Reconnected",
			Message = info.Type.ToString(),
		});
	}
	#endregion

	#region Parse Callback Message & Response
	/// <summary>
	/// 
	/// </summary>
	/// <param name="trCode"></param>
	/// <param name="callbackTxt"></param>
	protected void ParseCallbackMessage(string trCode, string callbackTxt) { }

	/// <summary>
	/// Parse Callback Response Data
	/// </summary>
	/// <param name="callbackTxt"></param>
	protected virtual void ParseCallbackResponse(string trCode, string callbackTxt) { }
	#endregion

	#region Generate Parameters
	/// <summary>
	/// Generate Parameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string?> GenerateParameters(Dictionary<string, string?> additionalOption)
	{
		var basicParameters = new
		{
		};

		var parameters = basicParameters.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(basicParameters, null)?.ToString());
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
	protected Dictionary<string, string?> GenerateParameters(object additionalOption) =>
		GenerateParameters(additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
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
	protected Dictionary<string, string> GenerateHeaders(string tr, string nextKey = "")
	{
		return new Dictionary<string, string>
		{
			{ "content-type", "application/json; charset=utf-8" },
			{ "authorization", $"Bearer {KeyInfo.AccessToken}"},
			{ "tr_cd", tr},
			{ "tr_cont", string.IsNullOrEmpty(nextKey) ? "N" : "Y" },
			{ "tr_cont_key", nextKey },
			{ "mac_address", ""}
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

	#region Request Standard & Continue Option
	internal bool DelayRequest(string trCode, bool needsMessage = true)
	{
		var requestsOld = Requests.Where(w => w.TrCode == trCode && w.RequestTime < DateTime.UtcNow.AddSeconds(-1)).ToList();
		try
		{
			foreach (var request in requestsOld)
			{
				Requests.Remove(request);
			}
		}
		catch (Exception ex)
		{
			var x = ex.Message;
			return false;
		}

		var requests = Requests.Where(request => request.TrCode == trCode).OrderByDescending(o => o.RequestTime).ToList();
		if (requests.Count() < CodeRef.RequestIntervals[trCode])
		{
			Requests.Add(new Request { TrCode = trCode });
			return true;
		}

		var delaying = requests[0].RequestTime.Subtract(DateTime.UtcNow.AddSeconds(-1));

		if (needsMessage && delaying.TotalMilliseconds > 250)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Code = trCode,
				Message = $"request forcely delayed {(delaying.TotalMilliseconds * 0.001).ToString("N3")} sec."
			}); 
		}

		Thread.Sleep(delaying);
		Requests.Add(new Request { TrCode = trCode });

		return true;
	}

	internal async Task<T> RequestStandardAsync<T>(string endpoint, object parameter) where T : LsResponseCore
	{
		var client = new RestClient($"{host}/{endpoint}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name));
		request.AddBody(JsonSerializer.Serialize(parameter));

		var delaying = DelayRequest(typeof(T).Name);
		if (!delaying)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = "delaying calculation failed"
			});

			return (T)new LsResponseCore
			{
				Code = "ERR",
				Message = "delaying calculation failed",
				TrCode = nameof(T)
			};
		}
		var response = await client.PostAsync<T>(request) ?? (T)new LsResponseCore();
		if (response is null) return (T)new LsResponseCore
		{
			Code = "ERR",
			Message = "failed to response",
			TrCode = nameof(T),
		};

		response.TrCode = nameof(T);
		return response;
	}
	
	internal async Task<T> RequestContinuousAsync<T>(string endpoint, object parameter, string nextKey) where T : LsResponseCore
	{
		var client = new RestClient($"{host}/{endpoint}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name, nextKey));
		request.AddBody(JsonSerializer.Serialize(parameter));
		var delaying = DelayRequest(typeof(T).Name, false);
		if (!delaying)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = "delaying calculation failed"
			});
			return (T)new LsResponseCore
			{
				Code = "ERR",
				Message = "delaying calculation failed",
				TrCode = nameof(T)
			};
		}

		var response = await client.PostAsync(request);
		if (response is null || !response.IsSuccessful) return (T)new LsResponseCore
		{
			Code = "ERR",
			Message = response?.ErrorMessage ?? "failed to response",
			TrCode = nameof(T),
		};

		var responseDeserialized = client.Serializers.DeserializeContent<T>(response);
		if (responseDeserialized is null) return (T)new LsResponseCore
		{
			Code = "ERR",
			Message = "failed to response",
			TrCode = nameof(T),
		};

		var continueOption = response.Headers?.FirstOrDefault(f => f.Name == "tr_cont");
		if (continueOption is not null && continueOption.Value == "Y")
		{
			responseDeserialized.NextKey = response.Headers?.First(f => f.Name == "tr_cont_key").Value ?? "";
			responseDeserialized.TrCode = nameof(T);
		}

		return responseDeserialized;
	}
	#endregion

	#region JIF 장운영정보
	/// <summary>
	/// JIF 장운영정보 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	protected bool CallbackJIF(string message)
	{
		if (Message is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<JIFOutBlock>>(message);
			if (response is null || response.Body is null) return false;
			Message(this, new ResponseCore
			{
				Typ = MessageType.MKTS,
				Code = $"{response.Body.jangubun}.{response.Body.jstatus}",
				Message = $"{CodeRef.MarketSectionDic[response.Body.jangubun]} {CodeRef.MarketStatusDic[response.Body.jstatus]}",
				Broker = Brkr.LS
			});
			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Typ = MessageType.MKTS,
				Code = nameof(JIF),
				Message = ex.Message,
				Broker = Brkr.LS
			});
			return false;
		}
	}
	#endregion
}
