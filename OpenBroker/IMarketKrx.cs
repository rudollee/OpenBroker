using OpenBroker.Models;

namespace OpenBroker;
public interface IMarketKrx
{
	Task<ResponseResults<PriceRate>> RequestOptions();
}
