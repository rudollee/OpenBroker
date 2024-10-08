namespace OpenBroker.Models;

/// <summary>
/// 시장 체결
/// </summary>
public class MarketContract
{
    /// <summary>
    /// 종목/상품 코드
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 체결 시간
    /// </summary>
    public DateTime TimeContract { get; set; }

    /// <summary>
    /// 현재가
    /// </summary>
    public decimal C { get; set; }

    /// <summary>
    /// 체결 거래량
    /// </summary>
    public decimal V { get; set; }

    /// <summary>
    /// 기준가격
    /// </summary>
    public decimal BasePrice { get; set; }

    /// <summary>
    /// 등락
    /// </summary>
	public decimal Diff { get => BasePrice == 0 ? 0 : C - BasePrice; }

    /// <summary>
    /// 등락률
    /// </summary>
	public decimal DiffRate { get => BasePrice == 0 ? 0 : (C - BasePrice) / BasePrice; }

    /// <summary>
    /// 일간 누적 거래량
    /// </summary>
    public decimal VolumeAcc { get; set; }

    /// <summary>
    /// 일간 누적 거래대금
    /// </summary>
    public decimal MoneyAcc { get; set; }
}
