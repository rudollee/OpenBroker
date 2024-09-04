﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker;
using OpenBroker.Models;

namespace EBestOpenApi.KrxEquity;
public partial class EBestKrxEquity : ConnectionBase, IMarket
{
	public EventHandler<ResponseResult<MarketContract>> MarketContracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public EventHandler<ResponseResult<News>> NewsPosted { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResults<Instrument>> RequestInstruments(int option) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) => throw new NotImplementedException();
	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await Subscribe("NWS", "NWS001", connecting);
}
