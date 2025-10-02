using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션현재가호가조회(t2105)
/// </summary>
internal class T2105 : LsResponseCore
{
	[JsonPropertyName("t2105InBlock")]
	public T2105InBlock T2105InBlock { get; set; } = new();
	[JsonPropertyName("t2105OutBlock")]
	public T2105OutBlock T2105OutBlock { get; set; } = new();
}

/// <summary>
/// 선물/옵션현재가호가조회(t2105) - InBlock
/// </summary>
internal class T2105InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션현재가호가조회(t2105) - OutBlock
/// </summary>
internal class T2105OutBlock
{
	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public decimal Price { get; set; }

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public decimal Change { get; set; }

	/// <summary>등락율</summary>
	[JsonPropertyName("diff")]
	public decimal Diff { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>거래량전일동시간비율</summary>
	[JsonPropertyName("stimeqrt")]
	public decimal Stimeqrt { get; set; }

	/// <summary>전일종가</summary>
	[JsonPropertyName("jnilclose")]
	public decimal Jnilclose { get; set; }

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public decimal Offerho1 { get; set; }

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public decimal Bidho1 { get; set; }

	/// <summary>매도호가수량1</summary>
	[JsonPropertyName("offerrem1")]
	public long Offerrem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	[JsonPropertyName("bidrem1")]
	public long Bidrem1 { get; set; }

	/// <summary>매도호가건수1</summary>
	[JsonPropertyName("dcnt1")]
	public long Dcnt1 { get; set; }

	/// <summary>매수호가건수1</summary>
	[JsonPropertyName("scnt1")]
	public long Scnt1 { get; set; }

	/// <summary>매도호가2</summary>
	[JsonPropertyName("offerho2")]
	public decimal Offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	[JsonPropertyName("bidho2")]
	public decimal Bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	[JsonPropertyName("offerrem2")]
	public long Offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	[JsonPropertyName("bidrem2")]
	public long Bidrem2 { get; set; }

	/// <summary>매도호가건수2</summary>
	[JsonPropertyName("dcnt2")]
	public long Dcnt2 { get; set; }

	/// <summary>매수호가건수2</summary>
	[JsonPropertyName("scnt2")]
	public long Scnt2 { get; set; }

	/// <summary>매도호가3</summary>
	[JsonPropertyName("offerho3")]
	public decimal Offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	[JsonPropertyName("bidho3")]
	public decimal Bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	[JsonPropertyName("offerrem3")]
	public long Offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	[JsonPropertyName("bidrem3")]
	public long Bidrem3 { get; set; }

	/// <summary>매도호가건수3</summary>
	[JsonPropertyName("dcnt3")]
	public long Dcnt3 { get; set; }

	/// <summary>매수호가건수3</summary>
	[JsonPropertyName("scnt3")]
	public long Scnt3 { get; set; }

	/// <summary>매도호가4</summary>
	[JsonPropertyName("offerho4")]
	public decimal Offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	[JsonPropertyName("bidho4")]
	public decimal Bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	[JsonPropertyName("offerrem4")]
	public long Offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	[JsonPropertyName("bidrem4")]
	public long Bidrem4 { get; set; }

	/// <summary>매도호가건수4</summary>
	[JsonPropertyName("dcnt4")]
	public long Dcnt4 { get; set; }

	/// <summary>매수호가건수4</summary>
	[JsonPropertyName("scnt4")]
	public long Scnt4 { get; set; }

	/// <summary>매도호가5</summary>
	[JsonPropertyName("offerho5")]
	public decimal Offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	[JsonPropertyName("bidho5")]
	public decimal Bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	[JsonPropertyName("offerrem5")]
	public long Offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	[JsonPropertyName("bidrem5")]
	public long Bidrem5 { get; set; }

	/// <summary>매도호가건수5</summary>
	[JsonPropertyName("dcnt5")]
	public long Dcnt5 { get; set; }

	/// <summary>매수호가건수5</summary>
	[JsonPropertyName("scnt5")]
	public long Scnt5 { get; set; }

	/// <summary>매도호가총수량</summary>
	[JsonPropertyName("dvol")]
	public long Dvol { get; set; }

	/// <summary>매수호가총수량</summary>
	[JsonPropertyName("svol")]
	public long Svol { get; set; }

	/// <summary>총매도호가건수</summary>
	[JsonPropertyName("toffernum")]
	public long Toffernum { get; set; }

	/// <summary>총매수호가건수</summary>
	[JsonPropertyName("tbidnum")]
	public long Tbidnum { get; set; }

	/// <summary>수신시간</summary>
	[JsonPropertyName("time")]
	public string Time { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// KRX야간파생 호가조회(API용)(t8457)
/// </summary>
internal class T8457 : LsResponseCore
{
	[JsonPropertyName("t8457InBlock")]
	public T2105InBlock T8457InBlock { get; set; } = new();
	[JsonPropertyName("t8457OutBlock")]
	public T2105OutBlock T8457OutBlock { get; set; } = new();
}