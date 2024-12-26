namespace OpenBroker.Models;
public class SubscriptionPack
{
	public string TrCode { get; set; } = string.Empty;

	public string Key { get; set; } = string.Empty;

	public List<string> Subscriber { get; set; } = new() { Capacity = 16 };
}
