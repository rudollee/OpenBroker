using System.Net.WebSockets;
using System.Text.Json;
using RestSharp;
using Websocket.Client;
using KisOpenApi.Models;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace KisOpenApi;
public class ConnectionBase
{
    internal readonly string host = "https://openapi.koreainvestment.com:9443";
    internal readonly string hostSocket = "ws://ops.koreainvestment.com:21000";
    internal readonly string grant_type = "client_credentials";

    public KeyPack KeyInfo { get; private set; } = new();
    public void SetKeyPack(KeyPack keyInfo) => KeyInfo = keyInfo;

    public Account AccountInfo { get; private set; } = new();
    public void SetAccount(Account account) => AccountInfo = account;

    public BankAccount BankAccountInfo { get; private set; } = new();
    public void SetBankAccount(BankAccount bankAccount) => BankAccountInfo = bankAccount;

    public bool IsConnected { get; private set; }
    protected void SetConnect(bool connecting = true) => IsConnected = connecting;

	public required EventHandler<ResponseCore> Message { get; set; }

	public required EventHandler<ResponseCore> Connected { get; set; }

	protected IWebsocketClient? Client;

	protected string _iv = string.Empty;
	protected string _key = string.Empty;

	private readonly Dictionary<string, SubscriptionPack> _subscriptions = [];

	private readonly List<Request> Requests = [];

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

			if (response is null) return ReturnErrorResult<KeyPack>("TOKEN", "response is null");

			if (string.IsNullOrEmpty(response.AccessToken)) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.UNAUTHORIZED,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = response.ReturnCode
			};

			return ReturnResult<KeyPack>(new()
			{
				AccessToken = response.AccessToken,
				AccessTokenExpired = response.DateExpired
			});
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<KeyPack>("TOKEN", $"error-catched: {ex.Message}");
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

			if (response is null) return ReturnErrorResult<KeyPack>("WEBSOCKET-CODE", "response is null");

			if (string.IsNullOrEmpty(response.ApprovalKey)) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.UNAUTHORIZED,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = response.ReturnCode
			};

			return ReturnResult<KeyPack>(new() { WebsocketCode = response.ApprovalKey }, response.MessageCode, response.Message);
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<KeyPack>("WEBSOCKET-CODE", $"error catched: {ex.Message}");
		}
	}
	#endregion

	#region Connect/disconnect Websocket
	/// <summary>
	/// Connect Websocket & subscribe Order/Execution
	/// </summary>
	/// <returns></returns>
	public async Task<ResponseCore> ConnectAsync()
	{
		try
		{
			var options = new Func<ClientWebSocket>(() => new ClientWebSocket
			{
				Options = { KeepAliveInterval = TimeSpan.FromSeconds(15) }
			});

			Client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "KIS",
				ReconnectTimeout = TimeSpan.FromSeconds(30),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(60),
			};

			Client.MessageReceived.Subscribe(SubscribeCallback);
			Client.ReconnectionHappened.Subscribe(async info => await ReconnectCallback(info));
			Client.DisconnectionHappened.Subscribe(async info => await DisconnectCallback(info));
			await Client.Start();

			SetConnect();

			foreach (KeyValuePair<string, SubscriptionPack> subscription in _subscriptions)
			{
				await SubscribeAsync("RECONNECTION", subscription.Value.TrCode, subscription.Value.Key);
			}

			return ReturnCore("CONNECTION", "Connected", MessageType.CONNECTION);
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				Broker = Brkr.KI,
				StatusCode = Status.INTERNALSERVERERROR,
				Typ = MessageType.CONNECTION,
				Message = ex.Message,
				Remark = "during connect websocket"
			};
		}
	}

    public async Task<ResponseCore> DisconnectAsync()
	{
		if (Client is null) return ReturnError("DISCONNECTION", "no connection to disconnect or already disconnected", typ: MessageType.CONNECTION);
		if (Client.IsRunning) await Client.Stop(WebSocketCloseStatus.NormalClosure, "");

		SetConnect(false);

		return ReturnCore("DISCONNECTION", "Disconnected", typ: MessageType.CONNECTION);
	}
	#endregion

	#region Subscribe / Unsubscribe
	protected async Task<ResponseCore> SubscribeAsync(string subscriber, string trCode, string key, bool connecting = true)
	{
		if (Client is null) return ReturnError("NULL-WEBSOCKET", "Websocket Client is null", typ: MessageType.CONNECTION);

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
						Subscriber = [subscriber]
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
					else
					{
						_subscriptions[$"{trCode}-{key}"].Subscriber.Remove(subscriber);
						if (_subscriptions[$"{trCode}-{key}"].Subscriber.Count == 0)
						{
							_subscriptions.Remove($"{trCode}-{key}");
							needsAction = true;
						}
					}
				}
			}

			if (!needsAction) return ReturnCore("NOACTION", message, MessageType.SUB, $"{trCode}-{key}:{subscriber}");

			var result = await Task.Run(() => Client.Send(GenerateSubscriptionRequest(trCode, key, connecting)));

			SendMessage($"{trCode}({key})", $"Sent {(connecting ? "subscribe" : "unsubscribe")} request.", MessageType.SUB);

			return ReturnError(string.Empty, string.Empty, typ: MessageType.SUB, statusCode: result ? Status.SUCCESS : Status.ERROR_OPEN_API);
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				Broker = Brkr.KI,
				Typ = MessageType.SUB,
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
		try
		{
			if (message is null || message.MessageType != WebSocketMessageType.Text)
			{
				SendErrorMessage("BINARY", "binary message type");
				return;
			}

			if (message.Text is null)
			{
				SendErrorMessage("TEXTNULL", "message.Text is null");
				return;
			}

			if (message.Text.StartsWith('{')) ParseCallbackMessage(message.Text);
			else if (new string[] { "0", "1" }.Contains(message.Text[..1])) ParseCallbackResponse(message.Text);
			else SendErrorMessage("WEIRD_MESSAGE", "message format is weird", message.Text);
		}
		catch (Exception ex)
		{
			SendErrorMessage("SUB-CALLBACK-ERR", ex.Message, message?.Text ?? string.Empty);
		}
	}

	protected async Task ReconnectCallback(ReconnectionInfo info)
	{
		if (info.Type is ReconnectionType.Initial) return;

		if (info.Type is ReconnectionType.ByServer)
		{
			var response = await DisconnectAsync();
			response.Code = $"{info.Type}";
			Connected(this, response);
			return;
		}

		Connected(this, new()
		{
			Broker = Brkr.KI,
			Typ = MessageType.CONNECTION,
			Code = $"{info.Type}",
			Message = $"Reconnected : {info.Type}"
		});

		foreach (var subscirption in _subscriptions)
		{
			var response = await SubscribeAsync("RECONNECTION", subscirption.Value.TrCode, subscirption.Value.Key);
			if (response.StatusCode != Status.SUCCESS)
			{
				SendErrorMessage(subscirption.Value.TrCode, $"subscription {subscirption.Key} failed during reconnection", subscirption.Value.Key);
			}
		}
	}
	#endregion

	protected async Task DisconnectCallback(DisconnectionInfo info)
	{
		Connected(this, new()
		{
			Broker = Brkr.KI,
			Typ= MessageType.CONNECTION,
			Code = $"{info.Type}",
			Message = $"Disconnected : {info.Type}"
		});
	}

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
				SendErrorMessage("JSON_PARSING_ERR", "messageInfo is null", callbackTxt);
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

			SendMessage($"{messageInfo.Body.ResultCode}.{messageInfo.Body.MessageCode}", messageInfo.Body.Message, MessageType.SUB, $"{messageInfo.Header.ID}: {messageInfo.Header.Key}");
		}
		catch (Exception ex)
		{
			SendErrorMessage("JSON_PARSING_ERR", $"catch err: ${ex.Message}", callbackTxt);
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
				CANO = BankAccountInfo.AccountNumber[..8],
				ACNT_PRDT_CD = BankAccountInfo.AccountNumber[8..],
			};

			parameters = accountInfo.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(accountInfo, null)?.ToString());
		}

		foreach (var parameter in additionalOption)
		{
			parameters.Add(parameter.Key, parameter.Value?.ToString());
		}

		return parameters ?? [];
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
		try
		{
			Requests.RemoveAll(r => r.RequestTime < DateTime.UtcNow.AddMilliseconds(-999));
		}
		catch (Exception ex)
		{
			SendErrorMessage(trCode, $"error catched during removing old delayed request: {ex.Message}");
			return false;
		}

		if (Requests.Count < 20)
		{
			Requests.Add(new Request { TrCode = trCode });
			return true;
		}

		var delaying = Requests[0].RequestTime.Subtract(DateTime.UtcNow.AddMilliseconds(-1001));

		if (needsMessage) SendMessage(trCode, $"request forcely to delay for {delaying.TotalMilliseconds * 0.001:N3} sec.");

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
        return response is null
            ? (T)new KisResponseBase
			{
				ReturnCode = "ERR",
				MessageCode = $"{typeof(T).Name}-ERR",
				Message = "failed to response",
			}
            : response;
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

	#region simple response callback or return
	protected void SendMessage(string code, string message, MessageType typ = MessageType.SYS, string remark = "") => Message(this, new ResponseCore
	{
		Broker = Brkr.KI,
		Typ = typ,
		Code = code,
		Message = message,
		Remark = remark
	});

	protected void SendErrorMessage(string code, string message, string remark = "", MessageType typ = MessageType.SYSERR) => Message(this, new ResponseCore
	{
		StatusCode = Status.ERROR_OPEN_API,
		Broker = Brkr.KI,
		Typ = typ,
		Code = code,
		Message = message,
		Remark = remark
	});

	protected static ResponseCore ReturnError(string code, string message, string remark = "", MessageType typ = MessageType.SYSERR, Status statusCode = Status.ERROR_OPEN_API) => new()
	{
		Broker = Brkr.KI,
		Typ = typ,
		StatusCode = statusCode,
		Code = code,
		Message = message,
		Remark = remark
	};

	protected static ResponseCore ReturnCore(string code = "", string message = "", MessageType typ = MessageType.SYS, string remark = "") => new()
	{
		Broker = Brkr.KI,
		Typ = typ,
		Code = code,
		Message = message,
		Remark = remark
	};

	protected static ResponseResult<T> ReturnErrorResult<T>(string code, string meesage, string remark = "") where T : class => new()
	{
		Broker = Brkr.KI,
		Typ = MessageType.SYSERR,
		Code = code,
		StatusCode = Status.ERROR_OPEN_API,
		Message = meesage,
		Remark = remark
	};

	protected static ResponseResult<T> ReturnResult<T>(T info, string code = "", string message = "", MessageType typ = MessageType.SYS, string remark = "") where T : class => new()
	{
		Broker = Brkr.KI,
		StatusCode = info is null ? Status.NODATA : Status.SUCCESS,
		Typ = typ,
		Code = code,
		Message = message,
		Info = info,
		Remark = remark
	};

	protected static ResponseResults<T> ReturnErrorResults<T>(string code = "", string message = "", string remark = "", Status statusCode = Status.ERROR_OPEN_API) where T : class => new()
	{
		Broker = Brkr.KI,
		StatusCode = statusCode,
		Typ = MessageType.SYSERR,
		Code = code,
		Message = message,
		Remark = remark,
		List = []
	};

	protected static ResponseResults<T> ReturnResults<T>(List<T> list, string code = "", string message = "", MessageType typ = MessageType.SYS, string remark = "", Dictionary<string, decimal>? extraData = null) where T : class => new()
	{
		Broker = Brkr.KI,
		StatusCode = list.Count > 0 ? Status.SUCCESS : Status.NODATA,
		Typ = typ,
		Code = code,
		Message = string.IsNullOrEmpty(message) && list.Count == 0 ? "no data" : message,
		List = list,
		Remark = remark,
		ExtraData = extraData ?? []
	};
	#endregion
}
