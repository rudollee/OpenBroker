using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식선물현재가조회(API용)(t8402)
/// </summary>
internal class T8402 : LsResponseCore
{
	[JsonPropertyName("t8402InBlock")]
	public T8402InBlock T8402InBlock { get; set; } = new();
	[JsonPropertyName("t8402OutBlock")]
	public T8402OutBlock T8402OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물현재가조회(API용)(t8402) - InBlock
/// </summary>
internal class T8402InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("focode")]
	public string FoCode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물현재가조회(API용)(t8402) - OutBlock
/// </summary>
internal class T8402OutBlock
{
	/// <summary>한글명</summary>
	[JsonPropertyName("hname")]
	public string HName { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public long Change { get; set; }

	/// <summary>전일종가</summary>
	[JsonPropertyName("jnilclose")]
	public long JnilClose { get; set; }

	/// <summary>등락율</summary>
	[JsonPropertyName("diff")]
	public decimal Diff { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>거래량전일동시간비율</summary>
	[JsonPropertyName("stimeqrt")]
	public decimal STimeQrt { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>미결제량</summary>
	[JsonPropertyName("mgjv")]
	public long Mgjv { get; set; }

	/// <summary>미결제증감</summary>
	[JsonPropertyName("mgjvdiff")]
	public long MgjvDiff { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>상한가</summary>
	[JsonPropertyName("uplmtprice")]
	public long UplmtPrice { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public long DnlmtPrice { get; set; }

	/// <summary>52최고가</summary>
	[JsonPropertyName("high52w")]
	public long High52w { get; set; }

	/// <summary>52최저가</summary>
	[JsonPropertyName("low52w")]
	public long Low52w { get; set; }

	/// <summary>베이시스</summary>
	[JsonPropertyName("basis")]
	public decimal Basis { get; set; }

	/// <summary>기준가</summary>
	[JsonPropertyName("recprice")]
	public long RecPrice { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theoryprice")]
	public long TheoryPrice { get; set; }

	/// <summary>괴리율</summary>
	[JsonPropertyName("glyl")]
	public decimal Glyl { get; set; }

	/// <summary>만기일</summary>
	[JsonPropertyName("lastmonth")]
	public string LastMonth { get; set; } = string.Empty;

	/// <summary>잔여일</summary>
	[JsonPropertyName("jandatecnt")]
	public long JanDateCnt { get; set; }

	/// <summary>종합지수</summary>
	[JsonPropertyName("pricejisu")]
	public decimal PriceJisu { get; set; }

	/// <summary>종합지수전일대비구분</summary>
	[JsonPropertyName("jisusign")]
	public string JisuSign { get; set; } = string.Empty;

	/// <summary>종합지수전일대비</summary>
	[JsonPropertyName("jisuchange")]
	public decimal JisuChange { get; set; }

	/// <summary>종합지수등락율</summary>
	[JsonPropertyName("jisudiff")]
	public decimal JisuDiff { get; set; }

	/// <summary>KOSPI200지수</summary>
	[JsonPropertyName("kospijisu")]
	public decimal KospiJisu { get; set; }

	/// <summary>KOSPI200전일대비구분</summary>
	[JsonPropertyName("kospisign")]
	public string KospiSign { get; set; } = string.Empty;

	/// <summary>KOSPI200전일대비</summary>
	[JsonPropertyName("kospichange")]
	public decimal KospiChange { get; set; }

	/// <summary>KOSPI200등락율</summary>
	[JsonPropertyName("kospidiff")]
	public decimal KospiDiff { get; set; }

	/// <summary>상장최고가</summary>
	[JsonPropertyName("listhprice")]
	public long ListhPrice { get; set; }

	/// <summary>상장최저가</summary>
	[JsonPropertyName("listlprice")]
	public long ListlPrice { get; set; }

	/// <summary>델타</summary>
	[JsonPropertyName("delt")]
	public decimal Delt { get; set; }

	/// <summary>감마</summary>
	[JsonPropertyName("gama")]
	public decimal Gama { get; set; }

	/// <summary>세타</summary>
	[JsonPropertyName("ceta")]
	public decimal Ceta { get; set; }

	/// <summary>베가</summary>
	[JsonPropertyName("vega")]
	public decimal Vega { get; set; }

	/// <summary>로우</summary>
	[JsonPropertyName("rhox")]
	public decimal Rhox { get; set; }

	/// <summary>근월물현재가</summary>
	[JsonPropertyName("gmprice")]
	public long GmPrice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	[JsonPropertyName("gmsign")]
	public string GmSign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	[JsonPropertyName("gmchange")]
	public long GmChange { get; set; }

	/// <summary>근월물등락율</summary>
	[JsonPropertyName("gmdiff")]
	public decimal GmDiff { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theorypriceg")]
	public long TheoryPriceg { get; set; }

	/// <summary>역사적변동성</summary>
	[JsonPropertyName("histimpv")]
	public decimal HistImpv { get; set; }

	/// <summary>내재변동성</summary>
	[JsonPropertyName("impv")]
	public decimal Impv { get; set; }

	/// <summary>시장BASIS</summary>
	[JsonPropertyName("sbasis")]
	public long Sbasis { get; set; }

	/// <summary>이론BASIS</summary>
	[JsonPropertyName("ibasis")]
	public long Ibasis { get; set; }

	/// <summary>근월물종목코드</summary>
	[JsonPropertyName("gmfutcode")]
	public string Gmfutcode { get; set; } = string.Empty;

	/// <summary>행사가</summary>
	[JsonPropertyName("actprice")]
	public long ActPrice { get; set; }

	/// <summary>기초자산단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>기초자산한글명</summary>
	[JsonPropertyName("basehname")]
	public string BasehName { get; set; } = string.Empty;

	/// <summary>기초자산현재가</summary>
	[JsonPropertyName("baseprice")]
	public long BasePrice { get; set; }

	/// <summary>기초자산현재가대비구분</summary>
	[JsonPropertyName("basesign")]
	public string BaseSign { get; set; } = string.Empty;

	/// <summary>기초자산현재가전일대비</summary>
	[JsonPropertyName("basechange")]
	public long BaseChange { get; set; }

	/// <summary>기초자산등락률</summary>
	[JsonPropertyName("basediff")]
	public decimal BaseDiff { get; set; }

	/// <summary>기초자산거래량</summary>
	[JsonPropertyName("basevol")]
	public long BaseVol { get; set; }

	/// <summary>기초자산전일거래량</summary>
	[JsonPropertyName("baseprevol")]
	public long BasePreVol { get; set; }

	/// <summary>기초자산매수호가</summary>
	[JsonPropertyName("basebidprc")]
	public long BaseBidPrc { get; set; }

	/// <summary>기초자산매도호가</summary>
	[JsonPropertyName("baseaskprc")]
	public long BaseAskPrc { get; set; }

	/// <summaryii>기초자산외국계회원사순매수</summary>
	[JsonPropertyName("basefornetbid")]
	public long BaseFornetBid { get; set; }

	/// <summary>상품군</summary>
	[JsonPropertyName("prodgrp")]
	public string ProdGrp { get; set; } = string.Empty;

	/// <summary>승수</summary>
	[JsonPropertyName("mulcnt")]
	public decimal MulCnt { get; set; }

	/// <summary>단일가호가여부</summary>
	[JsonPropertyName("danhochk")]
	public string Danhochk { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	[JsonPropertyName("yeprice")]
	public long YePrice { get; set; }

	/// <summary>예상체결가전일종가대비구분</summary>
	[JsonPropertyName("jnilysign")]
	public string JnilySign { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비</summary>
	[JsonPropertyName("jnilychange")]
	public long JnilyChange { get; set; }

	/// <summary>예상체결가전일종가등락율</summary>
	[JsonPropertyName("jnilydrate")]
	public decimal JnilydRate { get; set; }
}