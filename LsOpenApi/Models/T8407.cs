namespace LsOpenApi.Models;
/// <summary>
/// API용주식멀티현재가조회(t8407)
/// </summary>
internal class t8407
{
	public List<t8407OutBlock1> t8407OutBlock1 { get; set; } = new();
}

/// <summary>
/// API용주식멀티현재가조회(t8407) - InBlock
/// </summary>
internal class t8407InBlock
{
	/// <summary>건수</summary>
	public long nrec { get; set; }

	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// API용주식멀티현재가조회(t8407) - OutBlock1
/// </summary>
internal class t8407OutBlock1
{
	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>누적거래량</summary>
	public long volume { get; set; }

	/// <summary>매도호가</summary>
	public long offerho { get; set; }

	/// <summary>매수호가</summary>
	public long bidho { get; set; }

	/// <summary>체결수량</summary>
	public long cvolume { get; set; }

	/// <summary>체결강도</summary>
	public decimal chdegree { get; set; }

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>거래대금(백만)</summary>
	public long value { get; set; }

	/// <summary>우선매도잔량</summary>
	public long offerrem { get; set; }

	/// <summary>우선매수잔량</summary>
	public long bidrem { get; set; }

	/// <summary>총매도잔량</summary>
	public long totofferrem { get; set; }

	/// <summary>총매수잔량</summary>
	public long totbidrem { get; set; }

	/// <summary>전일종가</summary>
	public long jnilclose { get; set; }

	/// <summary>상한가</summary>
	public long uplmtprice { get; set; }

	/// <summary>하한가</summary>
	public long dnlmtprice { get; set; }
}