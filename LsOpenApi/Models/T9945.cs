namespace LsOpenApi.Models;
/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945)
/// </summary>
internal class t9945 : LsResponseCore
{
	public t9945InBlock t9945InBlock { get; set; } = new();
	public List<t9945OutBlock> t9945OutBlock { get; set; } = new();
}

/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945) - InBlock
/// </summary>
internal class t9945InBlock
{
	/// <summary>구분(KSP:1KSD:2)</summary>
	public string gubun { get; set; } = "1";
}

/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945) - OutBlock
/// </summary>
internal class t9945OutBlock
{
	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>확장코드</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>ETF구분</summary>
	public string etfchk { get; set; } = string.Empty;

	/// <summary>NXT상장구분</summary>
	public string nxt_chk { get; set; } = string.Empty;

	/// <summary>filler</summary>
	public string filler { get; set; } = string.Empty;
}