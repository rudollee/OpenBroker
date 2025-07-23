using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using OpenBroker.Extensions;
using RestSharp;
using System;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IExecution, IExecutionKrxEquity
{
	public required EventHandler<ResponseResult<Execution>> Executed { get; set; }
	public required EventHandler<ResponseResult<Order>> OrderReceived { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	#region 주문/정정/취소 - CSPAT00601/CSPAT00701/CSPAT00801
	public async Task<ResponseCore> PlaceOrderAsync(OrderCore order) =>
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
					OrderType.MID => "12",
					_ => "03"
				},
				MbrNo = order.ExchangeCode switch
				{
					Exchange.NXT => "NXT",
					_ => "KRX"
				}
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
					OrderType.MID => "12",
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

	private async Task<ResponseCore> RequestOrderAsync<T>(object parameters) where T : LsOrderResponseStandard
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

	#region 예수금 - CSPAQ22200
	public async Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.NONE)
	{
		try
		{
			var response = await RequestStandardAsync<CSPAQ22200>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				CSPAQ22200InBlock1 = new CSPAQ22200InBlock1
				{
					BalCreTp = "0"
				}
			});

			if (response is null || response.CSPAQ22200OutBlock2 is null) return new ResponseResult<Balance>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response or CSPAQ22200OutBlock2 is null"
			};

			return new ResponseResult<Balance>
			{
				Info = new Balance
				{
					BrokerCode = "LS",
					CurBased = Currency.KRW,
					AccountNumber = response.CSPAQ22200OutBlock1.AcntNo,
					DepositInit = Convert.ToDecimal(response.CSPAQ22200OutBlock2.Dps),
					DepositD1 = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D1Dps),
					DepositEst = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D2Dps),
					CashTradable = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D2Dps),
					MarginInitial = Convert.ToDecimal(response.CSPAQ22200OutBlock2.MgnMny),
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<Balance>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				Remark = "catch"
			};
		}
	} 
	#endregion

	#region 체결/미체결 - t0425
	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "")
	{
		try
		{
			var response = await RequestStandardAsync<t0425>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0425InBlock = new t0425InBlock
				{
					expcode = symbol,
					chegb = status switch
					{
						ExecutionStatus.All => "0",
						ExecutionStatus.ExecutedOnly => "1",
						ExecutionStatus.UnexecutedOnly => "2",
						_ => "0"
					},
					medosu = "0",
					sortgb = "1",
					cts_ordno = "",
				}
			});

			var executions = new List<Execution>() { Capacity = response.t0425OutBlock1.Count };
			response.t0425OutBlock1.ForEach(execution =>
			{
				executions.Add(new Execution
				{
					BrokerCo = "LS",
					OID = execution.ordno,
					CID = execution.sysprocseq,
					Currency = Currency.KRW,
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					ExchangeCode = Exchange.KRX,
					Symbol = execution.expcode,
					TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + execution.ordtime).ToDateTime(),
					IdOrigin = execution.orgordno,
					IsLong = execution.orggb == "02",
					PriceOrdered = execution.price,
					Price = execution.cheprice,
					Volume = execution.cheqty,
					VolumeLeft = execution.ordrem,
					VolumeOrdered = execution.qty,
					VolumeCancelable = execution.ordrem,
					VolumeUpdatable = execution.ordrem,
					VolumeOrderable = execution.ordrem,
				});
			});

			return new ResponseResults<Execution>
			{
				List = executions,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Execution>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Execution>()
			};
		}
	}
	#endregion

	#region 체결/미체결 기간 - CSPAQ13700
	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, DateTime dateFin, ExecutionStatus status = ExecutionStatus.ExecutedOnly)
	{
		try
		{
			var response = await RequestStandardAsync<CSPAQ13700>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				CSPAQ13700InBlock1 = new CSPAQ13700InBlock1
				{
					ExecYn = status switch
					{
						ExecutionStatus.All => "0",
						ExecutionStatus.ExecutedOnly => "1",
						ExecutionStatus.UnexecutedOnly => "3",
						_ => "0"
					},
					OrdDt = dateBegun.ToString("yyyyMMdd"),
				}
			});

			var executions = new List<Execution>() { Capacity = response.CSPAQ13700OutBlock3.Count };

			var date = DateOnly.FromDateTime(DateTime.Now);
			var symbol = string.Empty;
			var instrumentName = string.Empty;
			long oid = 0;
			long idOrigin = 0;
			var seq = 1;
			decimal qtyOrdered = 0;
			decimal priceOrdered = 0;
			DateTime timeOrdered = DateTime.Now;
			ExchangeSection section = ExchangeSection.NONE;
			response.CSPAQ13700OutBlock3.ForEach(execution =>
			{
				if (!string.IsNullOrEmpty(execution.OrdDt))
				{
					date = execution.OrdDt.ToDate();
					symbol = execution.IsuNo;
					instrumentName = execution.IsuNm;
					oid = execution.OrdNo;
					idOrigin = execution.OrgOrdNo;
					seq = 1;
					qtyOrdered = execution.OrdQty;
					priceOrdered = execution.OrdPrc;
					timeOrdered = (execution.OrdDt + execution.OrdTime).ToDateTimeMicro();
					section = execution.OrdMktCode == "10" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ;
				}
				else
				{
					seq++;
				}
				
				executions.Add(new Execution
				{
					BrokerCo = "LS",
					DateBiz = date,
					TimeOrdered = timeOrdered,
					TimeExecuted = (date.ToString("yyyyMMdd") + execution.ExecTrxTime).ToDateTimeMicro(),
					Currency = Currency.KRW,
					Precision = 0,
					NumeralSystem = 10,
					Symbol = symbol,
					InstrumentName = instrumentName,
					OID = oid,
					IdOrigin = idOrigin,
					CID = seq,
					IsLong = execution.BnsTpCode == "2",
					Mode = execution.MrcTpCode switch
					{
						"0" => OrderMode.PLACE,
						"1" => OrderMode.UPDATE,
						"2" => OrderMode.CANCEL,
						_ => OrderMode.NONE,
					},
					PriceOrdered = priceOrdered,
					VolumeOrdered = qtyOrdered,
					Price = execution.ExecPrc,
					Volume = execution.ExecQty,
					Aggregation = execution.OrdPrc * execution.OrdQty,
					Section = section
				});
			});

			return new ResponseResults<Execution>
			{
				List = executions
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Execution>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "catch area",
				List = new List<Execution>()
			};
		}
	} 
	#endregion

	public Task<ResponseResults<Pnl>> RequestPnlAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();

	#region 주문가능금액 - CSPBQ00200 / CSPAQ12300
	public async Task<ResponseCore> RequestOrderableAsync(Order order)
	{
		try
		{
			var response = await RequestStandardAsync<CSPBQ00200>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				CSPBQ00200InBlock1 = new CSPBQ00200InBlock1
				{
					BnsTpCode = order.IsLong ? "2" : "1",
					IsuNo = $"A{order.Symbol}",
					OrdPrc = order.PriceOrdered
				}
			});

			decimal bep = 0.00m;

			if (!order.IsLong && response.CSPBQ00200OutBlock2.OrdAbleQty > 0)
			{
				var responseBep = await RequestStandardAsync<CSPAQ12300>(LsEndpoint.EquityAccount.ToDescription(), new
				{
					CSPAQ12300InBlock1 = new CSPAQ12300InBlock1
					{
						BalCreTp = "1",
						CmsnAppTpCode = "0",
						D2balBaseQryTp = "1",
						UprcTpCode = "1"
					}
				});

				var position = responseBep.CSPAQ12300OutBlock3.FirstOrDefault(f => f.IsuNo == $"A{order.Symbol}");
				if (position is not null)
				{
					bep = position.AvrUprc;
				}
			}

			return new ResponseCore
			{
				Code = response.CSPBQ00200OutBlock2.IsuMgnRat.ToString(),
				Remark = response.CSPBQ00200OutBlock2.OrdAbleQty.ToString(),
				Message = bep.ToString(),
				ExtraData = new Dictionary<string, decimal>
				{
					{ "BEP", bep }
				},
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "catch area"
			};
		}
	} 
	#endregion

	#region 주문 내역 - CSPAQ13700
	public async Task<ResponseResults<Order>> RequestOrdersAsync() =>
		await RequestOrdersAsync(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now));

	public async Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin)
	{
		try
		{
			var response = await RequestStandardAsync<CSPAQ13700>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				CSPAQ13700InBlock1 = new CSPAQ13700InBlock1
				{
					ExecYn = "0",
					OrdDt = dateBegun.ToString("yyyyMMdd"),
				}
			});

			var orders = new List<Order>() { Capacity = response.CSPAQ13700OutBlock3.Count };

			response.CSPAQ13700OutBlock3.ForEach(order =>
			{
				if (!string.IsNullOrEmpty(order.OrdDt))
				{
					orders.Add(new Order
					{
						BrokerCo = "LS",
						DateBiz = order.OrdDt.ToDate(),
						TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + order.OrdTime).ToDateTimeMicro(),
						Symbol = order.IsuNo.Substring(1),
						InstrumentName = order.IsuNm,
						OID = order.OrdNo,
						IdOrigin = order.OrgOrdNo,
						Currency = Currency.KRW,
						NumeralSystem = 10,
						Precision = 0,
						IsLong = order.BnsTpCode.Equals("2"),
						Mode = order.MrcTpCode switch
						{
							"0" => OrderMode.PLACE,
							"1" => OrderMode.UPDATE,
							"2" => OrderMode.CANCEL,
							_ => OrderMode.NONE,
						},
						PriceOrdered = order.OrdPrc,
						VolumeOrdered = order.OrdQty,
						Aggregation = order.OrdPrc * order.OrdQty,
						Section = order.OrdMktCode == "10" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ
					}); 
				}
			});

			return new ResponseResults<Order>
			{
				List = orders,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Order>(),
				Remark = "catch area"
			};
			throw;
		}
	}
	#endregion

	#region 잔고 - t0424
	public async Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		var positions = new List<Position>();
		try
		{
			var response = await RequestStandardAsync<t0424>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0424InBlock = new t0424InBlock
				{
					prcgb = "1",
					chegb = "2",
					dangb = "0",
					charge = "1",
					cts_expcode = ""
				}
			});

			positions.Capacity = response.t0424OutBlock1.Count;

			response.t0424OutBlock1.ForEach(position =>
			{
				positions.Add(new Position
				{
					Currency = Currency.KRW,
					Symbol = position.expcode,
					InstrumentName = position.hname,
					NumeralSystem = 10,
					Precision = 0,
					PriceEntry = position.pamt,
					Price = position.price,
					VolumeEntry = position.janqty,
					Volume = position.janqty,
					Tradable = true,
					Tax = position.tax,
					Commission = position.fee,
				});
			});

			return new ResponseResults<Position>
			{
				List = positions,
				Remark = response.t0424OutBlock.dtsunik.ToString()
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Position>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = "ERROR - T0424",
				Message = ex.Message,
				List = positions,
			};
		}
	}
	#endregion

	#region 일간 거래내역 집계 - t0150/t0151
	public async Task<ResponseResults<Position>> RequestExecutionAgg(DateOnly date)
	{
		try
		{
			if (date == DateOnly.FromDateTime(DateTime.Now)) return await RequestExecutionAggToday();

			var response = await RequestStandardAsync<t0151>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0151InBlock = new t0151InBlock { date = date.ToString("yyyyMMdd") }
			});

			if (response is null) return new ResponseResults<Position>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = $"{nameof(t0151)} is null",
				List = []
			};

			if (!response.t0151OutBlock1.Any()) return new ResponseResults<Position>
			{
				Message = $"no executed",
				List = []
			};

			return GeneratePositions(date, response.t0151OutBlock1);
		}
		catch (Exception ex)
		{
			return new ResponseResults<Position>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = []
			};
		}
	}

	private async Task<ResponseResults<Position>> RequestExecutionAggToday()
	{
		var response = await RequestStandardAsync<t0150>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			t0150InBlock = new t0150InBlock { }
		});

		if (response is null) return new ResponseResults<Position>
		{
			StatusCode = Status.ERROR_OPEN_API,
			Message = $"{nameof(t0150)} is null",
			List = []
		};

		if (!response.t0150OutBlock1.Any()) return new ResponseResults<Position>
		{
			Message = $"no executed",
			List = []
		};

		return GeneratePositions(DateOnly.FromDateTime(DateTime.Now), response.t0150OutBlock1);
	}
	
	private ResponseResults<Position> GeneratePositions(DateOnly date, List<t0150OutBlock1> outblock)
	{
		List<Position> positions = [];
		var symbol = string.Empty;
		var isLong = true;
		foreach (var execution in outblock)
		{
			if (execution.medosu == "종목소계")
			{
				positions.Add(new Position
				{
					DateEntry = date.ToString("yyyyMMdd").ToDateTime(),
					Symbol = symbol,
					InstrumentName = Equities[symbol].NameOfficial,
					IsLong = isLong,
					Commission = execution.fee,
					Tax = execution.tax + execution.argtax,
				});
			}
			else
			{
				symbol = execution.expcode;
				isLong = execution.medosu == "매수";
			}
		}

		return new ResponseResults<Position>
		{
			List = positions
		};
	}
	#endregion

	public async Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true) => await SubscribeAsync("SYS", "SC1", "", connecting);

	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true)
	{
		foreach (var trCode in new string[] { "SC0", "SC2", "SC3", "SC4" })
		{
			var response = await SubscribeAsync("SYS", trCode, "", connecting) ?? new ResponseCore
			{
				Code = trCode,
				StatusCode = Status.ERROR_OPEN_API,
			};

			if (response.StatusCode != Status.SUCCESS) return response;
		}

		return new ResponseCore
		{
			StatusCode = Status.SUCCESS,
		};
	}

	
}
