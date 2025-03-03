namespace LsOpenApi.Models;
/// <summary>
/// 주식체결/미체결(t0425)
/// </summary>
internal class t0425 : LsResponseCore
{
	public t0425OutBlock t0425OutBlock { get; set; } = new();
	public List<t0425OutBlock1> t0425OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식체결/미체결(t0425) - InBlock
/// </summary>
internal class t0425InBlock
{
	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	public string chegb { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string medosu { get; set; } = string.Empty;

	/// <summary>정렬순서</summary>
	public string sortgb { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string cts_ordno { get; set; } = string.Empty;
}

/// <summary>
/// 주식체결/미체결(t0425) - OutBlock
/// </summary>
internal class t0425OutBlock
{
	/// <summary>총주문수량</summary>
	public long tqty { get; set; }

	/// <summary>총체결수량</summary>
	public long tcheqty { get; set; }

	/// <summary>총미체결수량</summary>
	public long tordrem { get; set; }

	/// <summary>추정수수료</summary>
	public long cmss { get; set; }

	/// <summary>총주문금액</summary>
	public long tamt { get; set; }

	/// <summary>총매도체결금액</summary>
	public long tmdamt { get; set; }

	/// <summary>총매수체결금액</summary>
	public long tmsamt { get; set; }

	/// <summary>추정제세금</summary>
	public long tax { get; set; }

	/// <summary>주문번호</summary>
	public string cts_ordno { get; set; } = string.Empty;

}

/// <summary>
/// 주식체결/미체결(t0425) - OutBlock1
/// </summary>
internal class t0425OutBlock1
{
	/// <summary>주문번호</summary>
	public long ordno { get; set; }

	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>구분</summary>
	public string medosu { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public long qty { get; set; }

	/// <summary>주문가격</summary>
	public long price { get; set; }

	/// <summary>체결수량</summary>
	public long cheqty { get; set; }

	/// <summary>체결가격</summary>
	public long cheprice { get; set; }

	/// <summary>미체결잔량</summary>
	public long ordrem { get; set; }

	/// <summary>확인수량</summary>
	public long cfmqty { get; set; }

	/// <summary>상태</summary>
	public string status { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public long orgordno { get; set; }

	/// <summary>유형</summary>
	public string ordgb { get; set; } = string.Empty;

	/// <summary>주문시간</summary>
	public string ordtime { get; set; } = string.Empty;

	/// <summary>주문매체</summary>
	public string ordermtd { get; set; } = string.Empty;

	/// <summary>처리순번</summary>
	public long sysprocseq { get; set; }

	/// <summary>호가유형</summary>
	public string hogagb { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price1 { get; set; }

	/// <summary>주문구분</summary>
	public string orggb { get; set; } = string.Empty;

	/// <summary>신용구분</summary>
	public string singb { get; set; } = string.Empty;

	/// <summary>대출일자</summary>
	public string loandt { get; set; } = string.Empty;

	/// <summary>거래소명</summary>
	public string exchname { get; set; } = string.Empty;
}
