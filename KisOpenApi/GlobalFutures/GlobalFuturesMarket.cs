using KisOpenApi.Models;
using KisOpenApi.Models.GlobalFutures;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IMarket
{
	public required EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }
	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public required EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public async Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/quotations/stock-detail");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(HHDFC55010100)));

		request.AddQueryParameter("SRS_CD", symbol);

		try
		{
			var response = await client.GetAsync<HHDFC55010100>(request);
			if (response is null) return new ResponseResult<Instrument>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Info = new Instrument(),
				Message = "response is null"
			};

			var info = new Instrument
			{
				ExchangeCode = (Exchange)Enum.Parse(typeof(Exchange), response.Output1.exch_cd),
				Symbol = symbol,
				Sym = symbol.ToSym(),
				Margin = Convert.ToDecimal(response.Output1.trst_mgn),
				Tick = Convert.ToDecimal(response.Output1.tick_sz),
				TickValue = Convert.ToDecimal(response.Output1.tick_val),
				TimeOpen = response.Output1.mrkt_open_time.ToTime(),
				TimeClosed = response.Output1.mrkt_close_time.ToTime(),
				DateOpened = response.Output1.trd_fr_date.ToDate(),
				DateExpired = response.Output1.expr_date.ToDate(),
				Currency = (Currency)Enum.Parse(typeof(Currency), response.Output1.crc_cd),
				NumeralSystem = Convert.ToInt32(response.Output1.disp_digit.Trim()),
				Tradable = response.Output1.stat_tp == "1",
			};

			return new ResponseResult<Instrument>
			{
				Info = info,
				Remark = $"clas_cd: {response.Output1.clas_cd}, crc_cd: {response.Output1.crc_cd}"
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<Instrument>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Info = new Instrument(),
				Message = ex.Message
			};
		}
	}

	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "SYS") =>
		await SubscribeAsync(nameof(HDFFF020), symbol, connecting, subscriber);

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "SYS") =>
		await SubscribeAsync(nameof(HDFFF010), symbol, connecting, subscriber);

	public Task<ResponseResults<Instrument>> RequestInstruments(int option) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContract(List<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();
	public Task<ResponseResult<PricePack>> RequestPricePack(PricePackRequest request) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
}
