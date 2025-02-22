namespace OpenBroker.Models;

public class InstrumentCore
{
    /// <summary>
    /// Market
    /// </summary>
	public ExchangeSection Section { get; set; } = ExchangeSection.NONE;
	
    /// <summary>
    /// Currency
    /// </summary>
    public Currency Currency { get; set; }

    /// <summary>
    /// Symbol Code for Order
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Instrument Code (part of Symbol)
    /// </summary>
    public string Sym { get; set; } = string.Empty;

    /// <summary>
    /// Expiration Code (part of Symbol)
    /// </summary>
    public string SymD { get; set; } = string.Empty;

    /// <summary>
    /// Strike Price Code (part of Symbol) (for options)
    /// </summary>
    public string SymStrike { get; set; } = string.Empty;

    /// <summary>
    /// Instrument Name
    /// </summary>
    public string InstrumentName { get; set; } = string.Empty;

    /// <summary>
    /// Nemeral System (default: 10)
    /// </summary>
    public int NumeralSystem { get; set; } = 10;

    /// <summary>
    /// Precision
    /// </summary>
    public int Precision { get; set; }

    /// <summary>
    /// Tradable
    /// </summary>
    public bool Tradable { get; set; }

    /// <summary>
    /// Status for Trading
    /// </summary>
	public DiscardStatus DiscardStatus { get; set; } = DiscardStatus.TRADABLE;
}

public class Instrument : InstrumentCore
{
    public Exchange ExchangeCode { get; set; }

	/// <summary>
	/// Tick Size
	/// </summary>
	public decimal Tick { get; set; }

	/// <summary>
	/// Tick Value
	/// </summary>
	public decimal TickValue { get; set; }

	/// <summary>
	/// Symbol Code of Unerlying Asset
	/// </summary>
	public string SymbolUnderlying { get; set; } = string.Empty;

	/// <summary>
	/// Margin Rate
	/// </summary>
	public decimal MarginRate { get; set; }

	/// <summary>
	/// Margin Amount
	/// </summary>
	public decimal Margin { get; set; }

    public decimal Multiple { get; set; }

    public bool HasNearing { get; set; }

	public DateOnly DateOpened { get; set; }

    public DateOnly DateExpired { get; set; }

    public TimeOnly TimeOpen { get; set; }

    public TimeOnly TimeClosed { get; set; }
}

