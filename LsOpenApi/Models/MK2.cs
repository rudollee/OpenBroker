namespace LsOpenApi.Models;
/// <summary>
/// US지수(MK2)
/// </summary>
internal class MK2
{
	public MK2InBlock MK2InBlock { get; set; } = new();
	public MK2OutBlock MK2OutBlock { get; set; } = new();
}

/// <summary>
/// US지수(MK2) - InBlock
/// </summary>
internal class MK2InBlock
{
	/// <summary>심볼코드</summary>
	public string symbol { get; set; } = string.Empty;
}

/// <summary>
/// US지수(MK2) - OutBlock
/// </summary>
internal class MK2OutBlock
{
	/// <summary>일자</summary>
	public string date { get; set; } = string.Empty;

	/// <summary>시간</summary>
	public string time { get; set; } = string.Empty;

	/// <summary>한국일자</summary>
	public string kodate { get; set; } = string.Empty;

	/// <summary>한국시간</summary>
	public string kotime { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public string open { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public string high { get; set; } = string.Empty;

	/// <summary>저가</summary>
	public string low { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public string price { get; set; } = string.Empty;

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public string change { get; set; } = string.Empty;

	/// <summary>등락율</summary>
	public string uprate { get; set; } = string.Empty;

	/// <summary>매수호가</summary>
	public string bidho { get; set; } = string.Empty;

	/// <summary>매수잔량</summary>
	public string bidrem { get; set; } = string.Empty;

	/// <summary>매도호가</summary>
	public string offerho { get; set; } = string.Empty;

	/// <summary>매도잔량</summary>
	public string offerrem { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	public string volume { get; set; } = string.Empty;

	/// <summary>심벌</summary>
	public string xsymbol { get; set; } = string.Empty;

	/// <summary>체결거래량</summary>
	public string cvolume { get; set; } = string.Empty;
}