namespace LsOpenApi.Models;
/// <summary>
/// 테마종목별시세조회(t1537)
/// </summary>
internal class t1537 : LsResponseCore
{
	public t1537InBlock t1537InBlock { get; set; } = new();
	public t1537OutBlock t1537OutBlock { get; set; } = new();
	public List<t1537OutBlock1> t1537OutBlock1 { get; set; } = new();
}

/// <summary>
/// 테마종목별시세조회(t1537) - InBlock
/// </summary>
internal class t1537InBlock
{
	/// <summary>테마코드</summary>
	public string tmcode { get; set; } = string.Empty;
}

/// <summary>
/// 테마종목별시세조회(t1537) - OutBlock
/// </summary>
internal class t1537OutBlock
{
	/// <summary>상승종목수</summary>
	public long upcnt { get; set; }

	/// <summary>테마종목수</summary>
	public long tmcnt { get; set; }

	/// <summary>상승종목비율</summary>
	public long uprate { get; set; }

	/// <summary>테마명</summary>
	public string tmname { get; set; } = string.Empty;
}

/// <summary>
/// 테마종목별시세조회(t1537) - OutBlock1
/// </summary>
internal class t1537OutBlock1
{
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

	/// <summary>전일동시간</summary>
	public decimal jniltime { get; set; }

	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	public long yeprice { get; set; }

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>누적거래대금(단위:백만)</summary>
	public long value { get; set; }

	/// <summary>시가총액(단위:백만)</summary>
	public long marketcap { get; set; }
}