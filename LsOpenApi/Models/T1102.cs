using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식현재가(시세)조회(t1102)
/// </summary>
internal class T1102 : LsResponseCore
{
	[JsonPropertyName("t1102InBlock")]
	public T1102InBlock T1102InBlock { get; set; } = new();
	[JsonPropertyName("t1102OutBlock")]
	public T1102OutBlock T1102OutBlock { get; set; } = new();
}

/// <summary>
/// 주식현재가(시세)조회(t1102) - InBlock
/// </summary>
internal class T1102InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>거래소구분코드</summary>
	[JsonPropertyName("exchgubun")]
	public string Exchgubun { get; set; } = "K";
}

/// <summary>
/// 주식현재가(시세)조회(t1102) - OutBlock
/// </summary>
internal class T1102OutBlock
{
	/// <summary>한글명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>전일대비구분(1.상한, 2.상승, 3.보합, 4.하한, 5.하락)</summary>
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

	/// <summary>기준가(평가가격)</summary>
	[JsonPropertyName("recprice")]
	public long Recprice { get; set; }

	/// <summary>가중평균</summary>
	[JsonPropertyName("avg")]
	public long Avg { get; set; }

	/// <summary>상한가(최고호가가격)</summary>
	[JsonPropertyName("uplmtprice")]
	public long UpLmtPrice { get; set; }

	/// <summary>하한가(최저호가가격)</summary>
	[JsonPropertyName("dnlmtprice")]
	public long DnLmtPrice { get; set; }

	/// <summary>전일거래량</summary>
	[JsonPropertyName("jnilvolume")]
	public long Jnilvolume { get; set; }

	/// <summary>거래량차</summary>
	[JsonPropertyName("volumediff")]
	public long Volumediff { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>시가시간</summary>
	[JsonPropertyName("opentime")]
	public string Opentime { get; set; } = string.Empty;

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>고가시간</summary>
	[JsonPropertyName("hightime")]
	public string Hightime { get; set; } = string.Empty;

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>저가시간</summary>
	[JsonPropertyName("lowtime")]
	public string Lowtime { get; set; } = string.Empty;

	/// <summary>52최고가</summary>
	[JsonPropertyName("high52w")]
	public long High52w { get; set; }

	/// <summary>52최고가일</summary>
	[JsonPropertyName("high52wdate")]
	public string High52wdate { get; set; } = string.Empty;

	/// <summary>52최저가</summary>
	[JsonPropertyName("low52w")]
	public long Low52w { get; set; }

	/// <summary>52최저가일</summary>
	[JsonPropertyName("low52wdate")]
	public string Low52wdate { get; set; } = string.Empty;

	/// <summary>소진율</summary>
	[JsonPropertyName("exhratio")]
	public decimal Exhratio { get; set; }

	/// <summary>PER</summary>
	[JsonPropertyName("per")]
	public decimal Per { get; set; }

	/// <summary>PBRX</summary>
	[JsonPropertyName("pbrx")]
	public decimal Pbrx { get; set; }

	/// <summary>상장주식수(천)</summary>
	[JsonPropertyName("listing")]
	public long Listing { get; set; }

	/// <summary>증거금율</summary>
	[JsonPropertyName("jkrate")]
	public long Jkrate { get; set; }

	/// <summary>수량단위</summary>
	[JsonPropertyName("memedan")]
	public string Memedan { get; set; } = string.Empty;

	/// <summary>매도증권사코드1</summary>
	[JsonPropertyName("offernocd1")]
	public string Offernocd1 { get; set; } = string.Empty;

	/// <summary>매수증권사코드1</summary>
	[JsonPropertyName("bidnocd1")]
	public string Bidnocd1 { get; set; } = string.Empty;

	/// <summary>매도증권사명1</summary>
	[JsonPropertyName("offerno1")]
	public string Offerno1 { get; set; } = string.Empty;

	/// <summary>매수증권사명1</summary>
	[JsonPropertyName("bidno1")]
	public string Bidno1 { get; set; } = string.Empty;

	/// <summary>총매도수량1</summary>
	[JsonPropertyName("dvol1")]
	public long Dvol1 { get; set; }

	/// <summary>총매수수량1</summary>
	[JsonPropertyName("svol1")]
	public long Svol1 { get; set; }

	/// <summary>매도증감1</summary>
	[JsonPropertyName("dcha1")]
	public long Dcha1 { get; set; }

	/// <summary>매수증감1</summary>
	[JsonPropertyName("scha1")]
	public long Scha1 { get; set; }

	/// <summary>매도비율1</summary>
	[JsonPropertyName("ddiff1")]
	public decimal Ddiff1 { get; set; }

	/// <summary>매수비율1</summary>
	[JsonPropertyName("sdiff1")]
	public decimal Sdiff1 { get; set; }

	/// <summary>매도증권사코드2</summary>
	[JsonPropertyName("offernocd2")]
	public string Offernocd2 { get; set; } = string.Empty;

	/// <summary>매수증권사코드2</summary>
	[JsonPropertyName("bidnocd2")]
	public string Bidnocd2 { get; set; } = string.Empty;

	/// <summary>매도증권사명2</summary>
	[JsonPropertyName("offerno2")]
	public string Offerno2 { get; set; } = string.Empty;

	/// <summary>매수증권사명2</summary>
	[JsonPropertyName("bidno2")]
	public string Bidno2 { get; set; } = string.Empty;

	/// <summary>총매도수량2</summary>
	[JsonPropertyName("dvol2")]
	public long Dvol2 { get; set; }

	/// <summary>총매수수량2</summary>
	[JsonPropertyName("svol2")]
	public long Svol2 { get; set; }

	/// <summary>매도증감2</summary>
	[JsonPropertyName("dcha2")]
	public long Dcha2 { get; set; }

	/// <summary>매수증감2</summary>
	[JsonPropertyName("scha2")]
	public long Scha2 { get; set; }

	/// <summary>매도비율2</summary>
	[JsonPropertyName("ddiff2")]
	public decimal Ddiff2 { get; set; }

	/// <summary>매수비율2</summary>
	[JsonPropertyName("sdiff2")]
	public decimal Sdiff2 { get; set; }

	/// <summary>매도증권사코드3</summary>
	[JsonPropertyName("offernocd3")]
	public string Offernocd3 { get; set; } = string.Empty;

	/// <summary>매수증권사코드3</summary>
	[JsonPropertyName("bidnocd3")]
	public string Bidnocd3 { get; set; } = string.Empty;

	/// <summary>매도증권사명3</summary>
	[JsonPropertyName("offerno3")]
	public string Offerno3 { get; set; } = string.Empty;

	/// <summary>매수증권사명3</summary>
	[JsonPropertyName("bidno3")]
	public string Bidno3 { get; set; } = string.Empty;

	/// <summary>총매도수량3</summary>
	[JsonPropertyName("dvol3")]
	public long Dvol3 { get; set; }

	/// <summary>총매수수량3</summary>
	[JsonPropertyName("svol3")]
	public long Svol3 { get; set; }

	/// <summary>매도증감3</summary>
	[JsonPropertyName("dcha3")]
	public long Dcha3 { get; set; }

	/// <summary>매수증감3</summary>
	[JsonPropertyName("scha3")]
	public long Scha3 { get; set; }

	/// <summary>매도비율3</summary>
	[JsonPropertyName("ddiff3")]
	public decimal Ddiff3 { get; set; }

	/// <summary>매수비율3</summary>
	[JsonPropertyName("sdiff3")]
	public decimal Sdiff3 { get; set; }

	/// <summary>매도증권사코드4</summary>
	[JsonPropertyName("offernocd4")]
	public string Offernocd4 { get; set; } = string.Empty;

	/// <summary>매수증권사코드4</summary>
	[JsonPropertyName("bidnocd4")]
	public string Bidnocd4 { get; set; } = string.Empty;

	/// <summary>매도증권사명4</summary>
	[JsonPropertyName("offerno4")]
	public string Offerno4 { get; set; } = string.Empty;

	/// <summary>매수증권사명4</summary>
	[JsonPropertyName("bidno4")]
	public string Bidno4 { get; set; } = string.Empty;

	/// <summary>총매도수량4</summary>
	[JsonPropertyName("dvol4")]
	public long Dvol4 { get; set; }

	/// <summary>총매수수량4</summary>
	[JsonPropertyName("svol4")]
	public long Svol4 { get; set; }

	/// <summary>매도증감4</summary>
	[JsonPropertyName("dcha4")]
	public long Dcha4 { get; set; }

	/// <summary>매수증감4</summary>
	[JsonPropertyName("scha4")]
	public long Scha4 { get; set; }

	/// <summary>매도비율4</summary>
	[JsonPropertyName("ddiff4")]
	public decimal Ddiff4 { get; set; }

	/// <summary>매수비율4</summary>
	[JsonPropertyName("sdiff4")]
	public decimal Sdiff4 { get; set; }

	/// <summary>매도증권사코드5</summary>
	[JsonPropertyName("offernocd5")]
	public string Offernocd5 { get; set; } = string.Empty;

	/// <summary>매수증권사코드5</summary>
	[JsonPropertyName("bidnocd5")]
	public string Bidnocd5 { get; set; } = string.Empty;

	/// <summary>매도증권사명5</summary>
	[JsonPropertyName("offerno5")]
	public string Offerno5 { get; set; } = string.Empty;

	/// <summary>매수증권사명5</summary>
	[JsonPropertyName("bidno5")]
	public string Bidno5 { get; set; } = string.Empty;

	/// <summary>총매도수량5</summary>
	[JsonPropertyName("dvol5")]
	public long Dvol5 { get; set; }

	/// <summary>총매수수량5</summary>
	[JsonPropertyName("svol5")]
	public long Svol5 { get; set; }

	/// <summary>매도증감5</summary>
	[JsonPropertyName("dcha5")]
	public long Dcha5 { get; set; }

	/// <summary>매수증감5</summary>
	[JsonPropertyName("scha5")]
	public long Scha5 { get; set; }

	/// <summary>매도비율5</summary>
	[JsonPropertyName("ddiff5")]
	public decimal Ddiff5 { get; set; }

	/// <summary>매수비율5</summary>
	[JsonPropertyName("sdiff5")]
	public decimal Sdiff5 { get; set; }

	/// <summary>외국계매도합계수량</summary>
	[JsonPropertyName("fwdvl")]
	public long Fwdvl { get; set; }

	/// <summary>외국계매도직전대비</summary>
	[JsonPropertyName("ftradmdcha")]
	public long Ftradmdcha { get; set; }

	/// <summary>외국계매도비율</summary>
	[JsonPropertyName("ftradmddiff")]
	public decimal Ftradmddiff { get; set; }

	/// <summary>외국계매수합계수량</summary>
	[JsonPropertyName("fwsvl")]
	public long Fwsvl { get; set; }

	/// <summary>외국계매수직전대비</summary>
	[JsonPropertyName("ftradmscha")]
	public long Ftradmscha { get; set; }

	/// <summary>외국계매수비율</summary>
	[JsonPropertyName("ftradmsdiff")]
	public decimal Ftradmsdiff { get; set; }

	/// <summary>회전율</summary>
	[JsonPropertyName("vol")]
	public decimal Vol { get; set; }

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>누적거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>전일동시간거래량</summary>
	[JsonPropertyName("jvolume")]
	public long Jvolume { get; set; }

	/// <summary>연중최고가</summary>
	[JsonPropertyName("highyear")]
	public long Highyear { get; set; }

	/// <summary>연중최고일자</summary>
	[JsonPropertyName("highyeardate")]
	public string Highyeardate { get; set; } = string.Empty;

	/// <summary>연중최저가</summary>
	[JsonPropertyName("lowyear")]
	public long Lowyear { get; set; }

	/// <summary>연중최저일자</summary>
	[JsonPropertyName("lowyeardate")]
	public string Lowyeardate { get; set; } = string.Empty;

	/// <summary>목표가</summary>
	[JsonPropertyName("target")]
	public long Target { get; set; }

	/// <summary>자본금</summary>
	[JsonPropertyName("capital")]
	public long Capital { get; set; }

	/// <summary>유동주식수</summary>
	[JsonPropertyName("abscnt")]
	public long Abscnt { get; set; }

	/// <summary>액면가</summary>
	[JsonPropertyName("parprice")]
	public long Parprice { get; set; }

	/// <summary>결산월</summary>
	[JsonPropertyName("gsmm")]
	public string Gsmm { get; set; } = string.Empty;

	/// <summary>대용가</summary>
	[JsonPropertyName("subprice")]
	public long Subprice { get; set; }

	/// <summary>시가총액</summary>
	[JsonPropertyName("total")]
	public long Total { get; set; }

	/// <summary>상장일</summary>
	[JsonPropertyName("listdate")]
	public string Listdate { get; set; } = string.Empty;

	/// <summary>전분기명</summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>전분기매출액</summary>
	[JsonPropertyName("bfsales")]
	public long Bfsales { get; set; }

	/// <summary>전분기영업이익</summary>
	[JsonPropertyName("bfoperatingincome")]
	public long Bfoperatingincome { get; set; }

	/// <summary>전분기경상이익</summary>
	[JsonPropertyName("bfordinaryincome")]
	public long Bfordinaryincome { get; set; }

	/// <summary>전분기순이익</summary>
	[JsonPropertyName("bfnetincome")]
	public long Bfnetincome { get; set; }

	/// <summary>전분기EPS</summary>
	[JsonPropertyName("bfeps")]
	public decimal Bfeps { get; set; }

	/// <summary>전전분기명</summary>
	[JsonPropertyName("name2")]
	public string Name2 { get; set; } = string.Empty;

	/// <summary>전전분기매출액</summary>
	[JsonPropertyName("bfsales2")]
	public long Bfsales2 { get; set; }

	/// <summary>전전분기영업이익</summary>
	[JsonPropertyName("bfoperatingincome2")]
	public long Bfoperatingincome2 { get; set; }

	/// <summary>전전분기경상이익</summary>
	[JsonPropertyName("bfordinaryincome2")]
	public long Bfordinaryincome2 { get; set; }

	/// <summary>전전분기순이익</summary>
	[JsonPropertyName("bfnetincome2")]
	public long Bfnetincome2 { get; set; }

	/// <summary>전전분기EPS</summary>
	[JsonPropertyName("bfeps2")]
	public decimal Bfeps2 { get; set; }

	/// <summary>전년대비매출액</summary>
	[JsonPropertyName("salert")]
	public decimal Salert { get; set; }

	/// <summary>전년대비영업이익</summary>
	[JsonPropertyName("opert")]
	public decimal Opert { get; set; }

	/// <summary>전년대비경상이익</summary>
	[JsonPropertyName("ordrt")]
	public decimal Ordrt { get; set; }

	/// <summary>전년대비순이익</summary>
	[JsonPropertyName("netrt")]
	public decimal Netrt { get; set; }

	/// <summary>전년대비EPS</summary>
	[JsonPropertyName("epsrt")]
	public decimal Epsrt { get; set; }

	/// <summary>락구분</summary>
	[JsonPropertyName("info1")]
	public string Info1 { get; set; } = string.Empty;

	/// <summary>관리/급등구분</summary>
	[JsonPropertyName("info2")]
	public string Info2 { get; set; } = string.Empty;

	/// <summary>정지/연장구분</summary>
	[JsonPropertyName("info3")]
	public string Info3 { get; set; } = string.Empty;

	/// <summary>투자/불성실구분</summary>
	[JsonPropertyName("info4")]
	public string Info4 { get; set; } = string.Empty;

	/// <summary>장구분</summary>
	[JsonPropertyName("janginfo")]
	public string Janginfo { get; set; } = string.Empty;

	/// <summary>T.PER</summary>
	[JsonPropertyName("t_per")]
	public decimal TPer { get; set; }

	/// <summary>통화ISO코드</summary>
	[JsonPropertyName("tonghwa")]
	public string Tonghwa { get; set; } = string.Empty;

	/// <summary>총매도대금1</summary>
	[JsonPropertyName("dval1")]
	public long Dval1 { get; set; }

	/// <summary>총매수대금1</summary>
	[JsonPropertyName("sval1")]
	public long Sval1 { get; set; }

	/// <summary>총매도대금2</summary>
	[JsonPropertyName("dval2")]
	public long Dval2 { get; set; }

	/// <summary>총매수대금2</summary>
	[JsonPropertyName("sval2")]
	public long Sval2 { get; set; }

	/// <summary>총매도대금3</summary>
	[JsonPropertyName("dval3")]
	public long Dval3 { get; set; }

	/// <summary>총매수대금3</summary>
	[JsonPropertyName("sval3")]
	public long Sval3 { get; set; }

	/// <summary>총매도대금4</summary>
	[JsonPropertyName("dval4")]
	public long Dval4 { get; set; }

	/// <summary>총매수대금4</summary>
	[JsonPropertyName("sval4")]
	public long Sval4 { get; set; }

	/// <summary>총매도대금5</summary>
	[JsonPropertyName("dval5")]
	public long Dval5 { get; set; }

	/// <summary>총매수대금5</summary>
	[JsonPropertyName("sval5")]
	public long Sval5 { get; set; }

	/// <summary>총매도평단가1</summary>
	[JsonPropertyName("davg1")]
	public long Davg1 { get; set; }

	/// <summary>총매수평단가1</summary>
	[JsonPropertyName("savg1")]
	public long Savg1 { get; set; }

	/// <summary>총매도평단가2</summary>
	[JsonPropertyName("davg2")]
	public long Davg2 { get; set; }

	/// <summary>총매수평단가2</summary>
	[JsonPropertyName("savg2")]
	public long Savg2 { get; set; }

	/// <summary>총매도평단가3</summary>
	[JsonPropertyName("davg3")]
	public long Davg3 { get; set; }

	/// <summary>총매수평단가3</summary>
	[JsonPropertyName("savg3")]
	public long Savg3 { get; set; }

	/// <summary>총매도평단가4</summary>
	[JsonPropertyName("davg4")]
	public long Davg4 { get; set; }

	/// <summary>총매수평단가4</summary>
	[JsonPropertyName("savg4")]
	public long Savg4 { get; set; }

	/// <summary>총매도평단가5</summary>
	[JsonPropertyName("davg5")]
	public long Davg5 { get; set; }

	/// <summary>총매수평단가5</summary>
	[JsonPropertyName("savg5")]
	public long Savg5 { get; set; }

	/// <summary>외국계매도대금</summary>
	[JsonPropertyName("ftradmdval")]
	public long Ftradmdval { get; set; }

	/// <summary>외국계매수대금</summary>
	[JsonPropertyName("ftradmsval")]
	public long Ftradmsval { get; set; }

	/// <summary>외국계매도평단가</summary>
	[JsonPropertyName("ftradmdvag")]
	public long Ftradmdvag { get; set; }

	/// <summary>외국계매수평단가</summary>
	[JsonPropertyName("ftradmsvag")]
	public long Ftradmsvag { get; set; }

	/// <summary>투자주의환기</summary>
	[JsonPropertyName("info5")]
	public string Info5 { get; set; } = string.Empty;

	/// <summary>기업인수목적회사여부</summary>
	[JsonPropertyName("spac_gubun")]
	public string SpacGubun { get; set; } = string.Empty;

	/// <summary>발행가격</summary>
	[JsonPropertyName("issueprice")]
	public long Issueprice { get; set; }

	/// <summary>배분적용구분코드(1:배분발생2:배분해제그외:미발생)</summary>
	[JsonPropertyName("alloc_gubun")]
	public string AllocGubun { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	[JsonPropertyName("alloc_text")]
	public string AllocText { get; set; } = string.Empty;

	/// <summary>단기과열/VI발동</summary>
	[JsonPropertyName("shterm_text")]
	public string ShtermText { get; set; } = string.Empty;

	/// <summary>정적VI상한가</summary>
	[JsonPropertyName("svi_uplmtprice")]
	public long SviUplmtprice { get; set; }

	/// <summary>정적VI하한가</summary>
	[JsonPropertyName("svi_dnlmtprice")]
	public long SviDnlmtprice { get; set; }

	/// <summary>저유동성종목여부</summary>
	[JsonPropertyName("low_lqdt_gu")]
	public string LowLqdtGu { get; set; } = string.Empty;

	/// <summary>이상급등종목여부</summary>
	[JsonPropertyName("abnormal_rise_gu")]
	public string AbnormalRiseGu { get; set; } = string.Empty;

	/// <summary>대차불가표시</summary>
	[JsonPropertyName("lend_text")]
	public string LendText { get; set; } = string.Empty;

	/// <summary>ETF/ETN투자유의</summary>
	[JsonPropertyName("ty_text")]
	public string TyText { get; set; } = string.Empty;

	/// <summary>NXT장구분</summary>
	[JsonPropertyName("nxt_janginfo")]
	public string NxtJanginfo { get; set; } = string.Empty;

	/// <summary>NXT단기과열/VI발동</summary>
	[JsonPropertyName("nxt_shterm_text")]
	public string NxtShtermText { get; set; } = string.Empty;

	/// <summary>NXT정적VI상한가</summary>
	[JsonPropertyName("nxt_svi_uplmtprice")]
	public long NxtSviUplmtprice { get; set; }

	/// <summary>NXT정적VI하한가</summary>
	[JsonPropertyName("nxt_svi_dnlmtprice")]
	public long NxtSviDnlmtprice { get; set; }

	/// <summary>거래소별단축코드</summary>
	[JsonPropertyName("ex_shcode")]
	public string ExShcode { get; set; } = string.Empty;
}