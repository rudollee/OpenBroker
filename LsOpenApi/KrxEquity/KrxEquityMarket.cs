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

			if (now.TimeOfDay < new TimeSpan(8, 30, 00)) return false;
			if (now.TimeOfDay > new TimeSpan(16, 45, 00)) return false;

			return true;
		}
	}

	public EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Dictionary<string, Equity> Equities { get; set; } = new();

	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		if (symbol == "USD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol == "JPYUSD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);
		else if (symbol.Contains('@')) return await SubscribeAsync(subscriber, "MK2", symbol.PadRight(16, ' '), connecting);

		if (!Equities.ContainsKey(symbol)) return new ResponseCore
		{
			Code = "NOT-FOUND",
			Message = "A requested Symbol have not found",
			StatusCode = Status.BAD_REQUEST,
		};

		return await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "S3_" : "K3_", symbol, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "")
	{
		if (!Equities.ContainsKey(symbol)) return new ResponseCore
		{
			Code = "NOT-FOUND",
			Message = "A requested Symbol have not found",
			StatusCode = Status.BAD_REQUEST,
		};

		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		var estimation = await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "YS3" : "YK3", symbol, connecting);
		if (estimation.StatusCode != Status.SUCCESS) return estimation;

		return await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "H1_" : "HA_", symbol, connecting);
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

			if (!response.t3102OutBlock1.Any()) return new ResponseResult<News>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = response.Code,
				Message = response.Message,
				Remark = $"{response.TrCode}: response failed"
			};

			var htmlString = string.Join("", response.t3102OutBlock1.Select(s => s.sBody)).Replace("t3102OutBlock1", "");

			return new ResponseResult<News>
			{
				Info = new News
				{
					Code = id,
					Title = response.t3102OutBlock2.sTitle,
					Body = htmlString,
					SymbolList = response.t3102OutBlock.Select(s => s.sJongcode).ToArray()
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<News>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception catch area"
			};
		}
	}
	#endregion

	#region request equity dictionary using t8436
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

			if (!response.t8436OutBlock.Any()) return new ResponseResults<Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
				List = new List<Equity>()
			};

			var equities = new List<Equity>();
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

			return new ResponseResults<Equity>
			{
				List = equities,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Equity>(),
			};
		}
	}

	public async Task<ResponseDictionary<string, Equity>> RequestEquityDictionary(int option = 0)
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

			if (!response.t8436OutBlock.Any()) return new ResponseDictionary<string, Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = response.Code,
				Message = "no data",
			};

			foreach (var instrument in response.t8436OutBlock.Where(w => new string[] { "01", "03" }.Contains(w.bu12gubun)))
			{
				Equities.Add(instrument.shcode, new Equity
				{
					Symbol = instrument.shcode,
					Section = instrument.gubun == "1" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
					NameOfficial = instrument.hname,
				});
			}

			return new ResponseDictionary<string, Equity>
			{
				Dic = Equities
			};

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

			if (!response.t1403OutBlock1.Any()) return new ResponseResults<Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
				List = new List<Equity>()
			};

			var equities = new List<Equity>();
			foreach (var equity in response.t1403OutBlock1)
			{
				equities.Add(new Equity
				{
					Symbol = equity.shcode,
					NameOfficial = equity.hname,
				});
			}

			return new ResponseResults<Equity>
			{
				List = equities,
				Remark = response.t1403OutBlock1.Select(s => s.date).Max() ?? string.Empty
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Equity>(),
			};
		}
	}
	#endregion

	#region request equity complex using t1101 & t1102
	public async Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol, bool needsOrderBook = false)
	{
		try
		{
			var response = await RequestStandardAsync<t1102>(LsEndpoint.EquityMarketData.ToDescription(), new
			{
				t1102InBlock = new t1102InBlock
				{
					shcode = symbol
				}
			});

			if (response.t1102OutBlock is null) return new ResponseResult<EquityPack>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data"
			};

			var equity = new EquityPack
			{
				Symbol = response.t1102OutBlock.shcode,
				NameOfficial = response.t1102OutBlock.hname,
				Section = response.t1102OutBlock.janginfo.Contains("KOSPI") ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
				PriceInfo = new PriceRate
				{
					Symbol = response.t1102OutBlock.shcode,
					TimeContract = DateTime.Now,
					BasePrice = response.t1102OutBlock.recprice,
					C = response.t1102OutBlock.price,
					O = response.t1102OutBlock.open,
					H = response.t1102OutBlock.high,
					L = response.t1102OutBlock.low,
					V = response.t1102OutBlock.volume,
					VolumeAcc = response.t1102OutBlock.volume,
					MoneyAcc = response.t1102OutBlock.value,
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
				var responseOrderbook = await RequestStandardAsync<t1101>(LsEndpoint.EquityMarketData.ToDescription(), new
				{
					t1101InBlock = new t1101InBlock
					{
						shcode = symbol
					}
				});

				if (responseOrderbook.t1101OutBlock is not null)
				{
					var orderbook = new OrderBook();
					var asks = new List<MarketOrder>();
					var bids = new List<MarketOrder>();
					for (int i = 0; i < 10; i++)
					{
						asks.Add(new MarketOrder
						{
							Seq = Convert.ToByte(i + 1),
							Price = Convert.ToDecimal(responseOrderbook.t1101OutBlock.GetPropValue($"offerho{(i + 1)}")),
							Amount = Convert.ToDecimal(responseOrderbook.t1101OutBlock.GetPropValue($"offerrem{(i + 1)}"))
						});

						bids.Add(new MarketOrder
						{
							Seq = Convert.ToByte(i + 1),
							Price = Convert.ToDecimal(responseOrderbook.t1101OutBlock.GetPropValue($"bidho{(i + 1)}")),
							Amount = Convert.ToDecimal(responseOrderbook.t1101OutBlock.GetPropValue($"bidrem{(i + 1)}"))
						});
					}

					equity.OrderBook = new OrderBook
					{
						Ask = asks,
						Bid = bids,
						AskAgg = responseOrderbook.t1101OutBlock.offer,
						BidAgg = responseOrderbook.t1101OutBlock.bid,
						TimeTaken = responseOrderbook.t1101OutBlock.hotime.ToTime()
					};
				}
			}

			return new ResponseResult<EquityPack>
			{
				Info = equity,
				Remark = "MoneyAgg multiple: M"
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<EquityPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message
			};
		}
	}
	#endregion

	#region request marketContract using t8407
	public async Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol)
	{
		var response = await RequestMarketContract(new string[] { symbol });
		if (!response.List.Any()) return new ResponseResult<MarketContract>
		{
			StatusCode = Status.NODATA,
			Message = response.Message,
			Code = response.Code,
			Remark = "no data"
		};

		return new ResponseResult<MarketContract>
		{
			Code = response.Code,
			Info = response.List.FirstOrDefault()
		};
	}

	public async Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols)
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

			if (response.t8407OutBlock1 is null) return new ResponseResults<MarketContract>
			{
				StatusCode = Status.NODATA,
				List = new List<MarketContract>(),
				Code = response.Code,
				Message = response.Message,
				Remark = "no data"
			};

			var contracts = new List<MarketContract>();
			response.t8407OutBlock1.ForEach(f =>
			{
				contracts.Add(new MarketContract
				{
					TimeContract = DateTime.Now,
					Symbol = f.shcode,
					C = f.price,
					BasePrice = f.jnilclose,
					V = f.cvolume,
					VolumeAcc = f.volume,
					MoneyAcc = f.value
				});
			});

			return new ResponseResults<MarketContract>
			{
				Code = response.Code,
				List = contracts,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<MarketContract>
			{
				StatusCode = Status.ERROR_OPEN_API,
				List = new List<MarketContract>(),
				Code = "ERROR",
				Message = ex.Message,
			};
		}
	}
	#endregion

	#region request marketContractHistory using t1301
	public async Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0)
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

			if (!response.t1301OutBlock1.Any()) return new ResponseResults<MarketContract>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data",
				List = new List<MarketContract>()
			};

			var marketContracts = new List<MarketContract>();
			response.t1301OutBlock1.ForEach(contract => marketContracts.Add(new MarketContract
			{
				TimeContract = (DateTime.Now.ToString("yyyyMMdd") + contract.chetime).ToDateTime(),
				C = contract.price,
				BasePrice = contract.price + contract.change * (Convert.ToInt32(contract.sign) > 3 ? 1 : -1),
				V = contract.cvolume,
				VolumeAcc = contract.volume,
			}));

			return new ResponseResults<MarketContract>
			{
				List = marketContracts,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<MarketContract>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<MarketContract>()
			};
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

			if (!response.t1531OutBlock.Any()) return new ResponseResults<Sector>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data",
				List = new List<Sector>()
			};

			var sectors = new List<Sector>();
			response.t1531OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.tmcode,
				Name = sector.tmname,
				Diff = Convert.ToDecimal(sector.avgdiff)
			}));

			return new ResponseResults<Sector> { List = sectors };
		}
		catch (Exception ex)
		{
			return new ResponseResults<Sector>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Sector>()
			};
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

			if (!response.t1532OutBlock.Any()) return new ResponseResults<Sector>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data",
				List = new List<Sector>()
			};

			var sectors = new List<Sector>();
			response.t1532OutBlock.ForEach(sector => sectors.Add(new Sector
			{
				Code = sector.tmcode,
				Name = sector.tmname,
				Diff = Convert.ToDecimal(sector.avgdiff)
			}));

			return new ResponseResults<Sector> { List = sectors };
		}
		catch (Exception ex)
		{
			return new ResponseResults<Sector>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Sector>()
			};
		}
	}
	#endregion

	#region request equities by sector using t1537
	public async Task<ResponseResults<PriceOHLC>> RequestEquitiesBySector(string sectorCode)
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

			if (!response.t1537OutBlock1.Any()) return new ResponseResults<PriceOHLC>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data",
				List = new List<PriceOHLC>()
			};

			var equities = new List<PriceOHLC>();
			response.t1537OutBlock1.ForEach(equity => equities.Add(new PriceOHLC
			{
				Symbol = equity.shcode,
				O = Convert.ToDecimal(equity.open),
				C = Convert.ToDecimal(equity.price),
				H = Convert.ToDecimal(equity.high),
				L = Convert.ToDecimal(equity.low),
				VolumeAcc = Convert.ToDecimal(equity.volume),
				BasePrice = Convert.ToDecimal(equity.price) - Convert.ToDecimal(equity.change) * (new string[] { "4", "5" }.Contains(equity.sign) ? -1 : 1)
			}));

			return new ResponseResults<PriceOHLC> { List = equities };
		}
		catch (Exception ex)
		{
			return new ResponseResults<PriceOHLC>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<PriceOHLC>()
			};
		}
	}
	#endregion

	#region request chart data by t8410, t8411, t8412
	public async Task<ResponseResult<PricePack>> RequestPricePack(PricePackRequest request) =>
		request.TimeIntervalUnit switch
		{
			IntervalUnit.Tick => await RequestPricePackTick(request),
			IntervalUnit.Minute => await RequestPricePackMinute(request),
			_ => await RequestPricePackX(request)
		};

	private async Task<ResponseResult<PricePack>> RequestPricePackTick(PricePackRequest request)
	{
		try
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

			if (!response.t8411OutBlock1.Any()) return new ResponseResult<PricePack>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data"
			};

			var priceInfo = new PriceRate
			{
				Symbol = response.t8411OutBlock.shcode,
				TimeContract = DateTime.UtcNow.AddHours(9),
				BasePrice = response.t8411OutBlock.jiclose,
				C = response.t8411OutBlock.diclose,
				O = response.t8411OutBlock.disiga,
				H = response.t8411OutBlock.dihigh,
				L = response.t8411OutBlock.dilow,
				HighLimit = response.t8411OutBlock.highend,
				LowLimit = response.t8411OutBlock.lowend,
			};

			var prices = new List<PriceOHLC>();
			response.t8411OutBlock1.ForEach(price => prices.Add(new PriceOHLC
			{
				TimeContract = (price.date + price.time).ToDateTime(),
				O = Convert.ToDecimal(price.open),
				C = Convert.ToDecimal(price.close),
				H = Convert.ToDecimal(price.high),
				L = Convert.ToDecimal(price.low),
				V = Convert.ToDecimal(price.jdiff_vol),
				BasePrice = priceInfo.BasePrice,
			}));

			// TODO : 수정주가 적용 여부

			return new ResponseResult<PricePack>
			{
				Info = new PricePack
				{
					Symbol = request.Symbol,
					TimeIntervalUnit = request.TimeIntervalUnit,
					TimeInterval = request.TimeInterval,
					PrimaryList = prices,
					SecondaryInfo = priceInfo
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<PricePack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception catch area"
			};
		}
	}

	private async Task<ResponseResult<PricePack>> RequestPricePackMinute(PricePackRequest request)
	{
		try
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

			if (!response.t8412OutBlock1.Any()) return new ResponseResult<PricePack>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data"
			};

			var priceInfo = new PriceRate
			{
				Symbol = response.t8412OutBlock.shcode,
				TimeContract = DateTime.UtcNow.AddHours(9),
				BasePrice = response.t8412OutBlock.jiclose,
				C = response.t8412OutBlock.diclose,
				O = response.t8412OutBlock.disiga,
				H = response.t8412OutBlock.dihigh,
				L = response.t8412OutBlock.dilow,
				HighLimit = response.t8412OutBlock.highend,
				LowLimit = response.t8412OutBlock.lowend,
			};

			var prices = new List<PriceOHLC>();
			response.t8412OutBlock1.ForEach(price => prices.Add(new PriceOHLC
			{
				TimeContract = (price.date + price.time).ToDateTime(),
				O = Convert.ToDecimal(price.open),
				C = Convert.ToDecimal(price.close),
				H = Convert.ToDecimal(price.high),
				L = Convert.ToDecimal(price.low),
				V = Convert.ToDecimal(price.jdiff_vol),
				BasePrice = priceInfo.BasePrice,
			}));

			// TODO : 수정주가 적용 여부

			return new ResponseResult<PricePack>
			{
				Info = new PricePack
				{
					Symbol = request.Symbol,
					TimeIntervalUnit = request.TimeIntervalUnit,
					TimeInterval = request.TimeInterval,
					PrimaryList = prices,
					SecondaryInfo = priceInfo
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<PricePack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception catch area"
			};
		}
	}

	private async Task<ResponseResult<PricePack>> RequestPricePackX(PricePackRequest request)
	{
		try
		{
			var response = await RequestStandardAsync<t8410>(LsEndpoint.EquityChart.ToDescription(), new
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
				}
			});

			if (!response.t8410OutBlock1.Any()) return new ResponseResult<PricePack>
			{
				StatusCode = Status.NODATA,
				Message = response.Message,
				Code = response.Code,
				Remark = "no data"
			};

			var prices = new List<PriceOHLC>();
			response.t8410OutBlock1.ForEach(price => prices.Add(new PriceOHLC
			{
				TimeContract = price.date.ToDateTime(),
				O = Convert.ToDecimal(price.open),
				C = Convert.ToDecimal(price.close),
				H = Convert.ToDecimal(price.high),
				L = Convert.ToDecimal(price.low),
				V = Convert.ToDecimal(price.jdiff_vol),
				BasePrice = Convert.ToDecimal(response.t8410OutBlock.jiclose),
			}));

			// TODO : 수정주가 적용 여부

			return new ResponseResult<PricePack>
			{
				Info = new PricePack
				{
					PrimaryList = prices,
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<PricePack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception catch area"
			};
		}
	}
	#endregion
}
