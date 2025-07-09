namespace KisOpenApi.Models;
internal static class EndpointRef
{
	internal static Dictionary<TrId, EndpointPack> EndpointDic = new()
	{
		{
			TrId.TTTC0012U,
			new EndpointPack
			{
				ID = TrId.TTTC0012U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-cash"
			}
		},
		{
			TrId.TTTC0011U,
			new EndpointPack
			{
				ID = TrId.TTTC0011U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-cash"
			}
		},
		{
			TrId.TTTC0052U,
			new EndpointPack
			{
				ID = TrId.TTTC0052U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-credit"
			}
		},
		{
			TrId.TTTC0051U,
			new EndpointPack
			{
				ID = TrId.TTTC0051U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-credit"
			}
		},
		{
			TrId.TTTC0013U,
			new EndpointPack
			{
				ID = TrId.TTTC0013U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-rvsecncl"
			}
		},
		{
			TrId.TTTC0084R,
			new EndpointPack
			{
				ID = TrId.TTTC0084R,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psbl-rvsecncl"
			}
		},
		{
			TrId.TTTC0081R,
			new EndpointPack
			{
				ID = TrId.TTTC0081R,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-daily-ccld"
			}
		},
		{
			TrId.CTSC9215R,
			new EndpointPack
			{
				ID = TrId.CTSC9215R,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-daily-ccld"
			}
		},
		{
			TrId.TTTC8434R,
			new EndpointPack
			{
				ID = TrId.TTTC8434R,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-balance"
			}
		},
		{
			TrId.TTTC8908R,
			new EndpointPack
			{
				ID = TrId.TTTC8908R,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psbl-order"
			}
		},
		{
			TrId.CTSC0008U,
			new EndpointPack
			{
				ID = TrId.CTSC0008U,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-reserve"
			}
		},
		{
			TrId.FHKST01010100,
			new EndpointPack
			{
				ID = TrId.FHKST01010100,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-price"
			}
		},
		{
			TrId.FHKST01010200,
			new EndpointPack
			{
				ID = TrId.FHKST01010200,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-asking-price"
			}
		},
		{
			TrId.FHKST01010300,
			new EndpointPack
			{
				ID = TrId.FHKST01010300,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-ccnl"
			}
		},
		{
			TrId.FHKST01010400,
			new EndpointPack
			{
				ID = TrId.FHKST01010400,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-daily-order"
			}
		},
		{
			TrId.FHKST03010100,
			new EndpointPack
			{
				ID = TrId.FHKST03010100,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-daily-itemchartprice"
			}
		},
		{
			TrId.FHKST03010200,
			new EndpointPack
			{
				ID = TrId.FHKST03010200,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-time-itemchartprice"
			}
		},
		{
			TrId.FHKST03010230,
			new EndpointPack
			{
				ID = TrId.FHKST03010230,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-time-itemchartprice"
			}
		},
		{
			TrId.FHPST01710000,
			new EndpointPack
			{
				ID = TrId.FHPST01710000,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "search-info"
			}
		},
		{
			TrId.FHPST02310000,
			new EndpointPack
			{
				ID = TrId.FHPST02310000,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "investor"
			}
		},
		{
			TrId.FHPST02320000,
			new EndpointPack
			{
				ID = TrId.FHPST02320000,
				Prefix = EndpointPrefix.KrxEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "industry-investor"
			}
		},
		{
			TrId.TTTC0952U,
			new EndpointPack
			{
				ID = TrId.TTTC0952U,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "buy"
			}
		},
		{
			TrId.TTTC0958U,
			new EndpointPack
			{
				ID = TrId.TTTC0958U,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "sell"
			}
		},
		{
			TrId.TTTC0953U,
			new EndpointPack
			{
				ID = TrId.TTTC0953U,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "order-rvsecncl"
			}
		},
		{
			TrId.CTSC8035R,
			new EndpointPack
			{
				ID = TrId.CTSC8035R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psbl-rvsecncl"
			}
		},
		{
			TrId.CTSC8013R,
			new EndpointPack
			{
				ID = TrId.CTSC8013R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-daily-ccld"
			}
		},
		{
			TrId.CTSC8407R,
			new EndpointPack
			{
				ID = TrId.CTSC8407R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-balance"
			}
		},
		{
			TrId.TTTC8910R,
			new EndpointPack
			{
				ID = TrId.TTTC8910R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psbl-order"
			}
		},
		{
			TrId.CTPF1101R,
			new EndpointPack
			{
				ID = TrId.CTPF1101R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "issue-info"
			}
		},
		{
			TrId.FHKBJ773401C0,
			new EndpointPack
			{
				ID = TrId.FHKBJ773401C0,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-asking-price"
			}
		},
		{
			TrId.CTPF2005R,
			new EndpointPack
			{
				ID = TrId.CTPF2005R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "avg-unit"
			}
		},
		{
			TrId.FHKBJ773701C0,
			new EndpointPack
			{
				ID = TrId.FHKBJ773701C0,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-daily-itemchartprice"
			}
		},
		{
			TrId.FHKBJ773400C0,
			new EndpointPack
			{
				ID = TrId.FHKBJ773400C0,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-price"
			}
		},
		{
			TrId.FHKBJ773403C0,
			new EndpointPack
			{
				ID = TrId.FHKBJ773403C0,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-ccnl"
			}
		},
		{
			TrId.FHKBJ773404C0,
			new EndpointPack
			{
				ID = TrId.FHKBJ773404C0,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-ccnl"
			}
		},
		{
			TrId.CTPF1114R,
			new EndpointPack
			{
				ID = TrId.CTPF1114R,
				Prefix = EndpointPrefix.KrxBondV1,
				Type = EndpointType.Quote,
				Endpoint = "search-bond-info"
			}
		},
		{
			TrId.TTTS0308U,
			new EndpointPack
			{
				ID = TrId.TTTS0308U,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order"
			}
		},
		{
			TrId.TTTS0302U,
			new EndpointPack
			{
				ID = TrId.TTTS0302U,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "order-rvsecncl"
			}
		},
		{
			TrId.TTTS0318R,
			new EndpointPack
			{
				ID = TrId.TTTS0318R,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-balance"
			}
		},
		{
			TrId.TTTS0307R,
			new EndpointPack
			{
				ID = TrId.TTTS0307R,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-executions"
			}
		},
		{
			TrId.TTTS0311R,
			new EndpointPack
			{
				ID = TrId.TTTS0311R,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psbl-order"
			}
		},
		{
			TrId.HHDFS00000300,
			new EndpointPack
			{
				ID = TrId.HHDFS00000300,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-price"
			}
		},
		{
			TrId.HHDFS76240000,
			new EndpointPack
			{
				ID = TrId.HHDFS76240000,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-daily-price"
			}
		},
		{
			TrId.HHDFS76200100,
			new EndpointPack
			{
				ID = TrId.HHDFS76200100,
				Prefix = EndpointPrefix.GlobalEquityV1,
				Type = EndpointType.Quote,
				Endpoint = "search-info"
			}
		},
		{
			TrId.OTFM3001U,
			new EndpointPack
			{
				ID = TrId.OTFM3001U,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Trading,
				Endpoint = "order-rsncl"
			}
		},
		{
			TrId.OTFM3003U,
			new EndpointPack
			{
				ID = TrId.OTFM3003U,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Trading,
				Endpoint = "order-rvsecncl"
			}
		},
		{
			TrId.OTFM1412R,
			new EndpointPack
			{
				ID = TrId.OTFM1412R,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-balance"
			}
		},
		{
			TrId.OTFM3121R,
			new EndpointPack
			{
				ID = TrId.OTFM3121R,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-executions"
			}
		},
		{
			TrId.HHDFC5510000,
			new EndpointPack
			{
				ID = TrId.HHDFC5510000,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-price"
			}
		},
		{
			TrId.HHDFC0860000000,
			new EndpointPack
			{
				ID = TrId.HHDFC0860000000,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-asking-price"
			}
		},
		{
			TrId.HHDFC5520100,
			new EndpointPack
			{
				ID = TrId.HHDFC5520100,
				Prefix = EndpointPrefix.KrxV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-daily-price"
			}
		},
		{
			TrId.TTTC0501U,
			new EndpointPack
			{
				ID = TrId.TTTC0501U,
				Prefix = EndpointPrefix.KrxFundV1,
				Type = EndpointType.Trading,
				Endpoint = "order-buy"
			}
		},
		{
			TrId.TTTC0502U,
			new EndpointPack
			{
				ID = TrId.TTTC0502U,
				Prefix = EndpointPrefix.KrxFundV1,
				Type = EndpointType.Trading,
				Endpoint = "order-sell"
			}
		},
		{
			TrId.TTTC0510R,
			new EndpointPack
			{
				ID = TrId.TTTC0510R,
				Prefix = EndpointPrefix.KrxFundV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-balance"
			}
		},
		{
			TrId.FHPFUND01000000,
			new EndpointPack
			{
				ID = TrId.FHPFUND01000000,
				Prefix = EndpointPrefix.KrxFundV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-price"
			}
		},
		{
			TrId.OTFM316R,
			new EndpointPack
			{
				ID = TrId.OTFM316R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-ccld"
			}
		},
		{
			TrId.OTFM304R,
			new EndpointPack
			{
				ID = TrId.OTFM304R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-psamount"
			}
		},
		{
			TrId.OTFM3118R,
			new EndpointPack
			{
				ID = TrId.OTFM3118R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-period-ccld"
			}
		},
		{
			TrId.OTFM3122R,
			new EndpointPack
			{
				ID = TrId.OTFM3122R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-daily-ccld"
			}
		},
		{
			TrId.OTFM1411R,
			new EndpointPack
			{
				ID = TrId.OTFM1411R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-deposit"
			}
		},
		{
			TrId.OTFM3120R,
			new EndpointPack
			{
				ID = TrId.OTFM3120R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-daily-order"
			}
		},
		{
			TrId.OTFM3114R,
			new EndpointPack
			{
				ID = TrId.OTFM3114R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-period-trans"
			}
		},
		{
			TrId.OTFM3115R,
			new EndpointPack
			{
				ID = TrId.OTFM3115R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "margin-detail"
			}
		},
		{
			TrId.HHDFC5510100,
			new EndpointPack
			{
				ID = TrId.HHDFC5510100,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "stock-detail"
			}
		},
		{
			TrId.HHDFC5520400,
			new EndpointPack
			{
				ID = TrId.HHDFC5520400,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-time-futurechartprice"
			}
		},
		{
			TrId.HHDFC5520200,
			new EndpointPack
			{
				ID = TrId.HHDFC5520200,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "tick-ccnl"
			}
		},
		{
			TrId.HHDFC5520300,
			new EndpointPack
			{
				ID = TrId.HHDFC5520300,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "monthly-ccnl"
			}
		},
		{
			TrId.HHDFC8600000,
			new EndpointPack
			{
				ID = TrId.HHDFC8600000,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-asking-price"
			}
		},
		{
			TrId.HHDFC5520000,
			new EndpointPack
			{
				ID = TrId.HHDFC5520000,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "market-execution-detail"
			}
		},
		{
			TrId.OTFM2229R,
			new EndpointPack
			{
				ID = TrId.OTFM2229R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "investor-upnpd-trend"
			}
		},
		{
			TrId.HHDFC0550100,
			new EndpointPack
			{
				ID = TrId.HHDFC0550100,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "opt-detail"
			}
		},
		{
			TrId.HHDFC0550200,
			new EndpointPack
			{
				ID = TrId.HHDFC0550200,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "opt-weekly-ccnl"
			}
		},
		{
			TrId.HHDFC0550210,
			new EndpointPack
			{
				ID = TrId.HHDFC0550210,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "opt-daily-ccnl"
			}
		},
		{
			TrId.HHDFC0550220,
			new EndpointPack
			{
				ID = TrId.HHDFC0550220,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "opt-tick-ccnl"
			}
		},
		{
			TrId.HHDFC0550230,
			new EndpointPack
			{
				ID = TrId.HHDFC0550230,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "opt-monthly-ccnl"
			}
		},
		{
			TrId.HHDFC0550240,
			new EndpointPack
			{
				ID = TrId.HHDFC0550240,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "inquire-time-optchartprice"
			}
		},
		{
			TrId.HHDFC0552000,
			new EndpointPack
			{
				ID = TrId.HHDFC0552000,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "search-opt-detail"
			}
		},
		{
			TrId.OTFM3041R,
			new EndpointPack
			{
				ID = TrId.OTFM3041R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-order-possible"
			}
		},
		{
			TrId.OTFM1410R,
			new EndpointPack
			{
				ID = TrId.OTFM1410R,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Trading,
				Endpoint = "inquire-account-deposit"
			}
		},
		{
			TrId.HHDFC0552100,
			new EndpointPack
			{
				ID = TrId.HHDFC0552100,
				Prefix = EndpointPrefix.GlobalV1,
				Type = EndpointType.Quote,
				Endpoint = "search-stock"
			}
		}
	};
}