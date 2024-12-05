namespace LsOpenApi.Models;
/// <summary>
/// 테마별종목(t1531)
/// </summary>
internal class t1531 : LsResponseCore
{
	public t1531InBlock t1531InBlock { get; set; } = new();
	public List<t1531OutBlock> t1531OutBlock { get; set; } = new();
}

/// <summary>
/// 테마별종목(t1531) - InBlock
/// </summary>
internal class t1531InBlock
{
	/// <summary>테마명</summary>
	public string tmname { get; set; } = string.Empty;

	/// <summary>테마코드</summary>
	public string tmcode { get; set; } = string.Empty;
}

/// <summary>
/// 테마별종목(t1531) - OutBlock
/// </summary>
internal class t1531OutBlock
{
	/// <summary>테마명</summary>
	public string tmname { get; set; } = string.Empty;

	/// <summary>평균등락율</summary>
	public decimal avgdiff { get; set; }

	/// <summary>테마코드</summary>
	public string tmcode { get; set; } = string.Empty;
}