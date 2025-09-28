using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 종목별테마(t1532)
/// </summary>
internal class T1532 : LsResponseCore
{
	[JsonPropertyName("t1532InBlock")]
	public T1532InBlock T1532InBlock { get; set; } = new();
	[JsonPropertyName("t1532OutBlock")]
	public List<T1532OutBlock> T1532OutBlock { get; set; } = [];
}

/// <summary>
/// 종목별테마(t1532) - InBlock
/// </summary>
internal class T1532InBlock
{
	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// 종목별테마(t1532) - OutBlock
/// </summary>
internal class T1532OutBlock
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