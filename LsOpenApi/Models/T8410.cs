using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// API전용주식챠트(일주월년)(t8410)
/// </summary>
internal class T8410 : LsResponseCore
{
	[JsonPropertyName("t8410InBlock")]
	public T8410InBlock T8410InBlock { get; set; } = new();
	[JsonPropertyName("t8410OutBlock")]
	public T8410OutBlock T8410OutBlock { get; set; } = new();
	[JsonPropertyName("t8410OutBlock1")]
	public List<T8410OutBlock1> T8410OutBlock1 { get; set; } = [];
}

/// <summary>
/// API전용주식챠트(일주월년)(t8410) - InBlock
/// </summary>
internal class T8410InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>주기구분(2:일3:주4:월5:년)</summary>
	[JsonPropertyName("gubun")]
	public string Gubun { get; set; } = "2";

	/// <summary>요청건수(최대-압축:2000비압축:500)</summary>
	[JsonPropertyName("qrycnt")]
	public long Qrycnt { get; set; } = 500;

	/// <summary>시작일자</summary>
	[JsonPropertyName("sdate")]
	public string Sdate { get; set; } = string.Empty;

	/// <summary>종료일자</summary>
	[JsonPropertyName("edate")]
	public string Edate { get; set; } = string.Empty;

	/// <summary>연속일자</summary>
	[JsonPropertyName("cts_date")]
	public string CtsDate { get; set; } = string.Empty;

	/// <summary>압축여부(Y:압축N:비압축)</summary>
	[JsonPropertyName("comp_yn")]
	public string CompYn { get; set; } = "N";

	/// <summary>수정주가여부(Y:적용N:비적용)</summary>
	[JsonPropertyName("sujung")]
	public string Sujung { get; set; } = "N";
}

/// <summary>
/// API전용주식챠트(일주월년)(t8410) - OutBlock
/// </summary>
internal class T8410OutBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>전일시가</summary>
	[JsonPropertyName("jisiga")]
	public long Jisiga { get; set; }

	/// <summary>전일고가</summary>
	[JsonPropertyName("jihigh")]
	public long Jihigh { get; set; }

	/// <summary>전일저가</summary>
	[JsonPropertyName("jilow")]
	public long Jilow { get; set; }

	/// <summary>전일종가</summary>
	[JsonPropertyName("jiclose")]
	public long Jiclose { get; set; }

	/// <summary>전일거래량</summary>
	[JsonPropertyName("jivolume")]
	public long Jivolume { get; set; }

	/// <summary>당일시가</summary>
	[JsonPropertyName("disiga")]
	public long Disiga { get; set; }

	/// <summary>당일고가</summary>
	[JsonPropertyName("dihigh")]
	public long Dihigh { get; set; }

	/// <summary>당일저가</summary>
	[JsonPropertyName("dilow")]
	public long Dilow { get; set; }

	/// <summary>당일종가</summary>
	[JsonPropertyName("diclose")]
	public long Diclose { get; set; }

	/// <summary>상한가</summary>
	[JsonPropertyName("highend")]
	public long Highend { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("lowend")]
	public long Lowend { get; set; }

	/// <summary>연속일자</summary>
	[JsonPropertyName("cts_date")]
	public string CtsDate { get; set; } = string.Empty;

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

	/// <summary>정적VI상한가</summary>
	[JsonPropertyName("svi_uplmtprice")]
	public long SviUplmtprice { get; set; }

	/// <summary>정적VI하한가</summary>
	[JsonPropertyName("svi_dnlmtprice")]
	public long SviDnlmtprice { get; set; }
}

/// <summary>
/// API전용주식챠트(일주월년)(t8410) - OutBlock1
/// </summary>
internal class T8410OutBlock1
{
	/// <summary>날짜</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>종가</summary>
	[JsonPropertyName("close")]
	public long Close { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("jdiff_vol")]
	public long JdiffVol { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>수정구분</summary>
	[JsonPropertyName("jongchk")]
	public long Jongchk { get; set; }

	/// <summary>수정비율</summary>
	[JsonPropertyName("rate")]
	public decimal Rate { get; set; }

	/// <summary>수정주가반영항목</summary>
	[JsonPropertyName("pricechk")]
	public long Pricechk { get; set; }

	/// <summary>수정비율반영거래대금</summary>
	[JsonPropertyName("ratevalue")]
	public long Ratevalue { get; set; }

	/// <summary>종가등락구분(1:상한2:상승3:보합4:하한5:하락주식일만사용)</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;
}