namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션체결/미체결(t0434)
/// </summary>
internal class t0434 : LsResponseCore
{
	public t0434InBlock t0434InBlock { get; set; } = new();
	public t0434OutBlock t0434OutBlock { get; set; } = new();
	public List<t0434OutBlock1> t0434OutBlock1 { get; set; } = new();
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - InBlock
/// </summary>
internal class t0434InBlock
{
	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	public string chegb { get; set; } = "0";

	/// <summary>정렬순서</summary>
	public string sortgb { get; set; } = "2";

	/// <summary>CTS_주문번호</summary>
	public string cts_ordno { get; set; } = " ";
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - OutBlock
/// </summary>
internal class t0434OutBlock
{
	/// <summary>CTS_주문번호</summary>
	public string cts_ordno { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - OutBlock1
/// </summary>
internal class t0434OutBlock1
{
	/// <summary>주문번호</summary>
	public long ordno { get; set; }

	/// <summary>원주문번호</summary>
	public long orgordno { get; set; }

	/// <summary>구분</summary>
	public string medosu { get; set; } = string.Empty;

	/// <summary>유형</summary>
	public string ordgb { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public long qty { get; set; }

	/// <summary>주문가격</summary>
	public decimal price { get; set; }

	/// <summary>체결수량</summary>
	public long cheqty { get; set; }

	/// <summary>체결가격</summary>
	public decimal cheprice { get; set; }

	/// <summary>미체결잔량</summary>
	public long ordrem { get; set; }

	/// <summary>상태</summary>
	public string status { get; set; } = string.Empty;

	/// <summary>주문시간</summary>
	public string ordtime { get; set; } = string.Empty;

	/// <summary>주문매체</summary>
	public string ordermtd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>사유코드</summary>
	public string rtcode { get; set; } = string.Empty;

	/// <summary>처리순번</summary>
	public long sysprocseq { get; set; }

	/// <summary>호가타입</summary>
	public string hogatype { get; set; } = string.Empty;
}