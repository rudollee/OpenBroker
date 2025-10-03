using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 옵션전광판(t2301)
/// </summary>
internal class T2301 : LsResponseCore
{
	[JsonPropertyName("t2301InBlock")]
	public T2301InBlock T2301InBlock { get; set; } = new();
	[JsonPropertyName("t2301OutBlock")]
	public T2301OutBlock T2301OutBlock { get; set; } = new();
	[JsonPropertyName("t2301OutBlock1")]
	public List<T2301OutBlock1> T2301OutBlock1 { get; set; } = [];
	[JsonPropertyName("t2301OutBlock2")]
	public List<T2301OutBlock2> T2301OutBlock2 { get; set; } = [];
}

/// <summary>
/// 옵션전광판(t2301) - InBlock
/// </summary>
internal class T2301InBlock
{
	/// <summary>월물</summary>
	[JsonPropertyName("yyyymm")]
	public string YyyyMm { get; set; } = string.Empty;

	/// <summary>미니구분(M:미니G:정규)</summary>
	[JsonPropertyName("gubun")]
	public string Gubun { get; set; } = "G";
}

/// <summary>
/// 옵션전광판(t2301) - OutBlock
/// </summary>
internal class T2301OutBlock
{
	/// <summary>역사적변동성</summary>
	[JsonPropertyName("histimpv")]
	public long HistImpv { get; set; }

	/// <summary>옵션잔존일</summary>
	[JsonPropertyName("jandatecnt")]
	public long JanDateCnt { get; set; }

	/// <summary>콜옵션대표IV</summary>
	[JsonPropertyName("cimpv")]
	public decimal CImpv { get; set; }

	/// <summary>풋옵션대표IV</summary>
	[JsonPropertyName("pimpv")]
	public decimal PImpv { get; set; }

	/// <summary>근월물현재가</summary>
	[JsonPropertyName("gmprice")]
	public decimal GmPrice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	[JsonPropertyName("gmsign")]
	public string GmSign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	[JsonPropertyName("gmchange")]
	public decimal GmChange { get; set; }

	/// <summary>근월물등락율</summary>
	[JsonPropertyName("gmdiff")]
	public decimal GmDiff { get; set; }

	/// <summary>근월물거래량</summary>
	[JsonPropertyName("gmvolume")]
	public long GmVolume { get; set; }

	/// <summary>근월물선물코드</summary>
	[JsonPropertyName("gmshcode")]
	public string GmShcode { get; set; } = string.Empty;
}

/// <summary>
/// 옵션전광판(t2301) - OutBlock1
/// </summary>
internal class T2301OutBlock1
{
	/// <summary>행사가</summary>
	[JsonPropertyName("actprice")]
	public decimal ActPrice { get; set; }

	/// <summary>콜옵션코드</summary>
	[JsonPropertyName("optcode")]
	public string OptCode { get; set; } = string.Empty;

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

	/// <summary>IV</summary>
	[JsonPropertyName("iv")]
	public decimal Iv { get; set; }

	/// <summary>미결제약정</summary>
	[JsonPropertyName("mgjv")]
	public long Mgjv { get; set; }

	/// <summary>미결제약정증감</summary>
	[JsonPropertyName("mgjvupdn")]
	public long Mgjvupdn { get; set; }

	/// <summary>매도호가</summary>
	[JsonPropertyName("offerho1")]
	public decimal Offerho1 { get; set; }

	/// <summary>매수호가</summary>
	[JsonPropertyName("bidho1")]
	public decimal Bidho1 { get; set; }

	/// <summary>체결량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>델타</summary>
	[JsonPropertyName("delt")]
	public decimal Delt { get; set; }

	/// <summary>감마</summary>
	[JsonPropertyName("gama")]
	public decimal Gama { get; set; }

	/// <summary>베가</summary>
	[JsonPropertyName("vega")]
	public decimal Vega { get; set; }

	/// <summary>쎄타</summary>
	[JsonPropertyName("ceta")]
	public decimal Ceta { get; set; }

	/// <summary>로우</summary>
	[JsonPropertyName("rhox")]
	public decimal Rhox { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theoryprice")]
	public decimal Theoryprice { get; set; }

	/// <summary>내재가치</summary>
	[JsonPropertyName("impv")]
	public decimal Impv { get; set; }

	/// <summary>시간가치</summary>
	[JsonPropertyName("timevl")]
	public decimal Timevl { get; set; }

	/// <summary>잔고수량</summary>
	[JsonPropertyName("jvolume")]
	public long Jvolume { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("parpl")]
	public long Parpl { get; set; }

	/// <summary>청산가능수량</summary>
	[JsonPropertyName("jngo")]
	public long Jngo { get; set; }

	/// <summary>매도잔량</summary>
	[JsonPropertyName("offerrem1")]
	public long Offerrem1 { get; set; }

	/// <summary>매수잔량</summary>
	[JsonPropertyName("bidrem1")]
	public long Bidrem1 { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public decimal Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public decimal High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public decimal Low { get; set; }

	/// <summary>ATM구분</summary>
	[JsonPropertyName("atmgubun")]
	public string Atmgubun { get; set; } = string.Empty;

	/// <summary>지수환산</summary>
	[JsonPropertyName("jisuconv")]
	public decimal Jisuconv { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public decimal Value { get; set; }
}

/// <summary>
/// 옵션전광판(t2301) - OutBlock2
/// </summary>
internal class T2301OutBlock2
{
	/// <summary>행사가</summary>
	[JsonPropertyName("actprice")]
	public decimal ActPrice { get; set; }

	/// <summary>풋옵션코드</summary>
	[JsonPropertyName("optcode")]
	public string OptCode { get; set; } = string.Empty;

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

	/// <summary>IV</summary>
	[JsonPropertyName("iv")]
	public decimal Iv { get; set; }

	/// <summary>미결제약정</summary>
	[JsonPropertyName("mgjv")]
	public long Mgjv { get; set; }

	/// <summary>미결제약정증감</summary>
	[JsonPropertyName("mgjvupdn")]
	public long Mgjvupdn { get; set; }

	/// <summary>매도호가</summary>
	[JsonPropertyName("offerho1")]
	public decimal Offerho1 { get; set; }

	/// <summary>매수호가</summary>
	[JsonPropertyName("bidho1")]
	public decimal Bidho1 { get; set; }

	/// <summary>체결량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>델타</summary>
	[JsonPropertyName("delt")]
	public decimal Delt { get; set; }

	/// <summary>감마</summary>
	[JsonPropertyName("gama")]
	public decimal Gama { get; set; }

	/// <summary>베가</summary>
	[JsonPropertyName("vega")]
	public decimal Vega { get; set; }

	/// <summary>쎄타</summary>
	[JsonPropertyName("ceta")]
	public decimal Ceta { get; set; }

	/// <summary>로우</summary>
	[JsonPropertyName("rhox")]
	public decimal Rhox { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theoryprice")]
	public decimal Theoryprice { get; set; }

	/// <summary>내재가치</summary>
	[JsonPropertyName("impv")]
	public decimal Impv { get; set; }

	/// <summary>시간가치</summary>
	[JsonPropertyName("timevl")]
	public decimal Timevl { get; set; }

	/// <summary>잔고수량</summary>
	[JsonPropertyName("jvolume")]
	public long Jvolume { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("parpl")]
	public long Parpl { get; set; }

	/// <summary>청산가능수량</summary>
	[JsonPropertyName("jngo")]
	public long Jngo { get; set; }

	/// <summary>매도잔량</summary>
	[JsonPropertyName("offerrem1")]
	public long Offerrem1 { get; set; }

	/// <summary>매수잔량</summary>
	[JsonPropertyName("bidrem1")]
	public long Bidrem1 { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public decimal Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public decimal High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public decimal Low { get; set; }

	/// <summary>ATM구분</summary>
	[JsonPropertyName("atmgubun")]
	public string Atmgubun { get; set; } = string.Empty;

	/// <summary>지수환산</summary>
	[JsonPropertyName("jisuconv")]
	public decimal Jisuconv { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public decimal Value { get; set; }
}