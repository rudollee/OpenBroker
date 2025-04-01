using OpenBroker.Models;

namespace OpenBroker;
public interface IMarketKrx
{
	/// <summary>
	/// Option Pack
	/// </summary>
	/// <param name="expiry6">yyyyMM</param>
	/// <param name="typ"></param>
	/// <returns></returns>
	Task<ResponseResult<OptionPack>> RequestOptionPack(string expiry6 = "", OptionsType typ = OptionsType.G);
}
