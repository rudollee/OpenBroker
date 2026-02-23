using OpenBroker.Models;
using OpenBroker;
using LsOpenApi.Models;
using OpenBroker.Extensions;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IMarket, IMarketKrxEquity
{
	public bool AvailableToSubscribe
	{
		get
		{
			var now = DateTime.UtcNow.AddHours(9);
			var closedWeeks = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
			if (closedWeeks.Contains(now.DayOfWeek)) return false;

			if (now.TimeOfDay < new TimeSpan(7, 20, 00)) return false;
            return now.TimeOfDay <= new TimeSpan(20, 45, 00);
        }
    }

	public EventHandler<ResponseResult<MarketExecution>>? MarketExecuted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Dictionary<string, Equity> Equities { get; set; } = [];

	public Dictionary<string, Instrument> Instruments { get; set; } = [];

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketExecution(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		if (symbol == "USD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol == "JPYUSD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol.Contains('@')) return await SubscribeAsync(subscriber, "MK2", symbol.PadRight(16, ' '), connecting);

		if (!Equities.ContainsKey(symbol)) return ReturnError("NOT-FOUND", "A requested Symbol has not found", typ: MessageType.MISC, statusCode: Status.BAD_REQUEST); 

		return await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "S3_" : "K3_", symbol, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "")
	{
		var isUnified = symbol.StartsWith('U');
		if (isUnified) symbol = symbol[1..];

		if (!Equities.ContainsKey(symbol)) return ReturnError("NOT-FOUND", "A requested Symbol has not found", typ: MessageType.MISC, statusCode: Status.BAD_REQUEST);

		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		var estimation = await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "YS3" : "YK3", symbol, connecting);
		if (estimation.StatusCode != Status.SUCCESS) return estimation;

		var realtimeCode = isUnified ? nameof(UH1) : Equities[symbol].Section == ExchangeSection.KOSPI ? "H1_" : "HA_";
		var symbolAdjusted = isUnified ? $"U{symbol}   " : symbol;

		return await SubscribeAsync(subscriber, realtimeCode, symbolAdjusted, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => await SubscribeAsync("SYS", "VI_", symbol);
	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await SubscribeAsync("SYS", "NWS", "NWS001", connecting);

	public Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option) => throw new NotImplementedException();

	#region request news using t3102
	public async Task<ResponseResult<News>> RequestNews(string id)
	{
		try
		{
			var response = await RequestStandardAsync<T3102>(LsEndpoint.EquityInfo.ToDescription(), new
			{
				t3102InBlock = new T3102InBlock
				{
					NewsNo = id
				}
			});

			if (response.T3102OutBlock1.Count == 0) return ReturnResult<News>(new() 
			{ 
				Code = nameof(T3102), 
				Title = string.Empty 
			}, nameof(T3102), response.Message);

			var htmlString = string.Join("", response.T3102OutBlock1.Select(s => s.Body))
				.Replace("t3102OutBlock1", "")
				.Replace("IMGsrc=", "img src=");

			return ReturnResult(new News
			{
				Code = id,
				Title = response.T3102OutBlock2.Title,
				Body = htmlString,
				SymbolList = [.. response.T3102OutBlock.Select(s => s.SymbolsTxt)]
			}, nameof(T3102));
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<News>(nameof(News), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request equity dictionary using t8436 / t9945
	public async Task<ResponseResults<Equity>> RequestEquityList(int option = 0)
	{
		try
		{
			var response = await RequestStandardAsync<t8436>(LsEndpoint.EquityEtc.ToDescription(), new
			{
				t8436InBlock = new t8436InBlock
				{
					gubun = "0"
				}
			});

			if (response.t8436OutBlock.Count == 0) return ReturnResults<Equity>([], nameof(t8436), "no data");

			List<Equity> equities = [];
			foreach (var instrument in response.t8436OutBlock.Where(w => new string[] { "01", "03" }.Contains(w.bu12gubun)))
			{
				var equity = new Equity
				{
					Symbol = instrument.shcode,
					Section = instrument.gubun == "1" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
					NameOfficial = instrument.hname,
				};

				equities.Add(equity);
				Equities.Add(instrument.shcode, equity);
			}

			return ReturnResults(equities, nameof(t8436));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Equity>(nameof(t8436), ex.Message, MessageSeverity.Critical);
		}
	}

	public async Task<ResponseDictionary<string, Equity>> RequestEquityDictionary(int option = 0)
	{
		try
		{
			foreach (var code in new string[] { "1", "2" })
			{
				var response = await RequestStandardAsync<t9945>(LsEndpoint.EquityMarketData.ToDescription(), new
				{
					t9945InBlock = new t9945InBlock { gubun = code }
				});

				if (response.t9945OutBlock.Count == 0) return new ResponseDictionary<string, Equity>
				{
					StatusCode = Status.ERROR_OPEN_API,
					Message = "no data",
					Code = response.Code,
					Dic = []
				};

				foreach (var instrument in response.t9945OutBlock.Where(w => w.etfchk == "0"))
				{
					var equity = new Equity
					{
						Symbol = instrument.shcode,
						Section = code == "1" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
						NameOfficial = instrument.hname,
					};

					equity.Exchanges.Add(Exchange.KRX);
					if (instrument.nxt_chk == "1") equity.Exchanges.Add(Exchange.NXT);

					Equities.Add(instrument.shcode, equity);
				}
			}

			return new ResponseDictionary<string, Equity> { Dic = Equities };
		}
		catch (Exception ex)
		{
			return new ResponseDictionary<string, Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Severity = MessageSeverity.Critical
			};
		}
	}
	#endregion

	#region request equity ipo list using t1403
	public async Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end)
	{
		try
		{
			var response = await RequestStandardAsync<T1403>(LsEndpoint.EquityEtc.ToDescription(), new
			{
				t1403InBlock = new T1403InBlock
				{
					Gubun = "0",
					Styymm = begin.ToString("yyyyMM"),
					Enyymm = end.ToString("yyyyMM"),
				}
			});

			if (response.T1403OutBlock1.Count == 0) return ReturnResults<Equity>([], nameof(T1403));

			var equities = new List<Equity>();
			foreach (var equity in response.T1403OutBlock1)
			{
				equities.Add(new Equity
				{
					Symbol = equity.Shcode,
					NameOfficial = equity.Hname,
				});
			}

			return ReturnResults(equities, nameof(T1403), string.Empty, MessageSeverity.Medium, MessageType.MKT, response.T1403OutBlock1.Select(s => s.Date).Max() ?? string.Empty);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Equity>(nameof(T1403), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request equity info (& orderbook) using t1102 (& t1101/t8450)
	public async Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol, bool needsOrderBook = false, Exchange exchange = Exchange.NONE)
	{
		var exchangeCode = exchange switch
		{
			Exchange.KRX => "K",
			Exchange.NXT => "N",
			_ => "U"
		};

		try
		{
			var response = await RequestStandardAsync<T1102>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t1102InBlock = new T1102InBlock
				{
					Shcode = symbol,
					Exchgubun = exchangeCode
				}
			});

			if (response.T1102OutBlock is null) return ReturnResult<EquityPack>(new(), nameof(T1102), response.Message);

			var equity = new EquityPack
			{
				Symbol = response.T1102OutBlock.Shcode,
				NameOfficial = response.T1102OutBlock.Hname,
				Section = response.T1102OutBlock.Janginfo.Contains("KOSPI") ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
				PriceInfo = new QuoteRate
				{
					T = DateTime.Now,
					BasePrice = response.T1102OutBlock.Recprice,
					C = response.T1102OutBlock.Price,
					O = response.T1102OutBlock.Open,
					H = response.T1102OutBlock.High,
					L = response.T1102OutBlock.Low,
					V = response.T1102OutBlock.Volume,
					Turnover = response.T1102OutBlock.Value,
					HighLimit = response.T1102OutBlock.Uplmtprice,
					LowLimit = response.T1102OutBlock.Dnlmtprice,
				},
				DiscardStatus = DiscardStatus.TRADABLE,
				TradingInfo = new EquityPack.TradingData
				{
					MarginRate = response.T1102OutBlock.Jkrate,
				}
			};

			if (needsOrderBook)
			{
				var responseOrderbook = exchange switch
				{
					Exchange.KRX => await RequestOrderbookAsync(symbol),
					_ => await RequestOrderbookAsync(symbol, exchange)
				};

				if (responseOrderbook.Info is null) return ReturnErrorResult<EquityPack>(nameof(T1102), responseOrderbook.Message);

				equity.OrderBook = responseOrderbook.Info;
			}

			return ReturnResult(equity, nameof(T1102), string.Empty, typ: MessageType.MKT, remark: "MoneyAgg multiple: M");
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<EquityPack>(nameof(T1102), ex.Message, MessageSeverity.Critical);
		}
	}

	private async Task<ResponseResult<OrderBook>> RequestOrderbookAsync(string symbol)
	{
		var response = await RequestStandardAsync<T1101>(LsEndpoint.EquityMarketData.ToDescription(), new
		{
			t1101InBlock = new T1101InBlock { Shcode = symbol }
		});

		if (response is null || response.T1101OutBlock is null) return ReturnErrorResult<OrderBook>(nameof(T1101), "response is null");

		List<MarketOrder> asks = [];
		List<MarketOrder> bids = [];
		for (int i = 0; i < 10; i++)
		{
			asks.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Offerho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Offerrem{(i + 1)}")),
			});

			bids.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Bidho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Bidrem{(i + 1)}"))
			});
		}

		return new ResponseResult<OrderBook>
		{
			Broker = Brkr.LS,
			Typ = MessageType.MKT,
			Info = new OrderBook
			{
				TimeTaken = response.T1101OutBlock.Hotime.ToTime(),
				Ask = asks,
				Bid = bids,
				AskAgg = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Offer")),
				BidAgg = Convert.ToDecimal(response.T1101OutBlock.GetPropValue($"Bid")),
			}
		};
	}

	private async Task<ResponseResult<OrderBook>> RequestOrderbookAsync(string symbol, Exchange exchange)
	{
		var exchangeCode = exchange switch
		{
			Exchange.KRX => "K",
			Exchange.NXT => "N",
			_ => "U"
		};

		var response = await RequestStandardAsync<t8450>(LsEndpoint.EquityMarketData.ToDescription(), new
		{
			t8450InBlock = new t8450InBlock
			{
				shcode = symbol,
				exchgubun = exchangeCode
			}
		});

		if (response.t8450OutBlock is null) return ReturnErrorResult<OrderBook>(nameof(t8450), response?.Message ?? "response is null");

		List<MarketOrder> asks = [];
		List<MarketOrder> bids = [];
		Dictionary<decimal, MarketOrder> asksx = [];
		Dictionary<decimal, MarketOrder> bidsx = [];

		var exchangePrefix = exchange switch
		{
			Exchange.KRX => "",
			Exchange.NXT => "nxt_",
			_ => "unx_"
		};

		for (int i = 0; i < 10; i++)
		{
			var price = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"offerho{i + 1}"));
			if (price == 0) continue;
		
			asks.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = price,
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}offerrem{(i + 1)}"))
			});

			asksx[price] = new()
			{
				Seq = Convert.ToByte(i + 1),
				Price = price,
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}offerrem{(i + 1)}"))
			};

		}

		for	(int i = 0; i < 10; i++)
		{
			var price = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"bidho{(i + 1)}"));
			if (price == 0) continue;

			bids.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = price,
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}bidrem{(i + 1)}"))
			});

			bidsx[price] = new()
			{
				Seq = Convert.ToByte(i + 1),
				Price = price,
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}bidrem{(i + 1)}"))
			};
		}

		return new ResponseResult<OrderBook>
		{
			Broker = Brkr.LS,
			Typ = MessageType.MKT,
			Info = new OrderBook
			{
				TimeTaken = response.t8450OutBlock.hotime.ToTime(),
				Ask = asks,
				Asks = asksx,
				Bid = bids,
				Bids = bidsx,
				AskAgg = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}offer")),
				BidAgg = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}bid")),
			}
		};
	}
	#endregion

	#region request marketExecution using t8407
	public async Task<ResponseResult<MarketExecution>> RequestMarketExecution(string symbol)
	{
		var response = await RequestMarketExecution([symbol]);
		if (!response.List.Any()) return new ResponseResult<MarketExecution>
		{
			StatusCode = Status.NODATA,
			Message = response.Message,
			Code = response.Code,
			Remark = "no data"
		};

		return new ResponseResult<MarketExecution>
		{
			Code = response.Code,
			Info = response.List.FirstOrDefault()
		};
	}

	public async Task<ResponseResults<MarketExecution>> RequestMarketExecution(IEnumerable<string> symbols)
	{
		try
		{
			var response = await RequestStandardAsync<T8407>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t8407InBlock = new T8407InBlock
				{
					Nrec = symbols.Count(),
					Shcode = string.Join("", symbols.Take(50))
				}
			});

			if (response.T8407OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(T8407), response.Message);

			var executions = new List<MarketExecution>();
			response.T8407OutBlock1.ForEach(f =>
			{
				executions.Add(new MarketExecution
				{
					TimeExecuted = DateTime.Now,
					Symbol = f.Shcode,
					C = f.Price,
					BasePrice = f.Jnilclose,
					QuoteDaily = new Quote
					{
						C = f.Price,
						O = f.Open,
						H = f.High,
						L = f.Low,
						V = f.Volume,
						Turnover = f.Value
					},
					VolumeExecuted = f.Cvolume,
				});
			});

			return ReturnResults(executions, nameof(T8407));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(T8407), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request marketExecutionHistory using t1301
	public async Task<ResponseResults<MarketExecution>> RequestMarketExecutionHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0)
	{
		try
		{
			var response = await RequestStandardAsync<T1301>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t1301InBlock = new T1301InBlock
				{
					Shcode = symbol,
					Starttime = begin,
					Endtime = end,
					Cvolume = Convert.ToInt64(baseVolume)
				}
			});

			if (response.T1301OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(T1301), response.Message);

			var marketExecutions = new List<MarketExecution>();
			response.T1301OutBlock1.ForEach(execution => marketExecutions.Add(new MarketExecution
			{
				TimeExecuted = execution.Chetime.ToDateTime(),
				C = execution.Price,
				BasePrice = execution.Price + execution.Change * (Convert.ToInt32(execution.Sign) > 3 ? 1 : -1),
				VolumeExecuted = execution.Cvolume,
				QuoteDaily = new Quote
				{
					V = execution.Volume,
				},
			}));

			return ReturnResults(marketExecutions, nameof(T1301));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(T1301), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	public async Task<ResponseResult<OrderBook>> RequestOrderbook(string symbol) => await RequestOrderbookAsync(symbol);

	#region request sectors using t1531
	public async Task<ResponseResults<Sector>> RequestSectors(string code = "", string name = "")
	{
		try
		{
			var response = await RequestStandardAsync<T1531>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1531InBlock = new T1531InBlock
				{
					TmName = name,
					TmCode = code
				}
			});

			if (response.T1531OutBlock.Count == 0) return ReturnResults<Sector>([], nameof(T1531), response.Message);

			var sectors = new List<Sector>();
			response.T1531OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.TmCode,
				Name = sector.TmName,
				Diff = Convert.ToDecimal(sector.AvgDiff)
			}));

			return ReturnResults(sectors, nameof(T1531));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Sector>(nameof(T1531), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request sectors by equity using t1532
	public async Task<ResponseResults<Sector>> RequestSectorsByEquity(string symbol)
	{
		try
		{
			var response = await RequestStandardAsync<T1532>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1532InBlock = new T1532InBlock
				{
					Shcode = symbol
				}
			});

			if (response.T1532OutBlock.Count == 0) return ReturnResults<Sector>([], nameof(T1532), response.Message);

			var sectors = new List<Sector>();
			response.T1532OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.TmCode,
				Name = sector.TmName,
				Diff = Convert.ToDecimal(sector.AvgDiff)
			}));

			return ReturnResults(sectors, nameof(T1532));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Sector>(nameof(T1532), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request equities by sector using t1537
	public async Task<ResponseResults<MarketExecution>> RequestEquitiesBySector(string sectorCode)
	{
		try
		{
			var response = await RequestStandardAsync<T1537>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1537InBlock = new T1537InBlock
				{
					TmCode = sectorCode
				}
			});

			if (response.T1537OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(T1537), response.Message);

			var equities = new List<MarketExecution>();
			response.T1537OutBlock1.ForEach(equity => equities.Add(new MarketExecution
			{
				Symbol = equity.Shcode,
				QuoteDaily = new Quote
				{
					O = Convert.ToDecimal(equity.Open),
					C = Convert.ToDecimal(equity.Price),
					H = Convert.ToDecimal(equity.High),
					L = Convert.ToDecimal(equity.Low),
					V = Convert.ToDecimal(equity.Volume),
					Turnover = Convert.ToDecimal(equity.Value),
				},
				C = Convert.ToDecimal(equity.Price),
				BasePrice = Convert.ToDecimal(equity.Price) - Convert.ToDecimal(equity.Change) * (DeclineCodes.Contains(equity.Sign) ? -1 : 1)
			}));

			return ReturnResults(equities, nameof(T1537));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(T1537), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion

	#region request chart data by t8410, t8411, t8412
	public async Task<ResponseResult<QuotePack<T>>> RequestPricePack<T>(QuoteRequest request) where T : Quote
	{
		try
		{
			return request.TimeIntervalUnit switch
			{
				IntervalUnit.Tick => await RequestPricePackTick<T>(request),
				IntervalUnit.Minute => await RequestPricePackMinute<T>(request),
				_ => await RequestPricePackX<T>(request)
			};
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<QuotePack<T>>("QUOTE", ex.Message, MessageSeverity.Critical);
		}
	}

	private async Task<ResponseResult<QuotePack<T>>> RequestPricePackTick<T>(QuoteRequest request) where T : Quote
	{
		var response = await RequestStandardAsync<t8411>(LsEndpoint.EquityChart.ToDescription(), new
		{
			t8411InBlock = new t841XInBlock
			{
				shcode = request.Symbol,
				ncnt = request.TimeInterval,
				qrycnt = 500,
				sdate = request.DateTimeBegin.ToString("yyyyMMdd"),
				edate = request.DateTimeEnd.ToString("yyyyMMdd"),
			}
		});

		if (typeof(T) != typeof(Quote)) return ReturnErrorResult<QuotePack<T>>(nameof(t8411), "Invalid type parameter for RequestPricePackTick", remark: "type mismatch");

		if (response.t8411OutBlock1.Count == 0) return ReturnResult<QuotePack<T>>(new() { PrimaryList = [] }, nameof(T8410), response.Message);

		var priceInfo = new QuoteRate
		{
			T = DateTime.UtcNow.AddHours(9),
			BasePrice = response.t8411OutBlock.jiclose,
			C = response.t8411OutBlock.diclose,
			O = response.t8411OutBlock.disiga,
			H = response.t8411OutBlock.dihigh,
			L = response.t8411OutBlock.dilow,
			HighLimit = response.t8411OutBlock.highend,
			LowLimit = response.t8411OutBlock.lowend,
		};

		var prices = new List<Quote>();
		response.t8411OutBlock1.ForEach(price => prices.Add(new Quote
		{
			T = (price.date + price.time).ToDateTime(),
			O = Convert.ToDecimal(price.open),
			C = Convert.ToDecimal(price.close),
			H = Convert.ToDecimal(price.high),
			L = Convert.ToDecimal(price.low),
			V = Convert.ToDecimal(price.jdiff_vol),
			BasePrice = priceInfo.BasePrice,
		}));

		// TODO : 수정주가 적용 여부

		return new ResponseResult<QuotePack<T>>
		{
			Broker = Brkr.LS,
			Info = new QuotePack<T>
			{
				Symbol = request.Symbol,
				TimeIntervalUnit = request.TimeIntervalUnit,
				TimeInterval = request.TimeInterval,
				PrimaryList = prices as List<T> ?? [],
				SecondaryInfo = priceInfo
			}
		};
	}

	private async Task<ResponseResult<QuotePack<T>>> RequestPricePackMinute<T>(QuoteRequest request) where T : Quote
	{
		var response = await RequestStandardAsync<t8412>(LsEndpoint.EquityChart.ToDescription(), new
		{
			t8412InBlock = new t841XInBlock
			{
				shcode = request.Symbol,
				ncnt = request.TimeInterval,
				qrycnt = 500,
				sdate = request.DateTimeBegin.ToString("yyyyMMdd"),
				edate = request.DateTimeEnd.ToString("yyyyMMdd"),
			}
		});

		if (response.t8412OutBlock1.Count == 0) return ReturnResult<QuotePack<T>>(new() { PrimaryList = [] }, nameof(t8412), response.Message);

		var priceInfo = new QuoteRate
		{
			T = DateTime.UtcNow.AddHours(9),
			BasePrice = response.t8412OutBlock.jiclose,
			C = response.t8412OutBlock.diclose,
			O = response.t8412OutBlock.disiga,
			H = response.t8412OutBlock.dihigh,
			L = response.t8412OutBlock.dilow,
			HighLimit = response.t8412OutBlock.highend,
			LowLimit = response.t8412OutBlock.lowend,
		};

		var prices = new List<Quote>();
		response.t8412OutBlock1.ForEach(price => prices.Add(new Quote
		{
			T = (price.date + price.time).ToDateTime(),
			O = Convert.ToDecimal(price.open),
			C = Convert.ToDecimal(price.close),
			H = Convert.ToDecimal(price.high),
			L = Convert.ToDecimal(price.low),
			V = Convert.ToDecimal(price.jdiff_vol),
			BasePrice = priceInfo.BasePrice,
		}));

		// TODO : 수정주가 적용 여부

		return new ResponseResult<QuotePack<T>>
		{
			Broker = Brkr.LS,
			Info = new QuotePack<T>
			{
				Symbol = request.Symbol,
				TimeIntervalUnit = request.TimeIntervalUnit,
				TimeInterval = request.TimeInterval,
				PrimaryList = prices as List<T> ?? [],
				SecondaryInfo = priceInfo
			}
		};
	}

	private async Task<ResponseResult<QuotePack<T>>> RequestPricePackX<T>(QuoteRequest request) where T : Quote
	{
		List<Quote> quotes = [];
		List<T8410OutBlock1> list = [];
		var nextKey = string.Empty;
		var ctsDate = string.Empty;
		do
		{
			var response = await RequestContinuousAsync<T8410>(LsEndpoint.EquityChart.ToDescription(), new
			{
				t8410InBlock = new T8410InBlock
				{
					Shcode = request.Symbol,
					Gubun = request.TimeIntervalUnit switch
					{
						IntervalUnit.Day => "2",
						IntervalUnit.Week => "3",
						IntervalUnit.Month => "4",
						_ => "5"
					},
					Qrycnt = 500,
					Sdate = request.DateTimeBegin.ToString("yyyyMMdd"),
					Edate = request.DateTimeEnd.ToString("yyyyMMdd"),
					CtsDate = ctsDate,
				}
			}, nextKey);

			if (response.T8410OutBlock1.Count == 0)
			{
				nextKey = string.Empty;
				break;
			}

			list.InsertRange(0, response.T8410OutBlock1);
			nextKey = response.NextKey;
			ctsDate = response.T8410OutBlock.CtsDate;
		} while (!string.IsNullOrEmpty(nextKey));

		quotes.Capacity = list.Count;
		list.ForEach(f =>
		{
			quotes.Add(new Quote
			{
				T = $"{f.Date}".ToDateTime(),
				O = f.Open,
				H = f.High,
				L = f.Low,
				C = f.Close,
				V = f.JdiffVol,
			});
		});

		// TODO : 수정주가 적용 여부

		return new ResponseResult<QuotePack<T>>
		{
			Broker = Brkr.LS,
			Info = new QuotePack<T>
			{
				Symbol = request.Symbol,
				PrimaryList = quotes as List<T> ?? [],
				TimeInterval = request.TimeInterval,
				TimeIntervalUnit = request.TimeIntervalUnit,
			},
		};
	}
	#endregion

	#region request search filters & filtered equities by t1866, t1859
	public async Task<ResponseResults<SearchFilter>> RequestSearchFilters()
	{
		try
		{
			if (AccountInfo is null || string.IsNullOrWhiteSpace(AccountInfo.ID)) return new ResponseResults<SearchFilter>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "HTS ID is required",
				List = []
			};

			var response = await RequestStandardAsync<T1866>(LsEndpoint.EquitySearch.ToDescription(), new
			{
				t1866InBlock = new T1866InBlock
				{
					UserId = AccountInfo.ID,
				}
			});

			if (response.T1866OutBlock1.Count == 0) return ReturnResults<SearchFilter>([], nameof(T1866), response.Message);

			var filters = new List<SearchFilter>();
			response.T1866OutBlock1.ForEach(filter => filters.Add(new SearchFilter
			{
				Group = filter.GroupName,
				ID = filter.QueryIndex,
				Query = filter.QueryName
			}));

			return ReturnResults(filters, nameof(T1866));
		}
		catch (Exception ex)
		{
			return ReturnResults<SearchFilter>([], nameof(T1866), ex.Message, MessageSeverity.Critical);
		}
	}

	public async Task<ResponseResults<MarketExecution>> RequestEquitiesByFilter(string query)
	{
		try
		{
			var response = await RequestStandardAsync<T1859>(LsEndpoint.EquitySearch.ToDescription(), new
			{
				t1859InBlock = new T1859InBlock
				{
					QueryIndex = query
				}
			});

			if (response.T1859OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(T1859), response.Message);

			var executions = new List<MarketExecution>();
			response.T1859OutBlock1.ForEach(execution => executions.Add(new MarketExecution
			{
				Symbol = execution.Shcode,
				C = execution.Price,
				BasePrice = execution.Price - execution.Change * (DeclineCodes.Contains(execution.Sign) ? -1 : 1),
				VolumeExecuted = execution.Volume,
			}));

			return ReturnResults(executions, nameof(T1859));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(T1859), ex.Message, MessageSeverity.Critical);
		}
	}
	#endregion
}
