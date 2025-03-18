namespace LsOpenApi.Models;
/// <summary>
/// 서버저장조건리스트조회(API)(t1866)
/// </summary>
internal class t1866 : LsResponseCore
{
	public t1866InBlock t1866InBlock { get; set; } = new();
	public t1866OutBlock t1866OutBlock { get; set; } = new();
	public List<t1866OutBlock1> t1866OutBlock1 { get; set; } = new();
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - InBlock
/// </summary>
internal class t1866InBlock
{
	/// <summary>로그인ID</summary>
	public string user_id { get; set; } = string.Empty;

	/// <summary>조회구분</summary>
	public string gb { get; set; } = "0";

	/// <summary>        그룹명</summary>
	public string group_name { get; set; } = string.Empty;

	/// <summary>연속여부</summary>
	public string cont { get; set; } = "0";

	/// <summary>        연속키</summary>
	public string contkey { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - OutBlock
/// </summary>
internal class t1866OutBlock
{
	/// <summary>        저장조건수</summary>
	public long result_count { get; set; }

	/// <summary>연속여부</summary>
	public string cont { get; set; } = string.Empty;

	/// <summary>        연속키</summary>
	public string contkey { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건리스트조회(API)(t1866) - OutBlock1
/// </summary>
internal class t1866OutBlock1
{
	/// <summary>        서버저장인덱스</summary>
	public string query_index { get; set; } = string.Empty;

	/// <summary>        그룹명</summary>
	public string group_name { get; set; } = string.Empty;

	/// <summary>        조건저장명</summary>
	public string query_name { get; set; } = string.Empty;
}