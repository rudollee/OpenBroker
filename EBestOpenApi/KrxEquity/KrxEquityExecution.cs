using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EBestOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace EBestOpenApi.KrxEquity;
public partial class EBestKrxEquity : ConnectionBase, IExecution
{
	public EventHandler<ResponseResult<Contract>> Contracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<Order>> Executed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<Balance>> BalanceAggregated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	#region KRX 주식 주문/정정/취소 - CSPAT00601/CSPAT00701/CSPAT00801
	public async Task<ResponseCore> AddOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00601>(new
		{
			CSPAT00601InBlock1 = new CSPAT00601InBlock1
			{
				IsuNo = $"A{order.Symbol}",
				OrdQty = order.VolumeOrdered,
				OrdPrc = order.PriceOrdered,
				BnsTpCode = order.IsLong ? "2" : "1",
				OrdprcPtnCode = order.OrderType switch
				{
					OrderType.LIMIT => "00",
					OrderType.MARKET => "03",
					_ => "03"
				},
				MgntrnCode = "000",
				LoanDt = "",
				OrdCndiTpCode = "0"
			}
		});

	public async Task<ResponseCore> UpdateOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00701>(new
		{
			CSPAT00701InBlock1 = new CSPAT00701InBlock1
			{
				OrgOrdNo = order.IdOrigin,
				IsuNo = $"A{order.Symbol}",
				OrdQty = order.VolumeOrdered,
				OrdPrc = order.PriceOrdered,
				OrdprcPtnCode = order.OrderType switch
				{
					OrderType.LIMIT => "00",
					OrderType.MARKET => "03",
					_ => "00"
				},
				OrdCndiTpCode = "0"
			}
		});

	public async Task<ResponseCore> CancelOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00801>(new
		{
			CSPAT00801InBlock1 = new CSPAT00801InBlock1
			{
				OrgOrdNo = order.IdOrigin,
				IsuNo = order.Symbol,
				OrdQty = order.VolumeOrdered,
			}
		});

	private async Task<ResponseCore> RequestOrderAsync<T>(object parameters) where T : EBestOrderResponseStandard
	{
		var client = new RestClient($"{host}/stock/order");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name));

		request.AddBody(JsonSerializer.Serialize(parameters));

		try
		{
			var response = await client.PostAsync<T>(request);
			if (response is null) return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response is null",
			};

			return new ResponseCore
			{
				Code = response.Code,
				Message = response.Message,
				Remark = response.OrderNo.ToString()
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception"
			};
		}
	}

	#endregion

	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null) => throw new NotImplementedException();

	public async Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ExecutedOnly)
	{
		var contracts = new List<Contract>();
		var client = new RestClient($"{host}/stock/accno");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t0425)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t0425InBlock = new t0425InBlock
			{
				expcode = "",
				chegb = "0",
				medosu = "0",
				sortgb = "1",
				cts_ordno = "",
			}
		}));

		try
		{
			var response = await client.PostAsync<t0425>(request) ?? new t0425();

			contracts.Capacity = response.t0425OutBlock1.Count;
			response.t0425OutBlock1.ForEach(contract =>
			{
				contracts.Add(new Contract
				{
					BrokerCo = "EB",
					OID = contract.ordno,
					CID = contract.sysprocseq,
					Currency = Currency.KRW,
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					ExchangeCode = Exchange.KRX,
					IdOrigin = contract.orgordno,
					PriceOrdered = contract.price,
					Price = contract.cheprice,
					Symbol = contract.expcode,
					TimeOrdered = contract.ordtime.ToDateTime(),
				});
			});

			return new ResponseResults<Contract>
			{
				List = contracts,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Contract>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Contract>()
			};
		}

	}
	
	public async Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly) => throw new NotImplementedException();

	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();
	public Task<ResponseCore> RequestOrderableAsync(Order order) => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync() => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin) => throw new NotImplementedException();
	public Task<ResponseResults<Position>> RequestPositionsAsync(DateTime? date = null) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeContractAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => throw new NotImplementedException();
}
