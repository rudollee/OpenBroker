namespace OpenBroker.Models;
public class MarketPause
{
	public TimeOnly Time { get; set; }

	public MarketPauseType PauseType { get; set; }

	public string Symbol { get; set; } = string.Empty;

	public string NameOfficial { get; set; } = string.Empty;

	public decimal BasePrice { get; set; }

	public decimal TriggerPrice { get; set; }

	public decimal Rate { get => (TriggerPrice - BasePrice) / Math.Max(1, BasePrice) * 100;}

	public string Remark { get; set; } = string.Empty;

}
