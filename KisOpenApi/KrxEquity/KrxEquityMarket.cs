using KisOpenApi.Models;
using KisOpenApi.Models.KrxEquity;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IMarket, IMarketKrxEquity
{
	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public required EventHandler<ResponseResult<MarketExecution>>? MarketExecuted { get; set; }
	public required EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }
	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }
	public Dictionary<string, Equity> Equities { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public bool AvailableToSubscribe => throw new NotImplementedException();

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResult<MarketExecution>> RequestMarketExecution(string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResults<MarketExecution>> RequestMarketExecution(IEnumerable<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id = "") => throw new NotImplementedException();
	public Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option) => throw new NotImplementedException();
	public Task<ResponseResults<MarketExecution>> RequestMarketExecutionHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();

	#region 국내주식기간별시세(일,주,월,년) - FHKST03010100
	public async Task<ResponseResult<QuotePack<T>>> RequestPricePack<T>(QuoteRequest request) where T : Quote
	{
		var parameters = GenerateParameters(new
		{
			FID_COND_MRKT_DIV_CODE = "J",
			FID_INPUT_ISCD = request.Symbol,
			FID_INPUT_DATE_1 = request.DateTimeBegin.ToString("yyyyMMdd"),
			FID_INPUT_DATE_2 = request.DateTimeEnd.ToString("yyyyMMdd"),
			FID_PERIOD_DIV_CODE = request.TimeIntervalUnit switch
			{
				IntervalUnit.Day => "D",
				IntervalUnit.Week => "W",
				IntervalUnit.Month => "M",
				_ => "D"
			},
			FID_ORG_ADJ_PRC = "1",
		});

		var response = await RequestStandardAsync<FHKST03010100>(EndpointRef.EndpointDic[TrId.FHKST03010100], parameters);
		if (response is null) return new ResponseResult<QuotePack<T>>
		{
			StatusCode = Status.ERROR_OPEN_API,
			Info = new QuotePack<T> { PrimaryList = [] },
			Message = "response is null"
		};

		var quotes = new List<Quote>();
		response.Output2.ForEach(f =>
		{
			var close = Convert.ToDecimal(f.stck_clpr);
			quotes.Add(new Quote
			{
				T = f.stck_bsop_date.ToDateTime(),
				C = close,
				H = Convert.ToDecimal(f.stck_hgpr),
				L = Convert.ToDecimal(f.stck_lwpr),
				O = Convert.ToDecimal(f.stck_oprc),
				V = Convert.ToDecimal(f.acml_vol),
				BasePrice = close - Convert.ToDecimal(f.prdy_vrss),
				Turnover = Convert.ToDecimal(f.acml_tr_pbmn) / 1_000_000,
			});
		});

		return new ResponseResult<QuotePack<T>>
		{
			Info = new QuotePack<T>
			{
				Symbol = request.Symbol,
				TimeIntervalUnit = request.TimeIntervalUnit,
				TimeInterval = request.TimeInterval,
				PrimaryList = quotes as List<T> ?? [],
			},
		};
	} 
	#endregion

	public async Task<ResponseCore> SubscribeMarketExecution(string symbol = "", bool connecting = true, string subscriber = "")
	{
		var krx = await SubscribeAsync(subscriber, nameof(H0STCNT0), symbol, connecting);
		var nxt = await SubscribeAsync(subscriber, nameof(H0NXCNT0), symbol, connecting);

		return krx;
	}

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol = "", bool connecting = true, string subscriber = "") =>
		await SubscribeAsync(subscriber, nameof(H0STASP0), symbol, connecting);

	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();

	public Task<ResponseDictionary<string, Equity>> RequestEquityDictionary(int option = 0) => throw new NotImplementedException();
	public Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol, bool needsOrderBook = false, Exchange exchange = Exchange.NONE) => throw new NotImplementedException();
	public Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end) => throw new NotImplementedException();
	public Task<ResponseResults<Sector>> RequestSectors(string code = "", string name = "") => throw new NotImplementedException();
	public Task<ResponseResults<Sector>> RequestSectorsByEquity(string symbol) => throw new NotImplementedException();
	public Task<ResponseResults<MarketExecution>> RequestEquitiesBySector(string sectorCode) => throw new NotImplementedException();
	public Task<ResponseResults<SearchFilter>> RequestSearchFilters() => throw new NotImplementedException();
	public Task<ResponseResults<MarketExecution>> RequestEquitiesByFilter(string query) => throw new NotImplementedException();
}
