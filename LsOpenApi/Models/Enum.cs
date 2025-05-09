﻿using System.ComponentModel;
using System.Reflection;

namespace LsOpenApi.Models;

internal enum LsEndpoint
{
	[Description("")]
	None,

	[Description("indtp/market-data")]
	IndustryData,

	[Description("indtp/chart")]
	IndustryChart,

	[Description("stock/market-data")]
	EquityMarketData,

	[Description("stock/exchange")]
	EquityExchange,

	[Description("stock/investinfo")]
	EquityInfo,

	[Description("stock/program")]
	EquityProgram,

	[Description("stock/investor")]
	EquityInvestor,

	[Description("stock/frgr-itt")]
	EquityClassification,

	[Description("stock/elw")]
	EquityElw,

	[Description("stock/etf")]
	EquityEtf,

	[Description("stock/sector")]
	EquitySector,

	[Description("stock/item-search")]
	EquitySearch,

	[Description("stock/high-item")]
	EquityRank,

	[Description("stock/chart")]
	EquityChart,

	[Description("stock/etc")]
	EquityEtc,

	[Description("stock/accno")]
	EquityAccount,

	[Description("stock/order")]
	EquityOrder,

	[Description("futureoption/market-data")]
	FuturesMarketData,

	[Description("futureoption/investor")]
	FuturesInvestor,

	[Description("futureoption/chart")]
	FuturesChart,

	[Description("futureoption/accno")]
	FuturesAccount,

	[Description("futureoption/order")]
	FuturesOrder,

	[Description("futureoption/etc")]
	FuturesEtc
}
