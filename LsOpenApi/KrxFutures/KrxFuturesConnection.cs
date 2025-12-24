using System.Net.WebSockets;
using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using Websocket.Client;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IConnection
{
	private readonly string[] _k200OrFx = ["01", "75"];

	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => throw new NotImplementedException();

	public async Task<ResponseCore> ConnectAsync() => await ConnectAsync(Callback);

	private void Callback(ResponseMessage message)
	{
		if (message is null || message.MessageType != WebSocketMessageType.Text)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				Code = "BINARY",
				Message = "binary message type"
			});
			return;
		}

		if (message.Text is null)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				Code = "TEXTNULL",
				Message = "message.Text is null"
			});
			return;
		}

		var document = JsonDocument.Parse(message.Text);
		var root = document.RootElement;

		var trCode = root.GetProperty("header").GetProperty("tr_cd").GetString();

		var callbackResult = trCode switch
		{
			nameof(JIF) => CallbackJIF(message.Text),
			nameof(FC0) => CallbackXC0(message.Text, trCode),
			nameof(JC0) => CallbackXC0(message.Text, trCode),
			nameof(DC0) => CallbackXC0(message.Text, trCode),
			nameof(FH0) => CallbackXH0(message.Text, trCode),
			nameof(DH0) => CallbackXH0(message.Text, trCode),
			nameof(O01) => CallbackO0X(message.Text, trCode),
			nameof(O02) => CallbackO0X(message.Text, trCode),
			//nameof(H01) => CallbackH01(message.Text),
			nameof(C01) => CallbackC0X(message.Text, trCode),
			nameof(C02) => CallbackC0X(message.Text, trCode),
			_ => false
		};
	}

	#region XC0 callback - FC0, JC0, DC0
	private bool CallbackXC0(string message, string trCode)
	{
		if (MarketExecuted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<JC0OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			MarketExecuted(this, new ResponseResult<MarketExecution>
			{
				Typ = MessageType.MKT,
				Code = $"{trCode}:{response.Header.Code}",
				Info = new MarketExecution
				{
					MarketSessionInfo = response.Body.Jgubun switch
					{
						"07" => MarketSession.CLOSED,
						"99" => MarketSession.CLOSED,
						"13" => MarketSession.CLOSED,
						"30" => MarketSession.CLOSING,
						"40" => trCode == nameof(DC0) ? MarketSession.EXTENDED : MarketSession.REGULAR,
						_ => trCode == nameof(DC0) ? MarketSession.EXTENDED : MarketSession.REGULAR,
					},
					Symbol = response.Body.Futcode,
					TimeExecuted = response.Body.Chetime.ToDateTime(),
					C = Convert.ToDecimal(response.Body.Price),
					VolumeExecuted = Convert.ToDecimal(response.Body.Cvolume),
					ExecutionSide = response.Body.Cgubun == "+" ? ExecutionSide.ASK : ExecutionSide.BID,
					BasePrice = Convert.ToDecimal(response.Body.Price) - Convert.ToDecimal((DeclineCodes.Contains(response.Body.Sign) ? "-" : "") + response.Body.Change),
					QuoteDaily = new Quote
					{
						V = Convert.ToDecimal(response.Body.Volume),
						Turnover = Convert.ToDecimal(response.Body.Value),
					}
				},
				Remark = message,
				Broker = Brkr.LS,
				ExtraData = new Dictionary<string, decimal>
				{
					{ "KOSPI200", Convert.ToDecimal(response.Body.K200jisu) },
					{ "BASIS", Convert.ToDecimal(response.Body.Sbasis) },
					{ "OI", Convert.ToDecimal(response.Body.Openyak) },
				}
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Typ = MessageType.MKTS,
				Code = trCode,
				Message = ex.Message,
				Broker = Brkr.LS
			});

			return false;
		}
	}
	#endregion

	#region XH0 callback - FH0, DH0
	private bool CallbackXH0(string message, string tr)
	{
		if (OrderBookTaken is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<FH0OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			IList<MarketOrder> asks = [];
			IList<MarketOrder> bids = [];
			for (int i = 0; i < 5; i++)
			{
				asks.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.Body.GetPropValue($"Offerho{i + 1}")),
					Amount = Convert.ToDecimal(response.Body.GetPropValue($"Offerrem{i + 1}")),
					AmountGroup = Convert.ToDecimal(response.Body.GetPropValue($"Offercnt{i + 1}"))
				});

				bids.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.Body.GetPropValue($"Bidho{i + 1}")),
					Amount = Convert.ToDecimal(response.Body.GetPropValue($"Bidrem{i + 1}")),
					AmountGroup = Convert.ToDecimal(response.Body.GetPropValue($"Bidcnt{i + 1}"))
				});
			}

			OrderBookTaken(this, new ResponseResult<OrderBook>
			{
				Broker = Brkr.LS,
				Typ = MessageType.MKT,
				Info = new()
				{
					Exchange = Exchange.KRX,
					MarketSessionInfo = tr == nameof(FH0) ? MarketSession.REGULAR : MarketSession.EXTENDED,
					Symbol = response.Body.Futcode,
					TimeTaken = response.Body.Hotime.ToTime(),
					Ask = asks,
					AskAgg = Convert.ToDecimal(response.Body.Totofferrem),
					Bid = bids,
					BidAgg = Convert.ToDecimal(response.Body.Totbidrem),
				}
			});
		}
		catch (Exception ex)
		{
			SendErrorMessage(tr, ex.Message);
			return false;
		}

		return true;
	} 
	#endregion

	#region C01/C02 callback
	private bool CallbackC0X(string message, string tr)
	{
		if (Executed is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<C01OutBlock>>(message);
            if (response is null || response.Body is null)
            {
                SendErrorMessage(tr, message);
                return false;
            }

            _ = long.TryParse(response.Body.Ordordno, out long idOrigin);
			Executed(this, new ResponseResult<Execution>
			{
				Typ = MessageType.EXECUTION,
				Code = $"{tr}:{response.Header.TrCode}",
				Info = new Execution
				{
					TimeExecuted = $"{response.Body.CheDate}{response.Body.CheTime}".ToDateTimeM(),
					OID = Convert.ToInt64(response.Body.Ordno),
					IdOrigin = idOrigin,
					EID = Convert.ToInt64(response.Body.Yakseq),
					Symbol = response.Body.Expcode.Substring(3, 8),
					Price = Convert.ToDecimal(response.Body.ChePrice),
					QtyExecuted = Convert.ToDecimal(response.Body.CheVol),
					DateBiz = response.Body.CheDate.ToDate(),
					IsLong = response.Body.DosuGb == "2",
				},
				Remark = message,
				Broker = Brkr.LS,
			});

			return true;
		}
		catch (Exception ex)
		{
            SendErrorMessage(tr, ex.Message);
            return false;
		}
	}
	#endregion

	#region O01/O02 callback
	private bool CallbackO0X(string message, string tr)
	{
		if (OrderReceived is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<O01OutBlock>>(message);
			if (response is null || response.Body is null)
			{
				SendErrorMessage(tr, message);
				return false;
			}

			OrderReceived(this, new ResponseResult<Execution>
			{
				Typ = MessageType.ORDER,
				Code = $"{tr}:{response.Header.TrCode}",
				Info = new Execution
				{
					DateBiz = DateTime.Now.ToKrxTradingDay(),
					TimeOrdered = response.Body.Trxtime.ToDateTimeM(),
					OID = Convert.ToInt64(response.Body.Ordno),
					IdOrigin = Convert.ToInt64(response.Body.Orgordno),
					Symbol = response.Body.Isuno.Substring(3, 8),
					IsLong = response.Body.Bnstp == "2",
					QtyOrdered = Convert.ToDecimal(response.Body.Ordqty),
					PriceOrdered = Convert.ToDecimal(response.Body.Ordprc),
					Mode = response.Body.Mrctp switch
					{
						"0" => OrderMode.PLACE,
						"1" => OrderMode.UPDATE,
						"2" => OrderMode.CANCEL,
						_ => OrderMode.NONE,
					},
					Aggregation = Convert.ToDecimal(response.Body.Ordprc) * Convert.ToDecimal(response.Body.Ordqty),
				},
				Remark = message,
				Broker = Brkr.LS,
			});

			return true;
		}
		catch (Exception ex)
		{
			SendErrorMessage(tr, ex.Message);
			return false;
		}
	}
	#endregion
}
