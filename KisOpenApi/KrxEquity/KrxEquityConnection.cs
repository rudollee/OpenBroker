using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KisOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using Websocket.Client;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IConnection
{
	#region Parse Callback Message
	/// <summary>
	/// Parse Callback Message
	/// </summary>
	/// <param name="callbackTxt"></param>
	protected override void ParseCallbackMessage(string callbackTxt)
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
					Client.Send(callbackTxt);
					return;
				case nameof(H0STCNI0):
					_iv = messageInfo.Body.Output.IV;
					_key = messageInfo.Body.Output.Key;
					break;
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
	protected override void ParseCallbackResponse(string callbackTxt)
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
		switch (rawData[1])
		{
			#region 실시간 호가 H0STASP0
			case nameof(H0STASP0):
				var bidList = new List<OrderBook>();
				var askList = new List<OrderBook>();
				var bidQuantityIndex = (int)H0STASP0.BIDP_RSQN1;
				var bidPriceIndex = (int)H0STASP0.BIDP1;
				var askQuantityIndex = (int)H0STASP0.ASKP_RSQN1;
				var askPriceIndex = (int)H0STASP0.ASKP1;
				for (int i = 0; i < 10; i++)
				{
					bidList.Add(new OrderBook
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[bidQuantityIndex + i]),
						Price = Convert.ToDecimal(data[bidPriceIndex + i]),
					});
					askList.Add(new OrderBook
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[askQuantityIndex + i]),
						Price = Convert.ToDecimal(data[askPriceIndex + i])
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
			#region 실시간 체결가 H0STCNT0
			case nameof(H0STCNT0):
				MarketContracted(this, new ResponseResult<MarketContract>
				{
					Code = rawData[2],
					Info = new MarketContract
					{
						Symbol = data[(int)H0STCNT0.MKSC_SHRN_ISCD],
						V = Convert.ToDecimal(data[(int)H0STCNT0.CNTG_VOL]),
						C = Convert.ToDecimal(data[(int)H0STCNT0.STCK_PRPR]),
						TimeContract = (DateTime.Now.ToString("yyyyMMdd") + data[(int)H0STCNT0.STCK_CNTG_HOUR]).ToDateTime(),
						Tradable = data[(int)H0STCNT0.TRHT_YN] == "N"
					},
					Remark = plainTxt
				});
				break;
			#endregion
			#region 실시간 체결 통보 H0STCNI0
			case nameof(H0STCNI0):
				Contracted(this, new ResponseResult<Contract>
				{
					StatusCode = Status.SUCCESS,
					Code = rawData[2],
					Info = new Contract
					{
						BrokerCo = "KI",
						DateBiz = DateOnly.FromDateTime(DateTime.Now),
						OID = Convert.ToInt64(data[(int)H0STCNI0.ODER_NO]),
						CID = 0,
						IsLong = data[(int)H0STCNI0.SELN_BYOV_CLS] == "02",
						Price = Convert.ToDecimal(data[(int)H0STCNI0.CNTG_UNPR]),
						Volume = Convert.ToInt32(data[(int)H0STCNI0.CNTG_QTY]),
						TimeContracted = data[(int)H0STCNI0.STCK_CNTG_HOUR].ToDateTime(),
						Symbol = data[(int)H0STCNI0.STCK_SHRN_ISCD],
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
