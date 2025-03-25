namespace LsOpenApi.Models;
/// <summary>
/// 주식선물마스터조회(API용)(t8401)
/// </summary>
internal class t8401 : LsResponseCore
{
	public t8401InBlock t8401InBlock { get; set; } = new();
	public List<t8401OutBlock> t8401OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물마스터조회(API용)(t8401) - InBlock
/// </summary>
internal class t8401InBlock
{
	/// <summary>Dummy</summary>
	public string dummy { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물마스터조회(API용)(t8401) - OutBlock
/// </summary>
internal class t8401OutBlock
{
	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>확장코드</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>기초자산코드</summary>
	public string basecode { get; set; } = string.Empty;
}