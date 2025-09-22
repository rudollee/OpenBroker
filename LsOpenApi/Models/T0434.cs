using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션체결/미체결(t0434)
/// </summary>
internal class T0434 : LsResponseCore
{
	[JsonPropertyName("t0434InBlock")]
	public T0434InBlock T0434InBlock { get; set; } = new();
	[JsonPropertyName("t0434OutBlock")]
	public T0434OutBlock T0434OutBlock { get; set; } = new();
	[JsonPropertyName("t0434OutBlock1")]
	public List<T0434OutBlock1> T0434OutBlock1 { get; set; } = [];
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - InBlock
/// </summary>
internal class T0434InBlock
{
	/// <summary>계좌번호</summary>
	[JsonPropertyName("accno")]
	public string Accno { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	[JsonPropertyName("passwd")]
	public string Passwd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	[JsonPropertyName("chegb")]
	public string Chegb { get; set; } = string.Empty;

	/// <summary>정렬순서</summary>
	[JsonPropertyName("sortgb")]
	public string Sortgb { get; set; } = string.Empty;

	/// <summary>CTS_주문번호</summary>
	[JsonPropertyName("cts_ordno")]
	public string CtsOrdno { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - OutBlock
/// </summary>
internal class T0434OutBlock
{
	/// <summary>CTS_주문번호</summary>
	[JsonPropertyName("cts_ordno")]
	public string CtsOrdno { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션체결/미체결(t0434) - OutBlock1
/// </summary>
internal class T0434OutBlock1
{
	/// <summary>주문번호</summary>
	[JsonPropertyName("ordno")]
	public long Ordno { get; set; }

	/// <summary>원주문번호</summary>
	[JsonPropertyName("orgordno")]
	public long Orgordno { get; set; }

	/// <summary>구분</summary>
	[JsonPropertyName("medosu")]
	public string Medosu { get; set; } = string.Empty;

	/// <summary>유형</summary>
	[JsonPropertyName("ordgb")]
	public string Ordgb { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	[JsonPropertyName("qty")]
	public long Qty { get; set; }

	/// <summary>주문가격</summary>
	[JsonPropertyName("price")]
	public decimal Price { get; set; }

	/// <summary>체결수량</summary>
	[JsonPropertyName("cheqty")]
	public long Cheqty { get; set; }

	/// <summary>체결가격</summary>
	[JsonPropertyName("cheprice")]
	public decimal Cheprice { get; set; }

	/// <summary>미체결잔량</summary>
	[JsonPropertyName("ordrem")]
	public long Ordrem { get; set; }

	/// <summary>상태</summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	/// <summary>주문시간</summary>
	[JsonPropertyName("ordtime")]
	public string Ordtime { get; set; } = string.Empty;

	/// <summary>주문매체</summary>
	[JsonPropertyName("ordermtd")]
	public string Ordermtd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>사유코드</summary>
	[JsonPropertyName("rtcode")]
	public string Rtcode { get; set; } = string.Empty;

	/// <summary>처리순번</summary>
	[JsonPropertyName("sysprocseq")]
	public long Sysprocseq { get; set; }

	/// <summary>호가타입</summary>
	[JsonPropertyName("hogatype")]
	public string Hogatype { get; set; } = string.Empty;
}