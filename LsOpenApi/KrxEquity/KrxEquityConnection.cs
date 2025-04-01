﻿using System.Net.WebSockets;
using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using Websocket.Client;
using OpenBroker.Extensions;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IConnection
{
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) =>
		throw new NotImplementedException();

	public async Task<ResponseCore> ConnectAsync() => await ConnectAsync(Callback);

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
		var callbackResult = trCode switch
		{
			nameof(NWS) => CallbackNWS(message.Text), // NWS 뉴스
			nameof(JIF) => CallbackJIF(message.Text), // JIF 장운영정보
			nameof(S3_) => CallbackX3(message.Text, trCode), // S3_ 시장 체결
			nameof(K3_) => CallbackX3(message.Text, trCode), // K3_ 시장 체결
			nameof(YS3) => CallbackYX3(message.Text, trCode), // YS3 예상체결
			nameof(YK3) => CallbackYX3(message.Text, trCode), // YK3 예상체결
			nameof(CUR) => CallbackCUR(message.Text), // CUR 현물정보USD
			nameof(MK2) => CallbackMK2(message.Text), // MK2 US지수
			nameof(H1_) => CallbackHX(message.Text, trCode), // H1_ 전체 호가
			nameof(HA_) => CallbackHX(message.Text, trCode), // HA_ 전체 호가
			nameof(VI_) => CallbackVI(message.Text), // VI_ 주식 VI 발동/해제
			nameof(SC0) => CallbackSC0(message.Text), // SC0 주식주문접수
			nameof(SC2) => CallbackSCX(message.Text, trCode), // SC2 주문 정정
			nameof(SC3) => CallbackSCX(message.Text, trCode), // SC3 주문 취소
			nameof(SC4) => CallbackSCX(message.Text, trCode), // SC4 주문 거부
			nameof(SC1) => CallbackSC1(message.Text), // SC1 주문체결
			_ => false
		};
	}

	#region NWS 뉴스 callback
	/// <summary>
	/// NWS 뉴스 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackNWS(string message)
	{
		if (NewsPosted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<NWSOutBlock>>(message);
			if (response is null || response.Body is null) return false;

			var publisherId = Convert.ToInt32(response.Body.id);
			NewsPosted(this, new ResponseResult<News>
			{
				Info = new News
				{
					Code = nameof(NWS),
					TimePosted = DateTime.Now,
					PublisherId = publisherId,
					Publisher = CodeRef.NewsPublishers.ContainsKey(publisherId) ? CodeRef.NewsPublishers[publisherId] : response.Body.id,
					Title = response.Body.title,
					Remark = response.Body.code,
				},
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Broker = Brkr.LS,
				Code = nameof(NWS),
				Message = ex.Message
			});

			return false;
		}
	}
	#endregion

	#region JIF 장운영정보
	/// <summary>
	/// JIF 장운영정보 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackJIF(string message)
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

	#region S3_/K3_ 시장 체결
	/// <summary>
	/// S3_/K3_ 시장 체결 callback
	/// </summary>
	/// <param name="message"></param>
	/// <param name="trCode"></param>
	/// <returns></returns>
	private bool CallbackX3(string message, string trCode)
	{
		if (MarketContracted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<S3_OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			MarketContracted(this, new ResponseResult<MarketContract>
			{
				Typ = MessageType.MKT,
				Code = trCode,
				Info = new MarketContract
				{
					MarketSessionInfo = response.Body.status switch
					{
						"3" => MarketSession.CLOSED,
						"4" => MarketSession.AFTER,
						"10" => MarketSession.PRE,
						_ => MarketSession.REGULAR,
					},
					Symbol = response.Body.shcode,
					TimeContract = response.Body.chetime.ToDateTime(),
					C = Convert.ToDecimal(response.Body.price),
					V = Convert.ToDecimal(response.Body.cvolume),
					ContractSide = response.Body.cgubun == "+" ? ContractSide.ASK : ContractSide.BID,
					BasePrice = Convert.ToDecimal(response.Body.price) - Convert.ToDecimal((new string[] { "4", "5" }.Contains(response.Body.sign) ? "-" : "") + response.Body.change),
					VolumeAcc = Convert.ToDecimal(response.Body.volume),
					MoneyAcc = Convert.ToDecimal(response.Body.value),
				},
				Remark = message,
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
				Code = trCode,
				Message = ex.Message,
				Broker = Brkr.LS
			});

			return false;
		}
	}
	#endregion

	#region YS3/YK3 예상체결
	/// <summary>
	/// YS3/YK3 예상체결 callback
	/// </summary>
	/// <param name="message"></param>
	/// <param name="trCode"></param>
	/// <returns></returns>
	private bool CallbackYX3(string message, string trCode)
	{
		if (MarketContracted is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<YS3OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			MarketContracted(this, new ResponseResult<MarketContract>
			{
				Typ = MessageType.MKT,
				Code = trCode,
				Info = new MarketContract
				{
					IsEstimated = true,
					Symbol = response.Body.shcode,
					TimeContract = response.Body.hotime.ToDateTime(),
					C = Convert.ToDecimal(response.Body.yeprice),
					V = Convert.ToDecimal(response.Body.yevolume),
					ContractSide = response.Body.yeprice == response.Body.ybidho0 ? ContractSide.ASK : ContractSide.BID,
					BasePrice = Convert.ToDecimal(response.Body.yeprice) - Convert.ToDecimal((new string[] { "4", "5" }.Contains(response.Body.jnilysign) ? "-" : "") + response.Body.jnilchange),
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Typ = MessageType.MKT,
				Code = trCode,
				Message = ex.Message,
				Broker = Brkr.LS
			});

			return false;
		}
	}
	#endregion

	#region CUR 현물정보USD
	/// <summary>
	/// CUR 현물정보USD callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackCUR(string message)
	{
		if (MarketContracted is null) return false;
		if (message is null) return false;
		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<CUROutBlock>>(message);
			if (response is null || response.Body is null) return false;
			MarketContracted(this, new ResponseResult<MarketContract>
			{
				Typ = MessageType.MKT,
				Code = nameof(CUR),
				Info = new MarketContract
				{
					Symbol = response.Body.base_id,
					TimeContract = (DateTime.UtcNow.AddHours(9).ToString("yyyyMMdd") + response.Body.ctime).ToDateTime(),
					C = Convert.ToDecimal(response.Body.price),
					BasePrice = Convert.ToDecimal(response.Body.price) - Convert.ToDecimal(response.Body.change),
				},
				Remark = message,
				Broker = Brkr.LS
			});
			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Broker = Brkr.LS,
				Code = nameof(CUR),
				Message = ex.Message
			});
			return false;
		}
	}
	#endregion

	#region MK2 US지수
	/// <summary>
	/// MK2 US지수 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackMK2(string message)
	{
		if (MarketContracted is null) return false;

		try
		{
			var mk2Res = JsonSerializer.Deserialize<LsSubscriptionCallback<MK2OutBlock>>(message);
			if (mk2Res is null || mk2Res.Body is null) return false;

			MarketContracted(this, new ResponseResult<MarketContract>
			{
				Typ = MessageType.MKT,
				Code = nameof(MK2),
				Info = new MarketContract
				{
					Symbol = mk2Res.Body.xsymbol,
					TimeContract = (mk2Res.Body.kodate + mk2Res.Body.kotime.PadLeft(6, '0')).ToDateTime(),
					C = Convert.ToDecimal(mk2Res.Body.price),
					BasePrice = Convert.ToDecimal(mk2Res.Body.price) - Convert.ToDecimal(mk2Res.Body.change)
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Broker = Brkr.LS,
				Code = nameof(MK2),
				Message = ex.Message
			});
			return false;
		}
	}
	#endregion

	#region H1_/HA_ 전체 호가
	/// <summary>
	/// H1_/HA_ 전체 호가 callback
	/// </summary>
	/// <param name="message"></param>
	/// <param name="trCode"></param>
	/// <returns></returns>
	private bool CallbackHX(string message, string trCode)
	{
		if (OrderBookTaken is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<H1_OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			var asks = new List<MarketOrder>();
			for (int i = 0; i < 10; i++)
			{
				asks.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.Body.GetPropValue($"offerho{(i + 1)}")),
					Amount = Convert.ToDecimal(response.Body.GetPropValue($"offerrem{(i + 1)}")),
				});
			}

			var bids = new List<MarketOrder>();
			for (int i = 0; i < 10; i++)
			{
				bids.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.Body.GetPropValue($"bidho{(i + 1)}")),
					Amount = Convert.ToDecimal(response.Body.GetPropValue($"bidrem{(i + 1)}"))
				});
			}

			OrderBookTaken(this, new ResponseResult<OrderBook>
			{
				Typ = MessageType.MKT,
				Code = trCode,
				Info = new OrderBook
				{
					Symbol = response.Body.shcode,
					TimeTaken = response.Body.hotime.ToTime(),
					Ask = asks,
					Bid = bids,
					AskAgg = Convert.ToDecimal(response.Body.totofferrem),
					BidAgg = Convert.ToDecimal(response.Body.totbidrem),
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				StatusCode = Status.ERROR_OPEN_API,
				Code = trCode,
				Message = ex.Message
			});
			return false;
		}
	}
	#endregion

	#region VI_ 주식 VI 발동/해제
	/// <summary>
	/// VI_ 주식 VI 발동/해제 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackVI(string message)
	{
		if (MarketPaused is null) return false;

		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<VI_OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			MarketPaused(this, new ResponseResult<MarketPause>
			{
				Typ = MessageType.MKTS,
				Code = nameof(VI_),
				Info = new MarketPause
				{
					Time = response.Body.time.ToTime(),
					Symbol = response.Body.ref_shcode,
					PauseType = response.Body.vi_gubun == "0"
						? MarketPauseType.VI0
						: (response.Body.vi_gubun == "1" ? MarketPauseType.VIS : MarketPauseType.VID),
					BasePrice = Convert.ToDecimal(response.Body.vi_gubun == "1" ? response.Body.svi_recprice : response.Body.dvi_recprice),
					TriggerPrice = Convert.ToDecimal(response.Body.vi_trgprice),
					Remark = response.Body.shcode,
				},
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				StatusCode = Status.ERROR_OPEN_API,
				Code = nameof(VI_),
				Message = ex.Message
			});
			return false;
		}
	}
	#endregion

	#region SC0 주식주문접수
	/// <summary>
	/// SC0 주식주문접수 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackSC0(string message)
	{
		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<SC0OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			Executed(this, new ResponseResult<Order>
			{
				Typ = MessageType.EXECUTION,
				StatusCode = Status.SUCCESS,
				Code = nameof(SC0),
				Info = new Order
				{
					BrokerCo = Brkr.LS.ToDescription(),
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					OID = Convert.ToInt64(response.Body.ordno),
					Symbol = response.Body.shtcode.Substring(1),
					InstrumentName = response.Body.hname,
					Mode = response.Body.ordchegb switch
					{
						"01" => OrderMode.PLACE,
						"02" => OrderMode.UPDATE,
						"03" => OrderMode.CANCEL,
						_ => OrderMode.NONE
					},
					IsLong = response.Body.bnstp == "2",
					PriceOrdered = Convert.ToDecimal(response.Body.ordprice),
					VolumeOrdered = Convert.ToDecimal(response.Body.ordqty),
					TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + response.Body.ordtm).ToDateTimeMicro(),
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				StatusCode = Status.ERROR_OPEN_API,
				Code = nameof(SC0),
				Message = ex.Message
			});

			return false;
		}
	}
	#endregion

	#region SC2/SC3/SC4 주문 정정/취소/거부
	/// <summary>
	/// SC2/SC3/SC4 주문 정정/취소/거부 callback
	/// </summary>
	/// <param name="message"></param>
	/// <param name="trCode"></param>
	/// <returns></returns>
	private bool CallbackSCX(string message, string trCode)
	{
		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<SC2OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			Executed(this, new ResponseResult<Order>
			{
				Typ = MessageType.EXECUTION,
				StatusCode = Status.SUCCESS,
				Code = trCode,
				Info = new Order
				{
					BrokerCo = Brkr.LS.ToDescription(),
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + response.Body.proctm.PadLeft(9, '0')).ToDateTimeMicro(),
					Currency = Currency.KRW,
					Precision = 0,
					NumeralSystem = 10,
					Symbol = response.Body.shtnIsuno.Substring(1),
					InstrumentName = response.Body.Isunm,
					OID = Convert.ToInt64(response.Body.ordno),
					IdOrigin = Convert.ToInt64(response.Body.orgordno),
					IsLong = response.Body.bnstp == "2",
					VolumeOrdered = Convert.ToDecimal(trCode == nameof(SC2) ? response.Body.mdfycnfqty : response.Body.canccnfqty),
					PriceOrdered = Convert.ToDecimal(trCode == nameof(SC2) ? response.Body.mdfycnfprc : "0"),
					Aggregation = Convert.ToDecimal(response.Body.ordamt),
					DiscardStatus = DiscardStatus.TRADABLE,
					Mode = trCode switch
					{
						"SC2" => OrderMode.UPDATE_RESPONSE,
						"SC3" => OrderMode.CANCEL_RESPONSE,
						_ => OrderMode.NONE
					},
					Tradable = true,
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				StatusCode = Status.ERROR_OPEN_API,
				Code = trCode,
				Message = ex.Message
			});

			return false;
		}
	}
	#endregion

	#region SC1 주문체결
	/// <summary>
	/// SC1 주문체결 callback
	/// </summary>
	/// <param name="message"></param>
	/// <returns></returns>
	private bool CallbackSC1(string message)
	{
		try
		{
			var response = JsonSerializer.Deserialize<LsSubscriptionCallback<SC1OutBlock>>(message);
			if (response is null || response.Body is null) return false;

			Contracted(this, new ResponseResult<Contract>
			{
				Typ = MessageType.CONTRACT,
				Code = nameof(SC1),
				Info = new Contract
				{
					BrokerCo = Brkr.LS.ToDescription(),
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					OID = Convert.ToInt64(response.Body.ordno),
					CID = Convert.ToInt64(response.Body.execno),
					Symbol = response.Body.shtnIsuno.Substring(1),
					InstrumentName = response.Body.Isunm,
					IsLong = response.Body.bnstp == "2",
					Price = Convert.ToDecimal(response.Body.execprc),
					PriceOrdered = Convert.ToDecimal(response.Body.ordprc),
					Volume = Convert.ToDecimal(response.Body.execqty),
					VolumeLeft = Convert.ToDecimal(response.Body.secbalqty),
					TimeContracted = (DateTime.Now.ToString("yyyyMMdd") + response.Body.exectime).ToDateTimeMicro(),
				},
				Remark = message,
				Broker = Brkr.LS
			});

			return true;
		}
		catch (Exception ex)
		{
			Message(this, new ResponseCore
			{
				Broker = Brkr.LS,
				StatusCode = Status.ERROR_OPEN_API,
				Code = nameof(SC1),
				Message = ex.Message
			});

			return false;
		}
	} 
	#endregion
}

