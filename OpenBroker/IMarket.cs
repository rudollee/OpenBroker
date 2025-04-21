using OpenBroker.Models;

namespace OpenBroker;

/// <summary>
/// Market Data
/// </summary>
public interface IMarket
{
	/// <summary>
	/// 종목 마스터
	/// </summary>
	Dictionary<string, Instrument> Instruments { get; set; }

	/// <summary>
	/// Marekt Contracted callback
	/// </summary>
	EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }

	/// <summary>
	/// Order Book callback
	/// </summary>
	EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }

	/// <summary>
	/// News callback
	/// </summary>
	EventHandler<ResponseResult<News>>? NewsPosted { get; set; }

	/// <summary>
	/// Market Paused callback
	/// </summary>
	EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	/// <summary>
	/// 거래 종목 리스트
	/// </summary>
	/// <param name="option"></param>
	/// <returns></returns>
	Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option = 0);

	/// <summary>
	/// 종목 상세
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol);

	/// <summary>
	/// 현재가
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol);

	/// <summary>
	/// 현재가 Multiple
	/// </summary>
	/// <param name="symbols"></param>
	/// <returns></returns>
	Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols);

	/// <summary>
	/// 기간별 체결 내역
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="begin"></param>
	/// <param name="end"></param>
	/// <param name="baseVolume"></param>
	/// <returns></returns>
	Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0);

	/// <summary>
	/// 차트 데이터
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	Task<ResponseResult<QuotePack>> RequestPricePack(QuoteRequest request);
	
	/// <summary>
	/// 뉴스 상세 정보
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<ResponseResult<News>> RequestNews(string id);

	/// <summary>
	/// 시장 중지 상태 - realtime
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeMarketPause(string symbol = "000000");

	/// <summary>
	/// 뉴스 정보 - realtime
	/// </summary>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeNews(bool connecting = true);

	/// <summary>
	/// 현재가 - realtime
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="connecting"></param>
	/// <param name="subscriber"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "");

	/// <summary>
	/// 호가 - realtime
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="connecting"></param>
	/// <param name="subscriber"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "");

}
