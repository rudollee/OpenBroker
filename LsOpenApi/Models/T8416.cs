namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션챠트(일주월)(t8416)
/// </summary>
internal class t8416 : LsResponseCore
{
	public t8416InBlock t8416InBlock { get; set; } = new();
	public t8416OutBlock t8416OutBlock { get; set; } = new();
	public List<t8416OutBlock1> t8416OutBlock1 { get; set; } = new();
}

/// <summary>
/// 선물/옵션챠트(일주월)(t8416) - InBlock
/// </summary>
internal class t8416InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>주기구분(2:일, 3:주, 4:월)</summary>
	public string gubun { get; set; } = "2";

	/// <summary>요청건수(최대-압축:2000비압축:500)</summary>
	public long qrycnt { get; set; } 

	/// <summary>시작일자</summary>
	public string sdate { get; set; } = string.Empty;

	/// <summary>종료일자</summary>
	public string edate { get; set; } = string.Empty;

	/// <summary>연속일자</summary>
	public string cts_date { get; set; } = string.Empty;

	/// <summary>압축여부(Y:압축N:비압축)</summary>
	public string comp_yn { get; set; } = "N";

}

/// <summary>
/// 선물/옵션챠트(일주월)(t8416) - OutBlock
/// </summary>
internal class t8416OutBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>전일시가</summary>
	public decimal jisiga { get; set; } 

	/// <summary>전일고가</summary>
	public decimal jihigh { get; set; } 

	/// <summary>전일저가</summary>
	public decimal jilow { get; set; } 

	/// <summary>전일종가</summary>
	public decimal jiclose { get; set; } 

	/// <summary>전일거래량</summary>
	public long jivolume { get; set; } 

	/// <summary>당일시가</summary>
	public decimal disiga { get; set; } 

	/// <summary>당일고가</summary>
	public decimal dihigh { get; set; } 

	/// <summary>당일저가</summary>
	public decimal dilow { get; set; } 

	/// <summary>당일종가</summary>
	public decimal diclose { get; set; } 

	/// <summary>상한가</summary>
	public decimal highend { get; set; } 

	/// <summary>하한가</summary>
	public decimal lowend { get; set; } 

	/// <summary>연속일자</summary>
	public string cts_date { get; set; } = string.Empty;

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
/// 선물/옵션챠트(일주월)(t8416) - OutBlock1
/// </summary>
internal class t8416OutBlock1
{
	/// <summary>날짜</summary>
	public string date { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public decimal open { get; set; } 

	/// <summary>고가</summary>
	public decimal high { get; set; } 

	/// <summary>저가</summary>
	public decimal low { get; set; } 

	/// <summary>종가</summary>
	public decimal close { get; set; } 

	/// <summary>누적거래량</summary>
	public long jdiff_vol { get; set; } 

	/// <summary>거래대금</summary>
	public long value { get; set; } 

	/// <summary>미결제약정</summary>
	public long openyak { get; set; } 

}

