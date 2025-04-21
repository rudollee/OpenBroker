namespace OpenBroker.Models;

/// <summary>
/// 호가 전체 정보
/// </summary>
public class OrderBook : MarketContract
{
    public TimeOnly TimeTaken { get; set; }
    public IList<MarketOrder> Ask { get; set; } = [];
    public IList<MarketOrder> Bid { get; set; } = [];
    public decimal AskAgg { get; set; }
    public decimal BidAgg { get; set; }
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
public class Quote : MarketContract
{
    public decimal O { get; set; }
    public decimal H { get; set; }
    public decimal L { get; set; }
}

/// <summary>
/// 시고저종 + 비율 + 상한가/하한가
/// </summary>
public class QuoteRate : Quote
{
    public decimal ORate { get => BasePrice == 0 ? 0 : (O - BasePrice) / BasePrice; }

    public decimal HRate { get => BasePrice == 0 ? 0 : (H - BasePrice) / BasePrice;  }

    public decimal LRate { get => BasePrice == 0 ? 0 : (L - BasePrice) / BasePrice; }

    /// <summary>
    /// 상한가
    /// </summary>
    public decimal HighLimit { get; set; }

    /// <summary>
    /// 하한가
    /// </summary>
    public decimal LowLimit { get; set; }
}

/// <summary>
/// 거래량, 미결제약정
/// </summary>
public class QuoteExt(decimal underlyingAssetPrice) : Quote
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