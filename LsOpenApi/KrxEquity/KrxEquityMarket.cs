using OpenBroker.Models;
using OpenBroker;
using RestSharp;
using LsOpenApi.Models;
using System.Text.Json;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IMarket, IMarketKrxEquity
{
	public EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => await SubscribeAsync("S3_", symbol, connecting);
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => await SubscribeAsync("VI_", symbol);
	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await SubscribeAsync("NWS", "NWS001", connecting);

	public Task<ResponseResults<Instrument>> RequestInstruments(int option) => throw new NotImplementedException();

	#region request news using t3102
	public async Task<ResponseResult<News>> RequestNews(string id)
	{
		var client = new RestClient($"{host}/stock/investinfo");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t3102)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t3102InBlock = new t3102InBlock
			{
				sNewsno = id
			}
		}));

		try
		{
			var response = await client.PostAsync<t3102>(request) ?? new t3102();
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
			};
		}
	}
	#endregion

	#region request equity list using t8436
	public async Task<ResponseResults<Equity>> RequestEquityList(int option = 0)
	{
		var client = new RestClient($"{host}/stock/etc");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t8436)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t8436InBlock = new t8436InBlock
			{
				gubun = "0"
			}
		}));

		try
		{
			var response = await client.PostAsync<t8436>(request) ?? new t8436();

			if (!response.t8436OutBlock.Any()) return new ResponseResults<Equity>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
				List = new List<Equity>()
			};

			var equities = new List<Equity>();
			foreach (var equity in response.t8436OutBlock.Where(w => new string[] { "01", "03" }.Contains(w.bu12gubun)))
			{
				equities.Add(new Equity
				{
					Symbol = equity.shcode,
					Section = equity.gubun == "1" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ,
					NameOfficial = equity.hname,
				});
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
	#endregion

	#region request equity ipo list using t1403
	public async Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end)
	{
		var client = new RestClient($"{host}/stock/etc");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t1403)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t1403InBlock = new t1403InBlock
			{
				gubun = "0",
				styymm = begin.ToString("yyyyMM"),
				enyymm = end.ToString("yyyyMM"),
			}
		}));

		try
		{
			var response = await client.PostAsync<t1403>(request) ?? new t1403();
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

	#region request equity complex using t1102
	public async Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol)
	{
		var client = new RestClient($"{host}/stock/market-data");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t1102)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t1102InBlock = new t1102InBlock
			{
				shcode = symbol
			}
		}));

		try
		{
			var response = await client.PostAsync<t1102>(request) ?? new t1102();

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
					BasePrice = response.t1102OutBlock.recprice,
					C = response.t1102OutBlock.price,
					O = response.t1102OutBlock.open,
					H = response.t1102OutBlock.high,
					L = response.t1102OutBlock.low,
					V = response.t1102OutBlock.volume,
					TimeContract = DateTime.Now
				},
				DiscardStatus = DiscardStatus.TRADABLE,
				TradingInfo = new EquityPack.TradingData
				{
					MarginRate = response.t1102OutBlock.jkrate,
				}
			};

			return new ResponseResult<EquityPack>
			{
				Info = equity,
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
		var client = new RestClient($"{host}/stock/market-data");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t8407)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t8407InBlock = new t8407InBlock
			{
				nrec = symbols.Count(),
				shcode = string.Join("", symbols)
			}
		}));

		try
		{
			var response = await client.PostAsync<t8407>(request) ?? new t8407();
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
					Symbol = f.shcode,
					C = f.price,
					BasePrice = f.jnilclose,
					V = f.volume,
					TimeContract = DateTime.Now,
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
}
