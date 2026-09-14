using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// VI발동해제(VI_)
/// </summary>
internal class VI_
{
	public VI_InBlock VIInBlock { get; set; } = new();
	public VI_OutBlock VI_OutBlock { get; set; } = new();
}

/// <summary>
/// VI발동해제(VI_) - InBlock
/// </summary>
internal class VI_InBlock
{
	/// <summary>단축코드(KEY)</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// VI발동해제(VI_) - OutBlock
/// </summary>
internal class VI_OutBlock
{
	/// <summary>구분(0:해제 1:정적발동 2:동적발동 3:정적&동적)</summary>
	[JsonPropertyName("vi_gubun")]
	public string ViGubun { get; set; } = string.Empty;

	/// <summary>정적VI발동기준가격</summary>
	[JsonPropertyName("svi_recprice")]
	public string SviRecprice { get; set; } = string.Empty;

	/// <summary>동적VI발동기준가격</summary>
	[JsonPropertyName("dvi_recprice")]
	public string DviRecprice { get; set; } = string.Empty;

	/// <summary>VI발동가격</summary>
	[JsonPropertyName("vi_trgprice")]
	public string ViTrgprice { get; set; } = string.Empty;

	/// <summary>단축코드(KEY)</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>참조코드(미사용)</summary>
	[JsonPropertyName("ref_shcode")]
	public string RefShcode { get; set; } = string.Empty;

	/// <summary>시간</summary>
	[JsonPropertyName("time")]
	public string Time { get; set; } = string.Empty;

	/// <summary>거래소명</summary>
	[JsonPropertyName("exchname")]
	public string Exchname { get; set; } = string.Empty;
}

/// <summary>
/// 시간외단일가 VI발동해제(DVI)
/// </summary>
internal class DVI
{
	public DVIInBlock DVI_InBlock { get; set; } = new();
	public DVIOutBlock DVI_OutBlock { get; set; } = new();
}

/// <summary>
/// 시간외단일가 VI발동해제(DVI) - InBlock
/// </summary>
internal class DVIInBlock : VI_InBlock { }

/// <summary>
/// 시간외단일가 VI발동해제(DVI) - OutBlock
/// </summary>
internal class DVIOutBlock : VI_OutBlock { }
