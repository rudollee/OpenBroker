﻿using KisOpenApi.Models;
using OpenBroker;
using OpenBroker.Models;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IMarket
{
	public Dictionary<string, Instrument> Instruments { get; set; } = new();

	public required EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public required EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }
	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol = "") => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id = "") => throw new NotImplementedException();
	public Task<ResponseDictionary<string, Instrument>> RequestInstruments(int option) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();
	public Task<ResponseResult<PricePack>> RequestPricePack(PricePackRequest request) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketContract(string symbol = "", bool connecting = true, string subscriber = "") =>
		await SubscribeAsync(subscriber, nameof(H0STCNT0), symbol, connecting);

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol = "", bool connecting = true, string subscriber = "") =>
		await SubscribeAsync(subscriber, nameof(H0STASP0), symbol, connecting);

	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
}
