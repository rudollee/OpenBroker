using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식선물호가조회(API용)(t8403)
/// </summary>
internal class T8403 : LsResponseCore
{
	[JsonPropertyName("t8403InBlock")]
	public T2105InBlock T8403InBlock { get; set; } = new();
	[JsonPropertyName("t8403OutBlock")]
	public T8403OutBlock T8403OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물호가조회(API용)(t8403) - OutBlock
/// </summary>
internal class T8403OutBlock : T2105OutBlock
{
	/// <summary>매도호가6</summary>
	[JsonPropertyName("offerho6")]
	public long Offerho6 { get; set; }

	/// <summary>매수호가6</summary>
	[JsonPropertyName("bidho6")]
	public long Bidho6 { get; set; }

	/// <summary>매도호가수량6</summary>
	[JsonPropertyName("offerrem6")]
	public long Offerrem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	[JsonPropertyName("bidrem6")]
	public long Bidrem6 { get; set; }

	/// <summary>매도호가건수6</summary>
	[JsonPropertyName("dcnt6")]
	public long Dcnt6 { get; set; }

	/// <summary>매수호가건수6</summary>
	[JsonPropertyName("scnt6")]
	public long Scnt6 { get; set; }

	/// <summary>매도호가7</summary>
	[JsonPropertyName("offerho7")]
	public long Offerho7 { get; set; }

	/// <summary>매수호가7</summary>
	[JsonPropertyName("bidho7")]
	public long Bidho7 { get; set; }

	/// <summary>매도호가수량7</summary>
	[JsonPropertyName("offerrem7")]
	public long Offerrem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	[JsonPropertyName("bidrem7")]
	public long Bidrem7 { get; set; }

	/// <summary>매도호가건수7</summary>
	[JsonPropertyName("dcnt7")]
	public long Dcnt7 { get; set; }

	/// <summary>매수호가건수7</summary>
	[JsonPropertyName("scnt7")]
	public long Scnt7 { get; set; }

	/// <summary>매도호가8</summary>
	[JsonPropertyName("offerho8")]
	public long Offerho8 { get; set; }

	/// <summary>매수호가8</summary>
	[JsonPropertyName("bidho8")]
	public long Bidho8 { get; set; }

	/// <summary>매도호가수량8</summary>
	[JsonPropertyName("offerrem8")]
	public long Offerrem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	[JsonPropertyName("bidrem8")]
	public long Bidrem8 { get; set; }

	/// <summary>매도호가건수8</summary>
	[JsonPropertyName("dcnt8")]
	public long Dcnt8 { get; set; }

	/// <summary>매수호가건수8</summary>
	[JsonPropertyName("scnt8")]
	public long Scnt8 { get; set; }

	/// <summary>매도호가9</summary>
	[JsonPropertyName("offerho9")]
	public long Offerho9 { get; set; }

	/// <summary>매수호가9</summary>
	[JsonPropertyName("bidho9")]
	public long Bidho9 { get; set; }

	/// <summary>매도호가수량9</summary>
	[JsonPropertyName("offerrem9")]
	public long Offerrem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	[JsonPropertyName("bidrem9")]
	public long Bidrem9 { get; set; }

	/// <summary>매도호가건수9</summary>
	[JsonPropertyName("dcnt9")]
	public long Dcnt9 { get; set; }

	/// <summary>매수호가건수9</summary>
	[JsonPropertyName("scnt9")]
	public long Scnt9 { get; set; }

	/// <summary>매도호가10</summary>
	[JsonPropertyName("offerho10")]
	public long Offerho10 { get; set; }

	/// <summary>매수호가10</summary>
	[JsonPropertyName("bidho10")]
	public long Bidho10 { get; set; }

	/// <summary>매도호가수량10</summary>
	[JsonPropertyName("offerrem10")]
	public long Offerrem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	[JsonPropertyName("bidrem10")]
	public long Bidrem10 { get; set; }

	/// <summary>매도호가건수10</summary>
	[JsonPropertyName("dcnt10")]
	public long Dcnt10 { get; set; }

	/// <summary>매수호가건수10</summary>
	[JsonPropertyName("scnt10")]
	public long Scnt10 { get; set; }
}
