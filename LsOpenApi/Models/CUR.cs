namespace LsOpenApi.Models;
/// <summary>
/// 현물정보 USD 실시간(CUR)
/// </summary>
internal class CUR
{
	public CURInBlock CURInBlock { get; set; } = new();
	public CUROutBlock CUROutBlock { get; set; } = new();
}

/// <summary>
/// 현물정보 USD 실시간(CUR) - InBlock
/// </summary>
internal class CURInBlock
{
	/// <summary>기초자산ID</summary>
	public string base_id { get; set; } = string.Empty;
}

/// <summary>
/// 현물정보 USD 실시간(CUR) - OutBlock
/// </summary>
internal class CUROutBlock
{
	/// <summary>전송시간</summary>
	public string time { get; set; } = string.Empty;

	/// <summary>매도호가</summary>
	public string offer { get; set; } = string.Empty;

	/// <summary>매수호가</summary>
	public string bid { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public string open { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public string high { get; set; } = string.Empty;

	/// <summary>저가</summary>
	public string low { get; set; } = string.Empty;

	/// <summary>체결가</summary>
	public string price { get; set; } = string.Empty;

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public string change { get; set; } = string.Empty;

	/// <summary>등락율</summary>
	public string drate { get; set; } = string.Empty;

	/// <summary>데이타 발생시간</summary>
	public string ctime { get; set; } = string.Empty;

	/// <summary>기초자산ID</summary>
	public string base_id { get; set; } = string.Empty;
}