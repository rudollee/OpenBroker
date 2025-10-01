using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 서버저장조건리스트조회(API)(t1866)
/// </summary>
internal class T1866 : LsResponseCore
{
	[JsonPropertyName("t1866InBlock")]
	public T1866InBlock T1866InBlock { get; set; } = new();
	[JsonPropertyName("t1866OutBlock")]
	public T1866OutBlock T1866OutBlock { get; set; } = new();
	[JsonPropertyName("t1866OutBlock1")]
	public List<T1866OutBlock1> T1866OutBlock1 { get; set; } = [];
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - InBlock
/// </summary>
internal class T1866InBlock
{
	/// <summary>로그인ID</summary>
	[JsonPropertyName("user_id")]
	public string UserId { get; set; } = string.Empty;

	/// <summary>조회구분</summary>
	[JsonPropertyName("gb")]
	public string Gb { get; set; } = "0";

	/// <summary>그룹명</summary>
	[JsonPropertyName("group_name")]
	public string GroupName { get; set; } = string.Empty;

	/// <summary>연속여부</summary>
	[JsonPropertyName("cont")]
	public string Cont { get; set; } = "0";

	/// <summary>연속키</summary>
	[JsonPropertyName("contkey")]
	public string Contkey { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - OutBlock
/// </summary>
internal class T1866OutBlock
{
	/// <summary>저장조건수</summary>
	[JsonPropertyName("result_count")]
	public long ResultCount { get; set; }

	/// <summary>연속여부</summary>
	[JsonPropertyName("cont")]
	public string Cont { get; set; } = string.Empty;

	/// <summary>연속키</summary>
	[JsonPropertyName("contkey")]
	public string Contkey { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - OutBlock1
/// </summary>
internal class T1866OutBlock1
{
	/// <summary>서버저장인덱스</summary>
	[JsonPropertyName("query_index")]
	public string QueryIndex { get; set; } = string.Empty;

	/// <summary>그룹명</summary>
	[JsonPropertyName("group_name")]
	public string GroupName { get; set; } = string.Empty;

	/// <summary>조건저장명</summary>
	[JsonPropertyName("query_name")]
	public string QueryName { get; set; } = string.Empty;
}
