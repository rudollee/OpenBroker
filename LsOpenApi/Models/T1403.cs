using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 신규상장종목조회(t1403)
/// </summary>
internal class T1403 : LsResponseCore
{
	[JsonPropertyName("t1403InBlock")]
	public T1403InBlock T1403InBlock { get; set; } = new();
	[JsonPropertyName("t1403OutBlock1")]
	public List<T1403OutBlock1> T1403OutBlock1 { get; set; } = [];
}

/// <summary>
/// 신규상장종목조회(t1403) - InBlock
/// </summary>
internal class T1403InBlock
{
	/// <summary>구분</summary>
	[JsonPropertyName("gubun")]
	public string Gubun { get; set; } = string.Empty;

	/// <summary>시작상장월</summary>
	[JsonPropertyName("styymm")]
	public string Styymm { get; set; } = string.Empty;

	/// <summary>종료상장월</summary>
	[JsonPropertyName("enyymm")]
	public string Enyymm { get; set; } = string.Empty;

	/// <summary>IDX</summary>
	[JsonPropertyName("idx")]
	public long Idx { get; set; }
}

/// <summary>
/// 신규상장종목조회(t1403) - OutBlock
/// </summary>
internal class T1403OutBlock
{
	/// <summary>IDX</summary>
	[JsonPropertyName("idx")]
	public long Idx { get; set; }
}

/// <summary>
/// 신규상장종목조회(t1403) - OutBlock1
/// </summary>
internal class T1403OutBlock1
{
	/// <summary>한글명</summary>
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

	/// <summary>누적거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>공모가</summary>
	[JsonPropertyName("kmprice")]
	public long Kmprice { get; set; }

	/// <summary>등록일</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;

	/// <summary>등록일기준가</summary>
	[JsonPropertyName("recprice")]
	public long Recprice { get; set; }

	/// <summary>기준가등락율</summary>
	[JsonPropertyName("kmdiff")]
	public decimal Kmdiff { get; set; }

	/// <summary>등록일종가</summary>
	[JsonPropertyName("close")]
	public long Close { get; set; }

	/// <summary>등록일등락율</summary>
	[JsonPropertyName("recdiff")]
	public decimal Recdiff { get; set; }

	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}