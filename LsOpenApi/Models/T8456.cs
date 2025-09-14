using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// KRX야간파생 시세조회(API용)(t8456)
/// </summary>
internal class t8456 : LsResponseCore
{
	[JsonPropertyName("t8456InBlock")]
	public T8456InBlock T8456InBlock { get; set; } = new();
	[JsonPropertyName("t8456OutBlock")]
	public T8456OutBlock T8456OutBlock { get; set; } = new();
}

/// <summary>
/// KRX야간파생 시세조회(API용)(t8456) - InBlock
/// </summary>
internal class T8456InBlock : T2101InBlock { }

/// <summary>
/// KRX야간파생 시세조회(API용)(t8456) - OutBlock
/// </summary>
internal class T8456OutBlock : T2101OutBlock
{
	/// <summary>시간가치</summary>
	[JsonPropertyName("timevl")]
	public decimal Timevl { get; set; }

	/// <summary>야간선물최근월현재가</summary>
	[JsonPropertyName("cmeprice")]
	public decimal Cmeprice { get; set; }

	/// <summary>야간선물최근월전일대비구분</summary>
	[JsonPropertyName("cmesign")]
	public string Cmesign { get; set; } = string.Empty;

	/// <summary>야간선물최근월전일대비</summary>
	[JsonPropertyName("cmechange")]
	public decimal Cmechange { get; set; }

	/// <summary>야간선물최근월등락율</summary>
	[JsonPropertyName("cmediff")]
	public decimal Cmediff { get; set; }

	/// <summary>야간선물최근월종목코드</summary>
	[JsonPropertyName("cmefocode")]
	public string Cmefocode { get; set; } = string.Empty;

	/// <summary>전일대비구분(옵션만제공)</summary>
	[JsonPropertyName("ysign")]
	public string Ysign { get; set; } = string.Empty;

	/// <summary>전일대비(옵션만제공)</summary>
	[JsonPropertyName("ychange")]
	public decimal Ychange { get; set; }

	/// <summary>등락율(옵션만제공)</summary>
	[JsonPropertyName("ydiff")]
	public decimal Ydiff { get; set; }

	/// <summary>전일거래량</summary>
	[JsonPropertyName("jnilvolume")]
	public long Jnilvolume { get; set; }

	/// <summary>전일거래대금</summary>
	[JsonPropertyName("jnilvalue")]
	public long Jnilvalue { get; set; }
}