using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식당일매매일지/수수료(t0150)
/// </summary>
internal class T0150 : LsResponseCore
{
	[JsonPropertyName("t0150InBlock")]
	public T0150InBlock T0150InBlock { get; set; } = new();
	[JsonPropertyName("t0150OutBlock")]
	public T0150OutBlock T0150OutBlock { get; set; } = new();
	[JsonPropertyName("t0150OutBlock1")]
	public List<T0150OutBlock1> T0150OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - InBlock
/// </summary>
internal class T0150InBlock
{
	/// <summary>계좌번호</summary>
	[JsonPropertyName("accno")]
	public string Accno { get; set; } = string.Empty;

	/// <summary>CTS_매매구분</summary>
	[JsonPropertyName("cts_medosu")]
	public string CtsMedosu { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;

	/// <summary>CTS_단가</summary>
	[JsonPropertyName("cts_price")]
	public string CtsPrice { get; set; } = string.Empty;

	/// <summary>CTS_매체</summary>
	[JsonPropertyName("cts_middiv")]
	public string CtsMiddiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock
/// </summary>
internal class T0150OutBlock
{
	/// <summary>매도수량</summary>
	[JsonPropertyName("mdqty")]
	public long Mdqty { get; set; }

	/// <summary>매도약정금액</summary>
	[JsonPropertyName("mdamt")]
	public long Mdamt { get; set; }

	/// <summary>매도수수료</summary>
	[JsonPropertyName("mdfee")]
	public long Mdfee { get; set; }

	/// <summary>매도거래세</summary>
	[JsonPropertyName("mdtax")]
	public long Mdtax { get; set; }

	/// <summary>매도농특세</summary>
	[JsonPropertyName("mdargtax")]
	public long Mdargtax { get; set; }

	/// <summary>매도제비용합</summary>
	[JsonPropertyName("tmdtax")]
	public long Tmdtax { get; set; }

	/// <summary>매도정산금액</summary>
	[JsonPropertyName("mdadjamt")]
	public long Mdadjamt { get; set; }

	/// <summary>매수수량</summary>
	[JsonPropertyName("msqty")]
	public long Msqty { get; set; }

	/// <summary>매수약정금액</summary>
	[JsonPropertyName("msamt")]
	public long Msamt { get; set; }

	/// <summary>매수수수료</summary>
	[JsonPropertyName("msfee")]
	public long Msfee { get; set; }

	/// <summary>매수제비용합</summary>
	[JsonPropertyName("tmstax")]
	public long Tmstax { get; set; }

	/// <summary>매수정산금액</summary>
	[JsonPropertyName("msadjamt")]
	public long Msadjamt { get; set; }

	/// <summary>합계수량</summary>
	[JsonPropertyName("tqty")]
	public long Tqty { get; set; }

	/// <summary>합계약정금액</summary>
	[JsonPropertyName("tamt")]
	public long Tamt { get; set; }

	/// <summary>합계수수료</summary>
	[JsonPropertyName("tfee")]
	public long Tfee { get; set; }

	/// <summary>합계거래세</summary>
	[JsonPropertyName("tottax")]
	public long Tottax { get; set; }

	/// <summary>합계농특세</summary>
	[JsonPropertyName("targtax")]
	public long Targtax { get; set; }

	/// <summary>합계제비용합</summary>
	[JsonPropertyName("ttax")]
	public long Ttax { get; set; }

	/// <summary>합계정산금액</summary>
	[JsonPropertyName("tadjamt")]
	public long Tadjamt { get; set; }

	/// <summary>CTS_매매구분</summary>
	[JsonPropertyName("cts_medosu")]
	public string CtsMedosu { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;

	/// <summary>CTS_단가</summary>
	[JsonPropertyName("cts_price")]
	public string CtsPrice { get; set; } = string.Empty;

	/// <summary>CTS_매체</summary>
	[JsonPropertyName("cts_middiv")]
	public string CtsMiddiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock1
/// </summary>
internal class T0150OutBlock1
{
	/// <summary>매매구분</summary>
	[JsonPropertyName("medosu")]
	public string Medosu { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>수량</summary>
	[JsonPropertyName("qty")]
	public long Qty { get; set; }

	/// <summary>단가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>약정금액</summary>
	[JsonPropertyName("amt")]
	public long Amt { get; set; }

	/// <summary>수수료</summary>
	[JsonPropertyName("fee")]
	public long Fee { get; set; }

	/// <summary>거래세</summary>
	[JsonPropertyName("tax")]
	public long Tax { get; set; }

	/// <summary>농특세</summary>
	[JsonPropertyName("argtax")]
	public long Argtax { get; set; }

	/// <summary>정산금액</summary>
	[JsonPropertyName("adjamt")]
	public long Adjamt { get; set; }

	/// <summary>매체</summary>
	[JsonPropertyName("middiv")]
	public string Middiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료 - 특정일자(t0150)
/// </summary>
internal class T0151 : LsResponseCore
{
	[JsonPropertyName("t0151InBlock")]
	public T0151InBlock T0151InBlock { get; set; } = new();
	[JsonPropertyName("t0151OutBlock")]
	public T0150OutBlock T0151OutBlock { get; set; } = new();
	[JsonPropertyName("t0151OutBlock1")]
	public List<T0150OutBlock1> T0151OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식당일매매일지/수수료 - 특정일자(t0150) - InBlock
/// </summary>
internal class T0151InBlock : T0150InBlock
{
	/// <summary>일자</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;
}