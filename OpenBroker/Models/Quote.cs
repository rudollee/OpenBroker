namespace OpenBroker.Models;

/// <summary>
/// 시고저종
/// </summary>
public class Quote
{
	public DateTime T { get; set; }
	public decimal BasePrice { get; set; }
    public decimal C { get; set; }
    public decimal O { get; set; }
    public decimal H { get; set; }
    public decimal L { get; set; }
    public decimal V { get; set; }
    public decimal Turnover { get; set; }
}

/// <summary>
/// 시고저종 + 비율 + 상한가/하한가
/// </summary>
public class QuoteRate : Quote
{
	public decimal ORate { get => BasePrice == 0 ? 0 : (O - BasePrice) / BasePrice; }

	public decimal HRate { get => BasePrice == 0 ? 0 : (H - BasePrice) / BasePrice; }

	public decimal LRate { get => BasePrice == 0 ? 0 : (L - BasePrice) / BasePrice; }

	/// <summary>
	/// 상한가
	/// </summary>
	public decimal HighLimit { get; set; }

	/// <summary>
	/// 하한가
	/// </summary>
	public decimal LowLimit { get; set; }
}

/// <summary>
/// 시고저종, 거래량, 미결제약정, 기초자산종가
/// </summary>
public class QuoteExt : Quote
{
	/// <summary>
	/// Open Interest
	/// </summary>
	public decimal OI { get; set; }

	/// <summary>
	/// Underlying Asset Price (Close)
	/// </summary>
	public decimal CloseUnderlying { get; set; }
}

/// <summary>
/// 시고저종, 거래량, 미결제약정, 행사가
/// </summary>
public class QuoteOption : Quote
{
	public string Strike { get; set; } = string.Empty;

	public decimal OI { get; set; }
}