using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션잔고평가(이동평균)(t0441)
/// </summary>
internal class T0441 : LsResponseCore
{
	[JsonPropertyName("t0441InBlock")]
	public T0441InBlock T0441InBlock { get; set; } = new();
	[JsonPropertyName("t0441OutBlock")]
	public T0441OutBlock T0441OutBlock { get; set; } = new();
	[JsonPropertyName("t0441OutBlock1")]
	public List<T0441OutBlock1> T0441OutBlock1 { get; set; } = [];
}

/// <summary>
/// 선물/옵션잔고평가(이동평균)(t0441) - InBlock
/// </summary>
internal class T0441InBlock
{
	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;

	/// <summary>CTS_매매구분</summary>
	[JsonPropertyName("cts_medocd")]
	public string CtsMedocd { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션잔고평가(이동평균)(t0441) - OutBlock
/// </summary>
internal class T0441OutBlock
{
	/// <summary>매매손익합계</summary>
	[JsonPropertyName("tdtsunik")]
	public long Tdtsunik { get; set; }

	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;

	/// <summary>CTS_매매구분</summary>
	[JsonPropertyName("cts_medocd")]
	public string CtsMedocd { get; set; } = string.Empty;

	/// <summary>평가금액</summary>
	[JsonPropertyName("tappamt")]
	public long Tappamt { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("tsunik")]
	public long Tsunik { get; set; }
}

/// <summary>
/// 선물/옵션잔고평가(이동평균)(t0441) - OutBlock1
/// </summary>
internal class T0441OutBlock1
{
	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>구분</summary>
	[JsonPropertyName("medosu")]
	public string Medosu { get; set; } = string.Empty;

	/// <summary>잔고수량</summary>
	[JsonPropertyName("jqty")]
	public long Jqty { get; set; }

	/// <summary>청산가능수량</summary>
	[JsonPropertyName("cqty")]
	public long Cqty { get; set; }

	/// <summary>평균단가</summary>
	[JsonPropertyName("pamt")]
	public decimal Pamt { get; set; }

	/// <summary>총매입금액</summary>
	[JsonPropertyName("mamt")]
	public long Mamt { get; set; }

	/// <summary>매매구분</summary>
	[JsonPropertyName("medocd")]
	public string Medocd { get; set; } = string.Empty;

	/// <summary>매매손익</summary>
	[JsonPropertyName("dtsunik")]
	public long Dtsunik { get; set; }

	/// <summary>처리순번</summary>
	[JsonPropertyName("sysprocseq")]
	public long Sysprocseq { get; set; }

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public decimal Price { get; set; }

	/// <summary>평가금액</summary>
	[JsonPropertyName("appamt")]
	public long Appamt { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("dtsunik1")]
	public long Dtsunik1 { get; set; }

	/// <summary>수익율</summary>
	[JsonPropertyName("sunikrt")]
	public decimal Sunikrt { get; set; }
}