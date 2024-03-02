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
