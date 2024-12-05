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

			if (now.TimeOfDay < new TimeSpan(8, 55, 00)) return false;
			if (now.TimeOfDay > new TimeSpan(16, 00, 00)) return false;

			return true;
		}
	}

	public EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Dictionary<string, Equity> Equities { get; set; } = new();

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "")
	{
		if (string.IsNullOrWhiteSpace(subscriber)) subscriber = "SYS";

		if (symbol == "USD") return await SubscribeAsync(subscriber, "CUR", symbol.PadRight(6, ' '), connecting);

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

		return await SubscribeAsync(subscriber, Equities[symbol].Section == ExchangeSection.KOSPI ? "H1_" : "HA_", symbol, connecting);
	}

	public async Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => await SubscribeAsync("SYS", "VI_", symbol);
	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await SubscribeAsync("SYS", "NWS", "NWS001", connecting);

	public Task<ResponseResults<Instrument>> RequestInstruments(int option) => throw new NotImplementedException();

	#region request news using t3102
	public async Task<ResponseResult<News>> RequestNews(string id)
	{
		var response = await RequestStandardAsync<t3102>(LsEndpoint.EquityInfo.ToDescription(), new
		{
			t3102InBlock = new t3102InBlock
			{
				sNewsno = id
			}
		});

		try
		{
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
		var response = await RequestStandardAsync<t8436>(LsEndpoint.EquityEtc.ToDescription(), new
		{
			t8436InBlock = new t8436InBlock
			{
				gubun = "0"
			}
		});

		try
		{
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
		var response = await RequestStandardAsync<t8436>(LsEndpoint.EquityEtc.ToDescription(), new
		{
			t8436InBlock = new t8436InBlock
			{
				gubun = "0"
			}
		});

		try
		{
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
		var response = await RequestStandardAsync<t1403>(LsEndpoint.EquityEtc.ToDescription(), new
		{
			t1403InBlock = new t1403InBlock
			{
				gubun = "0",
				styymm = begin.ToString("yyyyMM"),
				enyymm = end.ToString("yyyyMM"),
			}
		});

		try
		{
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
		var response = await RequestStandardAsync<t1102>(LsEndpoint.EquityMarketData.ToDescription(), new
		{
			t1102InBlock = new t1102InBlock
			{
				shcode = symbol
			}
		});

		try
		{
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
	public async Task<ResponseResults<MarketContract>> RequestMarketContract(List<string> symbols)
	{
		var response = await RequestStandardAsync<t8407>(LsEndpoint.EquityMarketData.ToDescription(), new
		{
			t8407InBlock = new t8407InBlock
			{
				nrec = symbols.Count(),
				shcode = string.Join("", symbols)
			}
		});

		try
		{
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
					MoneyAcc = f.value * 1000000
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
		var response = await RequestStandardAsync<t1301>("stock/market-data", new
		{
			t1301InBlock = new t1301InBlock
			{
				shcode = symbol,
				starttime = begin,
				endtime = end,
				cvolume = Convert.ToInt64(baseVolume)
			}
		});

		try
		{
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
		var response = await RequestStandardAsync<t1531>(LsEndpoint.EquitySector.ToDescription(), new
		{
			t1531InBlock = new t1531InBlock
			{
				tmname = name,
				tmcode = code
			}
		});

		try
		{
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

	#region request equities by sector using t1537
	public async Task<ResponseResults<PriceOHLC>> RequestEquitiesBySector(string sectorCode)
	{
		var response = await RequestStandardAsync<t1537>(LsEndpoint.EquitySector.ToDescription(), new
		{
			t1537InBlock = new t1537InBlock
			{
				tmcode = sectorCode
			}
		});

		try
		{
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
				BasePrice = Convert.ToDecimal(equity.price) - Convert.ToDecimal(equity.change) * (equity.sign == "2" ? 1 : -1)
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
}
