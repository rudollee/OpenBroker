namespace OpenBroker.Models;

/// <summary>
/// Price package
/// </summary>
public class PricePack
{
	public required List<PriceOHLC> PrimaryList { get; set; } = new List<PriceOHLC>();
	public PriceRate SecondaryInfo { get; set; } = new();
}

/// <summary>
/// Price Package Request
/// </summary>
public class PricePackRequest
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public int Amount { get; set; } = 0;
	public DateTime DateTimeBegin { get; set; }
	public DateTime DateTimeEnd { get; set; }
}
