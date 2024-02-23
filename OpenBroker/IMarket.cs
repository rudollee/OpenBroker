using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker.Models;

namespace OpenBroker;

/// <summary>
/// Market Data
/// </summary>
public interface IMarket
{
	/// <summary>
	/// Marekt Contracted callback
	/// </summary>
	EventHandler<ResponseResult<MarketContract>> MarketContracted { get; set; }

	/// <summary>
	/// Market Depth callback
	/// </summary>
	EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get; set; }

	/// <summary>
	/// News callback
	/// </summary>
	EventHandler<ResponseResult<News>> NewsPosted { get; set; }

	/// <summary>
	/// 현재가
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol);

	/// <summary>
	/// 현재가 - realtime
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true);

	/// <summary>
	/// 호가 - realtime
	/// </summary>
	/// <param name="symbol"></param>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true);

	/// <summary>
	/// 뉴스 정보 - realtime
	/// </summary>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeNews(bool connecting = true);

	/// <summary>
	/// 종목 상세
	/// </summary>
	/// <param name="symbol"></param>
	/// <returns></returns>
	Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol);

}
