namespace OpenBroker.Models;

/// <summary>
/// Price package
/// </summary>
public class PricePack
{
	public required IList<PriceOHLC> PrimaryList { get; set; } = new List<PriceOHLC>();
	public IList<PriceRate> SecondaryList { get; set; } = new List<PriceRate>();
}

/// <summary>
/// Price Package Request
/// </summary>
public class PricePackRequest
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public DateTime DateTimeBegin { get; set; }
	public DateTime DatetimeEnd { get; set; }
}
