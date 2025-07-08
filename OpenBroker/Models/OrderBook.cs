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
/// 옵션 Greek Included
/// </summary>
public class OptionGreek
{
    public decimal Delta { get; set; }
    public decimal Gamma { get; set; }
    public decimal Theta { get; set; }
}