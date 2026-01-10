using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션챠트(N분)(t8415)
/// </summary>
internal class T8415 : LsResponseCore
{
	[JsonPropertyName("t8415InBlock")]
	public T8415InBlock T8415InBlock { get; set; } = new();
	[JsonPropertyName("t8415OutBlock")]
	public T8415OutBlock T8415OutBlock { get; set; } = new();
	[JsonPropertyName("t8415OutBlock1")]
	public List<T8415OutBlock1> T8415OutBlock1 { get; set; } = [];
}

/// <summary>
/// 선물/옵션챠트(N분)(t8415) - InBlock
/// </summary>
internal class T8415InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>단위(n분)</summary>
	[JsonPropertyName("ncnt")]
	public long Ncnt { get; set; }

	/// <summary>요청건수(최대-압축:2000비압축:500)</summary>
	[JsonPropertyName("qrycnt")]
	public long Qrycnt { get; set; }

	/// <summary>조회영업일수(0:미사용1>=사용)</summary>
	[JsonPropertyName("nday")]
	public string Nday { get; set; } = string.Empty;

	/// <summary>시작일자</summary>
	[JsonPropertyName("sdate")]
	public string Sdate { get; set; } = string.Empty;

	/// <summary>시작시간(현재미사용)</summary>
	[JsonPropertyName("stime")]
	public string Stime { get; set; } = string.Empty;

	/// <summary>종료일자</summary>
	[JsonPropertyName("edate")]
	public string Edate { get; set; } = string.Empty;

	/// <summary>종료시간(현재미사용)</summary>
	[JsonPropertyName("etime")]
	public string Etime { get; set; } = string.Empty;

	/// <summary>연속일자</summary>
	[JsonPropertyName("cts_date")]
	public string CtsDate { get; set; } = string.Empty;

	/// <summary>연속시간</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;

	/// <summary>압축여부(Y:압축N:비압축)</summary>
	[JsonPropertyName("comp_yn")]
	public string CompYn { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션챠트(N분)(t8415) - OutBlock
/// </summary>
internal class T8415OutBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>전일시가</summary>
	[JsonPropertyName("jisiga")]
	public decimal Jisiga { get; set; }

	/// <summary>전일고가</summary>
	[JsonPropertyName("jihigh")]
	public decimal Jihigh { get; set; }

	/// <summary>전일저가</summary>
	[JsonPropertyName("jilow")]
	public decimal Jilow { get; set; }

	/// <summary>전일종가</summary>
	[JsonPropertyName("jiclose")]
	public decimal Jiclose { get; set; }

	/// <summary>전일거래량</summary>
	[JsonPropertyName("jivolume")]
	public long Jivolume { get; set; }

	/// <summary>당일시가</summary>
	[JsonPropertyName("disiga")]
	public decimal Disiga { get; set; }

	/// <summary>당일고가</summary>
	[JsonPropertyName("dihigh")]
	public decimal Dihigh { get; set; }

	/// <summary>당일저가</summary>
	[JsonPropertyName("dilow")]
	public decimal Dilow { get; set; }

	/// <summary>당일종가</summary>
	[JsonPropertyName("diclose")]
	public decimal Diclose { get; set; }

	/// <summary>상한가</summary>
	[JsonPropertyName("highend")]
	public decimal Highend { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("lowend")]
	public decimal Lowend { get; set; }

	/// <summary>연속일자</summary>
	[JsonPropertyName("cts_date")]
	public string CtsDate { get; set; } = string.Empty;

	/// <summary>연속시간</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;

	/// <summary>장시작시간(HHMMSS)</summary>
	[JsonPropertyName("s_time")]
	public string STime { get; set; } = string.Empty;

	/// <summary>장종료시간(HHMMSS)</summary>
	[JsonPropertyName("e_time")]
	public string ETime { get; set; } = string.Empty;

	/// <summary>동시호가처리시간(MM:분)</summary>
	[JsonPropertyName("dshmin")]
	public string Dshmin { get; set; } = string.Empty;

	/// <summary>레코드카운트</summary>
	[JsonPropertyName("rec_count")]
	public long RecCount { get; set; }
}

/// <summary>
/// 선물/옵션챠트(N분)(t8415) - OutBlock1
/// </summary>
internal class T8415OutBlock1
{
	/// <summary>날짜</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;

	/// <summary>시간</summary>
	[JsonPropertyName("time")]
	public string Time { get; set; } = string.Empty;

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public decimal Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public decimal High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public decimal Low { get; set; }

	/// <summary>종가</summary>
	[JsonPropertyName("close")]
	public decimal Close { get; set; }

	/// <summary>누적거래량</summary>
	[JsonPropertyName("jdiff_vol")]
	public long JdiffVol { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>미결제약정</summary>
	[JsonPropertyName("openyak")]
	public long Openyak { get; set; }
}