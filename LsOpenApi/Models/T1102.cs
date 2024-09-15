namespace LsOpenApi.Models;
/// <summary>
/// 주식현재가(시세)조회(t1102)
/// </summary>
internal class t1102 : LsResponseCore
{
	public t1102OutBlock t1102OutBlock { get; set; } = new();
}

/// <summary>
/// 주식현재가(시세)조회(t1102) - InBlock
/// </summary>
internal class t1102InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식현재가(시세)조회(t1102) - OutBlock
/// </summary>
internal class t1102OutBlock
{
	/// <summary>한글명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>누적거래량</summary>
	public long volume { get; set; }

	/// <summary>기준가(평가가격)</summary>
	public long recprice { get; set; }

	/// <summary>가중평균</summary>
	public long avg { get; set; }

	/// <summary>상한가(최고호가가격)</summary>
	public long uplmtprice { get; set; }

	/// <summary>하한가(최저호가가격)</summary>
	public long dnlmtprice { get; set; }

	/// <summary>전일거래량</summary>
	public long jnilvolume { get; set; }

	/// <summary>거래량차</summary>
	public long volumediff { get; set; }

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>시가시간</summary>
	public string opentime { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>고가시간</summary>
	public string hightime { get; set; } = string.Empty;

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>저가시간</summary>
	public string lowtime { get; set; } = string.Empty;

	/// <summary>52최고가</summary>
	public long high52w { get; set; }

	/// <summary>52최고가일</summary>
	public string high52wdate { get; set; } = string.Empty;

	/// <summary>52최저가</summary>
	public long low52w { get; set; }

	/// <summary>52최저가일</summary>
	public string low52wdate { get; set; } = string.Empty;

	/// <summary>소진율</summary>
	public decimal exhratio { get; set; }

	/// <summary>PER</summary>
	public decimal per { get; set; }

	/// <summary>PBRX</summary>
	public decimal pbrx { get; set; }

	/// <summary>상장주식수(천)</summary>
	public long listing { get; set; }

	/// <summary>증거금율</summary>
	public long jkrate { get; set; }

	/// <summary>수량단위</summary>
	public string memedan { get; set; } = string.Empty;

	/// <summary>매도증권사코드1</summary>
	public string offernocd1 { get; set; } = string.Empty;

	/// <summary>매수증권사코드1</summary>
	public string bidnocd1 { get; set; } = string.Empty;

	/// <summary>매도증권사명1</summary>
	public string offerno1 { get; set; } = string.Empty;

	/// <summary>매수증권사명1</summary>
	public string bidno1 { get; set; } = string.Empty;

	/// <summary>총매도수량1</summary>
	public long dvol1 { get; set; }

	/// <summary>총매수수량1</summary>
	public long svol1 { get; set; }

	/// <summary>매도증감1</summary>
	public long dcha1 { get; set; }

	/// <summary>매수증감1</summary>
	public long scha1 { get; set; }

	/// <summary>매도비율1</summary>
	public decimal ddiff1 { get; set; }

	/// <summary>매수비율1</summary>
	public decimal sdiff1 { get; set; }

	/// <summary>매도증권사코드2</summary>
	public string offernocd2 { get; set; } = string.Empty;

	/// <summary>매수증권사코드2</summary>
	public string bidnocd2 { get; set; } = string.Empty;

	/// <summary>매도증권사명2</summary>
	public string offerno2 { get; set; } = string.Empty;

	/// <summary>매수증권사명2</summary>
	public string bidno2 { get; set; } = string.Empty;

	/// <summary>총매도수량2</summary>
	public long dvol2 { get; set; }

	/// <summary>총매수수량2</summary>
	public long svol2 { get; set; }

	/// <summary>매도증감2</summary>
	public long dcha2 { get; set; }

	/// <summary>매수증감2</summary>
	public long scha2 { get; set; }

	/// <summary>매도비율2</summary>
	public decimal ddiff2 { get; set; }

	/// <summary>매수비율2</summary>
	public decimal sdiff2 { get; set; }

	/// <summary>매도증권사코드3</summary>
	public string offernocd3 { get; set; } = string.Empty;

	/// <summary>매수증권사코드3</summary>
	public string bidnocd3 { get; set; } = string.Empty;

	/// <summary>매도증권사명3</summary>
	public string offerno3 { get; set; } = string.Empty;

	/// <summary>매수증권사명3</summary>
	public string bidno3 { get; set; } = string.Empty;

	/// <summary>총매도수량3</summary>
	public long dvol3 { get; set; }

	/// <summary>총매수수량3</summary>
	public long svol3 { get; set; }

	/// <summary>매도증감3</summary>
	public long dcha3 { get; set; }

	/// <summary>매수증감3</summary>
	public long scha3 { get; set; }

	/// <summary>매도비율3</summary>
	public decimal ddiff3 { get; set; }

	/// <summary>매수비율3</summary>
	public decimal sdiff3 { get; set; }

	/// <summary>매도증권사코드4</summary>
	public string offernocd4 { get; set; } = string.Empty;

	/// <summary>매수증권사코드4</summary>
	public string bidnocd4 { get; set; } = string.Empty;

	/// <summary>매도증권사명4</summary>
	public string offerno4 { get; set; } = string.Empty;

	/// <summary>매수증권사명4</summary>
	public string bidno4 { get; set; } = string.Empty;

	/// <summary>총매도수량4</summary>
	public long dvol4 { get; set; }

	/// <summary>총매수수량4</summary>
	public long svol4 { get; set; }

	/// <summary>매도증감4</summary>
	public long dcha4 { get; set; }

	/// <summary>매수증감4</summary>
	public long scha4 { get; set; }

	/// <summary>매도비율4</summary>
	public decimal ddiff4 { get; set; }

	/// <summary>매수비율4</summary>
	public decimal sdiff4 { get; set; }

	/// <summary>매도증권사코드5</summary>
	public string offernocd5 { get; set; } = string.Empty;

	/// <summary>매수증권사코드5</summary>
	public string bidnocd5 { get; set; } = string.Empty;

	/// <summary>매도증권사명5</summary>
	public string offerno5 { get; set; } = string.Empty;

	/// <summary>매수증권사명5</summary>
	public string bidno5 { get; set; } = string.Empty;

	/// <summary>총매도수량5</summary>
	public long dvol5 { get; set; }

	/// <summary>총매수수량5</summary>
	public long svol5 { get; set; }

	/// <summary>매도증감5</summary>
	public long dcha5 { get; set; }

	/// <summary>매수증감5</summary>
	public long scha5 { get; set; }

	/// <summary>매도비율5</summary>
	public decimal ddiff5 { get; set; }

	/// <summary>매수비율5</summary>
	public decimal sdiff5 { get; set; }

	/// <summary>외국계매도합계수량</summary>
	public long fwdvl { get; set; }

	/// <summary>외국계매도직전대비</summary>
	public long ftradmdcha { get; set; }

	/// <summary>외국계매도비율</summary>
	public decimal ftradmddiff { get; set; }

	/// <summary>외국계매수합계수량</summary>
	public long fwsvl { get; set; }

	/// <summary>외국계매수직전대비</summary>
	public long ftradmscha { get; set; }

	/// <summary>외국계매수비율</summary>
	public decimal ftradmsdiff { get; set; }

	/// <summary>회전율</summary>
	public decimal vol { get; set; }

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>누적거래대금</summary>
	public long value { get; set; }

	/// <summary>전일동시간거래량</summary>
	public long jvolume { get; set; }

	/// <summary>연중최고가</summary>
	public long highyear { get; set; }

	/// <summary>연중최고일자</summary>
	public string highyeardate { get; set; } = string.Empty;

	/// <summary>연중최저가</summary>
	public long lowyear { get; set; }

	/// <summary>연중최저일자</summary>
	public string lowyeardate { get; set; } = string.Empty;

	/// <summary>목표가</summary>
	public long target { get; set; }

	/// <summary>자본금</summary>
	public long capital { get; set; }

	/// <summary>유동주식수</summary>
	public long abscnt { get; set; }

	/// <summary>액면가</summary>
	public long parprice { get; set; }

	/// <summary>결산월</summary>
	public string gsmm { get; set; } = string.Empty;

	/// <summary>대용가</summary>
	public long subprice { get; set; }

	/// <summary>시가총액</summary>
	public long total { get; set; }

	/// <summary>상장일</summary>
	public string listdate { get; set; } = string.Empty;

	/// <summary>전분기명</summary>
	public string name { get; set; } = string.Empty;

	/// <summary>전분기매출액</summary>
	public long bfsales { get; set; }

	/// <summary>전분기영업이익</summary>
	public long bfoperatingincome { get; set; }

	/// <summary>전분기경상이익</summary>
	public long bfordinaryincome { get; set; }

	/// <summary>전분기순이익</summary>
	public long bfnetincome { get; set; }

	/// <summary>전분기EPS</summary>
	public decimal bfeps { get; set; }

	/// <summary>전전분기명</summary>
	public string name2 { get; set; } = string.Empty;

	/// <summary>전전분기매출액</summary>
	public long bfsales2 { get; set; }

	/// <summary>전전분기영업이익</summary>
	public long bfoperatingincome2 { get; set; }

	/// <summary>전전분기경상이익</summary>
	public long bfordinaryincome2 { get; set; }

	/// <summary>전전분기순이익</summary>
	public long bfnetincome2 { get; set; }

	/// <summary>전전분기EPS</summary>
	public decimal bfeps2 { get; set; }

	/// <summary>전년대비매출액</summary>
	public decimal salert { get; set; }

	/// <summary>전년대비영업이익</summary>
	public decimal opert { get; set; }

	/// <summary>전년대비경상이익</summary>
	public decimal ordrt { get; set; }

	/// <summary>전년대비순이익</summary>
	public decimal netrt { get; set; }

	/// <summary>전년대비EPS</summary>
	public decimal epsrt { get; set; }

	/// <summary>락구분</summary>
	public string info1 { get; set; } = string.Empty;

	/// <summary>관리/급등구분</summary>
	public string info2 { get; set; } = string.Empty;

	/// <summary>정지/연장구분</summary>
	public string info3 { get; set; } = string.Empty;

	/// <summary>투자/불성실구분</summary>
	public string info4 { get; set; } = string.Empty;

	/// <summary>장구분</summary>
	public string janginfo { get; set; } = string.Empty;

	/// <summary>T.PER</summary>
	public decimal t_per { get; set; }

	/// <summary>통화ISO코드</summary>
	public string tonghwa { get; set; } = string.Empty;

	/// <summary>총매도대금1</summary>
	public long dval1 { get; set; }

	/// <summary>총매수대금1</summary>
	public long sval1 { get; set; }

	/// <summary>총매도대금2</summary>
	public long dval2 { get; set; }

	/// <summary>총매수대금2</summary>
	public long sval2 { get; set; }

	/// <summary>총매도대금3</summary>
	public long dval3 { get; set; }

	/// <summary>총매수대금3</summary>
	public long sval3 { get; set; }

	/// <summary>총매도대금4</summary>
	public long dval4 { get; set; }

	/// <summary>총매수대금4</summary>
	public long sval4 { get; set; }

	/// <summary>총매도대금5</summary>
	public long dval5 { get; set; }

	/// <summary>총매수대금5</summary>
	public long sval5 { get; set; }

	/// <summary>총매도평단가1</summary>
	public long davg1 { get; set; }

	/// <summary>총매수평단가1</summary>
	public long savg1 { get; set; }

	/// <summary>총매도평단가2</summary>
	public long davg2 { get; set; }

	/// <summary>총매수평단가2</summary>
	public long savg2 { get; set; }

	/// <summary>총매도평단가3</summary>
	public long davg3 { get; set; }

	/// <summary>총매수평단가3</summary>
	public long savg3 { get; set; }

	/// <summary>총매도평단가4</summary>
	public long davg4 { get; set; }

	/// <summary>총매수평단가4</summary>
	public long savg4 { get; set; }

	/// <summary>총매도평단가5</summary>
	public long davg5 { get; set; }

	/// <summary>총매수평단가5</summary>
	public long savg5 { get; set; }

	/// <summary>외국계매도대금</summary>
	public long ftradmdval { get; set; }

	/// <summary>외국계매수대금</summary>
	public long ftradmsval { get; set; }

	/// <summary>외국계매도평단가</summary>
	public long ftradmdvag { get; set; }

	/// <summary>외국계매수평단가</summary>
	public long ftradmsvag { get; set; }

	/// <summary>투자주의환기</summary>
	public string info5 { get; set; } = string.Empty;

	/// <summary>기업인수목적회사여부</summary>
	public string spac_gubun { get; set; } = string.Empty;

	/// <summary>발행가격</summary>
	public long issueprice { get; set; }

	/// <summary>배분적용구분코드(1:배분발생2:배분해제그외:미발생)</summary>
	public string alloc_gubun { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	public string alloc_text { get; set; } = string.Empty;

	/// <summary>단기과열/VI발동</summary>
	public string shterm_text { get; set; } = string.Empty;

	/// <summary>정적VI상한가</summary>
	public long svi_uplmtprice { get; set; }

	/// <summary>정적VI하한가</summary>
	public long svi_dnlmtprice { get; set; }

	/// <summary>저유동성종목여부</summary>
	public string low_lqdt_gu { get; set; } = string.Empty;

	/// <summary>이상급등종목여부</summary>
	public string abnormal_rise_gu { get; set; } = string.Empty;

	/// <summary>대차불가표시</summary>
	public string lend_text { get; set; } = string.Empty;

	/// <summary>ETF/ETN투자유의</summary>
	public string ty_text { get; set; } = string.Empty;
}