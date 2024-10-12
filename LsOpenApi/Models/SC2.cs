namespace LsOpenApi.Models;
/// <summary>
/// 주식주문정정
/// </summary>
internal class SC2
{
	public SC2InBlock SC2InBlock { get; set; } = new();
	public SC2OutBlock SC2OutBlock { get; set; } = new();
}

/// <summary>
/// 주식주문정정 - InBlock
/// </summary>
internal class SC2InBlock { }

/// <summary>
/// 주식주문정정 - OutBlock
/// </summary>
internal class SC2OutBlock : OrderOutBlockBase
{
	/// <summary>주문체결유형코드</summary>
	public string ordxctptncode { get; set; } = string.Empty;

	/// <summary>주문시장코드</summary>
	public string ordmktcode { get; set; } = string.Empty;

	/// <summary>주문유형코드</summary>
	public string ordptncode { get; set; } = string.Empty;

	/// <summary>관리지점번호</summary>
	public string mgmtbrnno { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string acntnm { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string Isuno { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string Isunm { get; set; } = string.Empty;

	/// <summary>체결번호</summary>
	public string execno { get; set; } = string.Empty;

	/// <summary>주문가격</summary>
	public string ordprc { get; set; } = string.Empty;

	/// <summary>체결수량</summary>
	public string execqty { get; set; } = string.Empty;

	/// <summary>체결가격</summary>
	public string execprc { get; set; } = string.Empty;

	/// <summary>정정확인수량</summary>
	public string mdfycnfqty { get; set; } = string.Empty;

	/// <summary>정정확인가격</summary>
	public string mdfycnfprc { get; set; } = string.Empty;

	/// <summary>취소확인수량</summary>
	public string canccnfqty { get; set; } = string.Empty;

	/// <summary>거부수량</summary>
	public string rjtqty { get; set; } = string.Empty;

	/// <summary>주문처리유형코드</summary>
	public string ordtrxptncode { get; set; } = string.Empty;

	/// <summary>복수주문일련번호</summary>
	public string mtiordseqno { get; set; } = string.Empty;

	/// <summary>주문조건</summary>
	public string ordcndi { get; set; } = string.Empty;

	/// <summary>호가유형코드</summary>
	public string ordprcptncode { get; set; } = string.Empty;

	/// <summary>비저축체결수량</summary>
	public string nsavtrdqty { get; set; } = string.Empty;

	/// <summary>단축종목번호</summary>
	public string shtnIsuno { get; set; } = string.Empty;

	/// <summary>운용지시번호</summary>
	public string opdrtnno { get; set; } = string.Empty;

	/// <summary>반대매매주문구분</summary>
	public string cvrgordtp { get; set; } = string.Empty;

	/// <summary>미체결수량(주문)</summary>
	public string unercqty { get; set; } = string.Empty;

	/// <summary>원주문미체결수량</summary>
	public string orgordunercqty { get; set; } = string.Empty;

	/// <summary>원주문정정수량</summary>
	public string orgordmdfyqty { get; set; } = string.Empty;

	/// <summary>원주문취소수량</summary>
	public string orgordcancqty { get; set; } = string.Empty;

	/// <summary>주문평균체결가격</summary>
	public string ordavrexecprc { get; set; } = string.Empty;

	/// <summary>표준종목번호</summary>
	public string stdIsuno { get; set; } = string.Empty;

	/// <summary>전표준종목번호</summary>
	public string bfstdIsuno { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string bnstp { get; set; } = string.Empty;

	/// <summary>주문거래유형코드</summary>
	public string ordtrdptncode { get; set; } = string.Empty;

	/// <summary>신용거래코드</summary>
	public string mgntrncode { get; set; } = string.Empty;

	/// <summary>수수료합산코드</summary>
	public string adduptp { get; set; } = string.Empty;

	/// <summary>통신매체코드</summary>
	public string commdacode { get; set; } = string.Empty;

	/// <summary>회원/비회원사번호</summary>
	public string mbrnmbrno { get; set; } = string.Empty;

	/// <summary>주문계좌번호</summary>
	public string ordacntno { get; set; } = string.Empty;

	/// <summary>집계지점번호</summary>
	public string agrgbrnno { get; set; } = string.Empty;

	/// <summary>관리사원번호</summary>
	public string mgempno { get; set; } = string.Empty;

	/// <summary>선물연계지점번호</summary>
	public string futsLnkbrnno { get; set; } = string.Empty;

	/// <summary>선물연계계좌번호</summary>
	public string futsLnkacntno { get; set; } = string.Empty;

	/// <summary>선물시장구분</summary>
	public string futsmkttp { get; set; } = string.Empty;

	/// <summary>등록시장코드</summary>
	public string regmktcode { get; set; } = string.Empty;

	/// <summary>현금증거금률</summary>
	public string mnymgnrat { get; set; } = string.Empty;

	/// <summary>대용증거금률</summary>
	public string substmgnrat { get; set; } = string.Empty;

	/// <summary>현금체결금액</summary>
	public string mnyexecamt { get; set; } = string.Empty;

	/// <summary>대용체결금액</summary>
	public string ubstexecamt { get; set; } = string.Empty;

	/// <summary>수수료체결금액</summary>
	public string cmsnamtexecamt { get; set; } = string.Empty;

	/// <summary>신용담보체결금액</summary>
	public string crdtpldgexecamt { get; set; } = string.Empty;

	/// <summary>신용체결금액</summary>
	public string crdtexecamt { get; set; } = string.Empty;

	/// <summary>전일재사용체결금액</summary>
	public string prdayruseexecval { get; set; } = string.Empty;

	/// <summary>금일재사용체결금액</summary>
	public string crdayruseexecval { get; set; } = string.Empty;

	/// <summary>실물체결수량</summary>
	public string spotexecqty { get; set; } = string.Empty;

	/// <summary>공매도체결수량</summary>
	public string stslexecqty { get; set; } = string.Empty;

	/// <summary>전략코드</summary>
	public string strtgcode { get; set; } = string.Empty;

	/// <summary>그룹Id</summary>
	public string grpId { get; set; } = string.Empty;

	/// <summary>포트폴리오번호</summary>
	public string ptflno { get; set; } = string.Empty;

	/// <summary>바스켓번호</summary>
	public string bskno { get; set; } = string.Empty;

	/// <summary>주문자Id</summary>
	public string orduserId { get; set; } = string.Empty;

	/// <summary>차입관리여부</summary>
	public string brwmgmtYn { get; set; } = string.Empty;

	/// <summary>외국인고유번호</summary>
	public string frgrunqno { get; set; } = string.Empty;

	/// <summary>거래세징수구분</summary>
	public string trtzxLevytp { get; set; } = string.Empty;

	/// <summary>유동성공급자구분</summary>
	public string lptp { get; set; } = string.Empty;

	/// <summary>체결시각</summary>
	public string exectime { get; set; } = string.Empty;

	/// <summary>거래소수신체결시각</summary>
	public string rcptexectime { get; set; } = string.Empty;

	/// <summary>잔여대출금액</summary>
	public string rmndLoanamt { get; set; } = string.Empty;

	/// <summary>매입금액</summary>
	public string pchsant { get; set; } = string.Empty;
}

/// <summary>
/// 주식주문취소
/// </summary>
internal class SC3 { }

/// <summary>
/// 주식주문거부
/// </summary>
internal class SC4 { }