namespace OpenBroker.Models;
public class Sector
{
	/// <summary>
	/// Sector Code
	/// </summary>
	public string Code { get; set; } = string.Empty;

	/// <summary>
	/// Sector Name
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Change Rate
	/// </summary>
	public decimal Diff { get; set; }
}
