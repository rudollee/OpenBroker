namespace OpenBroker.Models;

/// <summary>
/// 호가 전체 정보
/// </summary>
public class MarketDepth : PriceExt
{
    public TimeSpan TimeTaken { get; set; }
    public IList<OrderBook> Ask { get; set; } = new List<OrderBook>();
    public IList<OrderBook> Bid { get; set; } = new List<OrderBook>();
    public OrderBook AskAgg { get; set; } = new OrderBook();
    public OrderBook BidAgg { get; set; } = new OrderBook();
}

/// <summary>
/// 호가
/// </summary>
public class OrderBook
{
    public byte Seq { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountGroup { get; set; }
}

/// <summary>
/// 시장 체결
/// </summary>
public class MarketContract : InstrumentCore
{
    public DateTime TimeContract { get; set; }
    public decimal C { get; set; }
    public decimal V { get; set; }
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
/// 거래량, 미결제약정
/// </summary>
public class PriceExt : PriceOHLC
{
    /// <summary>
    /// Open Interest
    /// </summary>
    public decimal OI { get; set; }

    /// <summary>
    /// Underlying Asset Price (Close)
    /// </summary>
		public decimal UA { get; set; }
}

/// <summary>
/// 옵션 Greek Included
/// </summary>
public class OptionPrice : PriceExt
{
    public decimal Delta { get; set; }
    public decimal Gamma { get; set; }
    public decimal Theta { get; set; }
}
