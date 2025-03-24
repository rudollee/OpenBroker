using OpenBroker;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IExecution
{
	public EventHandler<ResponseResult<Contract>> Contracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<Order>> Executed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public Task<ResponseCore> AddOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseCore> CancelOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.TUS) => throw new NotImplementedException();
	public Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ContractedOnly, string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ContractedOnly) => throw new NotImplementedException();
	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();
	public Task<ResponseCore> RequestOrderableAsync(Order order) => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync() => throw new NotImplementedException();
	public Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin) => throw new NotImplementedException();
	public Task<ResponseResults<Position>> RequestPositionsAsync() => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeContractAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
}
