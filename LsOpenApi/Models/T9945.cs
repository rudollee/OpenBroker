using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945)
/// </summary>
internal class T9945 : LsResponseCore
{
	[JsonPropertyName("t9945InBlock")]
	public T9945InBlock T9945InBlock { get; set; } = new();
	[JsonPropertyName("t9945OutBlock")]
	public List<T9945OutBlock> T9945OutBlock { get; set; } = [];
}

/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945) - InBlock
/// </summary>
internal class T9945InBlock
{
	/// <summary>구분(KSP:1KSD:2)</summary>
	[JsonPropertyName("gubun")]
	public string Gubun { get; set; } = "1";
}

/// <summary>
/// 주식마스터조회API용-종목명40bytes(t9945) - OutBlock
/// </summary>
internal class T9945OutBlock
{
	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>확장코드</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>ETF구분</summary>
	[JsonPropertyName("etfchk")]
	public string Etfchk { get; set; } = string.Empty;

	/// <summary>NXT상장구분</summary>
	[JsonPropertyName("nxt_chk")]
	public string NxtChk { get; set; } = string.Empty;

	/// <summary>filler</summary>
	[JsonPropertyName("filler")]
	public string Filler { get; set; } = string.Empty;
}