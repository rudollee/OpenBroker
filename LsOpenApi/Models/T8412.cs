namespace LsOpenApi.Models;
/// <summary>
/// 주식챠트(N분)(t8412)
/// </summary>
internal class t8412 : LsResponseCore
{
	public t841XInBlock t8412InBlock { get; set; } = new();
	public t841XOutBlock t8412OutBlock { get; set; } = new();
	public List<t8412OutBlock1> t8412OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식챠트(N분)(t8412) - OutBlock1
/// </summary>
internal class t8412OutBlock1
{
	/// <summary>날짜</summary>
	public string date { get; set; } = string.Empty;

	/// <summary>시간</summary>
	public string time { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>종가</summary>
	public long close { get; set; }

	/// <summary>거래량</summary>
	public long jdiff_vol { get; set; }

	/// <summary>거래대금</summary>
	public long value { get; set; }

	/// <summary>수정구분</summary>
	public long jongchk { get; set; }

	/// <summary>수정비율</summary>
	public decimal rate { get; set; }

	/// <summary>종가등락구분(1:상한2:상승3:보합4:하한5:하락)</summary>
	public string sign { get; set; } = string.Empty;
}