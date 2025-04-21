namespace OpenBroker.Models;
public class OptionsInfo : InstrumentCore
{
	public required QuoteRate QuoteInfo { get; set; }

	public OptionGreek? Greek { get; set; }

	public decimal OI { get; set; }
}

public class OptionPack
{
	public int ExpiryLeft { get; set; }

	public List<OptionsInfo> Calls { get; set; } = new();

	public List<OptionsInfo> Puts { get; set; } = new();

}
