namespace OpenBroker.Models;

/// <summary>
/// 시장 체결
/// </summary>
public class MarketContract
{
    public string Symbol { get; set; } = string.Empty;
    public DateTime TimeContract { get; set; }
    public decimal C { get; set; }
    public decimal V { get; set; }
    public decimal BasePrice { get; set; }
	public decimal Diff { get => C - BasePrice; }
	public decimal DiffRate { get => (C - BasePrice) / BasePrice; }
}
