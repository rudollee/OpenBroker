namespace OpenBroker.Models;

/// <summary>
/// 호가 전체 정보
/// </summary>
public class OrderBook : MarketContract
{
    public TimeSpan TimeTaken { get; set; }
    public IList<MarketOrder> Ask { get; set; } = new List<MarketOrder>();
    public IList<MarketOrder> Bid { get; set; } = new List<MarketOrder>();
    public MarketOrder AskAgg { get; set; } = new MarketOrder();
    public MarketOrder BidAgg { get; set; } = new MarketOrder();
}

/// <summary>
/// 호가
/// </summary>
public class MarketOrder
{
    public byte Seq { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountGroup { get; set; }
}

/// <summary>
/// 시고저종
/// </summary>
public class PriceOHLC : MarketContract
{
    public decimal O { get; set; }
    public decimal H { get; set; }
    public decimal L { get; set; }
}

/// <summary>
/// 시고저종 + 비율
/// </summary>
public class PriceRate : PriceOHLC
{
    public decimal ORate { get => (O - BasePrice) / BasePrice; }

    public decimal HRate { get => (H - BasePrice) / BasePrice;  }

    public decimal LRate { get => (L - BasePrice) / BasePrice; }
}

/// <summary>
/// 거래량, 미결제약정
/// </summary>
public class PriceExt(decimal underlyingAssetPrice) : PriceOHLC
{
    /// <summary>
    /// Open Interest
    /// </summary>
    public decimal OI { get; set; }

    /// <summary>
    /// Underlying Asset Price (Close)
    /// </summary>
	public decimal Basis { get => C - underlyingAssetPrice; }
}

/// <summary>
/// 옵션 Greek Included
/// </summary>
public class OptionGreek
{
    public decimal Delta { get; set; }
    public decimal Gamma { get; set; }
    public decimal Theta { get; set; }
}
