namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션현재가(시세)조회(t2101)
/// </summary>
internal class t2101 : LsResponseCore
{
	public t2101InBlock t2101InBlock { get; set; } = new();
	public t2101OutBlock t2101OutBlock { get; set; } = new();
}

/// <summary>
/// 선물/옵션현재가(시세)조회(t2101) - InBlock
/// </summary>
internal class t2101InBlock
{
	/// <summary>단축코드</summary>
	public string focode { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션현재가(시세)조회(t2101) - OutBlock
/// </summary>
internal class t2101OutBlock
{
	/// <summary>한글명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public decimal price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public decimal change { get; set; }

	/// <summary>전일종가</summary>
	public decimal jnilclose { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>거래량</summary>
	public long volume { get; set; }

	/// <summary>거래대금</summary>
	public long value { get; set; }

	/// <summary>미결제량</summary>
	public long mgjv { get; set; }

	/// <summary>미결제증감</summary>
	public long mgjvdiff { get; set; }

	/// <summary>시가</summary>
	public decimal open { get; set; }

	/// <summary>고가</summary>
	public decimal high { get; set; }

	/// <summary>저가</summary>
	public decimal low { get; set; }

	/// <summary>상한가</summary>
	public decimal uplmtprice { get; set; }

	/// <summary>하한가</summary>
	public decimal dnlmtprice { get; set; }

	/// <summary>52최고가</summary>
	public decimal high52w { get; set; }

	/// <summary>52최저가</summary>
	public decimal low52w { get; set; }

	/// <summary>베이시스</summary>
	public decimal basis { get; set; }

	/// <summary>기준가</summary>
	public decimal recprice { get; set; }

	/// <summary>이론가</summary>
	public decimal theoryprice { get; set; }

	/// <summary>괴리율</summary>
	public decimal glyl { get; set; }

	/// <summary>CB상한가</summary>
	public decimal cbhprice { get; set; }

	/// <summary>CB하한가</summary>
	public decimal cblprice { get; set; }

	/// <summary>만기일</summary>
	public string lastmonth { get; set; } = string.Empty;

	/// <summary>잔여일</summary>
	public long jandatecnt { get; set; }

	/// <summary>종합지수</summary>
	public decimal pricejisu { get; set; }

	/// <summary>종합지수전일대비구분</summary>
	public string jisusign { get; set; } = string.Empty;

	/// <summary>종합지수전일대비</summary>
	public decimal jisuchange { get; set; }

	/// <summary>종합지수등락율</summary>
	public decimal jisudiff { get; set; }

	/// <summary>KOSPI200지수</summary>
	public decimal kospijisu { get; set; }

	/// <summary>KOSPI200전일대비구분</summary>
	public string kospisign { get; set; } = string.Empty;

	/// <summary>KOSPI200전일대비</summary>
	public decimal kospichange { get; set; }

	/// <summary>KOSPI200등락율</summary>
	public decimal kospidiff { get; set; }

	/// <summary>상장최고가</summary>
	public decimal listhprice { get; set; }

	/// <summary>상장최저가</summary>
	public decimal listlprice { get; set; }

	/// <summary>델타</summary>
	public decimal delt { get; set; }

	/// <summary>감마</summary>
	public decimal gama { get; set; }

	/// <summary>세타</summary>
	public decimal ceta { get; set; }

	/// <summary>베가</summary>
	public decimal vega { get; set; }

	/// <summary>로우</summary>
	public decimal rhox { get; set; }

	/// <summary>근월물현재가</summary>
	public decimal gmprice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	public string gmsign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	public decimal gmchange { get; set; }

	/// <summary>근월물등락율</summary>
	public decimal gmdiff { get; set; }

	/// <summary>이론가</summary>
	public decimal theorypriceg { get; set; }

	/// <summary>역사적변동성</summary>
	public decimal histimpv { get; set; }

	/// <summary>내재변동성</summary>
	public decimal impv { get; set; }

	/// <summary>시장BASIS</summary>
	public decimal sbasis { get; set; }

	/// <summary>이론BASIS</summary>
	public decimal ibasis { get; set; }

	/// <summary>근월물종목코드</summary>
	public string gmfutcode { get; set; } = string.Empty;

	/// <summary>행사가</summary>
	public decimal actprice { get; set; }

	/// <summary>거래소민감도수신시간</summary>
	public string greeks_time { get; set; } = string.Empty;

	/// <summary>거래소민감도확정여부</summary>
	public string greeks_confirm { get; set; } = string.Empty;

	/// <summary>단일가호가여부</summary>
	public string danhochk { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	public decimal yeprice { get; set; }

	/// <summary>예상체결가전일종가대비구분</summary>
	public string jnilysign { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비</summary>
	public decimal jnilychange { get; set; }

	/// <summary>예상체결가전일종가등락율</summary>
	public decimal jnilydrate { get; set; }

	/// <summary>배분구분(1:배분개시2:배분해제0:미발생)</summary>
	public string alloc_gubun { get; set; } = string.Empty;

	/// <summary>잔여일(영업일)</summary>
	public long bjandatecnt { get; set; }

	/// <summary>종목코드</summary>
	public string focode { get; set; } = string.Empty;

	/// <summary>실시간가격제한여부(0:대상아님1:적용중2:미적용중3:일시해제)</summary>
	public string dy_gubun { get; set; } = string.Empty;

	/// <summary>실시간상한가</summary>
	public decimal dy_uplmtprice { get; set; }

	/// <summary>실시간하한가</summary>
	public decimal dy_dnlmtprice { get; set; }

	/// <summary>가격제한폭확대(0:미확대1:확대2:대상아님)</summary>
	public string updnstep_gubun { get; set; } = string.Empty;

	/// <summary>상한적용단계</summary>
	public string upstep { get; set; } = string.Empty;

	/// <summary>하한적용단계</summary>
	public string dnstep { get; set; } = string.Empty;

	/// <summary>3단계상한가</summary>
	public decimal uplmtprice_3rd { get; set; }

	/// <summary>3단계하한가</summary>
	public decimal dnlmtprice_3rd { get; set; }

	/// <summary>예상체결수량</summary>
	public long expct_ccls_q { get; set; }
}