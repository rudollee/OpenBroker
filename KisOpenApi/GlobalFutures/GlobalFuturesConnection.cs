using KisOpenApi.Models;
using OpenBroker;
using OpenBroker.Models;
using RestSharp;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Websocket.Client;
using OpenBroker.Extensions;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IConnection
{
	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;
	public void SetAccount(Account account) => _accountInfo = account;
	public void SetBankAccount(BankAccount bankAccount) => _bankAccountInfo = bankAccount;

	public KeyPack KeyInfo { get => _keyInfo; }
	private KeyPack _keyInfo = new KeyPack();

	public bool IsConnected { get => _connected; }
	private bool _connected = false;

	private IWebsocketClient client;

	private string _iv = string.Empty;
	private string _key = string.Empty;

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
				Code = response.Code,
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
				Code = response.Code,
				Message = response.Message,
				Remark = response.ReturnCode
			};

			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.SUCCESS,
				Code = response.Code,
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

			client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "KIS",
				ReconnectTimeout = TimeSpan.FromSeconds(30),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
			};

			client.MessageReceived.Subscribe(message => SubscribeCallback(message));
			await client.Start();

			_connected = true;
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
		await client.Stop(WebSocketCloseStatus.NormalClosure, "");
		client.Dispose();
		_connected = false;

		return new ResponseCore
		{
			Message = "disconnected"
		};
	}

	public async Task<ResponseCore> Subscribe(string trCode, string key, bool connecting = true)
	{
		try
		{
			var result = await Task.Run(() => client.Send(GenerateSubscriptionRequest(trCode, key, connecting)));

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
	private void SubscribeCallback(ResponseMessage message)
	{
		if (message is null || message.MessageType != WebSocketMessageType.Text)
		{
			Message(this, new ResponseCore
			{
				Code = "BINARY",
				Message = "binary message type"
			});
			return;
		}

		if (message.Text is null)
		{
			Message(this, new ResponseCore
			{
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
				Code = "WEIRD_MESSAGE",
				Message = "message format is weird",
				Remark = message.Text
			});
		}
	}
	#endregion

	#region Generate request header & body for subscription
	/// <summary>
	/// Generate request header & body for subscription
	/// </summary>
	/// <param name="id">tr_id</param>
	/// <param name="key">tr_key</param>
	/// <param name="connecting">connecting / disconnecting</param>
	/// <returns></returns>
	private string GenerateSubscriptionRequest(string id, string key = "", bool connecting = true)
	{
		if (string.IsNullOrWhiteSpace(key)) key = AccountInfo.ID;

		return JsonSerializer.Serialize(new KisSubscriptionRequest(KeyInfo.WebsocketCode, id, key, connecting));
	}
	#endregion

	#region Parse Callback Message
	/// <summary>
	/// Parse Callback Message
	/// </summary>
	/// <param name="callbackTxt"></param>
	private void ParseCallbackMessage(string callbackTxt)
	{
		try
		{
			var messageInfo = JsonSerializer.Deserialize<KisSubscriptionResponse>(callbackTxt);
			if (messageInfo is null || messageInfo.Header is null || messageInfo.Header.ID is null)
			{
				Message(this, new ResponseCore
				{
					Code = "JSON_PARSING_ERR",
					Message = $"messageInfo is null",
					Remark = "from ParseCallbackMessage during message deserializing"
				});
				return;
			};

			switch (messageInfo.Header.ID)
			{
				case "PINGPONG":
					client.Send(callbackTxt);
					return;
				case nameof(HDFFF1C0):
				case nameof(HDFFF2C0):
					_iv = messageInfo.Body.Output.IV;
					_key = messageInfo.Body.Output.Key;
					break;
				case nameof(HDFFF010):
				case nameof(HDFFF020):
				default:
					break;
			}

			Message(this, new ResponseCore
			{
				Code = $"{messageInfo.Body.ResultCode}.{messageInfo.Body.MessageCode}",
				Message = messageInfo.Body.Message,
				Remark = $"{messageInfo.Header.ID}: {messageInfo.Header.Key}"
			});

		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Code = "JSON_PARSING_ERR",
				Message = $"catch err: ${ex.Message}",
				Remark = "from ParseCallbackMessage"
			});
		}
	}
	#endregion

	#region Parse Callback Response Data
	/// <summary>
	/// Parse Callback Response Data
	/// </summary>
	/// <param name="callbackTxt"></param>
	private void ParseCallbackResponse(string callbackTxt)
	{
		string decrypt(string stringEncrypted)
		{
			var encryptedBin = Convert.FromBase64String(stringEncrypted);
			using Aes aes = Aes.Create();
			aes.IV = Encoding.UTF8.GetBytes(_iv);
			aes.Key = Encoding.UTF8.GetBytes(_key);

			using var decryptor = aes.CreateDecryptor();
			var decryptedBin = decryptor.TransformFinalBlock(encryptedBin, 0, encryptedBin.Length);

			return Encoding.UTF8.GetString(decryptedBin);
		}

		var rawData = callbackTxt.Split('|');
		var plainTxt = rawData[0] == "0" ? rawData[3] : decrypt(rawData[3]);

		var data = plainTxt.Split("^");
		switch (data[1]) 
		{
			#region 실시간 호가 HDFFF010
			case nameof(HDFFF010):
				var bidList = new List<OrderBook>();
				var askList = new List<OrderBook>();
				var bidQuantityIndex = (int)HDFFF010.bid_qntt_1;
				var bidPriceIndex = (int)HDFFF010.bid_price_1;
				var askQuantityIndex = (int)HDFFF010.ask_qntt_1;
				var askPriceIndex = (int)HDFFF010.ask_price_1;
				for (int i = 0; i < 5; i++)
				{
					bidList.Add(new OrderBook
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[bidQuantityIndex + i * 6]),
						Price = Convert.ToDecimal(data[bidPriceIndex + i * 6]),
					});
					askList.Add(new OrderBook
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[askQuantityIndex + i * 6]),
						Price = Convert.ToDecimal(data[askPriceIndex + i * 6])
					});
				}
				MarketDepthListed(this, new ResponseResult<MarketDepth>
				{
					Code = rawData[2],
					Info = new MarketDepth
					{
						Ask = askList,
						Bid = bidList,
						AskAgg = new OrderBook { Seq = 0, Amount = askList.Sum(x => x.Amount) },
						BidAgg = new OrderBook { Seq = 0, Amount = bidList.Sum(x => x.Amount) },
						Symbol = data[(int)HDFFF010.series_cd],
						TimeContract = (data[(int)HDFFF010.recv_date] + data[(int)HDFFF010.recv_time]).ToDateTimeMicro(),

					},
					Remark = plainTxt
				});
				break;
			#endregion
			#region 실시간 체결가 HDFFF020
			case nameof(HDFFF020):
				MarketContracted(this, new ResponseResult<MarketContract>
				{
					Code = rawData[2],
					Info = new MarketContract
					{
						Symbol = data[(int)HDFFF020.series_cd],
						V = Convert.ToDecimal(data[(int)HDFFF020.last_qntt]),
						C = Convert.ToDecimal(data[(int)HDFFF020.last_price]),
						TimeContract = (data[(int)HDFFF020.recv_date] + data[(int)HDFFF020.recv_time]).ToDateTime()
					},
					Remark = plainTxt
				});
				break;
			#endregion
			#region 실시간 주문 HDFFF1C0
			case nameof(HDFFF1C0):
				Executed(this, new ResponseResult<Order>
				{
					StatusCode = Status.SUCCESS,
					Code = rawData[2],
					Info = new Order
					{
						BrokerCo = "KI",
						DateBiz = data[(int)HDFFF1C0.ord_dt].ToDate(),
						OID = Convert.ToInt64(data[(int)HDFFF1C0.odno]),
						IsLong = data[(int)HDFFF1C0.sll_buy_dvsn_cd] == "02",
						PriceOrdered = Convert.ToDecimal(data[(int)HDFFF1C0.fm_lmt_pric]),
						VolumeOrdered = Convert.ToInt32(data[(int)HDFFF1C0.ord_qty]),
						VolumeUpdatable = Convert.ToInt32(data[(int)HDFFF1C0.ord_qty]) - Convert.ToInt32(data[(int)HDFFF1C0.tot_ccld_qty]),
						TimeOrdered = data[(int)HDFFF1C0.ord_dtl_dtime].ToDateTimeMicro(),
						Symbol = data[(int)HDFFF1C0.series],
					},
					Remark = plainTxt
				});
				break;
			#endregion
			#region 실시간 체결 HDFFF2C0
			case nameof(HDFFF2C0):
				Contracted(this, new ResponseResult<Contract>
				{
					StatusCode = Status.SUCCESS,
					Code = rawData[2],
					Info = new Contract
					{
						BrokerCo = "KI",
						DateBiz = data[(int)HDFFF2C0.ccld_dt].ToDate(),
						OID = Convert.ToInt64(data[(int)HDFFF2C0.odno]),
						CID = Convert.ToInt64(data[(int)HDFFF2C0.ccno]),
						IsLong = data[(int)HDFFF2C0.sll_buy_dvsn_cd] == "02",
						Price = Convert.ToDecimal(data[(int)HDFFF2C0.fm_ccld_pric]),
						Volume = Convert.ToInt32(data[(int)HDFFF2C0.ccld_qty]),
						TimeContracted = data[(int)HDFFF2C0.ccld_dt].ToDateTime(),
						Symbol = data[(int)HDFFF2C0.series],
					},
					Remark = plainTxt
				});
				break; 
			#endregion
			default:
				Message(this, new ResponseCore
				{
					StatusCode = Status.ERROR_OPEN_API,
					Code = rawData[2],
					Message = "during parsing callback to swich",
					Remark = plainTxt,
				});
				break;
		}
	}
	#endregion
}
