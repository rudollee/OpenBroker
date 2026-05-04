using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식선물기초자산조회(t2522)
/// </summary>
internal class T2522 : LsResponseCore
{
	[JsonPropertyName("t2522InBlock")]
	public T2522InBlock T2522InBlock { get; set; } = new();
	[JsonPropertyName("t2522OutBlock")]
	public T2522OutBlock T2522OutBlock { get; set; } = new();
	[JsonPropertyName("t2522OutBlock1")]
	public List<T2522OutBlock1> T2522OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식선물기초자산조회(t2522) - InBlock
/// </summary>
internal class T2522InBlock
{
	/// <summary>Dummy</summary>
	[JsonPropertyName("dummy")]
	public string Dummy { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물기초자산조회(t2522) - OutBlock
/// </summary>
internal class T2522OutBlock
{
	/// <summary>건수</summary>
	[JsonPropertyName("cnt")]
	public long Cnt { get; set; }
}

/// <summary>
/// 주식선물기초자산조회(t2522) - OutBlock1
/// </summary>
internal class T2522OutBlock1
{
	/// <summary>기초자산명</summary>
	[JsonPropertyName("bsc_asts_nm")]
	public string BscAstsNm { get; set; } = string.Empty;

	/// <summary>기초자산종목코드</summary>
	[JsonPropertyName("bsc_asts_is_cd")]
	public string BscAstsIsCd { get; set; } = string.Empty;

	/// <summary>기초자산ID</summary>
	[JsonPropertyName("bsc_asts_id")]
	public string BscAstsId { get; set; } = string.Empty;

	/// <summary>최근월물종목코드</summary>
	[JsonPropertyName("nmc_is_shrt_cd")]
	public string NmcIsShrtCd { get; set; } = string.Empty;
}