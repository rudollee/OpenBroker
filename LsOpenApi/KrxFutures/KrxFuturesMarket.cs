using LsOpenApi.Models;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class LsKrxFutures : ConnectionBase, IMarket, IMarketKrx
{
	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public EventHandler<ResponseResult<MarketContract>>? MarketContracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<News>>? NewsPosted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();
	public Task<ResponseResult<QuotePack>> RequestPricePack(QuoteRequest request) => throw new NotImplementedException();

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
					Symbol = option.optcode,
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
					Symbol = option.optcode,
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

	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
