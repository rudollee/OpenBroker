using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식챠트(N분)(t8412)
/// </summary>
internal class T8412 : LsResponseCore
{
	[JsonPropertyName("t8412InBlock")]
	public T8412InBlock T8412InBlock { get; set; } = new();
	[JsonPropertyName("t8412OutBlock")]
	public T8412OutBlock T8412OutBlock { get; set; } = new();
	[JsonPropertyName("t8412OutBlock1")]
	public List<T8412OutBlock1> T8412OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식챠트(N분)(t8412) - InBlock
/// </summary>
internal class T8412InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>단위(n분)</summary>
	[JsonPropertyName("ncnt")]
	public long Ncnt { get; set; }

	/// <summary>요청건수(최대-압축:2000비압축:500)</summary>
	[JsonPropertyName("qrycnt")]
	public long QryCnt { get; set; }

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
	public string CompYn { get; set; } = "N";

	/// <summary>KRX정규장구분, Y: 정규장만</summary>
	[JsonPropertyName("krx_mmk_gubun")]
	public string KrxMmkGubun { get; set; } = "Y";
}

/// <summary>
/// 주식챠트(N분)(t8412) - OutBlock
/// </summary>
internal class T8412OutBlock
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
/// 주식챠트(N분)(t8412) - OutBlock1
/// </summary>
internal class T8412OutBlock1
{
	/// <summary>날짜</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;

	/// <summary>시간</summary>
	[JsonPropertyName("time")]
	public string Time { get; set; } = string.Empty;

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

	/// <summary>종가등락구분(1:상한2:상승3:보합4:하한5:하락)</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;
}