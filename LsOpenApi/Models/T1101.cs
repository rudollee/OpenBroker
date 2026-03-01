using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식현재가호가조회(t1101)
/// </summary>
internal class T1101 : LsResponseCore
{
	[JsonPropertyName("t1101InBlock")]
	public T1101InBlock T1101InBlock { get; set; } = new();
	[JsonPropertyName("t1101OutBlock")]
	public T1101OutBlock T1101OutBlock { get; set; } = new();
}

/// <summary>
/// 주식현재가호가조회(t1101) - InBlock
/// </summary>
internal class T1101InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식현재가호가조회(t1101) - OutBlock
/// </summary>
internal class T1101OutBlock
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

	/// <summary>전일종가(기준가)</summary>
	[JsonPropertyName("jnilclose")]
	public long JnilClose { get; set; }

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public long OfferHo1 { get; set; }

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public long BidHo1 { get; set; }

	/// <summary>매도호가수량1</summary>
	[JsonPropertyName("offerrem1")]
	public long OfferRem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	[JsonPropertyName("bidrem1")]
	public long BidRem1 { get; set; }

	/// <summary>직전매도대비수량1</summary>
	[JsonPropertyName("preoffercha1")]
	public long PreOfferCha1 { get; set; }

	/// <summary>직전매수대비수량1</summary>
	[JsonPropertyName("prebidcha1")]
	public long PreBidCha1 { get; set; }

	/// <summary>매도호가2</summary>
	[JsonPropertyName("offerho2")]
	public long OfferHo2 { get; set; }

	/// <summary>매수호가2</summary>
	[JsonPropertyName("bidho2")]
	public long BidHo2 { get; set; }

	/// <summary>매도호가수량2</summary>
	[JsonPropertyName("offerrem2")]
	public long OfferRem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	[JsonPropertyName("bidrem2")]
	public long BidRem2 { get; set; }

	/// <summary>직전매도대비수량2</summary>
	[JsonPropertyName("preoffercha2")]
	public long PreOfferCha2 { get; set; }

	/// <summary>직전매수대비수량2</summary>
	[JsonPropertyName("prebidcha2")]
	public long PreBidCha2 { get; set; }

	/// <summary>매도호가3</summary>
	[JsonPropertyName("offerho3")]
	public long OfferHo3 { get; set; }

	/// <summary>매수호가3</summary>
	[JsonPropertyName("bidho3")]
	public long BidHo3 { get; set; }

	/// <summary>매도호가수량3</summary>
	[JsonPropertyName("offerrem3")]
	public long OfferRem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	[JsonPropertyName("bidrem3")]
	public long BidRem3 { get; set; }

	/// <summary>직전매도대비수량3</summary>
	[JsonPropertyName("preoffercha3")]
	public long PreOfferCha3 { get; set; }

	/// <summary>직전매수대비수량3</summary>
	[JsonPropertyName("prebidcha3")]
	public long PreBidCha3 { get; set; }

	/// <summary>매도호가4</summary>
	[JsonPropertyName("offerho4")]
	public long OfferHo4 { get; set; }

	/// <summary>매수호가4</summary>
	[JsonPropertyName("bidho4")]
	public long BidHo4 { get; set; }

	/// <summary>매도호가수량4</summary>
	[JsonPropertyName("offerrem4")]
	public long OfferRem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	[JsonPropertyName("bidrem4")]
	public long BidRem4 { get; set; }

	/// <summary>직전매도대비수량4</summary>
	[JsonPropertyName("preoffercha4")]
	public long PreOfferCha4 { get; set; }

	/// <summary>직전매수대비수량4</summary>
	[JsonPropertyName("prebidcha4")]
	public long PreBidCha4 { get; set; }

	/// <summary>매도호가5</summary>
	[JsonPropertyName("offerho5")]
	public long OfferHo5 { get; set; }

	/// <summary>매수호가5</summary>
	[JsonPropertyName("bidho5")]
	public long BidHo5 { get; set; }

	/// <summary>매도호가수량5</summary>
	[JsonPropertyName("offerrem5")]
	public long OfferRem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	[JsonPropertyName("bidrem5")]
	public long BidRem5 { get; set; }

	/// <summary>직전매도대비수량5</summary>
	[JsonPropertyName("preoffercha5")]
	public long PreOfferCha5 { get; set; }

	/// <summary>직전매수대비수량5</summary>
	[JsonPropertyName("prebidcha5")]
	public long PreBidCha5 { get; set; }

	/// <summary>매도호가6</summary>
	[JsonPropertyName("offerho6")]
	public long OfferHo6 { get; set; }

	/// <summary>매수호가6</summary>
	[JsonPropertyName("bidho6")]
	public long BidHo6 { get; set; }

	/// <summary>매도호가수량6</summary>
	[JsonPropertyName("offerrem6")]
	public long OfferRem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	[JsonPropertyName("bidrem6")]
	public long BidRem6 { get; set; }

	/// <summary>직전매도대비수량6</summary>
	[JsonPropertyName("preoffercha6")]
	public long PreOfferCha6 { get; set; }

	/// <summary>직전매수대비수량6</summary>
	[JsonPropertyName("prebidcha6")]
	public long PreBidCha6 { get; set; }

	/// <summary>매도호가7</summary>
	[JsonPropertyName("offerho7")]
	public long OfferHo7 { get; set; }

	/// <summary>매수호가7</summary>
	[JsonPropertyName("bidho7")]
	public long BidHo7 { get; set; }

	/// <summary>매도호가수량7</summary>
	[JsonPropertyName("offerrem7")]
	public long OfferRem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	[JsonPropertyName("bidrem7")]
	public long BidRem7 { get; set; }

	/// <summary>직전매도대비수량7</summary>
	[JsonPropertyName("preoffercha7")]
	public long PreOfferCha7 { get; set; }

	/// <summary>직전매수대비수량7</summary>
	[JsonPropertyName("prebidcha7")]
	public long PreBidCha7 { get; set; }

	/// <summary>매도호가8</summary>
	[JsonPropertyName("offerho8")]
	public long OfferHo8 { get; set; }

	/// <summary>매수호가8</summary>
	[JsonPropertyName("bidho8")]
	public long BidHo8 { get; set; }

	/// <summary>매도호가수량8</summary>
	[JsonPropertyName("offerrem8")]
	public long OfferRem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	[JsonPropertyName("bidrem8")]
	public long BidRem8 { get; set; }

	/// <summary>직전매도대비수량8</summary>
	[JsonPropertyName("preoffercha8")]
	public long PreOfferCha8 { get; set; }

	/// <summary>직전매수대비수량8</summary>
	[JsonPropertyName("prebidcha8")]
	public long PreBidCha8 { get; set; }

	/// <summary>매도호가9</summary>
	[JsonPropertyName("offerho9")]
	public long OfferHo9 { get; set; }

	/// <summary>매수호가9</summary>
	[JsonPropertyName("bidho9")]
	public long BidHo9 { get; set; }

	/// <summary>매도호가수량9</summary>
	[JsonPropertyName("offerrem9")]
	public long OfferRem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	[JsonPropertyName("bidrem9")]
	public long BidRem9 { get; set; }

	/// <summary>직전매도대비수량9</summary>
	[JsonPropertyName("preoffercha9")]
	public long PreOfferCha9 { get; set; }

	/// <summary>직전매수대비수량9</summary>
	[JsonPropertyName("prebidcha9")]
	public long PreBidCha9 { get; set; }

	/// <summary>매도호가10</summary>
	[JsonPropertyName("offerho10")]
	public long OfferHo10 { get; set; }

	/// <summary>매수호가10</summary>
	[JsonPropertyName("bidho10")]
	public long BidHo10 { get; set; }

	/// <summary>매도호가수량10</summary>
	[JsonPropertyName("offerrem10")]
	public long OfferRem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	[JsonPropertyName("bidrem10")]
	public long BidRem10 { get; set; }

	/// <summary>직전매도대비수량10</summary>
	[JsonPropertyName("preoffercha10")]
	public long PreOfferCha10 { get; set; }

	/// <summary>직전매수대비수량10</summary>
	[JsonPropertyName("prebidcha10")]
	public long PreBidCha10 { get; set; }

	/// <summary>매도호가수량합</summary>
	[JsonPropertyName("offer")]
	public long Offer { get; set; }

	/// <summary>매수호가수량합</summary>
	[JsonPropertyName("bid")]
	public long Bid { get; set; }

	/// <summary>직전매도대비수량합</summary>
	[JsonPropertyName("preoffercha")]
	public long PreOfferCha { get; set; }

	/// <summary>직전매수대비수량합</summary>
	[JsonPropertyName("prebidcha")]
	public long PreBidCha { get; set; }

	/// <summary>수신시간</summary>
	[JsonPropertyName("hotime")]
	public string HoTime { get; set; } = string.Empty;

	/// <summary>예상체결가격</summary>
	[JsonPropertyName("yeprice")]
	public long YePrice { get; set; }

	/// <summary>예상체결수량</summary>
	[JsonPropertyName("yevolume")]
	public long YeVolume { get; set; }

	/// <summary>예상체결전일구분</summary>
	[JsonPropertyName("yesign")]
	public string YeSign { get; set; } = string.Empty;

	/// <summary>예상체결전일대비</summary>
	[JsonPropertyName("yechange")]
	public long YeChange { get; set; }

	/// <summary>예상체결등락율</summary>
	[JsonPropertyName("yediff")]
	public decimal Yediff { get; set; }

	/// <summary>시간외매도잔량</summary>
	[JsonPropertyName("tmoffer")]
	public long Tmoffer { get; set; }

	/// <summary>시간외매수잔량</summary>
	[JsonPropertyName("tmbid")]
	public long Tmbid { get; set; }

	/// <summary>동시구분</summary>
	[JsonPropertyName("ho_status")]
	public string HoStatus { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>상한가</summary>
	[JsonPropertyName("uplmtprice")]
	public long UpLmtPrice { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public long DnLmtPrice { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>KRX중간가격</summary>
	[JsonPropertyName("krx_midprice")]
	public long KrxMidprice { get; set; }

	/// <summary>KRX매도중간가잔량합계수량</summary>
	[JsonPropertyName("krx_offermidsumrem")]
	public long KrxOffermidsumrem { get; set; }

	/// <summary>KRX매수중간가잔량합계수량</summary>
	[JsonPropertyName("krx_bidmidsumrem")]
	public long KrxBidmidsumrem { get; set; }

	/// <summary>KRX중간가잔량합계수량</summary>
	[JsonPropertyName("krx_midsumrem")]
	public long KrxMidsumrem { get; set; }

	/// <summary>KRX중간가잔량구분(''없음'1'매도'2'매</summary>
	[JsonPropertyName("krx_midsumremgubun")]
	public string KrxMidsumremgubun { get; set; } = string.Empty;
}