using System;
using System.Collections.Generic;
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

	public Task<ResponseCore> AddOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseCore> CancelOrderAsync(DateOnly bizDate, long oid, int volume) => throw new NotImplementedException();
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
	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
}
