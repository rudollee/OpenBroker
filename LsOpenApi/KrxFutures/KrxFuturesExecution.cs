using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Execution>> Executed { get; set; }
	public required EventHandler<ResponseResult<Execution>> OrderReceived { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	public Task<ResponseCore> PlaceOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseCore> CancelOrderAsync(OrderCore order) => throw new NotImplementedException();
	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.TUS) => throw new NotImplementedException();

	#region request executions - T0434 / CFOAQ00600
	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "")
	{
		try
		{
			var response = await RequestStandardAsync<T0434>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				t0434InBlock = new T0434InBlock
				{
					Chegb = status switch
					{
						ExecutionStatus.All => "0",
						ExecutionStatus.ExecutedOnly => "1",
						ExecutionStatus.UnexecutedOnly => "2",
						_ => "0"
					}
				}
			});

			if (response.T0434OutBlock1.Count == 0) return ReturnResults<Execution>([], nameof(T0434), response.Message);

			List<Execution> executions = new() { Capacity = response.T0434OutBlock1.Count };
			response.T0434OutBlock1.ForEach(f =>
			{
				executions.Add(new Execution
				{
					DateBiz = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(9)),
					Broker = Brkr.LS,
					OID = f.OrdNo,
					IdOrigin = f.OrgOrdNo,
					Mode = f.OrgOrdNo == 0 ? OrderMode.PLACE : f.Medosu.Substring(2, 2) switch
					{
						"정정" => OrderMode.UPDATE,
						"취소" => OrderMode.CANCEL,
						_ => OrderMode.PLACE
					},
					OrderType = f.Hogatype switch
					{
						"L" => OrderType.LIMIT,
						_ => OrderType.MARKET,
					},
					Symbol = f.Expcode,
					IsLong = f.Medosu.Contains("매수"),
					QtyOrdered = f.Qty,
					QtyExecuted = f.Cheqty,
					QtyUpdatable = f.Ordrem,
					QtyOrderable = f.Ordrem,
					QtyCancelable = f.Ordrem,
					PriceOrdered = f.Price,
					Precision = f.Expcode.ToKrxInstrumentTypeCode() != InstrumentType.Futures ? 2 : f.Expcode.Substring(1, 2) switch
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						"75" => 2,
						_ => 0
					},
					TimeOrdered = $"{DateTime.UtcNow.AddHours(9):yyyyMMdd}{f.OrdTime.PadRight(9, '0')}".ToDateTimeM(),
					Channel = OrderChannel.API,
					Currency = Currency.KRW,

				});
			});

			return ReturnResults(executions);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Execution>(nameof(T0434), ex.Message, statusCode: Status.INTERNALSERVERERROR);
		}
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
						QrySrtDt = $"{dateBegun:yyyyMMdd}",
						QryEndDt = $"{dateFin:yyyyMMdd}",
						PrdtExecTpCode = status switch
						{
							ExecutionStatus.All => "0",
							ExecutionStatus.ExecutedOnly => "1",
							ExecutionStatus.UnexecutedOnly => "2",
							_ => "0"
						}
					}
				}, nextKey);

				if (response is null || response.CFOAQ00600OutBlock3.Count == 0)
				{
					nextKey = string.Empty;
					break;
				}

				executionsRaw.AddRange(response.CFOAQ00600OutBlock3);
				nextKey = response.NextKey;
			} while (!string.IsNullOrEmpty(nextKey));

			if (executionsRaw.Count == 0)
			{
				var periodTxt = dateBegun == dateFin ? $"on {dateBegun:yyyy-MM-dd}" : $"between {dateBegun:yyyy-MM-dd} and {dateFin:yyyy-MM-dd}";
				return ReturnErrorResults<Execution>(nameof(CFOAQ00600), $"No trading data found {periodTxt}", "", Status.NODATA);
			}

			Execution previousExecution = new();
			executions.Capacity = executionsRaw.Count;
			foreach (var execution in executionsRaw)
			{
				if (execution.OrdNo == 0)
				{
					var executionFromPrevious = (Execution)previousExecution.Clone();
					executionFromPrevious.TimeExecuted = $"{executionFromPrevious.TimeExecuted:yyyyMMdd}{execution.CtrctTime}".ToDateTimeM();
					executionFromPrevious.EID = execution.CtrctNo;
					executionFromPrevious.Qty = execution.ExecQty;
					executionFromPrevious.Price = execution.ExecPrc;

					executions.Add(executionFromPrevious);
					continue;
				}

				executions.Add(new Execution
				{ 
					DateBiz = execution.OrdDt.ToDate(),
                    Broker = Brkr.LS,
                    OID = execution.OrdNo,
					IdOrigin = execution.OrgOrdNo,
					EID = execution.CtrctNo,
					Symbol = execution.FnoIsuNo,
					InstrumentName = execution.IsuNm,
					IsLong = execution.BnsTpNm == "매수",
					Mode = execution.MrcTpNm switch
					{
						"정정" => OrderMode.UPDATE,
						"취소" => OrderMode.CANCEL,
						_ => OrderMode.PLACE
					},
					OrderType = execution.FnoOrdprcPtnCode switch
					{
						"00" => OrderType.LIMIT,
						"03" => OrderType.MARKET,
						_ => OrderType.LIMIT
					},
					QtyOrdered = execution.OrdQty,
					QtyExecuted = execution.ExecQty,
					QtyUpdatable = execution.UnercQty,
					QtyLeft = execution.UnercQty,
					Qty = execution.ExecQty,
					PriceOrdered = execution.OrdPrc,
					Price = execution.ExecPrc,
					Precision = execution.FnoIsuNo.ToKrxInstrumentTypeCode() != InstrumentType.Futures ? 2 : execution.FnoIsuNo.Substring(1, 2) switch 
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						"75" => 2,
						_ => 0
					},
					TimeOrdered = $"{execution.OrdDt}{execution.OrdTime}".ToDateTimeM(),
					TimeExecuted = $"{execution.OrdDt}{execution.CtrctTime}".ToDateTimeM(),
					ExchangeCode = Exchange.KRX,
					Aggregation = execution.ExecQty * execution.ExecPrc * execution.FnoIsuNo.ToKrxMultiple(),
					NumeralSystem = 10,
					Currency = Currency.KRW,
				});

				previousExecution = executions.Last();
			}

		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Execution>(nameof(CFOAQ00600), ex.Message);
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

			if (response is null || response.CFOEQ82600OutBlock2 is null)
			{
				return ReturnErrorResults<Execution>(nameof(CFOEQ82600), "response or CFOEQ82600OutBlock2 is null");
			}

			var results = ReturnResults(executions);
			results.ExtraData = new Dictionary<string, decimal>
			{
				{ "COMMISSION", response.CFOEQ82600OutBlock2.FnoCmsnAmt },
			};

			return results;
		}
		catch (Exception ex)
		{
			return new()
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
	public async Task<ResponseResults<Order>> RequestOrdersAsync(ExecutionStatus executionStatus = ExecutionStatus.All)
	{
		try
		{
			var response = await RequestStandardAsync<T0434>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				t0434InBlock = new T0434InBlock 
				{ 
					Chegb = executionStatus switch
					{
						ExecutionStatus.All => "0",
						ExecutionStatus.ExecutedOnly => "1",
						ExecutionStatus.UnexecutedOnly => "2",
						_ => "0"
					}
				}
			});

			if (response.T0434OutBlock1.Count == 0) return ReturnResults<Order>([], nameof(T0434), response.Message);

			List<Order> orders = new() { Capacity = response.T0434OutBlock1.Count };
			response.T0434OutBlock1.ForEach(f =>
			{
				orders.Add(new Order
				{
					DateBiz = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(9)),
                    Broker = Brkr.LS,
                    OID = f.OrdNo,
					IdOrigin = f.OrgOrdNo,
					Mode = f.OrgOrdNo == 0 ? OrderMode.PLACE : f.Medosu.Substring(2,2) switch
					{
						"정정" => OrderMode.UPDATE,
						"취소" => OrderMode.CANCEL,
						_ => OrderMode.PLACE
					},
					Symbol = f.Expcode,
					IsLong = f.Medosu.Contains("매수"),
					QtyOrdered = f.Qty,
					QtyExecuted = f.Cheqty,
					QtyUpdatable = f.Ordrem,
					QtyOrderable = f.Ordrem,
					QtyCancelable = f.Ordrem,
					PriceOrdered = f.Price,
					Precision = f.Expcode.ToKrxInstrumentTypeCode() != InstrumentType.Futures ? 2 : f.Expcode.Substring(1, 2) switch
					{
						"01" => 2,
						"05" => 2,
						"07" => 2,
						"75" => 2,
						_ => 0
					},
					TimeOrdered = $"{DateTime.UtcNow.AddHours(9):yyyyMMdd}{f.OrdTime.PadRight(9, '0')}".ToDateTimeM(),
					Channel = OrderChannel.API,
					Currency = Currency.KRW,
					
				});
			});

			return new ResponseResults<Order> { List = orders };
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Order>(nameof(T0434), ex.Message, statusCode: Status.INTERNALSERVERERROR);
		}
	}

	public async Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin)
	{
		try
		{
			List<CFOAQ00600OutBlock3> ordersRaw = [];
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
					Broker = Brkr.LS,
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
					QtyOrdered = order.OrdQty,
					PriceOrdered = order.OrdPrc,
					TimeOrdered = $"{order.OrdDt}{order.OrdTime}".ToDateTimeM(),
				});
			}

			return ReturnResults(orders);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Order>(nameof(CFOAQ00600), ex.Message, statusCode: Status.INTERNALSERVERERROR);
		}
	}
	#endregion

	#region request positions - t0441
	public async Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		List<Position> positions = [];
		try
		{
			var response = await RequestStandardAsync<T0441>(LsEndpoint.FuturesAccount.ToDescription(), new
			{
				t0441InBlock = new T0441InBlock() 
			});

			if (response is null) return ReturnErrorResults<Position>(message: "t0441 or t0441OutBlock1 is null");

			positions.Capacity = response.T0441OutBlock1.Count;
			response.T0441OutBlock1.ForEach(f => positions.Add(new Position
			{
				Symbol = f.Expcode,
				IsLong = f.Medocd == "2",
				PriceEntry = f.Pamt,
				Price = f.Price,
				Qty = f.Jqty,
			}));

			Dictionary<string, decimal> extraData = new()
			{
                { "REALIZED-PNL", response.T0441OutBlock.Tdtsunik },
				{ "PNL", response.T0441OutBlock.Tsunik }
            };

			return ReturnResults(positions, typ: MessageType.POSITION, extraData: extraData);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Position>(nameof(T0441), ex.Message, string.Empty, Status.INTERNALSERVERERROR);
		}
	}
	#endregion

	public async Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true) => await SubscribeAsync("SYS", nameof(C01), "", connecting);

	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) => await SubscribeAsync("SYS", nameof(O01), "", connecting);

	public Task<ResponseCore> UpdateOrderAsync(OrderCore order) => throw new NotImplementedException();
}
