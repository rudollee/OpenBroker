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
	public long Jnilclose { get; set; }

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public long Offerho1 { get; set; }

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public long Bidho1 { get; set; }

	/// <summary>매도호가수량1</summary>
	[JsonPropertyName("offerrem1")]
	public long Offerrem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	[JsonPropertyName("bidrem1")]
	public long Bidrem1 { get; set; }

	/// <summary>직전매도대비수량1</summary>
	[JsonPropertyName("preoffercha1")]
	public long Preoffercha1 { get; set; }

	/// <summary>직전매수대비수량1</summary>
	[JsonPropertyName("prebidcha1")]
	public long Prebidcha1 { get; set; }

	/// <summary>매도호가2</summary>
	[JsonPropertyName("offerho2")]
	public long Offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	[JsonPropertyName("bidho2")]
	public long Bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	[JsonPropertyName("offerrem2")]
	public long Offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	[JsonPropertyName("bidrem2")]
	public long Bidrem2 { get; set; }

	/// <summary>직전매도대비수량2</summary>
	[JsonPropertyName("preoffercha2")]
	public long Preoffercha2 { get; set; }

	/// <summary>직전매수대비수량2</summary>
	[JsonPropertyName("prebidcha2")]
	public long Prebidcha2 { get; set; }

	/// <summary>매도호가3</summary>
	[JsonPropertyName("offerho3")]
	public long Offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	[JsonPropertyName("bidho3")]
	public long Bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	[JsonPropertyName("offerrem3")]
	public long Offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	[JsonPropertyName("bidrem3")]
	public long Bidrem3 { get; set; }

	/// <summary>직전매도대비수량3</summary>
	[JsonPropertyName("preoffercha3")]
	public long Preoffercha3 { get; set; }

	/// <summary>직전매수대비수량3</summary>
	[JsonPropertyName("prebidcha3")]
	public long Prebidcha3 { get; set; }

	/// <summary>매도호가4</summary>
	[JsonPropertyName("offerho4")]
	public long Offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	[JsonPropertyName("bidho4")]
	public long Bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	[JsonPropertyName("offerrem4")]
	public long Offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	[JsonPropertyName("bidrem4")]
	public long Bidrem4 { get; set; }

	/// <summary>직전매도대비수량4</summary>
	[JsonPropertyName("preoffercha4")]
	public long Preoffercha4 { get; set; }

	/// <summary>직전매수대비수량4</summary>
	[JsonPropertyName("prebidcha4")]
	public long Prebidcha4 { get; set; }

	/// <summary>매도호가5</summary>
	[JsonPropertyName("offerho5")]
	public long Offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	[JsonPropertyName("bidho5")]
	public long Bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	[JsonPropertyName("offerrem5")]
	public long Offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	[JsonPropertyName("bidrem5")]
	public long Bidrem5 { get; set; }

	/// <summary>직전매도대비수량5</summary>
	[JsonPropertyName("preoffercha5")]
	public long Preoffercha5 { get; set; }

	/// <summary>직전매수대비수량5</summary>
	[JsonPropertyName("prebidcha5")]
	public long Prebidcha5 { get; set; }

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

	/// <summary>직전매도대비수량6</summary>
	[JsonPropertyName("preoffercha6")]
	public long Preoffercha6 { get; set; }

	/// <summary>직전매수대비수량6</summary>
	[JsonPropertyName("prebidcha6")]
	public long Prebidcha6 { get; set; }

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

	/// <summary>직전매도대비수량7</summary>
	[JsonPropertyName("preoffercha7")]
	public long Preoffercha7 { get; set; }

	/// <summary>직전매수대비수량7</summary>
	[JsonPropertyName("prebidcha7")]
	public long Prebidcha7 { get; set; }

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

	/// <summary>직전매도대비수량8</summary>
	[JsonPropertyName("preoffercha8")]
	public long Preoffercha8 { get; set; }

	/// <summary>직전매수대비수량8</summary>
	[JsonPropertyName("prebidcha8")]
	public long Prebidcha8 { get; set; }

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

	/// <summary>직전매도대비수량9</summary>
	[JsonPropertyName("preoffercha9")]
	public long Preoffercha9 { get; set; }

	/// <summary>직전매수대비수량9</summary>
	[JsonPropertyName("prebidcha9")]
	public long Prebidcha9 { get; set; }

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

	/// <summary>직전매도대비수량10</summary>
	[JsonPropertyName("preoffercha10")]
	public long Preoffercha10 { get; set; }

	/// <summary>직전매수대비수량10</summary>
	[JsonPropertyName("prebidcha10")]
	public long Prebidcha10 { get; set; }

	/// <summary>매도호가수량합</summary>
	[JsonPropertyName("offer")]
	public long Offer { get; set; }

	/// <summary>매수호가수량합</summary>
	[JsonPropertyName("bid")]
	public long Bid { get; set; }

	/// <summary>직전매도대비수량합</summary>
	[JsonPropertyName("preoffercha")]
	public long Preoffercha { get; set; }

	/// <summary>직전매수대비수량합</summary>
	[JsonPropertyName("prebidcha")]
	public long Prebidcha { get; set; }

	/// <summary>수신시간</summary>
	[JsonPropertyName("hotime")]
	public string Hotime { get; set; } = string.Empty;

	/// <summary>예상체결가격</summary>
	[JsonPropertyName("yeprice")]
	public long Yeprice { get; set; }

	/// <summary>예상체결수량</summary>
	[JsonPropertyName("yevolume")]
	public long Yevolume { get; set; }

	/// <summary>예상체결전일구분</summary>
	[JsonPropertyName("yesign")]
	public string Yesign { get; set; } = string.Empty;

	/// <summary>예상체결전일대비</summary>
	[JsonPropertyName("yechange")]
	public long Yechange { get; set; }

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
	public long Uplmtprice { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public long Dnlmtprice { get; set; }

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