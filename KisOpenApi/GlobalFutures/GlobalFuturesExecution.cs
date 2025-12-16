using KisOpenApi.Models;
using KisOpenApi.Models.GlobalFutures;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Execution>> Executed { get; set; }
	public required EventHandler<ResponseResult<Execution>> OrderReceived { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	#region 해외선물 주문가능조회 - OTFM3304R
	public async Task<ResponseCore> RequestOrderableAsync(Order order)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseCore
		{
			Code = "ANUMBER",
			Message = "no accountNumber",
		};

		var parameters = GenerateParameters(new
		{
			OVRS_FUTR_FX_PDNO = order.Symbol,
			SLL_BUY_DVSN_CD = order.IsLong ? "02" : "01",
			FM_ORD_PRIC = "N",
			ECIS_RSVN_ORD_YN = "N"
		}, true);

		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-psamount");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM3116R)));

		foreach (var parameter in parameters)
		{
			request.AddQueryParameter(parameter.Key, parameter.Value?.ToString());
		}

		try
		{
			var response = await client.GetAsync<OTFM3304R>(request);
			if (response is null || response.Output is null) return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = "response is null",
			};

			return new ResponseCore
			{
				Message = $"{response.Output.fm_new_ord_psbl_qty}",
				Remark = response.Output.Symbol
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}",
			};
		}
	}
	#endregion

	#region 해외선물 주문/정정/취소 - OTFM3001U/OTFM3002U/OTFM3003U
	public async Task<ResponseCore> PlaceOrderAsync(OrderCore order)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseCore
		{
			Code = "ANUMBER",
			Message = "no account number",
		};

		if (order.OrderType == OrderType.AUTO)
		{
			order.OrderType = order.PriceOrdered > 0 ? OrderType.LIMIT : OrderType.MARKET;
		}

		if (order.OrderDuration == OrderDuration.AUTO)
		{
			order.OrderDuration = order.PriceOrdered > 0 ? OrderDuration.LIMIT : OrderDuration.STOP;
		}

		var needsStop = new OrderType[] { OrderType.STOP, OrderType.STOPLIMIT }.Contains(order.OrderType);

		var parameters = GenerateParameters(new
		{
			OVRS_FUTR_FX_PDNO = order.Symbol, // 해외선물FX상품번호
			SLL_BUY_DVSN_CD = order.IsLong ? "02" : "01", // 매도매수구분코드: 01.매도; 02.매수
			PRIC_DVSN_CD = ((int)order.OrderType).ToString(),  // 가격구분코드: 1.지정, 2.시장, 3.STOP, 4S/L
			FM_LIMIT_ORD_PRIC = order.OrderType == OrderType.LIMIT ? order.PriceOrdered.ToString() : "",  // FMLIMIT주문가격: 지정가가 아닐 경우 빈칸
			FM_STOP_ORD_PRIC = needsStop ? order.PriceOrdered.ToString() : "",  // FMSTOP주문가격: 시장가, 지정가인 경우, 빈칸("") 입력
			FM_ORD_QTY = $"{order.QtyOrdered}", // FM주문수량
			CCLD_CNDT_CD = ((int)order.OrderDuration).ToString(), // 체결조건코드: EOD/지정가.6, GTD.5, 시장가.2
			CPLX_ORD_DVSN_CD = "0", // 복합주문구분코드
			ECIS_RSVN_ORD_YN = "N", // 행사예약주문여부
			FM_HDGE_ORD_SCRN_YN = "N" // FM_HEDGE주문화면여부
		}, true);

		return await RequestOrderAsync("OTFM3001U", parameters);
	}

	public Task<ResponseCore> UpdateOrderAsync(OrderCore order)
	{
		//TODO : OTFM3002U
		throw new NotImplementedException();
	}

	public async Task<ResponseCore> CancelOrderAsync(OrderCore order)
	{
		if (order.IdOrigin == 0 || order.QtyOrdered == 0) return new ResponseCore
		{
			StatusCode = Status.BAD_REQUEST,
			Code = "REFUSE",
			Message = "one of parameter value is not correct.",
		};

		var parameters = GenerateParameters(new
		{
			ORGN_ORD_DT = order.DateOrdered.ToDate8Txt(),
			ORGN_ODNO = order.IdOrigin.ToString().PadLeft(8, '0'),
			FM_HDGE_ORD_SCRN_YN = "N",
			FM_MKPR_CVSN_YN = "N"
		}, true);

		return await RequestOrderAsync("OTFM3003U", parameters);
	}

	private async Task<ResponseCore> RequestOrderAsync(string trId, object parameters)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/order{(trId == "OTFM3001U" ? "" : "-rvsecncl")}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(trId)).AddBody(parameters);

		try
		{
			var response = await client.PostAsync<OTFM300XU>(request);
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
				Remark = $"{response.Output.OrderDate8}-{response.Output.OrderNumber}"
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

	#region OTFM3116R 당일주문내역조회 / OTFM3120R 일별주문내역조회
	public async Task<ResponseResults<Order>> RequestOrdersAsync(ExecutionStatus executionStatus = ExecutionStatus.All)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseResults<Order>
		{
			Code = "ANUMBER",
			List = new List<Order>(),
			Message = "no accountNumber",
		};

		var queryParameters = GenerateParameters(new
		{
			CCLD_NCCS_DVSN = "01",
			SLL_BUY_DVSN_CD = "%%",
			FUOP_DVSN = "00",
			CTX_AREA_FK200 = "",
			CTX_AREA_NK200 = ""
		}, true);

		try
		{
			var response = await RequestStandardAsync<OTFM3116R>("uapi/overseas-futureoption/v1/trading/inquire-ccld", queryParameters);

			if (response is null) return new ResponseResults<Order>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				List = [],
				Message = "response is null",
			};

			if (!response.Output.Any()) return new ResponseResults<Order>
			{
				StatusCode = Status.NODATA,
				List = [],
				Message = "no order",
				Remark = $"{BankAccountInfo.AccountNumber}: {BankAccountInfo.AccountNumberSuffix}",
			};

			var orders = new List<Order>();
			var remark = string.Empty;
			response.Output.ForEach(f =>
			{
				orders.Add(new Order
				{
					Broker = Brkr.KI,
                    OID = f.OID,
					DateBiz = f.ord_dt.ToDate(),
					PriceOrdered = f.PriceOrdered,
					QtyOrdered = f.VolumeOrdered,
					QtyUpdatable = f.VolumeOrdered - f.VolumeExecuted,
					Symbol = f.Symbol,
					TimeOrdered = f.erlm_dtl_dtime.ToDateTimeM(),
					IsLong = f.sll_buy_dvsn_cd == "02", //
					Mode = f.rcit_dvsn_cd switch
					{
						"00" => OrderMode.PLACE,
						"01" => OrderMode.UPDATE,
						"02" => OrderMode.CANCEL,
						"03" => OrderMode.PLACE_RESPONSE,
						"04" => OrderMode.UPDATE_RESPONSE,
						_ => OrderMode.NONE
					}
				});

				remark += f.rcit_dvsn_cd + "|";
			});

			return new ResponseResults<Order>
			{
				List = orders,
				Remark = remark
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				List = new List<Order>(),
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}",
			};
		}
	}

	public async Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseResults<Order>
		{
			Code = "ANUMBER",
			List = new List<Order>(),
			Message = "no accountNumber",
		};

		var queryParameters = GenerateParameters(new
		{
			STRT_DT = dateBegun.ToDate8Txt(),
			END_DT = dateFin.ToDate8Txt(),
			FM_PDGR_CD = "",
			CCLD_NCCS_DVSN = "01",
			SLL_BUY_DVSN_CD = "%%",
			FUOP_DVSN = "00",
			CTX_AREA_FK200 = "",
			CTX_AREA_NK200 = ""
		}, true);

		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-daily-order");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM3120R)));

		foreach (var parameters in queryParameters)
		{
			request.AddQueryParameter(parameters.Key, parameters.Value?.ToString());
		}

		try
		{
			var response = await client.GetAsync<OTFM3120R>(request);

			if (response is null) return new ResponseResults<Order>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				List = new List<Order>(),
				Message = "response is null",
			};

			if (!response.Output.Any()) return new ResponseResults<Order>
			{
				StatusCode = Status.NODATA,
				List = new List<Order>(),
				Message = "no order",
				Remark = $"{BankAccountInfo.AccountNumber}: {BankAccountInfo.AccountNumberSuffix}",
			};

			var orders = new List<Order>();
			var remark = string.Empty;
			response.Output.ForEach(f =>
			{
				orders.Add(new Order
				{
					Broker = Brkr.KI,
                    OID = f.OID,
					DateBiz = f.ord_dt.ToDate(),
					PriceOrdered = f.PriceOrdered,
					QtyOrdered = f.VolumeOrdered,
					QtyUpdatable = f.VolumeOrdered - f.VolumeExecuted,
					Symbol = f.Symbol,
					TimeOrdered = f.OrderDateTime863.ToDateTimeM(),
					IsLong = f.sll_buy_dvsn_cd == "02", //
					Mode = f.rvse_cncl_dvsn_cd switch
					{
						"00" => OrderMode.PLACE,
						"01" => OrderMode.UPDATE,
						"02" => OrderMode.CANCEL,
						"03" => OrderMode.PLACE_RESPONSE,
						"04" => OrderMode.UPDATE_RESPONSE,
						_ => OrderMode.NONE
					}
				});

				remark += f.rvse_cncl_dvsn_cd + "|";
			});

			return new ResponseResults<Order>
			{
				List = orders,
				Remark = remark
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				List = new List<Order>(),
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}",
			};
		}
	}
	#endregion

	#region 일별 체결내역 : OTFM3122R
	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "")
	{
		var date = DateTime.Now.ToNewYorkTime();

		return await RequestExecutionsAsync(date, date, status);
	}

	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, ExecutionStatus status = ExecutionStatus.ExecutedOnly) =>
		await RequestExecutionsAsync(dateBegun, dateBegun, status);

	public async Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, DateTime dateFin, ExecutionStatus status = ExecutionStatus.ExecutedOnly)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseResults<Execution>
		{
			Code = "ANUMBER",
			List = new List<Execution>(),
			Message = "no accountNumber",
			Remark = dateBegun.ToDate8Txt()
		};

		var queryParameters = GenerateParameters(new
		{
			STRT_DT = dateBegun.ToDate8Txt(),
			END_DT = dateFin.ToDate8Txt(),
			FUOP_DVSN_CD = "00",
			FM_PDGR_CD = "",
			CRCY_CD = "%%%",
			FM_ITEM_FTNG_YN = "N",
			SLL_BUY_DVSN_CD = "%%",
			CTX_AREA_FK200 = "",
			CTX_AREA_NK200 = ""
		}, true);

		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-daily-ccld");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM3122R)));

		foreach (var parameters in queryParameters)
		{
			request.AddQueryParameter(parameters.Key, parameters.Value?.ToString());
		}

		try
		{
			var response = await client.GetAsync<OTFM3122R>(request);

			if (response is null) return new ResponseResults<Execution>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				List = new List<Execution>(),
				Message = "response is null",
				Remark = dateBegun.ToDate8Txt()
			};

			if (response.output1.Count == 0) return new ResponseResults<Execution>
			{
				StatusCode = Status.NODATA,
				List = new List<Execution>(),
				Message = $"{BankAccountInfo.AccountNumber}: {BankAccountInfo.AccountNumberSuffix}",
				Remark = $"{queryParameters["STRT_DT"]} - {queryParameters["END_DT"]}"
			};

			var executions = new List<Execution>();
			response.output1.ForEach(f =>
			{
				executions.Add(new Execution
				{
					Broker = Brkr.KI,
                    ExchangeCode = Exchange.CME,
					EID = f.CID,
					OID = f.OID,
					DateBiz = f.DateBizTxt8.ToDate(),
					Price = f.Price,
					Qty = f.QtyExecuted,
					Symbol = f.Symbol,
					TimeExecuted = f.ccld_dtl_dtime.ToDateTime(),
					IsLong = f.DirectionCode == "02", //
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
				List = new List<Execution>(),
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}",
			};
		}
	}
	#endregion

	#region 예수금현황 : OTFM1411R
	public async Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.TUS)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-deposit");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM1411R)));

		var body = GenerateParameters(new
		{
			CRCY_CD = currency.ToString(),
			INQR_DT = (date is null ? DateTime.Now : date)?.ToDate8Txt()
		}, true);

		foreach (var parameter in body)
		{
			request.AddQueryParameter(parameter.Key, parameter.Value);
		}

		try
		{
			var response = await client.GetAsync<OTFM1411R>(request);

			if (response is null) return new ResponseResult<Balance>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Info = new Balance()
			};

			var balance = new Balance
			{
				BID = Brkr.KI,
				AccountNumber = response.output.Account,
				CurBased = Enum.Parse<Currency>(response.output.crcy_cd),
				DepositInit = response.output.fm_dnca_rmnd,
				ProfitLiquidated = response.output.fm_lqd_pfls_amt,
				ProfitEst = response.output.fm_fuop_evlu_pfls_amt,
				CommissionAgg = response.output.fm_fee,
				DepositEst = response.output.fm_tot_asst_evlu_amt,  //fm_nxdy_dncl_amt,
				Margin = response.output.fm_mntn_mgn_amt,
				MarginInitial = response.output.fm_brkg_mgn_amt,
				CashTradable = response.output.fm_ord_psbl_amt,
			};

			return new ResponseResult<Balance>
			{
				StatusCode = Status.SUCCESS,
				Info = balance
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<Balance>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Info = new Balance(),
				Message = ex.Message
			};
		}
	}
	#endregion

	public Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Pnl>> RequestPnlAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX)
	{
		throw new NotImplementedException();
	}

	#region 주문내역 구독 : HDFFF1C0
	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) =>
		await SubscribeAsync("SYS", nameof(HDFFF1C0), "", connecting);
	#endregion

	#region 체결내역 구독 : HDFFF2C0
	public async Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true) =>
		await SubscribeAsync("SYS", nameof(HDFFF2C0), "", connecting);
	#endregion
}
