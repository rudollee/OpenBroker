using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식선물마스터조회(API용)(t8401)
/// </summary>
internal class T8401 : LsResponseCore
{
	[JsonPropertyName("t8401InBlock")]
	public T8401InBlock T8401InBlock { get; set; } = new();
	[JsonPropertyName("t8401OutBlock")]
	public List<T8401OutBlock> T8401OutBlock { get; set; } = [];
}

/// <summary>
/// 주식선물마스터조회(API용)(t8401) - InBlock
/// </summary>
internal class T8401InBlock
{
	/// <summary>Dummy</summary>
	[JsonPropertyName("dummy")]
	public string Dummy { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물마스터조회(API용)(t8401) - OutBlock
/// </summary>
internal class T8401OutBlock
{
	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string HName { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string ShCode { get; set; } = string.Empty;

	/// <summary>확장코드</summary>
	[JsonPropertyName("expcode")]
	public string ExpCode { get; set; } = string.Empty;

	/// <summary>기초자산코드</summary>
	[JsonPropertyName("basecode")]
	public string BaseCode { get; set; } = string.Empty;
}