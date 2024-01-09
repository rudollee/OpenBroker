namespace OpenBroker.Models;

public class Instrument
{
    public string Symbol { get; set; } = string.Empty;
    public string Sym { get; set; } = string.Empty;
    public string SymD { get; set; } = string.Empty;
    public string SymStrike { get; set; } = string.Empty;
    public string InstrumentName { get; set; } = string.Empty;
    public string SymbolUnderlying { get; set; } = string.Empty;
    public decimal MarginRate { get; set; }
    public decimal Margin { get; set; }
    public int PRCSN { get; set; }
}
