using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션현재가(시세)조회(t2101)
/// </summary>
internal class t2101 : LsResponseCore
{
	[JsonPropertyName("t2101InBlock")]
	public T2101InBlock T2101InBlock { get; set; } = new();
	[JsonPropertyName("t2101OutBlock")]
	public T2101OutBlock T2101OutBlock { get; set; } = new();
}

/// <summary>
/// 선물/옵션현재가(시세)조회(t2101) - InBlock
/// </summary>
internal class T2101InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("focode")]
	public string Focode { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션현재가(시세)조회(t2101) - OutBlock
/// </summary>
internal class T2101OutBlock
{
	/// <summary>한글명</summary>
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

	/// <summary>전일종가</summary>
	[JsonPropertyName("jnilclose")]
	public decimal Jnilclose { get; set; }

	/// <summary>등락율</summary>
	[JsonPropertyName("diff")]
	public decimal Diff { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>미결제량</summary>
	[JsonPropertyName("mgjv")]
	public long Mgjv { get; set; }

	/// <summary>미결제증감</summary>
	[JsonPropertyName("mgjvdiff")]
	public long Mgjvdiff { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public decimal Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public decimal High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public decimal Low { get; set; }

	/// <summary>상한가</summary>
	[JsonPropertyName("uplmtprice")]
	public decimal Uplmtprice { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public decimal Dnlmtprice { get; set; }

	/// <summary>52최고가</summary>
	[JsonPropertyName("high52w")]
	public decimal High52w { get; set; }

	/// <summary>52최저가</summary>
	[JsonPropertyName("low52w")]
	public decimal Low52w { get; set; }

	/// <summary>베이시스</summary>
	[JsonPropertyName("basis")]
	public decimal Basis { get; set; }

	/// <summary>기준가</summary>
	[JsonPropertyName("recprice")]
	public decimal Recprice { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theoryprice")]
	public decimal Theoryprice { get; set; }

	/// <summary>괴리율</summary>
	[JsonPropertyName("glyl")]
	public decimal Glyl { get; set; }

	/// <summary>CB상한가</summary>
	[JsonPropertyName("cbhprice")]
	public decimal Cbhprice { get; set; }

	/// <summary>CB하한가</summary>
	[JsonPropertyName("cblprice")]
	public decimal Cblprice { get; set; }

	/// <summary>만기일</summary>
	[JsonPropertyName("lastmonth")]
	public string Lastmonth { get; set; } = string.Empty;

	/// <summary>잔여일</summary>
	[JsonPropertyName("jandatecnt")]
	public long Jandatecnt { get; set; }

	/// <summary>종합지수</summary>
	[JsonPropertyName("pricejisu")]
	public decimal Pricejisu { get; set; }

	/// <summary>종합지수전일대비구분</summary>
	[JsonPropertyName("jisusign")]
	public string Jisusign { get; set; } = string.Empty;

	/// <summary>종합지수전일대비</summary>
	[JsonPropertyName("jisuchange")]
	public decimal Jisuchange { get; set; }

	/// <summary>종합지수등락율</summary>
	[JsonPropertyName("jisudiff")]
	public decimal Jisudiff { get; set; }

	/// <summary>KOSPI200지수</summary>
	[JsonPropertyName("kospijisu")]
	public decimal Kospijisu { get; set; }

	/// <summary>KOSPI200전일대비구분</summary>
	[JsonPropertyName("kospisign")]
	public string Kospisign { get; set; } = string.Empty;

	/// <summary>KOSPI200전일대비</summary>
	[JsonPropertyName("kospichange")]
	public decimal Kospichange { get; set; }

	/// <summary>KOSPI200등락율</summary>
	[JsonPropertyName("kospidiff")]
	public decimal Kospidiff { get; set; }

	/// <summary>상장최고가</summary>
	[JsonPropertyName("listhprice")]
	public decimal Listhprice { get; set; }

	/// <summary>상장최저가</summary>
	[JsonPropertyName("listlprice")]
	public decimal Listlprice { get; set; }

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
	public decimal Gmprice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	[JsonPropertyName("gmsign")]
	public string Gmsign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	[JsonPropertyName("gmchange")]
	public decimal Gmchange { get; set; }

	/// <summary>근월물등락율</summary>
	[JsonPropertyName("gmdiff")]
	public decimal Gmdiff { get; set; }

	/// <summary>이론가</summary>
	[JsonPropertyName("theorypriceg")]
	public decimal Theorypriceg { get; set; }

	/// <summary>역사적변동성</summary>
	[JsonPropertyName("histimpv")]
	public decimal Histimpv { get; set; }

	/// <summary>내재변동성</summary>
	[JsonPropertyName("impv")]
	public decimal Impv { get; set; }

	/// <summary>시장BASIS</summary>
	[JsonPropertyName("sbasis")]
	public decimal Sbasis { get; set; }

	/// <summary>이론BASIS</summary>
	[JsonPropertyName("ibasis")]
	public decimal Ibasis { get; set; }

	/// <summary>근월물종목코드</summary>
	[JsonPropertyName("gmfutcode")]
	public string Gmfutcode { get; set; } = string.Empty;

	/// <summary>행사가</summary>
	[JsonPropertyName("actprice")]
	public decimal Actprice { get; set; }

	/// <summary>거래소민감도수신시간</summary>
	[JsonPropertyName("greeks_time")]
	public string GreeksTime { get; set; } = string.Empty;

	/// <summary>거래소민감도확정여부</summary>
	[JsonPropertyName("greeks_confirm")]
	public string GreeksConfirm { get; set; } = string.Empty;

	/// <summary>단일가호가여부</summary>
	[JsonPropertyName("danhochk")]
	public string Danhochk { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	[JsonPropertyName("yeprice")]
	public decimal Yeprice { get; set; }

	/// <summary>예상체결가전일종가대비구분</summary>
	[JsonPropertyName("jnilysign")]
	public string Jnilysign { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비</summary>
	[JsonPropertyName("jnilychange")]
	public decimal Jnilychange { get; set; }

	/// <summary>예상체결가전일종가등락율</summary>
	[JsonPropertyName("jnilydrate")]
	public decimal Jnilydrate { get; set; }

	/// <summary>배분구분(1:배분개시2:배분해제0:미발생)</summary>
	[JsonPropertyName("alloc_gubun")]
	public string AllocGubun { get; set; } = string.Empty;

	/// <summary>잔여일(영업일)</summary>
	[JsonPropertyName("bjandatecnt")]
	public long Bjandatecnt { get; set; }

	/// <summary>종목코드</summary>
	[JsonPropertyName("focode")]
	public string Focode { get; set; } = string.Empty;

	/// <summary>실시간가격제한여부(0:대상아님1:적용중2:미적용중3:일시해제)</summary>
	[JsonPropertyName("dy_gubun")]
	public string DyGubun { get; set; } = string.Empty;

	/// <summary>실시간상한가</summary>
	[JsonPropertyName("dy_uplmtprice")]
	public decimal DyUplmtprice { get; set; }

	/// <summary>실시간하한가</summary>
	[JsonPropertyName("dy_dnlmtprice")]
	public decimal DyDnlmtprice { get; set; }

	/// <summary>가격제한폭확대(0:미확대1:확대2:대상아님)</summary>
	[JsonPropertyName("updnstep_gubun")]
	public string UpdnstepGubun { get; set; } = string.Empty;

	/// <summary>상한적용단계</summary>
	[JsonPropertyName("upstep")]
	public string Upstep { get; set; } = string.Empty;

	/// <summary>하한적용단계</summary>
	[JsonPropertyName("dnstep")]
	public string Dnstep { get; set; } = string.Empty;

	/// <summary>3단계상한가</summary>
	[JsonPropertyName("uplmtprice_3rd")]
	public decimal Uplmtprice3rd { get; set; }

	/// <summary>3단계하한가</summary>
	[JsonPropertyName("dnlmtprice_3rd")]
	public decimal Dnlmtprice3rd { get; set; }

	/// <summary>예상체결수량</summary>
	[JsonPropertyName("expct_ccls_q")]
	public long ExpctCclsQ { get; set; }
}