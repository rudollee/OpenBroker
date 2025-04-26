namespace OpenBroker.Models;

/// <summary>
/// Price package
/// </summary>
public class QuotePack
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public required List<Quote> PrimaryList { get; set; } = new List<Quote>();
	public QuoteRate SecondaryInfo { get; set; } = new();
}

/// <summary>
/// Price Package Request
/// </summary>
public class QuoteRequest
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public int Amount { get; set; } = 0;
	public DateTime DateTimeBegin { get; set; }
	public DateTime DateTimeEnd { get; set; }
	public Exchange Exchange { get; set; } = Exchange.NONE;
}
