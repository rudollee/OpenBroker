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
	public string FutCode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물호가(H0) - OutBlock
/// </summary>
internal class FH0OutBlock
{
	/// <summary>호가시간</summary>
	[JsonPropertyName("hotime")]
	public string HoTime { get; set; } = string.Empty;

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public string OfferHo1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public string BidHo1 { get; set; } = string.Empty;

	/// <summary>매도호가수량1</summary>
	[JsonPropertyName("offerrem1")]
	public string OfferRem1 { get; set; } = string.Empty;

	/// <summary>매수호가수량1</summary>
	[JsonPropertyName("bidrem1")]
	public string BidRem1 { get; set; } = string.Empty;

	/// <summary>매도호가건수1</summary>
	[JsonPropertyName("offercnt1")]
	public string OfferCnt1 { get; set; } = string.Empty;

	/// <summary>매수호가건수1</summary>
	[JsonPropertyName("bidcnt1")]
	public string BidCnt1 { get; set; } = string.Empty;

	/// <summary>매도호가2</summary>
	[JsonPropertyName("offerho2")]
	public string OfferHo2 { get; set; } = string.Empty;

	/// <summary>매수호가2</summary>
	[JsonPropertyName("bidho2")]
	public string BidHo2 { get; set; } = string.Empty;

	/// <summary>매도호가수량2</summary>
	[JsonPropertyName("offerrem2")]
	public string OfferRem2 { get; set; } = string.Empty;

	/// <summary>매수호가수량2</summary>
	[JsonPropertyName("bidrem2")]
	public string BidRem2 { get; set; } = string.Empty;

	/// <summary>매도호가건수2</summary>
	[JsonPropertyName("offercnt2")]
	public string OfferCnt2 { get; set; } = string.Empty;

	/// <summary>매수호가건수2</summary>
	[JsonPropertyName("bidcnt2")]
	public string BidCnt2 { get; set; } = string.Empty;

	/// <summary>매도호가3</summary>
	[JsonPropertyName("offerho3")]
	public string OfferHo3 { get; set; } = string.Empty;

	/// <summary>매수호가3</summary>
	[JsonPropertyName("bidho3")]
	public string BidHo3 { get; set; } = string.Empty;

	/// <summary>매도호가수량3</summary>
	[JsonPropertyName("offerrem3")]
	public string OfferRem3 { get; set; } = string.Empty;

	/// <summary>매수호가수량3</summary>
	[JsonPropertyName("bidrem3")]
	public string BidRem3 { get; set; } = string.Empty;

	/// <summary>매도호가건수3</summary>
	[JsonPropertyName("offercnt3")]
	public string OfferCnt3 { get; set; } = string.Empty;

	/// <summary>매수호가건수3</summary>
	[JsonPropertyName("bidcnt3")]
	public string BidCnt3 { get; set; } = string.Empty;

	/// <summary>매도호가4</summary>
	[JsonPropertyName("offerho4")]
	public string OfferHo4 { get; set; } = string.Empty;

	/// <summary>매수호가4</summary>
	[JsonPropertyName("bidho4")]
	public string BidHo4 { get; set; } = string.Empty;

	/// <summary>매도호가수량4</summary>
	[JsonPropertyName("offerrem4")]
	public string OfferRem4 { get; set; } = string.Empty;

	/// <summary>매수호가수량4</summary>
	[JsonPropertyName("bidrem4")]
	public string BidRem4 { get; set; } = string.Empty;

	/// <summary>매도호가건수4</summary>
	[JsonPropertyName("offercnt4")]
	public string OfferCnt4 { get; set; } = string.Empty;

	/// <summary>매수호가건수4</summary>
	[JsonPropertyName("bidcnt4")]
	public string BidCnt4 { get; set; } = string.Empty;

	/// <summary>매도호가5</summary>
	[JsonPropertyName("offerho5")]
	public string OfferHo5 { get; set; } = string.Empty;

	/// <summary>매수호가5</summary>
	[JsonPropertyName("bidho5")]
	public string BidHo5 { get; set; } = string.Empty;

	/// <summary>매도호가수량5</summary>
	[JsonPropertyName("offerrem5")]
	public string OfferRem5 { get; set; } = string.Empty;

	/// <summary>매수호가수량5</summary>
	[JsonPropertyName("bidrem5")]
	public string BidRem5 { get; set; } = string.Empty;

	/// <summary>매도호가건수5</summary>
	[JsonPropertyName("offercnt5")]
	public string OfferCnt5 { get; set; } = string.Empty;

	/// <summary>매수호가건수5</summary>
	[JsonPropertyName("bidcnt5")]
	public string BidCnt5 { get; set; } = string.Empty;

	/// <summary>매도호가총수량</summary>
	[JsonPropertyName("totofferrem")]
	public string TotOfferRem { get; set; } = string.Empty;

	/// <summary>매수호가총수량</summary>
	[JsonPropertyName("totbidrem")]
	public string TotBidRem { get; set; } = string.Empty;

	/// <summary>매도호가총건수</summary>
	[JsonPropertyName("totoffercnt")]
	public string TotOfferCnt { get; set; } = string.Empty;

	/// <summary>매수호가총건수</summary>
	[JsonPropertyName("totbidcnt")]
	public string TotBidCnt { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string FutCode { get; set; } = string.Empty;

	/// <summary>단일가호가여부</summary>
	[JsonPropertyName("danhochk")]
	public string DanHoChk { get; set; } = string.Empty;

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