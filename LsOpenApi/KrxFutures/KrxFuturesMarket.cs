using System.Collections.Generic;
using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IMarket, IMarketKrx
{
	private readonly string _date8txt = "yyyyMMdd";
	public Dictionary<string, Instrument> Instruments { get; set; } = [];

	public EventHandler<ResponseResult<MarketExecution>>? MarketExecuted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }
	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();

	#region request market execution - t2101/t8456, t8402
	public async Task<ResponseResult<MarketExecution>> RequestMarketExecution(string symbol)
	{
		if (_futuresCodes.Contains(symbol[..1]) && !_k200OrFx.Contains(symbol.Substring(1, 2)))
		{
			return await RequestMarketExecutionSsf(symbol);
		}

		if (symbol[(symbol.Length - 1)..] == "N") return await RequestMarketExecutionExtended(symbol[..8]);

		try
		{
			var response = await RequestStandardAsync<t2101>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t2101InBlock = new T2101InBlock { Focode = symbol }
			});

			if (response is null || response.T2101OutBlock is null) return ReturnResult<MarketExecution>(new(), nameof(t2101), response?.Message ?? string.Empty);

			var quote = new MarketExecution
			{
				Symbol = symbol,
				C = response.T2101OutBlock.Price,
				QuoteDaily = new Quote
				{
					T = DateTime.Now,
					BasePrice = response.T2101OutBlock.Jnilclose,
                    C = response.T2101OutBlock.Price,
					O = response.T2101OutBlock.Open,
					H = response.T2101OutBlock.High,
					L = response.T2101OutBlock.Low,
					V = response.T2101OutBlock.Volume,
					Turnover = response.T2101OutBlock.Value,
				},
				BasePrice = response.T2101OutBlock.Jnilclose,
				VolumeExecuted = response.T2101OutBlock.Volume,
			};

			var result = ReturnResult(quote);
			result.ExtraData = new()
			{
				{ "OI", response.T2101OutBlock.Mgjv }, // open interest
				{ "UNDERLYINGPRICE", response.T2101OutBlock.Price - response.T2101OutBlock.Sbasis }, // Underlying Asset Price
			};

			return result;
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<MarketExecution>(symbol, ex.Message);
		}
	}

	private async Task<ResponseResult<MarketExecution>> RequestMarketExecutionExtended(string symbol)
	{
		try
		{
			var response = await RequestStandardAsync<t8456>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8456InBlock = new T8456InBlock { Focode = symbol }
			});

			if (response is null || response.T8456OutBlock is null) return ReturnErrorResult<MarketExecution>(symbol, response?.Message ?? "no data");

			var quote = new MarketExecution
			{
				Symbol = symbol,
				C = response.T8456OutBlock.Price,
				QuoteDaily = new Quote
				{
					T = DateTime.Now,
					BasePrice = response.T8456OutBlock.Jnilclose,
					C = response.T8456OutBlock.Price,
					O = response.T8456OutBlock.Open,
					H = response.T8456OutBlock.High,
					L = response.T8456OutBlock.Low,
					V = response.T8456OutBlock.Volume,
					Turnover = response.T8456OutBlock.Value,
				},
				BasePrice = response.T8456OutBlock.Jnilclose,
				VolumeExecuted = response.T8456OutBlock.Volume,
			};

			var result = ReturnResult(quote);
			result.ExtraData = new()
			{
				{ "OI", response.T8456OutBlock.Mgjv }, // open interest
				{ "UNDERLYINGPRICE", response.T8456OutBlock.Price - response.T8456OutBlock.Sbasis }, // Underlying Asset Price
			};

			return result;
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<MarketExecution>(symbol, ex.Message);
		}
	}

	private async Task<ResponseResult<MarketExecution>> RequestMarketExecutionSsf(string symbol)
	{
		try
		{
			var response = await RequestStandardAsync<t8402>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8402InBlock = new t8402InBlock { focode = symbol }
			});

			if (response is null || response.t8402OutBlock is null) return ReturnErrorResult<MarketExecution>(symbol, response?.Message ?? "no data");

			var quote = new MarketExecution
			{
				TimeExecuted = DateTime.Now,
				C = response.t8402OutBlock.price,
				QuoteDaily = new Quote
				{
					O = response.t8402OutBlock.open,
					H = response.t8402OutBlock.high,
					L = response.t8402OutBlock.low,
					V = response.t8402OutBlock.volume,
					BasePrice = response.t8402OutBlock.jnilclose,
					Turnover = response.t8402OutBlock.value,
				},
				BasePrice = response.t8402OutBlock.jnilclose,
			};

			var result = ReturnResult(quote);
			result.ExtraData = new()
			{
				{ "OI", response.t8402OutBlock.mgjv }, // open interest
				{ "UNDERLYINGPRICE", response.t8402OutBlock.baseprice }, // Underlying Asset Price
			};

			return result;
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<MarketExecution>(symbol, ex.Message);
		}
	}
	#endregion

	#region request market execution - multiple instruments - t8434
	public async Task<ResponseResults<MarketExecution>> RequestMarketExecution(IEnumerable<string> symbols)
	{
		if (!symbols.Any()) return new ResponseResults<MarketExecution>
		{
			StatusCode = Status.BAD_REQUEST,
			Message = "no requested symbol",
			List = []
		};

		if (symbols.Count() > 50) return new ResponseResults<MarketExecution>
		{
			StatusCode = Status.BAD_REQUEST,
			Message = "Max request of symbols are 50",
			List = []
		};

		try
		{
			var response = await RequestStandardAsync<t8434>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8434InBlock = new t8434InBlock
				{
					qrycnt = symbols.Count(),
					focode = string.Join("", symbols.Take(50))
				}
			});

			if (response is null || response.t8434OutBlock1.Count == 0) 
			{
				return ReturnErrorResults<MarketExecution>(response?.Code ?? "ERR", response?.Message ?? "response is null");
			}

			List<MarketExecution> executions = [];
			response.t8434OutBlock1.ForEach(execution =>
			{
				executions.Add(new MarketExecution
				{
					TimeExecuted = DateTime.Now,
					Symbol = execution.focode,
					C = execution.price,
					VolumeExecuted = execution.checnt,
					BasePrice = execution.price - execution.change * (DeclineCodes.Contains(execution.sign) ? -1 : 1),
					QuoteDaily = new Quote
					{
						C = execution.price,
						V = execution.volume,
					}
				});
			});

			return ReturnResults(executions);
		}
		catch (Exception ex)
		{
			return ReturnErrorResults<MarketExecution>("ERR-CATch", ex.Message);
		}
	} 
	#endregion

	public Task<ResponseResults<MarketExecution>> RequestMarketExecutionHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();

	#region request orderbook - t2105(t8457)/t8403
	public async Task<ResponseResult<OrderBook>> RequestOrderbook(string symbol)
	{
		if (_futuresCodes.Contains(symbol[..1]) && !_k200OrFx.Contains(symbol.Substring(1, 2)))
		{
			return await RequestOrderbookSSFAsync(symbol);
		}

		try
		{
			var isRegular = symbol.Length != 9;
			var tr = isRegular ? typeof(t2105) : typeof(t8457);

			t2105 response = new();
			if (isRegular)
			{
				response = await RequestStandardAsync<t2105>(LsEndpoint.FuturesMarketData.ToDescription(), new
				{
					t2105InBlock = new t2105InBlock { shcode = symbol }
				});
			}
			else
			{
				var responseExt = await RequestStandardAsync<t8457>(LsEndpoint.FuturesMarketData.ToDescription(), new
				{
					t8457InBlock = new t2105InBlock { shcode = symbol[..8] }
				});

				response.t2105OutBlock = responseExt.t8457OutBlock;
			}

			if (response is null || response.t2105OutBlock is null) return ReturnErrorResult<OrderBook>(symbol, response?.Message ?? "no data");

			IList<MarketOrder> asks = [];
			IList<MarketOrder> bids = [];
			for (int i = 0; i < 5; i++)
			{
				asks.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"offerho{i + 1}")),
					Amount = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"offerrem{i + 1}")),
					AmountGroup = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"dcnt{i + 1}"))
				});
				bids.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"bidho{i + 1}")),
					Amount = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"bidrem{i + 1}")),
					AmountGroup = Convert.ToDecimal(response.t2105OutBlock.GetPropValue($"scnt{i + 1}"))
				});
			}

			return ReturnResult(new OrderBook
			{
				Symbol = symbol,
				TimeTaken = response.t2105OutBlock.time.ToTime(),
				C = response.t2105OutBlock.price,
				BasePrice = response.t2105OutBlock.jnilclose,
				Ask = asks,
				Bid = bids,
				AskAgg = response.t2105OutBlock.dvol,
				BidAgg = response.t2105OutBlock.svol,
			});
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<OrderBook>("CATCH", ex.Message);
		}
	}

	private async Task<ResponseResult<OrderBook>> RequestOrderbookSSFAsync(string symbol)
	{
		try
		{
			var response = await RequestStandardAsync<t8403>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8403InBlock = new t2105InBlock { shcode = symbol }
			});

			if (response is null || response.t8403OutBlock is null) return ReturnErrorResult<OrderBook>(symbol, response?.Message ?? "no data");

			IList<MarketOrder> asks = [];
			IList<MarketOrder> bids = [];
			for (int i = 0; i < 10; i++)
			{
				asks.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"offerho{(i + 1)}")),
					Amount = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"offerrem{(i + 1)}")),
					AmountGroup = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"dcnt{(i + 1)}"))
				});

				bids.Add(new MarketOrder
				{
					Seq = Convert.ToByte(i + 1),
					Price = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"bidho{(i + 1)}")),
					Amount = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"bidrem{(i + 1)}")),
					AmountGroup = Convert.ToDecimal(response.t8403OutBlock.GetPropValue($"scnt{(i + 1)}"))
				});
			}

			return ReturnResult(new OrderBook
			{
				Symbol = symbol,
				TimeTaken = response.t8403OutBlock.time.ToTime(),
				C = response.t8403OutBlock.price,
				BasePrice = response.t8403OutBlock.jnilclose,
				Ask = asks,
				Bid = bids,
				AskAgg = response.t8403OutBlock.dvol,
				BidAgg = response.t8403OutBlock.svol,
			});
		}
		catch (Exception ex)
		{
			return ReturnErrorResult<OrderBook>(symbol, ex.Message);
		}
	} 
	#endregion

	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();

	#region request Price Pack using t8415
	public async Task<ResponseResult<QuotePack<T>>> RequestPricePack<T>(QuoteRequest request) where T : Quote
	{
		if (request.DateTimeBegin > request.DateTimeEnd) return new ResponseResult<QuotePack<T>>
		{
			Broker = Brkr.LS,
			StatusCode = Status.BAD_REQUEST,
			Message = "period error"
		};

		if (request.TimeIntervalUnit == IntervalUnit.Minute)
		{
			try
			{
				return await RequestPricePackMinutes<T>(request);
			}
			catch (Exception ex)
			{
				return new ResponseResult<QuotePack<T>>
				{
					Broker = Brkr.LS,
					StatusCode = Status.INTERNALSERVERERROR,
					Message = ex.Message,
				};
			}
		}

		List<QuoteExt> quotes = [];
		try
		{
			List<t8416OutBlock1> list = [];
			var nextKey = string.Empty;
			var ctsDate = string.Empty;
			do
			{
				var response = await RequestContinuousAsync<t8416>(LsEndpoint.FuturesChart.ToDescription(), new
				{
					t8416InBlock = new t8416InBlock
					{
						shcode = request.Symbol,
						gubun = request.TimeIntervalUnit switch
						{
							IntervalUnit.Day => "2",
							IntervalUnit.Week => "3",
							IntervalUnit.Month => "4",
							_ => "2"
						},
						qrycnt = request.TimeInterval,
						sdate = request.Amount < 500 ? request.DateTimeBegin.ToString(_date8txt) : " ",
						edate = request.DateTimeEnd.ToString(_date8txt),
						cts_date = ctsDate
					}
				}, nextKey);

				if (response is null || !response.t8416OutBlock1.Any()) break;

				list.AddRange(response.t8416OutBlock1);
				nextKey = response.NextKey;
				ctsDate = response.t8416OutBlock.cts_date;
			} while (!string.IsNullOrEmpty(nextKey) && nextKey != "0" && !string.IsNullOrEmpty(ctsDate));

			quotes.Capacity = list.Count;
			list.ForEach(f =>
			{
				quotes.Add(new QuoteExt
				{
					T = $"{f.date}000000".ToDateTime(),
					O = f.open,
					H = f.high,
					L = f.low,
					C = f.close,
					V = f.jdiff_vol,
					OI = f.openyak,
				});
			});

			return new ResponseResult<QuotePack<T>>
			{
				Info = new QuotePack<T>
				{
					Symbol = request.Symbol,
					PrimaryList = quotes as List<T> ?? [],
					TimeInterval = request.TimeInterval,
					TimeIntervalUnit = request.TimeIntervalUnit,
				},
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<QuotePack<T>>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
			};
		}
	}

	private async Task<ResponseResult<QuotePack<T>>> RequestPricePackMinutes<T>(QuoteRequest request) where T : Quote
	{
		List<Quote> quotes = [];
		List<t8415OutBlock1> list = [];
		var nextKey = string.Empty;
		var ctsDate = string.Empty;
		do
		{
			var response = await RequestContinuousAsync<t8415>(LsEndpoint.FuturesChart.ToDescription(), new
			{
				t8415InBlock = new t8415InBlock
				{
					shcode = request.Symbol,
					ncnt = request.TimeInterval,
					sdate = request.Amount < 500 ? request.DateTimeBegin.ToString(_date8txt) : " ",
					edate = request.DateTimeEnd.ToString(_date8txt),
					cts_date = ctsDate
				}
			}, nextKey);

			if (response is null || !response.t8415OutBlock1.Any()) break;

			list.AddRange(response.t8415OutBlock1);
			nextKey = response.NextKey;
			ctsDate = response.t8415OutBlock.cts_date;
		} while (!string.IsNullOrEmpty(nextKey));

		quotes.Capacity = list.Count;
		list.ForEach(f =>
		{
			quotes.Add(new Quote
			{
				T = $"{f.date}{f.time}".ToDateTime(),
				O = f.open,
				H = f.high,
				L = f.low,
				C = f.close,
				V = f.jdiff_vol,
			});
		});

		return new ResponseResult<QuotePack<T>>
		{
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

	#region request SSF instruments using t8401
	public async Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option = 0)
	{
		try
		{
			var response = await RequestStandardAsync<t8401>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8401InBlock = new t8401InBlock { }
			});

			if (!response.t8401OutBlock.Any()) return new ResponseDictionary<string, Instrument>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
				Dic = new Dictionary<string, Instrument>(),
			};

			List<MMDAQ91200OutBlock2> margins = new();
			var nextKey = string.Empty;
			do
			{
				var responseMargin = await RequestContinuousAsync<MMDAQ91200>(LsEndpoint.FuturesEtc.ToDescription(), new
				{
					MMDAQ91200InBlock1 = new MMDAQ91200InBlock1 { },
				}, nextKey);

				margins.AddRange(responseMargin.MMDAQ91200OutBlock2);
				nextKey = responseMargin.NextKey;
			} while (!string.IsNullOrEmpty(nextKey));

			Instruments.Clear();
			response.t8401OutBlock.ForEach(instrument =>
			{
				var id = instrument.shcode.ToKrxProductCode();
				var marginInfo = margins.FirstOrDefault(f => $"{f.IsuSmclssCode.Substring(1)}" == id);
				Instruments.Add(instrument.shcode, new Instrument
				{
					Symbol = instrument.shcode,
					Product = id,
					InstrumentName = instrument.hname,
					SymbolUnderlying = instrument.basecode.Substring(1),
					Margin = marginInfo is null ? 0 : marginInfo.OnePrcntrOrdMgn * 0.1m,
					MarginRate = marginInfo is null ? 0.00m : marginInfo.CsgnMgnrt * 0.01m,
				});
			});

			return new ResponseDictionary<string, Instrument>
			{
				Broker = Brkr.LS,
				Typ = MessageType.MKT,
				Dic = Instruments,
			};
		}
		catch (Exception ex)
		{
			return new ResponseDictionary<string, Instrument>
			{
				Broker = Brkr.LS,
				Code = "OPENAPI-ERR",
				Message = ex.Message,
			};
		}
	} 
	#endregion

	#region request Option Pack using t2301
	public async Task<ResponseResult<OptionPack>> RequestOptionPack(string expiry6 = "", OptionsType typ = OptionsType.G)
	{
		try
		{
			var expiry = expiry6.Length == 6 ? expiry6 : DateOnly.FromDateTime(DateTime.Now).ToKrxExpiry().ToString("yyyyMM");
			var response = await RequestStandardAsync<t2301>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t2301InBlock = new t2301InBlock
				{
					yyyymm = expiry,
					gubun = typ.ToString(),
				},
			});

			if (!response.t2301OutBlock1.Any()) return new ResponseResult<OptionPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
			};

			var calls = new List<OptionsInfo>();
			response.t2301OutBlock1.ForEach(option => calls.Add(new OptionsInfo
			{
				Currency = Currency.KRW,
				Symbol = option.optcode,
				Product = option.optcode.ToKrxProductCode(),
				InstrumentType = InstrumentType.Call,
				Strike = Math.Floor(option.actprice).ToString(),
				QuoteInfo = new()
				{
					C = option.price,
					O = option.open,
					H = option.high,
					L = option.low,
					V = option.volume,
					BasePrice = option.price + option.change * (Convert.ToInt32(option.sign) > 3 ? 1 : -1),
					HighLimit = option.iv,
					Turnover = option.value,
				},
				OI = option.mgjv,
				Precision = 2,
				Greek = new()
				{
					Delta = option.delt,
					Gamma = option.gama,
					Theta = option.ceta,
				}
			}));

			var puts = new List<OptionsInfo>();
			response.t2301OutBlock2.ForEach(option => puts.Add(new OptionsInfo
			{
				Currency = Currency.KRW,
				Symbol = option.optcode,
				Product = option.optcode.ToKrxProductCode(),
				InstrumentType = InstrumentType.Put,
				Strike = Math.Floor(option.actprice).ToString(),
				QuoteInfo = new()
				{
					C = option.price,
					O = option.open,
					H = option.high,
					L = option.low,
					V = option.volume,
					BasePrice = option.price + option.change * (Convert.ToInt32(option.sign) > 3 ? 1 : -1),
					HighLimit = option.iv,
					Turnover = option.value,
				},
				OI = option.mgjv,
				Precision = 2,
				Greek = new()
				{
					Delta = option.delt,
					Gamma = option.gama,
					Theta = option.ceta,
				}
			}));

			return new ResponseResult<OptionPack>
			{
				Broker = Brkr.LS,
				Info = new OptionPack
				{
					ExpiryLeft = Convert.ToInt32(response.t2301OutBlock.jandatecnt),
					Calls = calls,
					Puts = puts,
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<OptionPack>
			{
				Broker = Brkr.LS,
				Code = "OPENAPI-ERR",
				Message = ex.Message,
			};
		}
	}

	#endregion

	public async Task<ResponseCore> SubscribeMarketExecution(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		string trCode = string.Empty;
		if (_futuresCodes.Contains(symbol[..1]))
		{
			trCode = symbol.Substring(1, 2) switch
			{
				"01" => nameof(FC0),
				"05" => nameof(FC0),
				//"07" => "EU1",
				"75" => nameof(FC0),
				_ => nameof(JC0)
			};
		}
		else trCode = "OC0";

		if (trCode == nameof(FC0)) await SubscribeAsync(subscriber, nameof(DC0), symbol, connecting); // 야간파생 추가

		return await SubscribeAsync(subscriber, trCode, symbol, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(symbol)) return ReturnError(symbol, "no symbol");

		string trCode = string.Empty;
		if (_futuresCodes.Contains(symbol[..1]))
		{
			trCode = symbol.Substring(1, 2) switch
			{
				"01" => nameof(FH0),
				//"05" => "FC0",
				//"07" => "EU1",
				"75" => nameof(FH0),
				_ => nameof(JC0)
			};
		}
		else trCode = "OC0";

		if (trCode == nameof(FH0)) await SubscribeAsync(subscriber, nameof(DH0), symbol, connecting); // KRX야간파생 호가

		return await SubscribeAsync(subscriber, trCode, symbol, connecting);
	}

	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
