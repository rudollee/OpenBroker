using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 뉴스본문(t3102)
/// </summary>
internal class T3102 : LsResponseCore
{
	[JsonPropertyName("t3102InBlock")]
	public T3102InBlock T3102InBlock { get; set; } = new();
	[JsonPropertyName("t3102OutBlock")]
	public List<T3102OutBlock> T3102OutBlock { get; set; } = [];
	[JsonPropertyName("t3102OutBlock1")]
	public List<T3102OutBlock1> T3102OutBlock1 { get; set; } = [];
	[JsonPropertyName("t3102OutBlock2")]
	public T3102OutBlock2 T3102OutBlock2 { get; set; } = new();
}

/// <summary>
/// 뉴스본문(t3102) - InBlock
/// </summary>
internal class T3102InBlock
{
	/// <summary>뉴스번호</summary>
	[JsonPropertyName("sNewsno")]
	public string SNewsno { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock
/// </summary>
internal class T3102OutBlock
{
	/// <summary>뉴스종목</summary>
	[JsonPropertyName("sJongcode")]
	public string SJongcode { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock1
/// </summary>
internal class T3102OutBlock1
{
	/// <summary>뉴스본문</summary>
	[JsonPropertyName("sBody")]
	public string SBody { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock2
/// </summary>
internal class T3102OutBlock2
{
	/// <summary>뉴스타이틀</summary>
	[JsonPropertyName("sTitle")]
	public string STitle { get; set; } = string.Empty;
}