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
			nameof(C01) => CallbackC01(message.Text, trCode),
			_ => false
		};
	}

	private bool CallbackXC0(string message, string trCode)
	{
		if (MarketContracted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<JC0OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			MarketContracted(this, new ResponseResult<MarketContract>
			{
				Typ = MessageType.MKT,
				Code = trCode,
				Info = new MarketContract
				{
					MarketSessionInfo = response.Body.jgubun switch
					{
						"07" => MarketSession.CLOSED,
						"13" => MarketSession.CLOSED,
						_ => MarketSession.REGULAR,
					},
					Symbol = response.Body.futcode,
					TimeContract = response.Body.chetime.ToDateTime(),
					C = Convert.ToDecimal(response.Body.price),
					V = Convert.ToDecimal(response.Body.cvolume),
					ContractSide = response.Body.cgubun == "+" ? ContractSide.ASK : ContractSide.BID,
					BasePrice = Convert.ToDecimal(response.Body.price) - Convert.ToDecimal((new string[] { "4", "5" }.Contains(response.Body.sign) ? "-" : "") + response.Body.change),
					VolumeAcc = Convert.ToDecimal(response.Body.volume),
					Turnover = Convert.ToDecimal(response.Body.value),
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

	private bool CallbackC01(string message, string trCode)
	{
		if (Contracted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<C01OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			Contracted(this, new ResponseResult<Contract>
			{
				Typ = MessageType.CONTRACT,
				Code = trCode,
				Info = new Contract
				{
					TimeContracted = $"{response.Body.chedate}{response.Body.chetime}".ToDateTimeMicro(),
					OID = Convert.ToInt64(response.Body.ordno),
					IdOrigin = Convert.ToInt64(response.Body.ordordno),
					CID = Convert.ToInt64(response.Body.seq),
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
				Typ = MessageType.CONTRACT,
				Code = trCode,
				Message = ex.Message,
				Broker = Brkr.LS
			});

			return false;
		}
	}

}
