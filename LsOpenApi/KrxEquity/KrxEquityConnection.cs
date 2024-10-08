using System.Net.WebSockets;
using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using Websocket.Client;
using OpenBroker.Extensions;
using System.Reflection;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IConnection
{
	private readonly string _broker = "LS";

	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) =>
		throw new NotImplementedException();

	private Dictionary<string, string> _subscriptions = new Dictionary<string, string>
	{
		{ "JIF", "0" },
		{ "SC0", "" },
		{ "SC1", "" }
	};

	public async Task<ResponseCore> ConnectAsync() => await ConnectAsync(Callback, _subscriptions);

	private void Callback(ResponseMessage message)
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

		var document = JsonDocument.Parse(message.Text);
		var root = document.RootElement;

		var trCode = root.GetProperty("header").GetProperty("tr_cd").GetString();
		switch (trCode)
		{
			#region NWS 뉴스
			case nameof(NWS):
				if (NewsPosted is null) return;

				var response = JsonSerializer.Deserialize<LsSubscriptionCallback<NWSOutBlock>>(message.Text);
				if (response is null || response.Body is null) return;

				NewsPosted(this, new ResponseResult<News>
				{
					Info = new News
					{
						Code = response.Body.realkey,
						TimePosted = DateTime.Now,
						Title = response.Body.title,
						Remark = response.Body.code,
					}
				});
				break;
			#endregion
			#region JIF 장운영정보
			case nameof(JIF):
				var resJif = JsonSerializer.Deserialize<LsSubscriptionCallback<JIFOutBlock>>(message.Text);
				if (resJif is null || resJif.Body is null) return;

				Message(this, new ResponseCore
				{
					Code = $"{resJif.Body.jangubun}.{resJif.Body.jstatus}",
					Message = $"{CodeRef.MarketSectionDic[resJif.Body.jangubun]} {CodeRef.MarketStatusDic[resJif.Body.jstatus]}"
				});
				break;
			#endregion
			#region S3_ 시장 체결
			case nameof(S3_):
			case nameof(K3_):
				if (MarketContracted is null) return;

				var s3Res = JsonSerializer.Deserialize<LsSubscriptionCallback<S3_OutBlock>>(message.Text);
				if (s3Res is null || s3Res.Body is null) return;

				MarketContracted(this, new ResponseResult<MarketContract>
				{
					Code = trCode,
					Info = new MarketContract
					{
						Symbol = s3Res.Body.shcode,
						TimeContract = s3Res.Body.chetime.ToDateTime(),
						C = Convert.ToDecimal(s3Res.Body.price),
						V = Convert.ToDecimal(s3Res.Body.cvolume),
						BasePrice = Convert.ToDecimal(s3Res.Body.price) - Convert.ToDecimal((new string[] { "4", "5" }.Contains(s3Res.Body.sign) ? "-" : "") + s3Res.Body.change),
						VolumeAgg = Convert.ToDecimal(s3Res.Body.volume),
						MoneyAgg = Convert.ToDecimal(s3Res.Body.value),
					},
					Remark = message.Text
				});
				break;
			#endregion
			#region H1_ 전체 호가
			case nameof(H1_):
			case nameof(HA_):
				if (OrderBookTaken is null) return;

				var h1Res = JsonSerializer.Deserialize<LsSubscriptionCallback<H1_OutBlock>>(message.Text);
				if (h1Res is null || h1Res.Body is null) return;

				var asks = new List<MarketOrder>();
				for (int i = 0; i < 10; i++)
				{
					asks.Add(new MarketOrder
					{
						Seq = Convert.ToByte(i + 1),
						Price = Convert.ToDecimal(h1Res.Body.GetPropValue($"offerho{(i + 1)}")),
						Amount = Convert.ToDecimal(h1Res.Body.GetPropValue($"offerrem{(i + 1)}")),
					});
				}

				var bids = new List<MarketOrder>();
				for (int i = 0; i < 10; i++)
				{
					bids.Add(new MarketOrder
					{
						Seq = Convert.ToByte(i + 1),
						Price = Convert.ToDecimal(h1Res.Body.GetPropValue($"bidho{(i + 1)}")),
						Amount = Convert.ToDecimal(h1Res.Body.GetPropValue($"bidrem{(i + 1)}"))
					});
				}

				OrderBookTaken(this, new ResponseResult<OrderBook>
				{
					Code = trCode,
					Info = new OrderBook
					{
						Symbol = h1Res.Body.shcode,
						TimeTaken = h1Res.Body.hotime.ToTime(),
						Ask = asks,
						Bid = bids,
						AskAgg = Convert.ToDecimal(h1Res.Body.totofferrem),
						BidAgg = Convert.ToDecimal(h1Res.Body.totbidrem),
					},
					Remark = message.Text
				});
				break;
			#endregion
			#region VI_ 주식 VI 발동/해제
			case nameof(VI_):
				if (MarketPaused is null) return;

				var viResponse = JsonSerializer.Deserialize<LsSubscriptionCallback<VI_OutBlock>>(message.Text);
				if (viResponse is null || viResponse.Body is null) break;

				MarketPaused(this, new ResponseResult<MarketPause>
				{
					Info = new MarketPause
					{
						Time = viResponse.Body.time.ToTime(),
						Symbol = viResponse.Body.ref_shcode,
						PauseType = viResponse.Body.vi_gubun == "0"
							? MarketPauseType.VI0
							: (viResponse.Body.vi_gubun == "1" ? MarketPauseType.VIS : MarketPauseType.VID),
						BasePrice = Convert.ToDecimal(viResponse.Body.vi_gubun == "1" ? viResponse.Body.svi_recprice : viResponse.Body.dvi_recprice),
						TriggerPrice = Convert.ToDecimal(viResponse.Body.vi_trgprice),
						Remark = viResponse.Body.shcode,
					}
				});
				break; 
			#endregion
			#region SC0 주식주문접수
			case nameof(SC0):
				var sc0Res = JsonSerializer.Deserialize<LsSubscriptionCallback<SC0OutBlock>>(message.Text);
				if (sc0Res is null || sc0Res.Body is null) return;

				Executed(this, new ResponseResult<Order>
				{
					StatusCode = Status.SUCCESS,
					Code = nameof(SC0),
					Info = new Order
					{
						BrokerCo = _broker,
						DateBiz = DateOnly.FromDateTime(DateTime.Now),
						OID = Convert.ToInt64(sc0Res.Body.ordno),
						Symbol = sc0Res.Body.shtcode.Substring(1),
						InstrumentName = sc0Res.Body.hname,
						Mode = sc0Res.Body.ordchegb switch
						{
							"01" => OrderMode.PLACE,
							"02" => OrderMode.UPDATE,
							"03" => OrderMode.CANCEL,
							_ => OrderMode.NONE
						},
						IsLong = sc0Res.Body.bnstp == "2",
						PriceOrdered = Convert.ToDecimal(sc0Res.Body.ordprice),
						VolumeOrdered = Convert.ToDecimal(sc0Res.Body.ordqty),
						TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + sc0Res.Body.ordtm).ToDateTimeMicro(),
					},
					Remark = message.Text
				});
				break;
			#endregion
			#region SC1 주문체결
			case nameof(SC1):
				var sc1Res = JsonSerializer.Deserialize<LsSubscriptionCallback<SC1OutBlock>>(message.Text);
				if (sc1Res is null || sc1Res.Body is null) return;

				Contracted(this, new ResponseResult<Contract>
				{
					StatusCode = Status.SUCCESS,
					Code = nameof(SC1),
					Info = new Contract
					{
						BrokerCo = _broker,
						DateBiz = DateOnly.FromDateTime(DateTime.Now),
						OID = Convert.ToInt64(sc1Res.Body.ordno),
						CID = Convert.ToInt64(sc1Res.Body.execno),
						Symbol = sc1Res.Body.shtnIsuno,
						InstrumentName = sc1Res.Body.Isunm,
						IsLong = sc1Res.Body.bnstp == "2",
						Price = Convert.ToDecimal(sc1Res.Body.execprc),
						Volume = Convert.ToDecimal(sc1Res.Body.execqty),
						TimeContracted = (DateTime.Now.ToString("yyyyMMdd") + sc1Res.Body.exectime).ToDateTimeMicro(),
					},
					Remark = message.Text
				});
				break;
			#endregion

		}
	}
}

