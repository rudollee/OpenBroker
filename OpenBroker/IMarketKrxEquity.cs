using OpenBroker.Models;

namespace OpenBroker;
public interface IMarketKrxEquity
{
	/// <summary>
	/// 종목 마스터
	/// </summary>
	Dictionary<string, Equity> Equities { get; set; }

	/// <summary>
	/// 거래 종목 리스트
	/// </summary>
	/// <param name="option"></param>
	/// <returns></returns>
	Task<ResponseDictionary<string, Equity>> RequestEquityDictionary(int option = 0);

	/// <summary>
	/// 종목 종합 정보
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="needsOrderBook"></param>
	/// <returns></returns>
	Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol, bool needsOrderBook = false);

	/// <summary>
	/// 신규 상장 종목 리스트
	/// </summary>
	/// <param name="begin"></param>
	/// <param name="end"></param>
	/// <returns></returns>
	Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end);

	/// <summary>
	/// 섹터/테마 리스트
	/// </summary>
	/// <param name="code"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	Task<ResponseResults<Sector>> RequestSectors(string code = "", string name = "");

	/// <summary>
	/// 섹터 종목 리스트
	/// </summary>
	/// <param name="sectorCode"></param>
	/// <returns></returns>
	Task<ResponseResults<PriceOHLC>> RequestEquitiesBySector(string sectorCode);

	/// <summary>
	/// Realtime Data 가능 상황
	/// </summary>
	bool AvailableToSubscribe { get; }
}
