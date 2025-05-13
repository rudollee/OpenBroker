using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
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

	#region request contracts - CFOAQ00600
	public Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ContractedOnly, string symbol = "")
	{
		var date = DateTime.UtcNow.AddHours(9);
		return RequestContractsAsync(date, date, status);
	}

	public async Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ContractedOnly)
	{
		try
		{
			List<CFOAQ00600OutBlock3> contractsRaw = new();
			var nextKey = string.Empty;
			do
			{
				var response = await RequestContinuousAsync<CFOAQ00600>(LsEndpoint.FuturesAccount.ToDescription(), new
				{
					CFOAQ00600InBlock1 = new CFOAQ00600InBlock1
					{
						QrySrtDt = dateBegun.ToString("yyyyMMdd"),
						QryEndDt = dateFin.ToString("yyyyMMdd"),
						PrdtExecTpCode = "1"
					}
				}, nextKey);

				if (response is null || !response.CFOAQ00600OutBlock3.Any())
				{
					nextKey = string.Empty;
					break;
				}

				contractsRaw.AddRange(response.CFOAQ00600OutBlock3);
				nextKey = response.NextKey;
			} while (!string.IsNullOrEmpty(nextKey));

			List<Contract> contracts = new() { Capacity = contractsRaw.Count };
			Contract previousContract = new();
			foreach (var contract in contractsRaw)
			{
				if (contract.OrdNo == 0)
				{
					previousContract.TimeContracted = $"{previousContract.TimeContracted.ToString("yyyyMMdd")}{contract.CtrctTime}".ToDateTimeMicro();
					previousContract.CID = contract.CtrctNo;
					previousContract.Volume = contract.ExecQty;
					previousContract.Price = contract.ExecPrc;

					contracts.Add(previousContract);
					continue;
				}

				contracts.Add(new Contract
				{
					DateBiz = contract.OrdDt.ToDate(),
					BrokerCo = "LS",
					OID = contract.OrdNo,
					IdOrigin = contract.OrgOrdNo,
					CID = contract.ExecNo,
					Symbol = contract.FnoIsuNo,
					InstrumentName = contract.IsuNm,
					IsLong = contract.BnsTpNm == "매수",
					VolumeOrdered = contract.OrdQty,
					VolumeUpdatable = contract.UnercQty,
					VolumeLeft = contract.UnercQty,
					Volume = contract.ExecQty,
					PriceOrdered = contract.OrdPrc,
					Price = contract.ExecPrc,
					Precision = !new string[] { "1", "A" }.Contains(contract.FnoIsuNo.Substring(0, 1)) ? 2 : contract.FnoIsuNo.Substring(1, 2) switch 
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						_ => 0
					},
					TimeOrdered = $"{contract.OrdDt}{contract.OrdTime}".ToDateTimeMicro(),
					TimeContracted = $"{contract.OrdDt}{contract.CtrctTime}".ToDateTimeMicro(),
					ExchangeCode = Exchange.KRX,
					Aggregation = contract.ExecQty * contract.ExecPrc,
					NumeralSystem = 10,
					Currency = Currency.KRW,
				});

				previousContract = contracts.Last();
			}

			return new ResponseResults<Contract> { List = contracts };
		}
		catch (Exception ex)
		{
			return new ResponseResults<Contract>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Contract>(),
			};
		}
	} 
	#endregion

	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();
	public Task<ResponseCore> RequestOrderableAsync(Order order) => throw new NotImplementedException();

	#region request Orders - t0434 / CFOAQ00600
	public async Task<ResponseResults<Order>> RequestOrdersAsync()
	{
		try
		{
			var response = await RequestStandardAsync<t0434>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				t0434InBlock = new t0434InBlock { }
			});

			if (response is null || !response.t0434OutBlock1.Any()) return new ResponseResults<Order>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response or t0434OutBlock1 is null",
				List = new List<Order>(),
			};

			List<Order> orders = new() { Capacity = response.t0434OutBlock1.Count };
			response.t0434OutBlock1.ForEach(f =>
			{
				orders.Add(new Order
				{
					DateBiz = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(9)),
					BrokerCo = "LS",
					OID = f.ordno,
					IdOrigin = f.orgordno,
					Mode = f.orgordno == 0 ? OrderMode.PLACE : f.medosu.Substring(2,2) switch
					{
						"정정" => OrderMode.UPDATE,
						"취소" => OrderMode.CANCEL,
						_ => OrderMode.PLACE
					},
					Symbol = f.expcode,
					IsLong = f.medosu.Contains("매수"),
					VolumeOrdered = f.qty,
					VolumeUpdatable = f.ordrem,
					PriceOrdered = f.price,
					Precision = !new string[] { "1", "A" }.Contains(f.expcode.Substring(0, 1)) ? 2 : f.expcode.Substring(1, 2) switch
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						_ => 0
					},
					TimeOrdered = $"{DateTime.UtcNow.AddHours(9).ToString("yyyyMMdd")}{f.ordtime.PadRight(9, '0')}".ToDateTimeMicro(),
				});
			});

			return new ResponseResults<Order> { List = orders };
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Order>(),
			};
		}
	}

	public async Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin)
	{
		try
		{
			List<CFOAQ00600OutBlock3> ordersRaw = new();
			var nextKey = string.Empty;
			do
			{
				var response = await RequestContinuousAsync<CFOAQ00600>(LsEndpoint.FuturesAccount.ToDescription(), new
				{
					CFOAQ00600InBlock1 = new CFOAQ00600InBlock1
					{
						QrySrtDt = dateBegun.ToString("yyyyMMdd"),
						QryEndDt = dateFin.ToString("yyyyMMdd"),
						PrdtExecTpCode = "0"
					}
				}, nextKey);

				if (response is null || !response.CFOAQ00600OutBlock3.Any())
				{
					nextKey = string.Empty;
					break;
				}

				ordersRaw.AddRange(response.CFOAQ00600OutBlock3);
				nextKey = response.NextKey;
			} while (!string.IsNullOrEmpty(nextKey));

			List<Order> orders = new() { Capacity = ordersRaw.Count };
			Order previousOrder = new();
			foreach (var order in ordersRaw)
			{
				if (order.OrdNo == 0) continue;

				orders.Add(new Order
				{
					DateBiz = order.OrdDt.ToDate(),
					BrokerCo = "LS",
					OID = order.OrdNo,
					IdOrigin = order.OrgOrdNo,
					Symbol = order.FnoIsuNo,
					InstrumentName = order.IsuNm,
					IsLong = order.BnsTpNm == "매수",
					Mode = order.OrdTpNm switch
					{
						"정정" => OrderMode.UPDATE,
						"취소" => OrderMode.CANCEL,
						_ => OrderMode.PLACE
					},
					VolumeOrdered = order.OrdQty,
					PriceOrdered = order.OrdPrc,
					TimeOrdered = $"{order.OrdDt}{order.OrdTime}".ToDateTimeMicro(),
				});
			}

			return new ResponseResults<Order>
			{
				List = orders,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Order>(),
			};
		}
	}
	#endregion

	#region request positions - CFOAQ50600
	public async Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		try
		{
			var response = await RequestStandardAsync<CFOAQ50600>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				CFOAQ50600InBlock1 = new CFOAQ50600InBlock1() 
			});

			if (response is null || !response.CFOAQ50600OutBlock3.Any()) return new ResponseResults<Position>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response or CFOAQ50600OutBlock3 is null",
				List = new List<Position>(),
			};

			List<Position> positions = new();
			response.CFOAQ50600OutBlock3.ForEach(f => positions.Add(new Position
			{
				Symbol = f.FnoIsuNo,
				InstrumentName = f.IsuNm,
				PriceEntry = f.FnoAvrPrc,
				Price = f.FnoNowPrc,
				Volume = f.UnsttQty,
			}));

			return new ResponseResults<Position> { List = positions };
		}
		catch (Exception ex)
		{
			return new ResponseResults<Position>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Position>()
			};
		}
	} 
	#endregion

	public Task<ResponseCore> SubscribeContractAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
}
