﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KisOpenApi.Models;
using OpenBroker;
using OpenBroker.Models;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IMarket
{
	public required EventHandler<ResponseResult<MarketContract>> MarketContracted { get; set; }
	public required EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get; set; }

	public EventHandler<ResponseResult<News>> NewsPosted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	
	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => 
		await Subscribe(nameof(H0STCNT0), symbol, connecting);

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) =>
		await Subscribe(nameof(H0STASP0), symbol, connecting);

	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
