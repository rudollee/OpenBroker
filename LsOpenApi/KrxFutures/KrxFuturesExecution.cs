using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Execution>> Executed { get; set; }
	public required EventHandler<ResponseResult<Order>> OrderReceived { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	public Task<ResponseCore> PlaceOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseCore> CancelOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.TUS) => throw new NotImplementedException();

	#region request executions - CFOAQ00600
	public Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "")
	{
		var date = DateTime.Now;
		return RequestExecutionsAsync(date, date, status);
	}

	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, DateTime dateFin, ExecutionStatus status = ExecutionStatus.ExecutedOnly)
	{
		List<Execution> executions = [];
		try
		{
			List<CFOAQ00600OutBlock3> executionsRaw = [];
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

				executionsRaw.AddRange(response.CFOAQ00600OutBlock3);
				nextKey = response.NextKey;
			} while (!string.IsNullOrEmpty(nextKey));

			Execution previousExecution = new();
			executions.Capacity = executionsRaw.Count;
			foreach (var execution in executionsRaw)
			{
				if (execution.OrdNo == 0)
				{
					var executionFromPrevious = (Execution)previousExecution.Clone();
					executionFromPrevious.TimeExecuted = $"{executionFromPrevious.TimeExecuted.ToString("yyyyMMdd")}{execution.CtrctTime}".ToDateTimeM();
					executionFromPrevious.CID = execution.CtrctNo;
					executionFromPrevious.Volume = execution.ExecQty;
					executionFromPrevious.Price = execution.ExecPrc;

					executions.Add(executionFromPrevious);
					continue;
				}

				executions.Add(new Execution
				{ 
					DateBiz = execution.OrdDt.ToDate(),
					BrokerCo = "LS",
					OID = execution.OrdNo,
					IdOrigin = execution.OrgOrdNo,
					CID = execution.CtrctNo,
					Symbol = execution.FnoIsuNo,
					InstrumentName = execution.IsuNm,
					IsLong = execution.BnsTpNm == "매수",
					VolumeOrdered = execution.OrdQty,
					VolumeUpdatable = execution.UnercQty,
					VolumeLeft = execution.UnercQty,
					Volume = execution.ExecQty,
					PriceOrdered = execution.OrdPrc,
					Price = execution.ExecPrc,
					Precision = !new string[] { "1", "A" }.Contains(execution.FnoIsuNo.Substring(0, 1)) ? 2 : execution.FnoIsuNo.Substring(1, 2) switch 
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						_ => 0
					},
					TimeOrdered = $"{execution.OrdDt}{execution.OrdTime}".ToDateTimeM(),
					TimeExecuted = $"{execution.OrdDt}{execution.CtrctTime}".ToDateTimeM(),
					ExchangeCode = Exchange.KRX,
					Aggregation = execution.ExecQty * execution.ExecPrc,
					NumeralSystem = 10,
					Currency = Currency.KRW,
				});

				previousExecution = executions.Last();
			}

		}
		catch (Exception ex)
		{
			return new ResponseResults<Execution>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = [],
			};
		}

		if (dateBegun.Date != dateFin.Date) return new ResponseResults<Execution> { List = executions };

		try
		{

			var response = await RequestStandardAsync<CFOEQ82600>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				CFOEQ82600InBlock1 = new CFOEQ82600InBlock1
				{
					QrySrtDt = dateBegun.ToString("yyyyMMdd"),
					QryEndDt = dateFin.ToString("yyyyMMdd")
				}
			});

			if (response is null || response.CFOEQ82600OutBlock3.Count == 0) return new ResponseResults<Execution>
			{
				StatusCode = Status.PARTIALLY_SUCCESS,
				Message = response?.Message ?? "response or CFOEQ82600OutBlock3 is null",
				List = executions,
			};

			return new ResponseResults<Execution>
			{
				StatusCode = Status.SUCCESS,
				Message = response.Message,
				List = executions,
				ExtraData = new Dictionary<string, decimal>
				{
					{ "COMMISSION", response.CFOEQ82600OutBlock3.First().CmsnAmt },
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Execution>
			{
				StatusCode = Status.PARTIALLY_SUCCESS,
				Message = ex.Message,
				List = executions,
			};
		}
	}
	#endregion

	public Task<ResponseResults<Pnl>> RequestPnlAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();
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

			if (response.t0434OutBlock1.Count == 0) return ReturnResults<Order>([], nameof(t0434), response.Message);

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
					TimeOrdered = $"{DateTime.UtcNow.AddHours(9).ToString("yyyyMMdd")}{f.ordtime.PadRight(9, '0')}".ToDateTimeM(),
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

				if (response.CFOAQ00600OutBlock3.Count == 0)
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
					TimeOrdered = $"{order.OrdDt}{order.OrdTime}".ToDateTimeM(),
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
		List<Position> positions = new();
		try
		{
			var response = await RequestStandardAsync<CFOAQ50600>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				CFOAQ50600InBlock1 = new CFOAQ50600InBlock1() 
			});

			if (response is null) return new ResponseResults<Position>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response or CFOAQ50600OutBlock3 is null",
				List = positions,
			};

			positions.Capacity = response.CFOAQ50600OutBlock3.Count;

			response.CFOAQ50600OutBlock3.ForEach(f => positions.Add(new Position
			{
				Symbol = f.FnoIsuNo,
				InstrumentName = f.IsuNm,
				PriceEntry = f.FnoAvrPrc,
				Price = f.FnoNowPrc,
				Volume = f.UnsttQty,
			}));

			return new ResponseResults<Position> { List = positions, ExtraData = new Dictionary<string, decimal>
			{
				{ "COMMISSION", response.CFOAQ50600OutBlock2.CmsnAmt }
			}};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Position>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = positions,
			};
		}
	}
	#endregion

	public async Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true) => await SubscribeAsync("SYS", nameof(C01), "", connecting);

	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => await SubscribeAsync("SYS", nameof(O01), "", connecting);

	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
}
