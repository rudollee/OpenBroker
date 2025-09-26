using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 테마별종목(t1531)
/// </summary>
internal class T1531 : LsResponseCore
{
	[JsonPropertyName("t1531InBlock")]
	public T1531InBlock T1531InBlock { get; set; } = new();
	[JsonPropertyName("t1531OutBlock")]
	public List<T1531OutBlock> T1531OutBlock { get; set; } = [];
}

/// <summary>
/// 테마별종목(t1531) - InBlock
/// </summary>
internal class T1531InBlock
{
	/// <summary>테마명</summary>
	[JsonPropertyName("tmname")]
	public string TmName { get; set; } = string.Empty;

	/// <summary>테마코드</summary>
	[JsonPropertyName("tmcode")]
	public string TmCode { get; set; } = string.Empty;
}

/// <summary>
/// 테마별종목(t1531) - OutBlock
/// </summary>
internal class T1531OutBlock
{
	/// <summary>테마명</summary>
	[JsonPropertyName("tmname")]
	public string TmName { get; set; } = string.Empty;

	/// <summary>평균등락율</summary>
	[JsonPropertyName("avgdiff")]
	public decimal AvgDiff { get; set; }

	/// <summary>테마코드</summary>
	[JsonPropertyName("tmcode")]
	public string TmCode { get; set; } = string.Empty;
}