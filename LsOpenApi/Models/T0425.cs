using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식체결/미체결(t0425)
/// </summary>
internal class T0425 : LsResponseCore
{
	[JsonPropertyName("t0425InBlock")]
	public T0425InBlock T0425InBlock { get; set; } = new();
	[JsonPropertyName("t0425OutBlock")]
	public T0425OutBlock T0425OutBlock { get; set; } = new();
	[JsonPropertyName("t0425OutBlock1")]
	public List<T0425OutBlock1> T0425OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식체결/미체결(t0425) - InBlock
/// </summary>
internal class T0425InBlock
{
	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	[JsonPropertyName("chegb")]
	public string Chegb { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	[JsonPropertyName("medosu")]
	public string Medosu { get; set; } = string.Empty;

	/// <summary>정렬순서</summary>
	[JsonPropertyName("sortgb")]
	public string Sortgb { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	[JsonPropertyName("cts_ordno")]
	public string CtsOrdno { get; set; } = string.Empty;
}

/// <summary>
/// 주식체결/미체결(t0425) - OutBlock
/// </summary>
internal class T0425OutBlock
{
	/// <summary>총주문수량</summary>
	[JsonPropertyName("tqty")]
	public long Tqty { get; set; }

	/// <summary>총체결수량</summary>
	[JsonPropertyName("tcheqty")]
	public long Tcheqty { get; set; }

	/// <summary>총미체결수량</summary>
	[JsonPropertyName("tordrem")]
	public long Tordrem { get; set; }

	/// <summary>추정수수료</summary>
	[JsonPropertyName("cmss")]
	public long Cmss { get; set; }

	/// <summary>총주문금액</summary>
	[JsonPropertyName("tamt")]
	public long Tamt { get; set; }

	/// <summary>총매도체결금액</summary>
	[JsonPropertyName("tmdamt")]
	public long Tmdamt { get; set; }

	/// <summary>총매수체결금액</summary>
	[JsonPropertyName("tmsamt")]
	public long Tmsamt { get; set; }

	/// <summary>추정제세금</summary>
	[JsonPropertyName("tax")]
	public long Tax { get; set; }

	/// <summary>주문번호</summary>
	[JsonPropertyName("cts_ordno")]
	public string CtsOrdno { get; set; } = string.Empty;
}

/// <summary>
/// 주식체결/미체결(t0425) - OutBlock1
/// </summary>
internal class T0425OutBlock1
{
	/// <summary>주문번호</summary>
	[JsonPropertyName("ordno")]
	public long Ordno { get; set; }

	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>구분</summary>
	[JsonPropertyName("medosu")]
	public string Medosu { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	[JsonPropertyName("qty")]
	public long Qty { get; set; }

	/// <summary>주문가격</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>체결수량</summary>
	[JsonPropertyName("cheqty")]
	public long Cheqty { get; set; }

	/// <summary>체결가격</summary>
	[JsonPropertyName("cheprice")]
	public long Cheprice { get; set; }

	/// <summary>미체결잔량</summary>
	[JsonPropertyName("ordrem")]
	public long Ordrem { get; set; }

	/// <summary>확인수량</summary>
	[JsonPropertyName("cfmqty")]
	public long Cfmqty { get; set; }

	/// <summary>상태</summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	[JsonPropertyName("orgordno")]
	public long Orgordno { get; set; }

	/// <summary>유형</summary>
	[JsonPropertyName("ordgb")]
	public string Ordgb { get; set; } = string.Empty;

	/// <summary>주문시간</summary>
	[JsonPropertyName("ordtime")]
	public string Ordtime { get; set; } = string.Empty;

	/// <summary>주문매체</summary>
	[JsonPropertyName("ordermtd")]
	public string Ordermtd { get; set; } = string.Empty;

	/// <summary>처리순번</summary>
	[JsonPropertyName("sysprocseq")]
	public long Sysprocseq { get; set; }

	/// <summary>호가유형</summary>
	[JsonPropertyName("hogagb")]
	public string Hogagb { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price1")]
	public long Price1 { get; set; }

	/// <summary>주문구분</summary>
	[JsonPropertyName("orggb")]
	public string Orggb { get; set; } = string.Empty;

	/// <summary>신용구분</summary>
	[JsonPropertyName("singb")]
	public string Singb { get; set; } = string.Empty;

	/// <summary>대출일자</summary>
	[JsonPropertyName("loandt")]
	public string Loandt { get; set; } = string.Empty;

	/// <summary>거래소명</summary>
	[JsonPropertyName("exchname")]
	public string Exchname { get; set; } = string.Empty;
}