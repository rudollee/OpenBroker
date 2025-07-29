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
			nameof(O01) => CallbackO01(message.Text),
			//nameof(H01) => CallbackH01(message.Text),
			nameof(C01) => CallbackC01(message.Text),
			_ => false
		};
	}

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
				Code = response.Header.Code,
				Info = new MarketExecution
				{
					MarketSessionInfo = response.Body.jgubun switch
					{
						"07" => MarketSession.CLOSED,
						"13" => MarketSession.CLOSED,
						_ => MarketSession.REGULAR,
					},
					Symbol = response.Body.futcode,
					TimeExecuted = response.Body.chetime.ToDateTime(),
					C = Convert.ToDecimal(response.Body.price),
					VolumeExecuted = Convert.ToDecimal(response.Body.cvolume),
					ExecutionSide = response.Body.cgubun == "+" ? ExecutionSide.ASK : ExecutionSide.BID,
					BasePrice = Convert.ToDecimal(response.Body.price) - Convert.ToDecimal((DeclineCodes.Contains(response.Body.sign) ? "-" : "") + response.Body.change),
					QuoteDaily = new Quote 
					{ 
						V = Convert.ToDecimal(response.Body.volume),
						Turnover = Convert.ToDecimal(response.Body.value),
					}
				},
				Remark = message,
				Broker = Brkr.LS,
				ExtraData = new Dictionary<string, decimal>
				{
					{ "KOSPI200", Convert.ToDecimal(response.Body.k200jisu) },
					{ "BASIS", Convert.ToDecimal(response.Body.sbasis) },
					{ "OI", Convert.ToDecimal(response.Body.openyak) },
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

	private bool CallbackC01(string message)
	{
		if (Executed is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<C01OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			Int64.TryParse(response.Body.ordordno, out long idOrigin);
			Executed(this, new ResponseResult<Execution>
			{
				Typ = MessageType.EXECUTION,
				Code = response.Header.TrCode,
				Info = new Execution
				{
					TimeExecuted = $"{response.Body.chedate}{response.Body.chetime}".ToDateTimeM(),
					OID = Convert.ToInt64(response.Body.ordno),
					IdOrigin = idOrigin,
					CID = Convert.ToInt64(response.Body.yakseq),
					Symbol = response.Body.expcode,
					Price = Convert.ToDecimal(response.Body.cheprice),
					Volume = Convert.ToDecimal(response.Body.chevol),
					DateBiz = response.Body.chedate.ToDate(),
					IsLong = response.Body.dosugb == "2",
				},
				Remark = message,
				Broker = Brkr.LS,
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Typ = MessageType.EXECUTION,
				Code = nameof(C01),
				Message = ex.Message,
				Remark = message,
				Broker = Brkr.LS
			});

			return false;
		}
	}

	private bool CallbackO01(string message)
	{
		if (OrderReceived is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<O01OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			OrderReceived(this, new ResponseResult<Order>
			{
				Typ = MessageType.ORDER,
				Code = response.Header.TrCode,
				Info = new Order
				{
					DateBiz = DateTime.Now.ToKrxTradingDay(),
					TimeOrdered = response.Body.trxtime.ToDateTimeM(),
					OID = Convert.ToInt64(response.Body.ordno),
					IdOrigin = Convert.ToInt64(response.Body.orgordno),
					Symbol = response.Body.isuno,
					IsLong = response.Body.bnstp == "2",
					VolumeOrdered = Convert.ToDecimal(response.Body.ordqty),
					PriceOrdered = Convert.ToDecimal(response.Body.ordprc),
					Mode = response.Body.mrctp switch
					{
						"0" => OrderMode.PLACE,
						"1" => OrderMode.UPDATE,
						"2" => OrderMode.CANCEL,
						_ => OrderMode.NONE,
					},
					Aggregation = Convert.ToDecimal(response.Body.ordprc) * Convert.ToDecimal(response.Body.ordqty),
				},
				Remark = message,
				Broker = Brkr.LS,
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Typ = MessageType.ORDER,
				Code = nameof(O01),
				Message = ex.Message,
				Remark = message,
				Broker = Brkr.LS
			});

			return false;
		}
	}
}
