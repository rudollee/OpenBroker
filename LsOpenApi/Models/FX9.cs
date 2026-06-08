using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// KOSPI200선물가격제한폭확대(X0)
/// </summary>
internal class FX9
{
	public FX9InBlock FX9InBlock { get; set; } = new();
	public FX9OutBlock FX9OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI200선물가격제한폭확대(X0) - InBlock
/// </summary>
internal class FX9InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물가격제한폭확대(X0) - OutBlock
/// </summary>
internal class FX9OutBlock
{
	/// <summary>적용 상한단계</summary>
	[JsonPropertyName("upstep")]
	public string Upstep { get; set; } = string.Empty;

	/// <summary>적용 하한단계</summary>
	[JsonPropertyName("dnstep")]
	public string Dnstep { get; set; } = string.Empty;

	/// <summary>적용 상한가</summary>
	[JsonPropertyName("uplmtprice")]
	public string Uplmtprice { get; set; } = string.Empty;

	/// <summary>적용 하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public string Dnlmtprice { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물가격제한폭확대(JX0)
/// </summary>
internal class JX0
{
	public FX9InBlock JX0InBlock { get; set; } = new();
	public FX9OutBlock JX0OutBlock { get; set; } = new();
}