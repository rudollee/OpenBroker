namespace LsOpenApi.Models;
/// <summary>
/// 주식선물현재가조회(API용)(t8402)
/// </summary>
internal class t8402 : LsResponseCore
{
	public t8402InBlock t8402InBlock { get; set; } = new();
	public t8402OutBlock t8402OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물현재가조회(API용)(t8402) - InBlock
/// </summary>
internal class t8402InBlock
{
	/// <summary>단축코드</summary>
	public string focode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물현재가조회(API용)(t8402) - OutBlock
/// </summary>
internal class t8402OutBlock
{
	/// <summary>한글명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>전일종가</summary>
	public long jnilclose { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>거래량</summary>
	public long volume { get; set; }

	/// <summary>거래량전일동시간비율</summary>
	public decimal stimeqrt { get; set; }

	/// <summary>거래대금</summary>
	public long value { get; set; }

	/// <summary>미결제량</summary>
	public long mgjv { get; set; }

	/// <summary>미결제증감</summary>
	public long mgjvdiff { get; set; }

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>상한가</summary>
	public long uplmtprice { get; set; }

	/// <summary>하한가</summary>
	public long dnlmtprice { get; set; }

	/// <summary>52최고가</summary>
	public long high52w { get; set; }

	/// <summary>52최저가</summary>
	public long low52w { get; set; }

	/// <summary>베이시스</summary>
	public decimal basis { get; set; }

	/// <summary>기준가</summary>
	public long recprice { get; set; }

	/// <summary>이론가</summary>
	public long theoryprice { get; set; }

	/// <summary>괴리율</summary>
	public decimal glyl { get; set; }

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
	public long listhprice { get; set; }

	/// <summary>상장최저가</summary>
	public long listlprice { get; set; }

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
	public long gmprice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	public string gmsign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	public long gmchange { get; set; }

	/// <summary>근월물등락율</summary>
	public decimal gmdiff { get; set; }

	/// <summary>이론가</summary>
	public long theorypriceg { get; set; }

	/// <summary>역사적변동성</summary>
	public decimal histimpv { get; set; }

	/// <summary>내재변동성</summary>
	public decimal impv { get; set; }

	/// <summary>시장BASIS</summary>
	public long sbasis { get; set; }

	/// <summary>이론BASIS</summary>
	public long ibasis { get; set; }

	/// <summary>근월물종목코드</summary>
	public string gmfutcode { get; set; } = string.Empty;

	/// <summary>행사가</summary>
	public long actprice { get; set; }

	/// <summary>기초자산단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>기초자산한글명</summary>
	public string basehname { get; set; } = string.Empty;

	/// <summary>기초자산현재가</summary>
	public long baseprice { get; set; }

	/// <summary>기초자산현재가대비구분</summary>
	public string basesign { get; set; } = string.Empty;

	/// <summary>기초자산현재가전일대비</summary>
	public long basechange { get; set; }

	/// <summary>기초자산등락률</summary>
	public decimal basediff { get; set; }

	/// <summary>기초자산거래량</summary>
	public long basevol { get; set; }

	/// <summary>기초자산전일거래량</summary>
	public long baseprevol { get; set; }

	/// <summary>기초자산매수호가</summary>
	public long basebidprc { get; set; }

	/// <summary>기초자산매도호가</summary>
	public long baseaskprc { get; set; }

	/// <summary>기초자산외국계회원사순매수</summary>
	public long basefornetbid { get; set; }

	/// <summary>상품군</summary>
	public string prodgrp { get; set; } = string.Empty;

	/// <summary>승수</summary>
	public decimal mulcnt { get; set; }

	/// <summary>단일가호가여부</summary>
	public string danhochk { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	public long yeprice { get; set; }

	/// <summary>예상체결가전일종가대비구분</summary>
	public string jnilysign { get; set; } = string.Empty;

	/// <summary>예상체결가전일종가대비</summary>
	public long jnilychange { get; set; }

	/// <summary>예상체결가전일종가등락율</summary>
	public decimal jnilydrate { get; set; }
}