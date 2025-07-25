﻿using KisOpenApi.Models.KrxEquity;
using OpenBroker;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Execution>> Executed { get; set; }
	public required EventHandler<ResponseResult<Order>> OrderReceived { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	#region 국내주식 주문 매수/매도/정정/취소 TTTC0802U/TTTC0801U/TTTC0803U 
	public async Task<ResponseCore> PlaceOrderAsync(OrderCore order)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseCore
		{
			StatusCode = Status.UNAUTHORIZED,
			Code = "ANUMBER",
			Message = "no account number"
		};

		var parameters = GenerateParameters(new
		{
			PDNO = order.Symbol,
			ORD_DVSN = order.OrderType == OrderType.MARKET ? "01" : "00",
			ORD_QTY = order.VolumeOrdered,
			ORD_UNPR = order.OrderType == OrderType.MARKET ? "0" : order.PriceOrdered.ToString(),
		}, true);

		return await RequestOrderAsync(order.IsLong ? "TTTC0802U" : "TTTC0801U", parameters);
	}

	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
	
	public async Task<ResponseCore> CancelOrderAsync(OrderCore order)
	{
		if (order.IdOrigin == 0 || order.VolumeOrdered == 0) return new ResponseCore
		{
			StatusCode = Status.BAD_REQUEST,
			Code = "REFUSE",
			Message = "one of parameter value is not correct.",
		};

		var parameters = GenerateParameters(new
		{
			KRX_FWDG_ORD_ORGNO = "",
			ORGN_ODNO = order.IdOrigin.ToString().PadLeft(10, '0'),
			ORD_DVSN = "00",
			RVSE_CNCL_DVSN_CD = "02",
			ORD_QTY = "0",
			ORD_UNPR = "0",
			QTY_ALL_ORD_YN = "Y"
		}, true);

		return await RequestOrderAsync("TTTC0803U", parameters);
	}

	private async Task<ResponseCore> RequestOrderAsync(string trId, object parameters)
	{
		var client = new RestClient($"{host}/uapi/domestic-stock/v1/trading/order-{(trId != "TTTC0803U" ? "cash" : "-rvsecncl")}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(trId)).AddBody(parameters);

		try
		{
			var response = await client.PostAsync<TTTC080XU>(request);
			if (response is null || response.Output is null || response.ReturnCode != "0") return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = response?.MessageCode ?? "NULL",
				Message = response?.Message ?? "response is null",
			};

			return new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Code = response.MessageCode,
				Message = response.Message,
				Remark = $"{response.Output.OrderTime6}-{response.Output.OrderNumber}"
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}"
			};
		}
	}
	#endregion

	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.NONE) => throw new NotImplementedException();
	public Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, DateTime dateFin, ExecutionStatus status = ExecutionStatus.ExecutedOnly) => throw new NotImplementedException();
	public Task<ResponseResults<Pnl>> RequestPnlAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();
	public Task<ResponseCore> RequestOrderableAsync(Order order) => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync() => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin) => throw new NotImplementedException();
	public Task<ResponseResults<Position>> RequestPositionsAsync() => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => throw new NotImplementedException();
}
