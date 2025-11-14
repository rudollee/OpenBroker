using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using OpenBroker.Extensions;
using RestSharp;

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
			if (response is null) return ReturnError(typeof(T).Name, "response is null");

			return ReturnCore(response.Code, response.Message, MessageType.ORDER, response.OrderNo.ToString());
		}
		catch (Exception ex)
		{
			return ReturnError(typeof(T).Name, ex.Message);
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

			if (response.CSPAQ22200OutBlock2 is null)
			{
				return ReturnErrorResult<Balance>($"{nameof(CSPAQ22200)}.{response.Code}", response?.Message ?? "response is null");
			}

			return ReturnResult<Balance>(new Balance
			{
				BrokerCode = "LS",
				CurBased = Currency.KRW,
				AccountNumber = response.CSPAQ22200OutBlock1.AcntNo,
				DepositInit = Convert.ToDecimal(response.CSPAQ22200OutBlock2.Dps),
				DepositD1 = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D1Dps),
				DepositEst = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D2Dps),
				CashTradable = Convert.ToDecimal(response.CSPAQ22200OutBlock2.D2Dps),
				MarginInitial = Convert.ToDecimal(response.CSPAQ22200OutBlock2.MgnMny),
			}, $"{nameof(CSPAQ22200)}.{response.Code}");
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<Balance>(nameof(CSPAQ22200), ex.Message);
		}
	} 
	#endregion

	#region 체결/미체결 - t0425
	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "")
	{
		try
		{
			var response = await RequestStandardAsync<T0425>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0425InBlock = new T0425InBlock
				{
					Expcode = symbol,
					Chegb = status switch
					{
						ExecutionStatus.All => "0",
						ExecutionStatus.ExecutedOnly => "1",
						ExecutionStatus.UnexecutedOnly => "2",
						_ => "0"
					},
					Medosu = "0",
					Sortgb = "1",
					CtsOrdno = "",
				}
			});

			if (response.T0425OutBlock1.Count == 0) return ReturnResults<Execution>([], $"{nameof(T0425)}.{response.Code}", response.Message);

			var executions = new List<Execution>() { Capacity = response.T0425OutBlock1.Count };
			response.T0425OutBlock1.ForEach(execution =>
			{
				executions.Add(new Execution
				{
					BrokerCo = "LS",
					OID = execution.Ordno,
					CID = execution.Sysprocseq,
					Currency = Currency.KRW,
					DateBiz = DateTime.Now.ToKrxTradingDay(),
					ExchangeCode = Exchange.KRX,
					Symbol = execution.Expcode,
					TimeOrdered = execution.Ordtime.ToDateTimeM(),
					IdOrigin = execution.Orgordno,
					IsLong = execution.Orggb == "02",
					PriceOrdered = execution.Price,
					Price = execution.Cheprice,
					Volume = execution.Cheqty,
					VolumeLeft = execution.Ordrem,
					VolumeOrdered = execution.Qty,
					VolumeCancelable = execution.Ordrem,
					VolumeUpdatable = execution.Ordrem,
					VolumeOrderable = execution.Ordrem,
				});
			});

			return ReturnResults(executions, $"{nameof(T0425)}.{response.Code}");
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Execution>(nameof(T0425), ex.Message);
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
					OrdDt = dateBegun.ToDate8Txt(),
				}
			});

			if (response.CSPAQ13700OutBlock3.Count == 0) return ReturnResults<Execution>([], $"{nameof(CSPAQ13700)}.{response.Code}", response.Message);

			var executions = new List<Execution>() { Capacity = response.CSPAQ13700OutBlock3.Count };

			var date = DateTime.Now.ToKrxTradingDay();
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
					timeOrdered = (execution.OrdDt + execution.OrdTime).ToDateTimeM();
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
					TimeExecuted = (date.ToDate8Txt() + execution.ExecTrxTime).ToDateTimeM(),
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

			return ReturnResults(executions, $"{nameof(CSPAQ13700)}.{response.Code}");
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Execution>(nameof(CSPAQ13700), ex.Message);
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
				Broker = Brkr.LS,
				Remark = response.CSPBQ00200OutBlock2.OrdAbleQty.ToString(),
				Message = bep.ToString(),
				ExtraData = new Dictionary<string, decimal>
				{
					{ "MARGIN-RATE", response.CSPBQ00200OutBlock2.IsuMgnRat },
					{ "QTY", response.CSPBQ00200OutBlock2.OrdAbleQty },
					{ "BEP", bep }
				},
			};
		}
		catch (Exception ex)
		{
			return ReturnError(nameof(CSPBQ00200), ex.Message);
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
					OrdDt = dateBegun.ToDate8Txt(),
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
						TimeOrdered = (order.OrdDt + order.OrdTime).ToDateTimeM(),
						Symbol = order.IsuNo[1..],
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

			return ReturnResults(orders, $"{nameof(CSPAQ13700)}.{response.Code}");
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Order>(nameof(CSPAQ13700), ex.Message);
		}
	}
	#endregion

	#region 잔고 - t0424
	public async Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		var positions = new List<Position>();
		try
		{
			var response = await RequestStandardAsync<T0424>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0424InBlock = new T0424InBlock
				{
					Prcgb = "1",
					Chegb = "2",
					Dangb = "0",
					Charge = "1",
					CtsExpcode = ""
				}
			});

			positions.Capacity = response.T0424OutBlock1.Count;

			response.T0424OutBlock1.ForEach(position =>
			{
				positions.Add(new Position
				{
					Currency = Currency.KRW,
					Symbol = position.Expcode,
					InstrumentName = position.Hname,
					NumeralSystem = 10,
					Precision = 0,
					PriceEntry = position.Pamt,
					Price = position.Price,
					VolumeEntry = position.Janqty,
					Volume = position.Janqty,
					Tradable = true,
					Tax = position.Tax,
					Commission = position.Fee,
				});
			});

			return ReturnResults(positions, $"{nameof(T0424)}.{response.Code}", string.Empty, MessageType.SYS, response.T0424OutBlock.Dtsunik.ToString());
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Position>(nameof(T0424), ex.Message);
		}
	}
	#endregion

	#region 일간 거래내역 집계 - t0150/t0151
	public async Task<ResponseResults<Execution>> RequestExecutionAgg(DateOnly date)
	{
		try
		{
			if (date == DateTime.Now.ToKrxTradingDay()) return await RequestExecutionAggToday();

			var response = await RequestStandardAsync<T0151>(LsEndpoint.EquityAccount.ToDescription(), new
			{
				t0151InBlock = new T0151InBlock { Date = date.ToDate8Txt() }
			});

			if (response is null) return ReturnErrorResults<Execution>(nameof(T0151), "response is null");
			if (response.T0151OutBlock1.Count == 0) return ReturnResults<Execution>([], $"{nameof(T0151)}.{response.Code}", "no execution");

			return GenerateExecutions(date, response.T0151OutBlock1);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Execution>(nameof(T0151), ex.Message);
		}
	}

	private async Task<ResponseResults<Execution>> RequestExecutionAggToday()
	{
		var response = await RequestStandardAsync<T0150>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			t0150InBlock = new T0150InBlock { }
		});

		if (response is null) return ReturnErrorResults<Execution>(nameof(T0150), "response is null");
		if (response.T0150OutBlock1.Count == 0) return ReturnResults<Execution>([], $"{nameof(T0150)}.{response.Code}", response.Message);

		return GenerateExecutions(DateTime.Now.ToKrxTradingDay(), response.T0150OutBlock1);
	}
	
	private ResponseResults<Execution> GenerateExecutions(DateOnly date, List<T0150OutBlock1> outblock)
	{
		List<Execution> executions = [];
		var symbol = string.Empty;
		var isLong = true;
		var channel = OrderChannel.API;
		foreach (var execution in outblock)
		{
			if (execution.Medosu == "종목소계")
			{
				executions.Add(new Execution
				{
					DateBiz = date,
					Symbol = symbol,
					InstrumentName = Equities[symbol].NameOfficial,
					Channel = channel,
					IsLong = isLong,
					Commission = execution.Fee,
					Tax = execution.Tax + execution.Argtax,
				});
			}
			else
			{
				symbol = execution.Expcode;
				isLong = execution.Medosu == "매수";
				channel = execution.Middiv switch
				{
					"OPEN API" => OrderChannel.API,
					"투혼(HTS)" => OrderChannel.HTS,
					"투혼(MTS)" => OrderChannel.MTS,
					var m => m.Contains("MTS") ? OrderChannel.MTS : OrderChannel.ETC
				};
			}
		}

		return ReturnResults(executions, nameof(T0150));
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

		return ReturnCore("ORDER");
	}
}
