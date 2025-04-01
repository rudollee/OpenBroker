using OpenBroker.Models;

namespace OpenBroker;
public interface IMarketKrx
{
	Task<ResponseResult<OptionPack>> RequestOptionPack();
}
