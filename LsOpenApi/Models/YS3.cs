namespace LsOpenApi.Models;
/// <summary>
/// KOSPI예상체결(YS3)
/// </summary>
internal class YS3
{
	public YS3OutBlock YS3OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI예상체결(YS3) - InBlock
/// </summary>
internal class YS3InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI예상체결(YS3) - OutBlock
/// </summary>
internal class YS3OutBlock
{
	/// <summary>호가시간</summary>
	public string hotime { get; set; } = string.Empty;

	/// <summary>예상체결가격</summary>
	public string yeprice { get; set; } = string.Empty;

	/// <summary>예상체결수량</summary>
	public string yevolume { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비구분</summary>
	public string jnilysign { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비</summary>
	public string jnilchange { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가등락율</summary>
	public string jnilydrate { get; set; } = string.Empty;

	/// <summary>예상매도호가</summary>
	public string yofferho0 { get; set; } = string.Empty;

	/// <summary>예상매수호가</summary>
	public string ybidho0 { get; set; } = string.Empty;

	/// <summary>예상매도호가수량</summary>
	public string yofferrem0 { get; set; } = string.Empty;

	/// <summary>예상매수호가수량</summary>
	public string ybidrem0 { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI예상체결(YS3)
/// </summary>
internal class YK3
{
	public YK3OutBlock YK3OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI예상체결(YS3) - InBlock
/// </summary>
internal class YK3InBlock : YS3InBlock { }

/// <summary>
/// KOSPI예상체결(YS3) - OutBlock
/// </summary>
internal class YK3OutBlock : YS3OutBlock { }