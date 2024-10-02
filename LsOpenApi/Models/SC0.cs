using System.Collections.Generic;

namespace LsOpenApi.Models;
/// <summary>
/// 주식주문접수
/// </summary>
internal class SC0
{
	public SC0InBlock InBlock { get; set; } = new();
	public SC0OutBlock OutBlock { get; set; } = new();
}

/// <summary>
/// 주식주문접수 - InBlock
/// </summary>
internal class SC0InBlock
{
}

/// <summary>
/// 주식주문접수 - OutBlock
/// </summary>
internal class SC0OutBlock
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

	/// <summary>주문체결구분</summary>
	public string ordchegb { get; set; } = string.Empty;

	/// <summary>시장구분</summary>
	public string marketgb { get; set; } = string.Empty;

	/// <summary>주문구분</summary>
	public string ordgb { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string orgordno { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno1 { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno2 { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	public string passwd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>단축종목번호</summary>
	public string shtcode { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public string ordqty { get; set; } = string.Empty;

	/// <summary>주문가격</summary>
	public string ordprice { get; set; } = string.Empty;

	/// <summary>주문조건</summary>
	public string hogagb { get; set; } = string.Empty;

	/// <summary>호가유형코드</summary>
	public string etfhogagb { get; set; } = string.Empty;

	/// <summary>프로그램호가구분</summary>
	public string pgmtype { get; set; } = string.Empty;

	/// <summary>공매도호가구분</summary>
	public string gmhogagb { get; set; } = string.Empty;

	/// <summary>공매도가능여부</summary>
	public string gmhogayn { get; set; } = string.Empty;

	/// <summary>신용구분</summary>
	public string singb { get; set; } = string.Empty;

	/// <summary>대출일</summary>
	public string loandt { get; set; } = string.Empty;

	/// <summary>반대매매주문구분</summary>
	public string cvrgordtp { get; set; } = string.Empty;

	/// <summary>전략코드</summary>
	public string strtgcode { get; set; } = string.Empty;

	/// <summary>그룹ID</summary>
	public string groupid { get; set; } = string.Empty;

	/// <summary>주문회차</summary>
	public string ordseqno { get; set; } = string.Empty;

	/// <summary>포트폴리오번호</summary>
	public string prtno { get; set; } = string.Empty;

	/// <summary>바스켓번호</summary>
	public string basketno { get; set; } = string.Empty;

	/// <summary>트렌치번호</summary>
	public string trchno { get; set; } = string.Empty;

	/// <summary>아아템번호</summary>
	public string itemno { get; set; } = string.Empty;

	/// <summary>차입구분</summary>
	public string brwmgmyn { get; set; } = string.Empty;

	/// <summary>회원사번호</summary>
	public string mbrno { get; set; } = string.Empty;

	/// <summary>처리구분</summary>
	public string procgb { get; set; } = string.Empty;

	/// <summary>관리지점번호</summary>
	public string admbrchno { get; set; } = string.Empty;

	/// <summary>선물계좌번호</summary>
	public string futaccno { get; set; } = string.Empty;

	/// <summary>선물상품구분</summary>
	public string futmarketgb { get; set; } = string.Empty;

	/// <summary>통신매체구분</summary>
	public string tongsingb { get; set; } = string.Empty;

	/// <summary>유동성공급자구분</summary>
	public string lpgb { get; set; } = string.Empty;

	/// <summary>DUMMY</summary>
	public string dummy { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno { get; set; } = string.Empty;

	/// <summary>주문시각</summary>
	public string ordtm { get; set; } = string.Empty;

	/// <summary>모주문번호</summary>
	public string prntordno { get; set; } = string.Empty;

	/// <summary>관리사원번호</summary>
	public string mgempno { get; set; } = string.Empty;

	/// <summary>원주문미체결수량</summary>
	public string orgordundrqty { get; set; } = string.Empty;

	/// <summary>원주문정정수량</summary>
	public string orgordmdfyqty { get; set; } = string.Empty;

	/// <summary>원주문취소수량</summary>
	public string ordordcancelqty { get; set; } = string.Empty;

	/// <summary>비회원사송신번호</summary>
	public string nmcpysndno { get; set; } = string.Empty;

	/// <summary>주문금액</summary>
	public string ordamt { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string bnstp { get; set; } = string.Empty;

	/// <summary>예비주문번호</summary>
	public string spareordno { get; set; } = string.Empty;

	/// <summary>반대매매일련번호</summary>
	public string cvrgseqno { get; set; } = string.Empty;

	/// <summary>예약주문번호</summary>
	public string rsvordno { get; set; } = string.Empty;

	/// <summary>복수주문일련번호</summary>
	public string mtordseqno { get; set; } = string.Empty;

	/// <summary>예비주문수량</summary>
	public string spareordqty { get; set; } = string.Empty;

	/// <summary>주문사원번호</summary>
	public string orduserid { get; set; } = string.Empty;

	/// <summary>실물주문수량</summary>
	public string spotordqty { get; set; } = string.Empty;

	/// <summary>재사용주문수량</summary>
	public string ordruseqty { get; set; } = string.Empty;

	/// <summary>현금주문금액</summary>
	public string mnyordamt { get; set; } = string.Empty;

	/// <summary>주문대용금액</summary>
	public string ordsubstamt { get; set; } = string.Empty;

	/// <summary>재사용주문금액</summary>
	public string ruseordamt { get; set; } = string.Empty;

	/// <summary>수수료주문금액</summary>
	public string ordcmsnamt { get; set; } = string.Empty;

	/// <summary>사용신용담보재사용금</summary>
	public string crdtuseamt { get; set; } = string.Empty;

	/// <summary>잔고수량</summary>
	public string secbalqty { get; set; } = string.Empty;

	/// <summary>실물가능수량</summary>
	public string spotordableqty { get; set; } = string.Empty;

	/// <summary>재사용가능수량(매도)</summary>
	public string ordableruseqty { get; set; } = string.Empty;

	/// <summary>변동수량</summary>
	public string flctqty { get; set; } = string.Empty;

	/// <summary>잔고수량(D2)</summary>
	public string secbalqtyd2 { get; set; } = string.Empty;

	/// <summary>매도주문가능수량</summary>
	public string sellableqty { get; set; } = string.Empty;

	/// <summary>미체결매도주문수량</summary>
	public string unercsellordqty { get; set; } = string.Empty;

	/// <summary>평균매입가</summary>
	public string avrpchsprc { get; set; } = string.Empty;

	/// <summary>매입금액</summary>
	public string pchsamt { get; set; } = string.Empty;

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

