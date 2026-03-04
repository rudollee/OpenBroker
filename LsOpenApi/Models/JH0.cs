using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식선물호가(JH0)
/// </summary>
internal class JH0
{
	public JH0InBlock JH0InBlock { get; set; } = new();
	public JH0OutBlock JH0OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물호가(JH0) - InBlock
/// </summary>
internal class JH0InBlock : FH0InBlock { }

/// <summary>
/// 주식선물호가(JH0) - OutBlock
/// </summary>
internal class JH0OutBlock : FH0OutBlock
{
	/// <summary>매도호가6</summary>
	[JsonPropertyName("offerho6")]
	public string OfferHo6 { get; set; } = string.Empty;

	/// <summary>매수호가6</summary>
	[JsonPropertyName("bidho6")]
	public string BidHo6 { get; set; } = string.Empty;

	/// <summary>매도호가수량6</summary>
	[JsonPropertyName("offerrem6")]
	public string OfferRem6 { get; set; } = string.Empty;

	/// <summary>매수호가수량6</summary>
	[JsonPropertyName("bidrem6")]
	public string BidRem6 { get; set; } = string.Empty;

	/// <summary>매도호가건수6</summary>
	[JsonPropertyName("offercnt6")]
	public string OfferCnt6 { get; set; } = string.Empty;

	/// <summary>매수호가건수6</summary>
	[JsonPropertyName("bidcnt6")]
	public string BidCnt6 { get; set; } = string.Empty;

	/// <summary>매도호가7</summary>
	[JsonPropertyName("offerho7")]
	public string OfferHo7 { get; set; } = string.Empty;

	/// <summary>매수호가7</summary>
	[JsonPropertyName("bidho7")]
	public string BidHo7 { get; set; } = string.Empty;

	/// <summary>매도호가수량7</summary>
	[JsonPropertyName("offerrem7")]
	public string OfferRem7 { get; set; } = string.Empty;

	/// <summary>매수호가수량7</summary>
	[JsonPropertyName("bidrem7")]
	public string BidRem7 { get; set; } = string.Empty;

	/// <summary>매도호가건수7</summary>
	[JsonPropertyName("offercnt7")]
	public string OfferCnt7 { get; set; } = string.Empty;

	/// <summary>매수호가건수7</summary>
	[JsonPropertyName("bidcnt7")]
	public string BidCnt7 { get; set; } = string.Empty;

	/// <summary>매도호가8</summary>
	[JsonPropertyName("offerho8")]
	public string OfferHo8 { get; set; } = string.Empty;

	/// <summary>매수호가8</summary>
	[JsonPropertyName("bidho8")]
	public string BidHo8 { get; set; } = string.Empty;

	/// <summary>매도호가수량8</summary>
	[JsonPropertyName("offerrem8")]
	public string OfferRem8 { get; set; } = string.Empty;

	/// <summary>매수호가수량8</summary>
	[JsonPropertyName("bidrem8")]
	public string BidRem8 { get; set; } = string.Empty;

	/// <summary>매도호가건수8</summary>
	[JsonPropertyName("offercnt8")]
	public string OfferCnt8 { get; set; } = string.Empty;

	/// <summary>매수호가건수8</summary>
	[JsonPropertyName("bidcnt8")]
	public string BidCnt8 { get; set; } = string.Empty;

	/// <summary>매도호가9</summary>
	[JsonPropertyName("offerho9")]
	public string OfferHo9 { get; set; } = string.Empty;

	/// <summary>매수호가9</summary>
	[JsonPropertyName("bidho9")]
	public string BidHo9 { get; set; } = string.Empty;

	/// <summary>매도호가수량9</summary>
	[JsonPropertyName("offerrem9")]
	public string OfferRem9 { get; set; } = string.Empty;

	/// <summary>매수호가수량9</summary>
	[JsonPropertyName("bidrem9")]
	public string BidRem9 { get; set; } = string.Empty;

	/// <summary>매도호가건수9</summary>
	[JsonPropertyName("offercnt9")]
	public string OfferCnt9 { get; set; } = string.Empty;

	/// <summary>매수호가건수9</summary>
	[JsonPropertyName("bidcnt9")]
	public string BidCnt9 { get; set; } = string.Empty;

	/// <summary>매도호가10</summary>
	[JsonPropertyName("offerho10")]
	public string OfferHo10 { get; set; } = string.Empty;

	/// <summary>매수호가10</summary>
	[JsonPropertyName("bidho10")]
	public string BidHo10 { get; set; } = string.Empty;

	/// <summary>매도호가수량10</summary>
	[JsonPropertyName("offerrem10")]
	public string OfferRem10 { get; set; } = string.Empty;

	/// <summary>매수호가수량10</summary>
	[JsonPropertyName("bidrem10")]
	public string BidRem10 { get; set; } = string.Empty;

	/// <summary>매도호가건수10</summary>
	[JsonPropertyName("offercnt10")]
	public string OfferCnt10 { get; set; } = string.Empty;

	/// <summary>매수호가건수10</summary>
	[JsonPropertyName("bidcnt10")]
	public string BidCnt10 { get; set; } = string.Empty;
}