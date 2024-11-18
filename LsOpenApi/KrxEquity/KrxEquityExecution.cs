using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using OpenBroker.Extensions;
using RestSharp;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Contract>> Contracted { get; set; }
	public required EventHandler<ResponseResult<Order>> Executed { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	#region 주문/정정/취소 - CSPAT00601/CSPAT00701/CSPAT00801
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
		var response = await RequestStandardAsync<CSPAQ22200>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			CSPAQ22200InBlock1 = new CSPAQ22200InBlock1
			{
				BalCreTp = "0"
			}
		});

		try
		{
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
	public async Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ContractedOnly, string symbol = "")
	{
		var response = await RequestStandardAsync<t0425>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			t0425InBlock = new t0425InBlock
			{
				expcode = symbol,
				chegb = status switch
				{
					ContractStatus.All => "0",
					ContractStatus.ContractedOnly => "1",
					ContractStatus.UncontractedOnly => "2",
					_ => "0"
				},
				medosu = "0",
				sortgb = "1",
				cts_ordno = "",
			}
		});

		var contracts = new List<Contract>() { Capacity = response.t0425OutBlock1.Count };
		try
		{
			response.t0425OutBlock1.ForEach(contract =>
			{
				contracts.Add(new Contract
				{
					BrokerCo = "LS",
					OID = contract.ordno,
					CID = contract.sysprocseq,
					Currency = Currency.KRW,
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					ExchangeCode = Exchange.KRX,
					Symbol = contract.expcode,
					TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + contract.ordtime).ToDateTime(),
					IdOrigin = contract.orgordno,
					IsLong = contract.orggb == "02",
					PriceOrdered = contract.price,
					Price = contract.cheprice,
					Volume = contract.cheqty,
					VolumeLeft = contract.ordrem,
					VolumeOrdered = contract.qty,
					VolumeCancelable = contract.ordrem,
					VolumeUpdatable = contract.ordrem,
					VolumeOrderable = contract.ordrem,
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
	#endregion

	#region 체결/미체결 기간 - CSPAQ13700
	public async Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ContractedOnly)
	{
		var response = await RequestStandardAsync<CSPAQ13700>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			CSPAQ13700InBlock1 = new CSPAQ13700InBlock1
			{
				OrdMktCode = "00",
				BnsTpCode = "0",
				IsuNo = string.Empty,
				ExecYn = status switch
				{
					ContractStatus.All => "0",
					ContractStatus.ContractedOnly => "1",
					ContractStatus.UncontractedOnly => "3",
					_ => "0"
				},
				OrdDt = dateBegun.ToString("yyyyMMdd"),
				SrtOrdNo2 = 0,
				BkseqTpCode = "1",
				OrdPtnCode = "00"
			}
		});

		var executions = new List<Contract>() { Capacity = response.CSPAQ13700OutBlock3.Count };

		try
		{
			response.CSPAQ13700OutBlock3.ForEach(execution =>
			{
				executions.Add(new Contract
				{
					BrokerCo = "LS",
					DateBiz = execution.OrdDt.ToDate(),
					TimeContracted = (DateTime.Now.ToString("yyyyMMdd") + execution.ExecTrxTime).ToDateTimeMicro(),
					Currency = Currency.KRW,
					Precision = 0,
					NumeralSystem = 10,
					Symbol = execution.IsuNo,
					InstrumentName = execution.IsuNm,
					OID = execution.OrdNo,
					IdOrigin = execution.OrgOrdNo,
					CID = execution.OrdNo,
					IsLong = execution.BnsTpCode == "2",
					Mode = execution.MrcTpCode switch
					{
						"0" => OrderMode.PLACE,
						"1" => OrderMode.UPDATE,
						"2" => OrderMode.CANCEL,
						_ => OrderMode.NONE,
					},
					PriceOrdered = execution.OrdPrc,
					VolumeOrdered = execution.OrdQty,
					Price = execution.ExecPrc,
					Volume = execution.ExecQty,
					Aggregation = execution.OrdPrc * execution.OrdQty,
					Section = execution.OrdMktCode == "10" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ
				});
			});

			return new ResponseResults<Contract>
			{
				List = executions
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Contract>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "catch area",
				List = new List<Contract>()
			};
		}
	} 
	#endregion

	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();

	#region 주문가능금액 - CSPBQ00200 / CSPAQ12300
	public async Task<ResponseCore> RequestOrderableAsync(Order order)
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

		try
		{
			return new ResponseCore
			{
				Code = response.CSPBQ00200OutBlock2.IsuMgnRat.ToString(),
				Remark = response.CSPBQ00200OutBlock2.OrdAbleQty.ToString(),
				Message = bep.ToString()
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
		var response = await RequestStandardAsync<CSPAQ13700>(LsEndpoint.EquityAccount.ToDescription(), new
		{
			CSPAQ13700InBlock1 = new CSPAQ13700InBlock1
			{
				OrdMktCode = "00",
				BnsTpCode = "0",
				IsuNo = string.Empty,
				ExecYn = "0",
				OrdDt = dateBegun.ToString("yyyyMMdd"),
				SrtOrdNo2 = 0,
				BkseqTpCode = "1",
				OrdPtnCode = "00"
			}
		});

		var orders = new List<Order>() { Capacity = response.CSPAQ13700OutBlock3.Count };
		try
		{
			response.CSPAQ13700OutBlock3.ForEach(order =>
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

		var positions = new List<Position>() { Capacity = response.t0424OutBlock1.Count };

		try
		{
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
					Fee = position.fee,
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

	public async Task<ResponseCore> SubscribeContractAsync(bool connecting = true) => await SubscribeAsync("SYS", "SC1", "", connecting);

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
