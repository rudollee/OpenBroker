namespace LsOpenApi.Models;
/// <summary>
/// 주식당일매매일지/수수료(t0150)
/// </summary>
internal class t0150 : LsResponseCore
{
	public t0150InBlock t0150InBlock { get; set; } = new();
	public t0150OutBlock t0150OutBlock { get; set; } = new();
	public List<t0150OutBlock1> t0150OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - InBlock
/// </summary>
internal class t0150InBlock
{
	/// <summary>CTS_매매구분</summary>
	public string cts_medosu { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	public string cts_expcode { get; set; } = string.Empty;

	/// <summary>CTS_단가</summary>
	public string cts_price { get; set; } = string.Empty;

	/// <summary>CTS_매체</summary>
	public string cts_middiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock
/// </summary>
internal class t0150OutBlock
{
	/// <summary>매도수량</summary>
	public long mdqty { get; set; }

	/// <summary>매도약정금액</summary>
	public long mdamt { get; set; }

	/// <summary>매도수수료</summary>
	public long mdfee { get; set; }

	/// <summary>매도거래세</summary>
	public long mdtax { get; set; }

	/// <summary>매도농특세</summary>
	public long mdargtax { get; set; }

	/// <summary>매도제비용합</summary>
	public long tmdtax { get; set; }

	/// <summary>매도정산금액</summary>
	public long mdadjamt { get; set; }

	/// <summary>매수수량</summary>
	public long msqty { get; set; }

	/// <summary>매수약정금액</summary>
	public long msamt { get; set; }

	/// <summary>매수수수료</summary>
	public long msfee { get; set; }

	/// <summary>매수제비용합</summary>
	public long tmstax { get; set; }

	/// <summary>매수정산금액</summary>
	public long msadjamt { get; set; }

	/// <summary>합계수량</summary>
	public long tqty { get; set; }

	/// <summary>합계약정금액</summary>
	public long tamt { get; set; }

	/// <summary>합계수수료</summary>
	public long tfee { get; set; }

	/// <summary>합계거래세</summary>
	public long tottax { get; set; }

	/// <summary>합계농특세</summary>
	public long targtax { get; set; }

	/// <summary>합계제비용합</summary>
	public long ttax { get; set; }

	/// <summary>합계정산금액</summary>
	public long tadjamt { get; set; }

	/// <summary>CTS_매매구분</summary>
	public string cts_medosu { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	public string cts_expcode { get; set; } = string.Empty;

	/// <summary>CTS_단가</summary>
	public string cts_price { get; set; } = string.Empty;

	/// <summary>CTS_매체</summary>
	public string cts_middiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock1
/// </summary>
internal class t0150OutBlock1
{
	/// <summary>매매구분</summary>
	public string medosu { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>수량</summary>
	public long qty { get; set; }

	/// <summary>단가</summary>
	public long price { get; set; }

	/// <summary>약정금액</summary>
	public long amt { get; set; }

	/// <summary>수수료</summary>
	public long fee { get; set; }

	/// <summary>거래세</summary>
	public long tax { get; set; }

	/// <summary>농특세</summary>
	public long argtax { get; set; }

	/// <summary>정산금액</summary>
	public long adjamt { get; set; }

	/// <summary>매체</summary>
	public string middiv { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료 - 특정일자(t0150)
/// </summary>
internal class t0151 : LsResponseCore
{
	public t0151InBlock t0151InBlock { get; set; } = new();
	public t0151OutBlock t0151OutBlock { get; set; } = new();
	public List<t0151OutBlock1> t0151OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식당일매매일지/수수료 - 특정일자(t0150) - InBlock
/// </summary>
internal class t0151InBlock : t0150InBlock
{
	/// <summary>일자</summary>
	public string date { get; set; } = string.Empty;
}

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock
/// </summary>
internal class t0151OutBlock : t0150OutBlock { }

/// <summary>
/// 주식당일매매일지/수수료(t0150) - OutBlock1
/// </summary>
internal class t0151OutBlock1 : t0150OutBlock1 { }