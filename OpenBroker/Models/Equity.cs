﻿namespace OpenBroker.Models;

public class Equity
{
	public string Symbol { get; set; } = string.Empty;

	public ExchangeSection Section { get; set; } = ExchangeSection.NONE;

	public string NameOfficial { get; set; } = string.Empty;

	public string NameAlt { get; set; } = string.Empty;

	public DiscardStatus DiscardStatus { get; set; } = DiscardStatus.TRADABLE;

	public List<Exchange> Exchanges { get; set; } = [];
}

public class EquityPack : Equity
{
	public QuoteRate PriceInfo { get; set; } = new();
	public OrderBook OrderBook { get; set; } = new();
	public TradingData TradingInfo { get; set; } = new();

	public class TradingData
	{
		public decimal Margin { get; set; }
		public decimal MarginRate { get; set; }
	}
}
