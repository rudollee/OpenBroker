using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker;
using OpenBroker.Models;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IMarket
{
	public required EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get; set; }
	public EventHandler<ResponseResult<News>> NewsPosted { get; set; }
	public required EventHandler<ResponseResult<MarketContract>> MarketContracted { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
