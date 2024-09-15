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
}
