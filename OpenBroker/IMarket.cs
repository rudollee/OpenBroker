using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker.Models;

namespace OpenBroker;

public interface IMarket
{
	/// <summary>
	/// Market Depth callback
	/// </summary>
	EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get; set; }

	/// <summary>
	/// News callback
	/// </summary>
	EventHandler<ResponseResult<News>> NewsPosted { get; set; }
}
