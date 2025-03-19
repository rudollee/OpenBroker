using System.Security.Cryptography;
using System.Text;
using KisOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IConnection
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
			#region 실시간 호가 H0STASP0
			case nameof(H0STASP0):
				if (OrderBookTaken is null) return;

				var bidList = new List<MarketOrder>();
				var askList = new List<MarketOrder>();
				var bidQuantityIndex = (int)H0STASP0.BIDP_RSQN1;
				var bidPriceIndex = (int)H0STASP0.BIDP1;
				var askQuantityIndex = (int)H0STASP0.ASKP_RSQN1;
				var askPriceIndex = (int)H0STASP0.ASKP1;
				for (int i = 0; i < 10; i++)
				{
					bidList.Add(new MarketOrder
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[bidQuantityIndex + i]),
						Price = Convert.ToDecimal(data[bidPriceIndex + i]),
					});
					askList.Add(new MarketOrder
					{
						Seq = Convert.ToByte(i + 1),
						Amount = Convert.ToDecimal(data[askQuantityIndex + i]),
						Price = Convert.ToDecimal(data[askPriceIndex + i])
					});
				}
				OrderBookTaken(this, new ResponseResult<OrderBook>
				{
					Typ = MessageType.MKT,
					Code = rawData[2],
					Info = new OrderBook
					{
						Ask = askList,
						Bid = bidList,
						AskAgg = askList.Sum(x => x.Amount),
						BidAgg = bidList.Sum(x => x.Amount),
						Symbol = data[(int)HDFFF010.series_cd],
						TimeContract = (data[(int)HDFFF010.recv_date] + data[(int)HDFFF010.recv_time]).ToDateTimeMicro(),
					},
					Remark = plainTxt,
					Broker = Brkr.KI
				});
				break;
			#endregion
			#region 실시간 체결가 H0STCNT0
			case nameof(H0STCNT0):
				if (MarketContracted is null) return;
				MarketContracted(this, new ResponseResult<MarketContract>
				{
					Typ = MessageType.MKT,
					Code = rawData[2],
					Info = new MarketContract
					{
						MarketSessionInfo = data[(int)H0STCNT0.NEW_MKOP_CLS_CODE].Substring(0, 1) switch
						{
							"1" => MarketSession.PRE,
							"2" => MarketSession.REGULAR,
							"3" => MarketSession.CLOSED,
							"4" => MarketSession.AFTER,
							_ => MarketSession.REGULAR
						},
						Symbol = data[(int)H0STCNT0.MKSC_SHRN_ISCD],
						TimeContract = (DateTime.Now.ToString("yyyyMMdd") + data[(int)H0STCNT0.STCK_CNTG_HOUR]).ToDateTime(),
						C = Convert.ToDecimal(data[(int)H0STCNT0.STCK_PRPR]),
						V = Convert.ToDecimal(data[(int)H0STCNT0.CNTG_VOL]),
						ContractSide = data[(int)H0STCNT0.CCLD_DVSN] switch
						{
							"1" => ContractSide.ASK,
							"5" => ContractSide.BID,
							_ => ContractSide.NONE
						},
						BasePrice = Convert.ToDecimal(data[(int)H0STCNT0.STCK_PRPR]) - Convert.ToDecimal(data[(int)H0STCNT0.PRDY_VRSS]),
						VolumeAcc = Convert.ToDecimal(data[(int)H0STCNT0.ACML_VOL]),
						MoneyAcc = Convert.ToDecimal(data[(int)H0STCNT0.ACML_TR_PBMN]) / 1_000_000,
					},
					Remark = plainTxt,
					Broker = Brkr.KI
				});
				break;
			#endregion
			#region 실시간 체결 통보 H0STCNI0
			case nameof(H0STCNI0):
				Contracted(this, new ResponseResult<Contract>
				{
					Typ = MessageType.CONTRACT,
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
					Remark = plainTxt,
					Broker = Brkr.KI
				});
				break;
			#endregion
			default:
				Message(this, new ResponseCore
				{
					Typ = MessageType.SYSERR,
					StatusCode = Status.ERROR_OPEN_API,
					Code = rawData[2],
					Message = "during parsing callback to swich",
					Remark = plainTxt,
					Broker = Brkr.KI
				});
				break;
		}
	}
	#endregion
}
