using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// KOSPI200선물호가(H0)
/// </summary>
internal class FH0
{
	public FH0InBlock FH0InBlock { get; set; } = new();
	public FH0OutBlock FH0OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI200선물호가(H0) - InBlock
/// </summary>
internal class FH0InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물호가(H0) - OutBlock
/// </summary>
internal class FH0OutBlock
{
	/// <summary>호가시간</summary>
	[JsonPropertyName("hotime")]
	public string Hotime { get; set; } = string.Empty;

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public string Offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public string Bidho1 { get; set; } = string.Empty;

	/// <summary>매도호가수량1</summary>
	[JsonPropertyName("offerrem1")]
	public string Offerrem1 { get; set; } = string.Empty;

	/// <summary>매수호가수량1</summary>
	[JsonPropertyName("bidrem1")]
	public string Bidrem1 { get; set; } = string.Empty;

	/// <summary>매도호가건수1</summary>
	[JsonPropertyName("offercnt1")]
	public string Offercnt1 { get; set; } = string.Empty;

	/// <summary>매수호가건수1</summary>
	[JsonPropertyName("bidcnt1")]
	public string Bidcnt1 { get; set; } = string.Empty;

	/// <summary>매도호가2</summary>
	[JsonPropertyName("offerho2")]
	public string Offerho2 { get; set; } = string.Empty;

	/// <summary>매수호가2</summary>
	[JsonPropertyName("bidho2")]
	public string Bidho2 { get; set; } = string.Empty;

	/// <summary>매도호가수량2</summary>
	[JsonPropertyName("offerrem2")]
	public string Offerrem2 { get; set; } = string.Empty;

	/// <summary>매수호가수량2</summary>
	[JsonPropertyName("bidrem2")]
	public string Bidrem2 { get; set; } = string.Empty;

	/// <summary>매도호가건수2</summary>
	[JsonPropertyName("offercnt2")]
	public string Offercnt2 { get; set; } = string.Empty;

	/// <summary>매수호가건수2</summary>
	[JsonPropertyName("bidcnt2")]
	public string Bidcnt2 { get; set; } = string.Empty;

	/// <summary>매도호가3</summary>
	[JsonPropertyName("offerho3")]
	public string Offerho3 { get; set; } = string.Empty;

	/// <summary>매수호가3</summary>
	[JsonPropertyName("bidho3")]
	public string Bidho3 { get; set; } = string.Empty;

	/// <summary>매도호가수량3</summary>
	[JsonPropertyName("offerrem3")]
	public string Offerrem3 { get; set; } = string.Empty;

	/// <summary>매수호가수량3</summary>
	[JsonPropertyName("bidrem3")]
	public string Bidrem3 { get; set; } = string.Empty;

	/// <summary>매도호가건수3</summary>
	[JsonPropertyName("offercnt3")]
	public string Offercnt3 { get; set; } = string.Empty;

	/// <summary>매수호가건수3</summary>
	[JsonPropertyName("bidcnt3")]
	public string Bidcnt3 { get; set; } = string.Empty;

	/// <summary>매도호가4</summary>
	[JsonPropertyName("offerho4")]
	public string Offerho4 { get; set; } = string.Empty;

	/// <summary>매수호가4</summary>
	[JsonPropertyName("bidho4")]
	public string Bidho4 { get; set; } = string.Empty;

	/// <summary>매도호가수량4</summary>
	[JsonPropertyName("offerrem4")]
	public string Offerrem4 { get; set; } = string.Empty;

	/// <summary>매수호가수량4</summary>
	[JsonPropertyName("bidrem4")]
	public string Bidrem4 { get; set; } = string.Empty;

	/// <summary>매도호가건수4</summary>
	[JsonPropertyName("offercnt4")]
	public string Offercnt4 { get; set; } = string.Empty;

	/// <summary>매수호가건수4</summary>
	[JsonPropertyName("bidcnt4")]
	public string Bidcnt4 { get; set; } = string.Empty;

	/// <summary>매도호가5</summary>
	[JsonPropertyName("offerho5")]
	public string Offerho5 { get; set; } = string.Empty;

	/// <summary>매수호가5</summary>
	[JsonPropertyName("bidho5")]
	public string Bidho5 { get; set; } = string.Empty;

	/// <summary>매도호가수량5</summary>
	[JsonPropertyName("offerrem5")]
	public string Offerrem5 { get; set; } = string.Empty;

	/// <summary>매수호가수량5</summary>
	[JsonPropertyName("bidrem5")]
	public string Bidrem5 { get; set; } = string.Empty;

	/// <summary>매도호가건수5</summary>
	[JsonPropertyName("offercnt5")]
	public string Offercnt5 { get; set; } = string.Empty;

	/// <summary>매수호가건수5</summary>
	[JsonPropertyName("bidcnt5")]
	public string Bidcnt5 { get; set; } = string.Empty;

	/// <summary>매도호가총수량</summary>
	[JsonPropertyName("totofferrem")]
	public string Totofferrem { get; set; } = string.Empty;

	/// <summary>매수호가총수량</summary>
	[JsonPropertyName("totbidrem")]
	public string Totbidrem { get; set; } = string.Empty;

	/// <summary>매도호가총건수</summary>
	[JsonPropertyName("totoffercnt")]
	public string Totoffercnt { get; set; } = string.Empty;

	/// <summary>매수호가총건수</summary>
	[JsonPropertyName("totbidcnt")]
	public string Totbidcnt { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;

	/// <summary>단일가호가여부</summary>
	[JsonPropertyName("danhochk")]
	public string Danhochk { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	[JsonPropertyName("alloc_gubun")]
	public string AllocGubun { get; set; } = string.Empty;
}

/// <summary>
/// KRX야간파생 호가(H0)
/// </summary>
internal class DH0
{
	public FH0InBlock DH0InBlock { get; set; } = new();
	public FH0OutBlock DH0OutBlock { get; set; } = new();
}