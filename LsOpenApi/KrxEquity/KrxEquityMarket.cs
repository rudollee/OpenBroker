using OpenBroker.Models;
using OpenBroker;
using RestSharp;
using LsOpenApi.Models;
using System.Text.Json;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IMarket, IMarketKrxEquity
{
	public EventHandler<ResponseResult<MarketContract>> MarketContracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public EventHandler<ResponseResult<News>> NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>> MarketPaused { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await Subscribe("NWS", "NWS001", connecting);

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

	public Task<ResponseResults<Instrument>> RequestInstruments(int option) => throw new NotImplementedException();

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

	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
}
