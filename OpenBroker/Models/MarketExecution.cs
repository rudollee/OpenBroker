namespace OpenBroker.Models;

/// <summary>
/// 시장 체결
/// </summary>
public class MarketExecution
{
    /// <summary>
    /// 시장 세션 구분
    /// </summary>
    public MarketSession MarketSessionInfo { get; set; } = MarketSession.REGULAR;

    /// <summary>
    /// 거래소 구분
    /// </summary>
    public Exchange Exchange { get; set; } = Exchange.NONE;

    /// <summary>
    /// 예상치 여부
    /// </summary>
    public bool IsEstimated { get; set; } = false;

    /// <summary>
    /// 종목/상품 코드
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 체결 시간
    /// </summary>
    public DateTime TimeExecuted { get; set; }

    /// <summary>
    /// 체결가/현재가
    /// </summary>
    public decimal C { get; set; }

    /// <summary>
    /// 체결 Side - Ask / Bid
    /// </summary>
    public ExecutionSide ExecutionSide { get; set; } = ExecutionSide.NONE;

    /// <summary>
    /// 체결 거래량
    /// </summary>
    public decimal VolumeExecuted { get; set; }

    /// <summary>
    /// 기준가격
    /// </summary>
    public decimal BasePrice { get; set; }

    /// <summary>
    /// 등락
    /// </summary>
	public decimal Diff => BasePrice == 0 ? 0 : C - BasePrice;

    /// <summary>
    /// 등락률
    /// </summary>
    public decimal DiffRate => BasePrice == 0 ? 0 : (C - BasePrice) / BasePrice;

    /// <summary>
    /// 일간 데이터
    /// </summary>
    public Quote QuoteDaily { get; set; } = new();
}
