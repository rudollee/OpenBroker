using System.Collections.Generic;

namespace LsOpenApi.Models;
/// <summary>
/// 주식주문체결
/// </summary>
internal class SC1
{
	public SC1InBlock InBlock { get; set; } = new();
	public SC1OutBlock OutBlock { get; set; } = new();
}

/// <summary>
/// 주식주문체결 - InBlock
/// </summary>
internal class SC1InBlock
{
}

/// <summary>
/// 주식주문체결 - OutBlock
/// </summary>
internal class SC1OutBlock
{
	/// <summary>라인일련번호</summary>
	public string lineseq { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno { get; set; } = string.Empty;

	/// <summary>조작자ID</summary>
	public string user { get; set; } = string.Empty;

	/// <summary>헤더길이</summary>
	public string len { get; set; } = string.Empty;

	/// <summary>헤더구분</summary>
	public string gubun { get; set; } = string.Empty;

	/// <summary>압축구분</summary>
	public string compress { get; set; } = string.Empty;

	/// <summary>암호구분</summary>
	public string encrypt { get; set; } = string.Empty;

	/// <summary>공통시작지점</summary>
	public string offset { get; set; } = string.Empty;

	/// <summary>TRCODE</summary>
	public string trcode { get; set; } = string.Empty;

	/// <summary>이용사번호</summary>
	public string comid { get; set; } = string.Empty;

	/// <summary>사용자ID</summary>
	public string userid { get; set; } = string.Empty;

	/// <summary>접속매체</summary>
	public string media { get; set; } = string.Empty;

	/// <summary>I/F일련번호</summary>
	public string ifid { get; set; } = string.Empty;

	/// <summary>전문일련번호</summary>
	public string seq { get; set; } = string.Empty;

	/// <summary>TR추적ID</summary>
	public string trid { get; set; } = string.Empty;

	/// <summary>공인IP</summary>
	public string pubip { get; set; } = string.Empty;

	/// <summary>사설IP</summary>
	public string prvip { get; set; } = string.Empty;

	/// <summary>처리지점번호</summary>
	public string pcbpno { get; set; } = string.Empty;

	/// <summary>지점번호</summary>
	public string bpno { get; set; } = string.Empty;

	/// <summary>단말번호</summary>
	public string termno { get; set; } = string.Empty;

	/// <summary>언어구분</summary>
	public string lang { get; set; } = string.Empty;

	/// <summary>AP처리시간</summary>
	public string proctm { get; set; } = string.Empty;

	/// <summary>메세지코드</summary>
	public string msgcode { get; set; } = string.Empty;

	/// <summary>메세지출력구분</summary>
	public string outgu { get; set; } = string.Empty;

	/// <summary>압축요청구분</summary>
	public string compreq { get; set; } = string.Empty;

	/// <summary>기능키</summary>
	public string funckey { get; set; } = string.Empty;

	/// <summary>요청레코드개수</summary>
	public string reqcnt { get; set; } = string.Empty;

	/// <summary>예비영역</summary>
	public string filler { get; set; } = string.Empty;

	/// <summary>연속구분</summary>
	public string cont { get; set; } = string.Empty;

	/// <summary>연속키값</summary>
	public string contkey { get; set; } = string.Empty;

	/// <summary>가변시스템길이</summary>
	public string varlen { get; set; } = string.Empty;

	/// <summary>가변해더길이</summary>
	public string varhdlen { get; set; } = string.Empty;

	/// <summary>가변메시지길이</summary>
	public string varmsglen { get; set; } = string.Empty;

	/// <summary>조회발원지</summary>
	public string trsrc { get; set; } = string.Empty;

	/// <summary>I/F이벤트ID</summary>
	public string eventid { get; set; } = string.Empty;

	/// <summary>I/F정보</summary>
	public string ifinfo { get; set; } = string.Empty;

	/// <summary>예비영역</summary>
	public string filler1 { get; set; } = string.Empty;

	/// <summary>주문체결유형코드</summary>
	public string ordxctptncode { get; set; } = string.Empty;

	/// <summary>주문시장코드</summary>
	public string ordmktcode { get; set; } = string.Empty;

	/// <summary>주문유형코드</summary>
	public string ordptncode { get; set; } = string.Empty;

	/// <summary>관리지점번호</summary>
	public string mgmtbrnno { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno1 { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno2 { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string acntnm { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string Isuno { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string Isunm { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string orgordno { get; set; } = string.Empty;

	/// <summary>체결번호</summary>
	public string execno { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public string ordqty { get; set; } = string.Empty;

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

	/// <summary>주문금액</summary>
	public string ordamt { get; set; } = string.Empty;

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

	/// <summary>대출일</summary>
	public string Loandt { get; set; } = string.Empty;

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

	/// <summary>주문회차</summary>
	public string ordseqno { get; set; } = string.Empty;

	/// <summary>포트폴리오번호</summary>
	public string ptflno { get; set; } = string.Empty;

	/// <summary>바스켓번호</summary>
	public string bskno { get; set; } = string.Empty;

	/// <summary>트렌치번호</summary>
	public string trchno { get; set; } = string.Empty;

	/// <summary>아이템번호</summary>
	public string itemno { get; set; } = string.Empty;

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

	/// <summary>잔고수량</summary>
	public string secbalqty { get; set; } = string.Empty;

	/// <summary>실물가능수량</summary>
	public string spotordableqty { get; set; } = string.Empty;

	/// <summary>재사용가능수량(매도)</summary>
	public string ordableruseqty { get; set; } = string.Empty;

	/// <summary>변동수량</summary>
	public string flctqty { get; set; } = string.Empty;

	/// <summary>잔고수량(d2)</summary>
	public string secbalqtyd2 { get; set; } = string.Empty;

	/// <summary>매도주문가능수량</summary>
	public string sellableqty { get; set; } = string.Empty;

	/// <summary>미체결매도주문수량</summary>
	public string unercsellordqty { get; set; } = string.Empty;

	/// <summary>평균매입가</summary>
	public string avrpchsprc { get; set; } = string.Empty;

	/// <summary>매입금액</summary>
	public string pchsant { get; set; } = string.Empty;

	/// <summary>예수금</summary>
	public string deposit { get; set; } = string.Empty;

	/// <summary>대용금</summary>
	public string substamt { get; set; } = string.Empty;

	/// <summary>위탁증거금현금</summary>
	public string csgnmnymgn { get; set; } = string.Empty;

	/// <summary>위탁증거금대용</summary>
	public string csgnsubstmgn { get; set; } = string.Empty;

	/// <summary>신용담보재사용금</summary>
	public string crdtpldgruseamt { get; set; } = string.Empty;

	/// <summary>주문가능현금</summary>
	public string ordablemny { get; set; } = string.Empty;

	/// <summary>주문가능대용</summary>
	public string ordablesubstamt { get; set; } = string.Empty;

	/// <summary>재사용가능금액</summary>
	public string ruseableamt { get; set; } = string.Empty;

}

