using KisOpenApi.Models;
using KisOpenApi.Models.GlobalFutures;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Contract>> Contracted { get; set; }
	public required EventHandler<ResponseResult<Order>> Executed { get; set; }
	public EventHandler<ResponseResult<Balance>> BalanceAggregated { get; set; }

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
		});

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
	public async Task<ResponseCore> AddOrderAsync(OrderCore order)
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
			FM_ORD_QTY = order.VolumeOrdered.ToString(), // FM주문수량
			CCLD_CNDT_CD = ((int)order.OrderDuration).ToString(), // 체결조건코드: EOD/지정가.6, GTD.5, 시장가.2
			CPLX_ORD_DVSN_CD = "0", // 복합주문구분코드
			ECIS_RSVN_ORD_YN = "N", // 행사예약주문여부
			FM_HDGE_ORD_SCRN_YN = "N" // FM_HEDGE주문화면여부
		});

		return await RequestOrderAsync("OTFM3001U", parameters);
	}

	public Task<ResponseCore> UpdateOrderAsync(OrderCore order)
	{
		//TODO : OTFM3002U
		throw new NotImplementedException();
	}

	public async Task<ResponseCore> CancelOrderAsync(DateOnly bizDate, long oid, int volume)
	{
		if (oid == 0 || volume == 0) return new ResponseCore
		{
			StatusCode = Status.BAD_REQUEST,
			Code = "REFUSE",
			Message = "one of parameter value is not correct.",
		};

		var parameters = GenerateParameters(new
		{
			ORGN_ORD_DT = bizDate.ToString("yyyyMMdd"),
			ORGN_ODNO = oid.ToString().PadLeft(8, '0'),
			FM_HDGE_ORD_SCRN_YN = "N",
			FM_MKPR_CVSN_YN = "N"
		});

		return await RequestOrderAsync("OTFM3003U", parameters);
	}

	private async Task<ResponseCore> RequestOrderAsync(string trId, object parameters)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/order{(trId == "OTFM3001U" ? "" : "-rvsecncl")}");
		var request = new RestRequest().AddHeaders(GenerateHeaders(trId)).AddBody(parameters);

		try
		{
			var response = await client.PostAsync<OTFM300XU>(request);
			if (response is null || response.Output is null || response.ResultCode != "0") return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = response?.ResponseCode ?? "NULL",
				Message = response?.ResponseMessage ?? "response is null",
			};

			return new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Code = response.ResponseCode,
				Message = response.ResponseMessage,
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
	public async Task<ResponseResults<Order>> RequestOrdersAsync()
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
		});

		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-ccld");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM3116R)));

		foreach (var parameters in queryParameters)
		{
			request.AddQueryParameter(parameters.Key, parameters.Value?.ToString());
		}

		try
		{
			var response = await client.GetAsync<OTFM3116R>(request);

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
					BrokerCo = "KI",
					OID = f.OID,
					DateBiz = f.ord_dt.ToDate(),
					PriceOrdered = f.PriceOrdered,
					VolumeOrdered = f.VolumeOrdered,
					VolumeUpdatable = f.VolumeOrdered - f.VolumeContracted,
					Symbol = f.Symbol,
					TimeOrdered = f.erlm_dtl_dtime.ToDateTimeMicro(),
					IsLong = f.sll_buy_dvsn_cd == "02", //
					Mode = f.rcit_dvsn_cd switch
					{
						"00" => OrderMode.Place,
						"01" => OrderMode.Update,
						"02" => OrderMode.Cancel,
						"03" => OrderMode.PlaceContracted,
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
			STRT_DT = dateBegun.ToString("yyyyMMdd"),
			END_DT = dateFin.ToString("yyyyMMdd"),
			FM_PDGR_CD = "",
			CCLD_NCCS_DVSN = "01",
			SLL_BUY_DVSN_CD = "%%",
			FUOP_DVSN = "00",
			CTX_AREA_FK200 = "",
			CTX_AREA_NK200 = ""
		});

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
					BrokerCo = "KI",
					OID = f.OID,
					DateBiz = f.ord_dt.ToDate(),
					PriceOrdered = f.PriceOrdered,
					VolumeOrdered = f.VolumeOrdered,
					VolumeUpdatable = f.VolumeOrdered - f.VolumeContracted,
					Symbol = f.Symbol,
					TimeOrdered = f.OrderDateTime863.ToDateTimeMicro(),
					IsLong = f.sll_buy_dvsn_cd == "02", //
					Mode = f.rvse_cncl_dvsn_cd switch
					{
						"00" => OrderMode.Place,
						"01" => OrderMode.Update,
						"02" => OrderMode.Cancel,
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
	public async Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ExecutedOnly)
	{
		var date = DateTime.Now.ToNewYorkTime();

		return await RequestContractsAsync(date, date, status);
	}

	public async Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, ContractStatus status = ContractStatus.ExecutedOnly) =>
		await RequestContractsAsync(dateBegun, dateBegun, status);

	public async Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly)
	{
		if (string.IsNullOrEmpty(BankAccountInfo.AccountNumber)) return new ResponseResults<Contract>
		{
			Code = "ANUMBER",
			List = new List<Contract>(),
			Message = "no accountNumber",
			Remark = dateBegun.ToString("yyyyMMdd")
		};

		var queryParameters = GenerateParameters(new
		{
			STRT_DT = dateBegun.ToString("yyyyMMdd"),
			END_DT = dateFin.ToString("yyyyMMdd"),
			FUOP_DVSN_CD = "00",
			FM_PDGR_CD = "",
			CRCY_CD = "%%%",
			FM_ITEM_FTNG_YN = "N",
			SLL_BUY_DVSN_CD = "%%",
			CTX_AREA_FK200 = "",
			CTX_AREA_NK200 = ""
		});

		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-daily-ccld");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM3122R)));

		foreach (var parameters in queryParameters)
		{
			request.AddQueryParameter(parameters.Key, parameters.Value?.ToString());
		}

		try
		{
			var response = await client.GetAsync<OTFM3122R>(request);

			if (response is null) return new ResponseResults<Contract>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				List = new List<Contract>(),
				Message = "response is null",
				Remark = dateBegun.ToString("yyyyMMdd")
			};

			if (response.output1.Count == 0) return new ResponseResults<Contract>
			{
				StatusCode = Status.NODATA,
				List = new List<Contract>(),
				Message = $"{BankAccountInfo.AccountNumber}: {BankAccountInfo.AccountNumberSuffix}",
				Remark = $"{queryParameters["STRT_DT"]} - {queryParameters["END_DT"]}"
			};

			var contracts = new List<Contract>();
			response.output1.ForEach(f =>
			{
				contracts.Add(new Contract
				{
					BrokerCo = "KI",
					ExchangeCode = Exchange.CME,
					CID = f.CID,
					OID = f.OID,
					DateBiz = f.DateBizTxt8.ToDate(),
					Price = f.Price,
					Volume = f.Volume,
					Symbol = f.Symbol,
					TimeContracted = f.ccld_dtl_dtime.ToDateTime(),
					IsLong = f.DirectionCode == "02", //
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
				List = new List<Contract>(),
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"error catch: {ex.Message}",
			};
		}
	}
	#endregion

	#region 예수금현황 : OTFM1411R
	public async Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/trading/inquire-deposit");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(OTFM1411R)));

		var body = GenerateParameters(new
		{
			CRCY_CD = "TUS",
			INQR_DT = (date is null ? DateTime.Now : date)?.ToString("yyyyMMdd")
		});

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
				BrokerCode = "KI",
				AccountNumber = response.output.Account,
				CurBased = Enum.Parse<Currency>(response.output.crcy_cd),
				DepositEst = response.output.fm_opt_icld_asst_evlu_amt,
				DepositConverted = response.output.fm_tot_asst_evlu_amt,
				CashAvailable = response.output.fm_ord_psbl_amt,
				Margin = response.output.fm_mntn_mgn_amt,
				MarginInitial = response.output.fm_brkg_mgn_amt,
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

	public Task<ResponseResults<Position>> RequestPositionsAsync(DateTime? date = null)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX)
	{
		throw new NotImplementedException();
	}

	#region 주문내역 구독 : HDFFF1C0
	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true) =>
		await Subscribe(nameof(HDFFF1C0), "", connecting);
	#endregion

	#region 체결내역 구독 : HDFFF2C0
	public async Task<ResponseCore> SubscribeContractAsync(bool connecting = true) =>
		await Subscribe(nameof(HDFFF2C0), "", connecting);
	#endregion

	#region Generate Headers and Parameters
	/// <summary>
	/// Generate Parameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string?> GenerateParameters(Dictionary<string, string?> additionalOption)
	{
		var basicParameters = new
		{
			CANO = BankAccountInfo.AccountNumber.Substring(0, 8),
			ACNT_PRDT_CD = BankAccountInfo.AccountNumber.Substring(8),
		};

		var parameters = basicParameters.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(basicParameters, null)?.ToString());
		foreach (var parameter in additionalOption)
		{
			parameters.Add(parameter.Key, parameter.Value?.ToString());
		}

		return parameters ?? new Dictionary<string, string?>();
	}

	/// <summary>
	/// Generate QueryParameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string?> GenerateParameters(object additionalOption) =>
		GenerateParameters(additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string> GenerateHeaders(string tr, Dictionary<string, string> additionalOption)
	{
		var headers = GenerateHeaders(tr);

		foreach (var header in additionalOption)
		{
			headers.Add(header.Key, header.Value);
		}

		return headers;
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <returns></returns>
	private Dictionary<string, string> GenerateHeaders(string tr)
	{
		return new Dictionary<string, string>
		{
			{ "content-type", "application/json" },
			{ "authorization", $"Bearer {KeyInfo.AccessToken}"},
			{ "appkey", KeyInfo.AppKey },
			{ "appsecret", KeyInfo.SecretKey},
			{ "tr_id", tr},
			{ "custtype", "P" }
		};
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string> GenerateHeaders(string tr, object additionalOption) =>
		GenerateHeaders(tr, additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
	#endregion
}
