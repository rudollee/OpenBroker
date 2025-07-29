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
			if (now.TimeOfDay > new TimeSpan(20, 45, 00)) return false;

			return true;
		}
	}

	public EventHandler<ResponseResult<MarketExecution>>? MarketExecuted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Dictionary<string, Equity> Equities { get; set; } = new();

	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketExecution(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		if (symbol == "USD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol == "JPYUSD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol.Contains('@')) return await SubscribeAsync(subscriber, "MK2", symbol.PadRight(16, ' '), connecting);

		if (!Equities.ContainsKey(symbol)) return new ResponseCore
		{
			Broker = Brkr.LS,
			StatusCode = Status.BAD_REQUEST,
			Code = "NOT-FOUND",
			Message = "A requested Symbol have not found",
		};

		return await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "S3_" : "K3_", symbol, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "")
	{
		var isUnified = symbol.StartsWith("U");
		if (isUnified) symbol = symbol.Substring(1);

		if (!Equities.ContainsKey(symbol)) return new ResponseCore
		{
			Broker = Brkr.LS,
			StatusCode = Status.BAD_REQUEST,
			Code = "NOT-FOUND",
			Message = "A requested Symbol have not found",
		};

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
			var response = await RequestStandardAsync<t3102>(LsEndpoint.EquityInfo.ToDescription(), new
			{
				t3102InBlock = new t3102InBlock
				{
					sNewsno = id
				}
			});

			if (!response.t3102OutBlock1.Any()) return ReturnResult<News>(new() 
			{ 
				Code = nameof(t3102), 
				Title = string.Empty 
			}, nameof(t3102), response.Message);

			var htmlString = string.Join("", response.t3102OutBlock1.Select(s => s.sBody)).Replace("t3102OutBlock1", "");

			return ReturnResult(new News
			{
				Code = id,
				Title = response.t3102OutBlock2.sTitle,
				Body = htmlString,
				SymbolList = response.t3102OutBlock.Select(s => s.sJongcode).ToArray()
			}, nameof(t3102));
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<News>(nameof(News), ex.Message);
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
			return ReturnErrorResults<Equity>(nameof(t8436), ex.Message);
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

				if (!response.t9945OutBlock.Any()) return new ResponseDictionary<string, Equity>
				{
					StatusCode = Status.ERROR_OPEN_API,
					Message = "no data",
					Code = response.Code,
					Dic = new Dictionary<string, Equity>()
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
			};
		}
	}
	#endregion

	#region request equity ipo list using t1403
	public async Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end)
	{
		try
		{
			var response = await RequestStandardAsync<t1403>(LsEndpoint.EquityEtc.ToDescription(), new
			{
				t1403InBlock = new t1403InBlock
				{
					gubun = "0",
					styymm = begin.ToString("yyyyMM"),
					enyymm = end.ToString("yyyyMM"),
				}
			});

			if (response.t1403OutBlock1.Count == 0) return ReturnResults<Equity>([], nameof(t1403));

			var equities = new List<Equity>();
			foreach (var equity in response.t1403OutBlock1)
			{
				equities.Add(new Equity
				{
					Symbol = equity.shcode,
					NameOfficial = equity.hname,
				});
			}

			return ReturnResults(equities, nameof(t1403), string.Empty, MessageType.MKT, response.t1403OutBlock1.Select(s => s.date).Max() ?? string.Empty);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Equity>(nameof(t1403), ex.Message);
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
			var response = await RequestStandardAsync<t1102>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t1102InBlock = new t1102InBlock
				{
					shcode = symbol,
					exchgubun = exchangeCode
				}
			});

			if (response.t1102OutBlock is null) return ReturnResult<EquityPack>(new(), nameof(t1102), response.Message);

			var equity = new EquityPack
			{
				Symbol = response.t1102OutBlock.shcode,
				NameOfficial = response.t1102OutBlock.hname,
				Section = response.t1102OutBlock.janginfo.Contains("KOSPI") ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
				PriceInfo = new QuoteRate
				{
					T = DateTime.Now,
					BasePrice = response.t1102OutBlock.recprice,
					C = response.t1102OutBlock.price,
					O = response.t1102OutBlock.open,
					H = response.t1102OutBlock.high,
					L = response.t1102OutBlock.low,
					V = response.t1102OutBlock.volume,
					Turnover = response.t1102OutBlock.value,
					HighLimit = response.t1102OutBlock.uplmtprice,
					LowLimit = response.t1102OutBlock.dnlmtprice,
				},
				DiscardStatus = DiscardStatus.TRADABLE,
				TradingInfo = new EquityPack.TradingData
				{
					MarginRate = response.t1102OutBlock.jkrate,
				}
			};

			if (needsOrderBook)
			{
				var responseOrderbook = exchange switch
				{
					Exchange.KRX => await RequestOrderbookAsync(symbol),
					_ => await RequestOrderbookAsync(symbol, exchange)
				};

				if (responseOrderbook.Info is null) return ReturnErrorResult<EquityPack>(nameof(t1102), responseOrderbook.Message);

				equity.OrderBook = responseOrderbook.Info;
			}

			return ReturnResult(equity, nameof(t1102), string.Empty, MessageType.MKT, "MoneyAgg multiple: M");
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<EquityPack>(nameof(t1102), ex.Message);
		}
	}

	private async Task<ResponseResult<OrderBook>> RequestOrderbookAsync(string symbol)
	{
		var response = await RequestStandardAsync<t1101>(LsEndpoint.EquityMarketData.ToDescription(), new
		{
			t1101InBlock = new t1101InBlock { shcode = symbol }
		});

		if (response is null || response.t1101OutBlock is null) return ReturnErrorResult<OrderBook>(nameof(t1101), "response is null");

		List<MarketOrder> asks = [];
		List<MarketOrder> bids = [];
		for (int i = 0; i < 10; i++)
		{
			asks.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"offerho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"offerrem{(i + 1)}")),
			});

			bids.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"bidho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"bidrem{(i + 1)}"))
			});
		}

		return new ResponseResult<OrderBook>
		{
			Broker = Brkr.LS,
			Typ = MessageType.MKT,
			Info = new OrderBook
			{
				TimeTaken = response.t1101OutBlock.hotime.ToTime(),
				Ask = asks,
				Bid = bids,
				AskAgg = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"offer")),
				BidAgg = Convert.ToDecimal(response.t1101OutBlock.GetPropValue($"bid")),
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
		var exchangePrefix = exchange switch
		{
			Exchange.KRX => "",
			Exchange.NXT => "nxt_",
			_ => "unx_"
		};

		for (int i = 0; i < 10; i++)
		{
			asks.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"offerho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}offerrem{(i + 1)}"))
			});

			bids.Add(new MarketOrder
			{
				Seq = Convert.ToByte(i + 1),
				Price = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"bidho{(i + 1)}")),
				Amount = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}bidrem{(i + 1)}"))
			});
		}

		return new ResponseResult<OrderBook>
		{
			Broker = Brkr.LS,
			Typ = MessageType.MKT,
			Info = new OrderBook
			{
				TimeTaken = response.t8450OutBlock.hotime.ToTime(),
				Ask = asks,
				Bid = bids,
				AskAgg = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}offer")),
				BidAgg = Convert.ToDecimal(response.t8450OutBlock.GetPropValue($"{exchangePrefix}bid")),
			}
		};
	}
	#endregion

	#region request marketExecution using t8407
	public async Task<ResponseResult<MarketExecution>> RequestMarketExecution(string symbol)
	{
		var response = await RequestMarketExecution(new string[] { symbol });
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
			var response = await RequestStandardAsync<t8407>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t8407InBlock = new t8407InBlock
				{
					nrec = symbols.Count(),
					shcode = string.Join("", symbols.Take(50))
				}
			});

			if (response.t8407OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(t8407), response.Message);

			var executions = new List<MarketExecution>();
			response.t8407OutBlock1.ForEach(f =>
			{
				executions.Add(new MarketExecution
				{
					TimeExecuted = DateTime.Now,
					Symbol = f.shcode,
					C = f.price,
					BasePrice = f.jnilclose,
					QuoteDaily = new Quote
					{
						C = f.price,
						O = f.open,
						H = f.high,
						L = f.low,
						V = f.volume,
						Turnover = f.value
					},
					VolumeExecuted = f.cvolume,
				});
			});

			return ReturnResults(executions, nameof(t8407));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(t8407), ex.Message);
		}
	}
	#endregion

	#region request marketExecutionHistory using t1301
	public async Task<ResponseResults<MarketExecution>> RequestMarketExecutionHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0)
	{
		try
		{
			var response = await RequestStandardAsync<t1301>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t1301InBlock = new t1301InBlock
				{
					shcode = symbol,
					starttime = begin,
					endtime = end,
					cvolume = Convert.ToInt64(baseVolume)
				}
			});

			if (response.t1301OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(t1301), response.Message);

			var marketExecutions = new List<MarketExecution>();
			response.t1301OutBlock1.ForEach(execution => marketExecutions.Add(new MarketExecution
			{
				TimeExecuted = execution.chetime.ToDateTime(),
				C = execution.price,
				BasePrice = execution.price + execution.change * (Convert.ToInt32(execution.sign) > 3 ? 1 : -1),
				VolumeExecuted = execution.cvolume,
				QuoteDaily = new Quote
				{
					V = execution.volume,
				},
			}));

			return ReturnResults(marketExecutions, nameof(t1301));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(t1301), ex.Message);
		}
	}
	#endregion

	#region request sectors using t1531
	public async Task<ResponseResults<Sector>> RequestSectors(string code = "", string name = "")
	{
		try
		{
			var response = await RequestStandardAsync<t1531>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1531InBlock = new t1531InBlock
				{
					tmname = name,
					tmcode = code
				}
			});

			if (response.t1531OutBlock.Count == 0) return ReturnResults<Sector>([], nameof(t1531), response.Message);

			var sectors = new List<Sector>();
			response.t1531OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.tmcode,
				Name = sector.tmname,
				Diff = Convert.ToDecimal(sector.avgdiff)
			}));

			return ReturnResults(sectors, nameof(t1531));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Sector>(nameof(t1531), ex.Message);
		}
	}
	#endregion

	#region request sectors by equity using t1532
	public async Task<ResponseResults<Sector>> RequestSectorsByEquity(string symbol)
	{
		try
		{
			var response = await RequestStandardAsync<t1532>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1532InBlock = new t1532InBlock
				{
					shcode = symbol
				}
			});

			if (response.t1532OutBlock.Count == 0) return ReturnResults<Sector>([], nameof(t1532), response.Message);

			var sectors = new List<Sector>();
			response.t1532OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.tmcode,
				Name = sector.tmname,
				Diff = Convert.ToDecimal(sector.avgdiff)
			}));

			return ReturnResults(sectors, nameof(t1532));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<Sector>(nameof(t1532), ex.Message);
		}
	}
	#endregion

	#region request equities by sector using t1537
	public async Task<ResponseResults<MarketExecution>> RequestEquitiesBySector(string sectorCode)
	{
		try
		{
			var response = await RequestStandardAsync<t1537>(LsEndpoint.EquitySector.ToDescription(), new
			{
				t1537InBlock = new t1537InBlock
				{
					tmcode = sectorCode
				}
			});

			if (response.t1537OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(t1537), response.Message);

			var equities = new List<MarketExecution>();
			response.t1537OutBlock1.ForEach(equity => equities.Add(new MarketExecution
			{
				Symbol = equity.shcode,
				QuoteDaily = new Quote
				{
					O = Convert.ToDecimal(equity.open),
					C = Convert.ToDecimal(equity.price),
					H = Convert.ToDecimal(equity.high),
					L = Convert.ToDecimal(equity.low),
				},
				C = Convert.ToDecimal(equity.price),
				BasePrice = Convert.ToDecimal(equity.price) - Convert.ToDecimal(equity.change) * (DeclineCodes.Contains(equity.sign) ? -1 : 1)
			}));

			return ReturnResults(equities, nameof(t1537));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(t1537), ex.Message);
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
			return ReturnErrorResult<QuotePack<T>>("QUOTE", ex.Message);
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

		if (typeof(T) != typeof(Quote)) return ReturnErrorResult<QuotePack<T>>(nameof(t8411), "Invalid type parameter for RequestPricePackTick", "type mismatch");

		if (response.t8411OutBlock1.Count == 0) return ReturnResult<QuotePack<T>>(new() { PrimaryList = [] }, nameof(t8410), response.Message);

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
		List<t8410OutBlock1> list = [];
		var nextKey = string.Empty;
		var ctsDate = string.Empty;
		do
		{
			var response = await RequestContinuousAsync<t8410>(LsEndpoint.EquityChart.ToDescription(), new
			{
				t8410InBlock = new t8410InBlock
				{
					shcode = request.Symbol,
					gubun = request.TimeIntervalUnit switch
					{
						IntervalUnit.Day => "2",
						IntervalUnit.Week => "3",
						IntervalUnit.Month => "4",
						_ => "5"
					},
					qrycnt = 500,
					sdate = request.DateTimeBegin.ToString("yyyyMMdd"),
					edate = request.DateTimeEnd.ToString("yyyyMMdd"),
					cts_date = ctsDate,
				}
			}, nextKey);

			if (response.t8410OutBlock1.Count == 0)
			{
				nextKey = string.Empty;
				break;
			}

			list.InsertRange(0, response.t8410OutBlock1);
			nextKey = response.NextKey;
			ctsDate = response.t8410OutBlock.cts_date;
		} while (!string.IsNullOrEmpty(nextKey));

		quotes.Capacity = list.Count;
		list.ForEach(f =>
		{
			quotes.Add(new Quote
			{
				T = $"{f.date}".ToDateTime(),
				O = f.open,
				H = f.high,
				L = f.low,
				C = f.close,
				V = f.jdiff_vol,
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
				List = new List<SearchFilter>()
			};

			var response = await RequestStandardAsync<t1866>(LsEndpoint.EquitySearch.ToDescription(), new
			{
				t1866InBlock = new t1866InBlock
				{
					user_id = AccountInfo.ID,
				}
			});

			if (response.t1866OutBlock1.Count == 0) return ReturnResults<SearchFilter>([], nameof(t1866), response.Message);

			var filters = new List<SearchFilter>();
			response.t1866OutBlock1.ForEach(filter => filters.Add(new SearchFilter
			{
				Group = filter.group_name,
				ID = filter.query_index,
				Query = filter.query_name
			}));

			return ReturnResults(filters, nameof(t1866));
		}
		catch (Exception ex)
		{
			return ReturnResults<SearchFilter>([], nameof(t1866), ex.Message);
		}
	}

	public async Task<ResponseResults<MarketExecution>> RequestEquitiesByFilter(string query)
	{
		try
		{
			var response = await RequestStandardAsync<t1859>(LsEndpoint.EquitySearch.ToDescription(), new
			{
				t1859InBlock = new t1859InBlock
				{
					query_index = query
				}
			});

			if (response.t1859OutBlock1.Count == 0) return ReturnResults<MarketExecution>([], nameof(t1859), response.Message);

			var executions = new List<MarketExecution>();
			response.t1859OutBlock1.ForEach(execution => executions.Add(new MarketExecution
			{
				Symbol = execution.shcode,
				C = execution.price,
				BasePrice = execution.price - execution.change * (DeclineCodes.Contains(execution.sign) ? -1 : 1),
				VolumeExecuted = execution.volume,
			}));

			return ReturnResults(executions, nameof(t1859));
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>(nameof(t1859), ex.Message);
		}
	} 
	#endregion

}
