using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 서버저장조건 조건검색
/// </summary>
internal class T1859 : LsResponseCore
{
	[JsonPropertyName("t1859InBlock")]
	public T1859InBlock T1859InBlock { get; set; } = new();
	[JsonPropertyName("t1859OutBlock")]
	public T1859OutBlock T1859OutBlock { get; set; } = new();
	[JsonPropertyName("t1859OutBlock1")]
	public List<T1859OutBlock1> T1859OutBlock1 { get; set; } = [];
}

/// <summary>
/// 서버저장조건 조건검색 - InBlock
/// </summary>
internal class T1859InBlock
{
	/// <summary>종목검색입력값</summary>
	[JsonPropertyName("query_index")]
	public string QueryIndex { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건 조건검색 - OutBlock
/// </summary>
internal class T1859OutBlock
{
	/// <summary>검색종목수</summary>
	[JsonPropertyName("result_count")]
	public long ResultCount { get; set; }

	/// <summary>포착시간</summary>
	[JsonPropertyName("result_time")]
	public string ResultTime { get; set; } = string.Empty;

	/// <summary>전략설명</summary>
	[JsonPropertyName("text")]
	public string Text { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건 조건검색 - OutBlock1
/// </summary>
internal class T1859OutBlock1
{
	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public long Change { get; set; }

	/// <summary>등락율</summary>
	[JsonPropertyName("diff")]
	public decimal Diff { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }
}