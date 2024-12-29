namespace LsOpenApi.Models;
/// <summary>
/// 주식챠트(틱/n틱)(t8411)
/// </summary>
internal class t8411 : LsResponseCore
{
	public t841XInBlock t8411InBlock { get; set; } = new();
	public t841XOutBlock t8411OutBlock { get; set; } = new();
	public List<t8411OutBlock1> t8411OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식챠트(틱 / 분)(t8411 or t8412) - InBlock
/// </summary>
internal class t841XInBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>단위(n틱)</summary>
	public long ncnt { get; set; }

	/// <summary>요청건수(최대-압축:2000비압축:500)</summary>
	public long qrycnt { get; set; } = 500;

	/// <summary>조회영업일수(0:미사용1>=사용)</summary>
	public string nday { get; set; } = "0";

	/// <summary>시작일자</summary>
	public string sdate { get; set; } = string.Empty;

	/// <summary>시작시간(현재미사용)</summary>
	public string stime { get; set; } = " ";

	/// <summary>종료일자</summary>
	public string edate { get; set; } = " ";

	/// <summary>종료시간(현재미사용)</summary>
	public string etime { get; set; } = string.Empty;

	/// <summary>연속일자</summary>
	public string cts_date { get; set; } = " ";

	/// <summary>연속시간</summary>
	public string cts_time { get; set; } = " ";

	/// <summary>압축여부(Y:압축N:비압축)</summary>
	public string comp_yn { get; set; } = "N";

}

/// <summary>
/// 주식챠트(틱 / 분)(t8411 or t8412) - OutBlock
/// </summary>
internal class t841XOutBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>전일시가</summary>
	public long jisiga { get; set; }

	/// <summary>전일고가</summary>
	public long jihigh { get; set; }

	/// <summary>전일저가</summary>
	public long jilow { get; set; }

	/// <summary>전일종가</summary>
	public long jiclose { get; set; }

	/// <summary>전일거래량</summary>
	public long jivolume { get; set; }

	/// <summary>당일시가</summary>
	public long disiga { get; set; }

	/// <summary>당일고가</summary>
	public long dihigh { get; set; }

	/// <summary>당일저가</summary>
	public long dilow { get; set; }

	/// <summary>당일종가</summary>
	public long diclose { get; set; }

	/// <summary>상한가</summary>
	public long highend { get; set; }

	/// <summary>하한가</summary>
	public long lowend { get; set; }

	/// <summary>연속일자</summary>
	public string cts_date { get; set; } = string.Empty;

	/// <summary>연속시간</summary>
	public string cts_time { get; set; } = string.Empty;

	/// <summary>장시작시간(HHMMSS)</summary>
	public string s_time { get; set; } = string.Empty;

	/// <summary>장종료시간(HHMMSS)</summary>
	public string e_time { get; set; } = string.Empty;

	/// <summary>동시호가처리시간(MM:분)</summary>
	public string dshmin { get; set; } = string.Empty;

	/// <summary>레코드카운트</summary>
	public long rec_count { get; set; }
}

/// <summary>
/// 주식챠트(틱/n틱)(t8411) - OutBlock1
/// </summary>
internal class t8411OutBlock1
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

	/// <summary>수정구분</summary>
	public long jongchk { get; set; }

	/// <summary>수정비율</summary>
	public decimal rate { get; set; }

	/// <summary>수정주가반영항목</summary>
	public long pricechk { get; set; }
}