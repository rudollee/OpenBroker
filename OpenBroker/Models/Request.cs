namespace OpenBroker.Models;

public class Request
{
	public string TrCode { get; set; } = string.Empty;

	public DateTime RequestTime { get; set; } = DateTime.UtcNow;
}