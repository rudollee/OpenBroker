using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IMarket
{
	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public EventHandler<ResponseResult<MarketContract>>? MarketContracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<News>>? NewsPosted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();

	#region request SSF instruments using t8401
	public async Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option = 0)
	{
		try
		{
			var response = await RequestStandardAsync<t8401>(LsEndpoint.FuturesMarketData.ToDescription(), new
			{
				t8401InBlock = new t8401InBlock
				{
					dummy = "0",
				}
			});

			if (!response.t8401OutBlock.Any()) return new ResponseDictionary<string, Instrument>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "no data",
				Code = response.Code,
				Dic = new Dictionary<string, Instrument>(),
			};

			Instruments.Clear();
			response.t8401OutBlock.ForEach(instrument =>
			{
				Instruments.Add(instrument.shcode, new Instrument
				{
					Symbol = instrument.shcode,
					InstrumentName = instrument.hname,
					SymbolUnderlying = instrument.basecode.Substring(1),
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

	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();
	public Task<ResponseResult<PricePack>> RequestPricePack(PricePackRequest request) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
