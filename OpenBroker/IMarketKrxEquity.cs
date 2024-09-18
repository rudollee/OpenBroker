using OpenBroker.Models;

namespace OpenBroker;
public interface IMarketKrxEquity
{
	/// <summary>
	/// 거래 종목 리스트
	/// </summary>
	/// <param name="option"></param>
	/// <returns></returns>
	Task<ResponseResults<Equity>> RequestEquityList(int option = 0);

	/// <summary>
	/// 종목 종합 정보
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseResult<EquityPack>> RequestEquityInfo(string symbol);

	/// <summary>
	/// 신규 상장 종목 리스트
	/// </summary>
	/// <param name="begin"></param>
	/// <param name="end"></param>
	/// <returns></returns>
	Task<ResponseResults<Equity>> RequestIPO(DateOnly begin, DateOnly end);
}
