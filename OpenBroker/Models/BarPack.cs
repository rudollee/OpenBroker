namespace OpenBroker.Models;

/// <summary>
/// Price package
/// </summary>
public class BarPack
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public required List<Bar> PrimaryList { get; set; } = [];
	public BarRate SecondaryInfo { get; set; } = new();
}

public class BarPack<T> where T : Bar 
{
	public Exchange ExchangeCode { get; set; } = Exchange.CME;
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public required List<T> PrimaryList { get; set; } = [];
	public BarRate SecondaryInfo { get; set; } = new();
}

/// <summary>
/// Price Package Request
/// </summary>
public class BarRequest
{
	public string Symbol { get; set; } = string.Empty;
	public IntervalUnit TimeIntervalUnit { get; set; } = IntervalUnit.Day;
	public int TimeInterval { get; set; } = 1;
	public int Amount { get; set; } = 0;
	public DateTime DateTimeBegin { get; set; }
	public DateTime DateTimeEnd { get; set; } = DateTime.Today;
	public Exchange Exchange { get; set; } = Exchange.NONE;
	public bool IsRegularSessionOnly { get; set; } = true;
}