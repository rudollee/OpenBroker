namespace LsOpenApi.Models;
/// <summary>
/// 종목별테마(t1532)
/// </summary>
internal class t1532 : LsResponseCore
{
	public t1532InBlock t1532InBlock { get; set; } = new();
	public List<t1532OutBlock> t1532OutBlock { get; set; } = new();
}

/// <summary>
/// 종목별테마(t1532) - InBlock
/// </summary>
internal class t1532InBlock
{
	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// 종목별테마(t1532) - OutBlock
/// </summary>
internal class t1532OutBlock
{
	/// <summary>테마명</summary>
	public string tmname { get; set; } = string.Empty;

	/// <summary>평균등락율</summary>
	public decimal avgdiff { get; set; }

	/// <summary>테마코드</summary>
	public string tmcode { get; set; } = string.Empty;
}