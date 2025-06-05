namespace LsOpenApi.Models;
/// <summary>
/// 선물접수
/// </summary>
internal class O01
{
	public O01InBlock O01InBlock { get; set; } = new();
	public O01OutBlock O01OutBlock { get; set; } = new();
}

/// <summary>
/// 선물접수 - InBlock
/// </summary>
internal class O01InBlock { }

/// <summary>
/// 선물접수 - OutBlock
/// </summary>
internal class O01OutBlock
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

	/// <summary>tr코드</summary>
	public string trcode1 { get; set; } = string.Empty;

	/// <summary>회사번호</summary>
	public string firmno { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string acntno { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string acntno1 { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string acntnm { get; set; } = string.Empty;

	/// <summary>지점번호</summary>
	public string brnno { get; set; } = string.Empty;

	/// <summary>주문시장코드</summary>
	public string ordmktcode { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno1 { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string orgordno1 { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string orgordno { get; set; } = string.Empty;

	/// <summary>모주문번호</summary>
	public string prntordno { get; set; } = string.Empty;

	/// <summary>모주문번호</summary>
	public string prntordno1 { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string isuno { get; set; } = string.Empty;

	/// <summary>선물옵션종목번호</summary>
	public string fnoIsuno { get; set; } = string.Empty;

	/// <summary>선물옵션종목명</summary>
	public string fnoIsunm { get; set; } = string.Empty;

	/// <summary>상품군분류코드</summary>
	public string pdgrpcode { get; set; } = string.Empty;

	/// <summary>선물옵션종목유형구분</summary>
	public string fnoIsuptntp { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string bnstp { get; set; } = string.Empty;

	/// <summary>정정취소구분</summary>
	public string mrctp { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public string ordqty { get; set; } = string.Empty;

	/// <summary>호가유형코드</summary>
	public string hogatype { get; set; } = string.Empty;

	/// <summary>거래유형코드</summary>
	public string mmgb { get; set; } = string.Empty;

	/// <summary>주문가격</summary>
	public string ordprc { get; set; } = string.Empty;

	/// <summary>미체결수량</summary>
	public string unercqty { get; set; } = string.Empty;

	/// <summary>통신매체</summary>
	public string commdacode { get; set; } = string.Empty;

	/// <summary>수수료합산코드</summary>
	public string peeamtcode { get; set; } = string.Empty;

	/// <summary>관리사원</summary>
	public string mgempno { get; set; } = string.Empty;

	/// <summary>선물옵션거래단위금액</summary>
	public string fnotrdunitamt { get; set; } = string.Empty;

	/// <summary>처리시각</summary>
	public string trxtime { get; set; } = string.Empty;

	/// <summary>전략코드</summary>
	public string strtgcode { get; set; } = string.Empty;

	/// <summary>그룹Id</summary>
	public string grpId { get; set; } = string.Empty;

	/// <summary>주문회차</summary>
	public string ordseqno { get; set; } = string.Empty;

	/// <summary>포트폴리오 번호</summary>
	public string ptflno { get; set; } = string.Empty;

	/// <summary>바스켓번호</summary>
	public string bskno { get; set; } = string.Empty;

	/// <summary>트렌치번호</summary>
	public string trchno { get; set; } = string.Empty;

	/// <summary>아이템번호</summary>
	public string Itemno { get; set; } = string.Empty;

	/// <summary>주문자Id</summary>
	public string userId { get; set; } = string.Empty;

	/// <summary>운영지시번호</summary>
	public string opdrtnno { get; set; } = string.Empty;

	/// <summary>부적격코드</summary>
	public string rjtcode { get; set; } = string.Empty;

	/// <summary>정정취소확인수량</summary>
	public string mrccnfqty { get; set; } = string.Empty;

	/// <summary>원주문미체결수량</summary>
	public string orgordunercqty { get; set; } = string.Empty;

	/// <summary>원주문정정취소수량</summary>
	public string orgordmrcqty { get; set; } = string.Empty;

	/// <summary>약정시각(체결시각)</summary>
	public string ctrcttime { get; set; } = string.Empty;

	/// <summary>약정번호</summary>
	public string ctrctno { get; set; } = string.Empty;

	/// <summary>체결가격</summary>
	public string execprc { get; set; } = string.Empty;

	/// <summary>체결수량</summary>
	public string execqty { get; set; } = string.Empty;

	/// <summary>신규체결수량</summary>
	public string newqty { get; set; } = string.Empty;

	/// <summary>청산체결수량</summary>
	public string qdtqty { get; set; } = string.Empty;

	/// <summary>최종결제수량</summary>
	public string lastqty { get; set; } = string.Empty;

	/// <summary>전체체결수량</summary>
	public string lallexecqty { get; set; } = string.Empty;

	/// <summary>전체체결금액</summary>
	public string allexecamt { get; set; } = string.Empty;

	/// <summary>잔고평가구분</summary>
	public string fnobalevaltp { get; set; } = string.Empty;

	/// <summary>매매손익금액</summary>
	public string bnsplamt { get; set; } = string.Empty;

	/// <summary>선물옵션종목번호1</summary>
	public string fnoIsuno1 { get; set; } = string.Empty;

	/// <summary>매매구분1</summary>
	public string bnstp1 { get; set; } = string.Empty;

	/// <summary>체결가1</summary>
	public string execprc1 { get; set; } = string.Empty;

	/// <summary>신규체결수량1</summary>
	public string newqty1 { get; set; } = string.Empty;

	/// <summary>청산체결수량1</summary>
	public string qdtqty1 { get; set; } = string.Empty;

	/// <summary>전체체결금액1</summary>
	public string allexecamt1 { get; set; } = string.Empty;

	/// <summary>선물옵션종목번호2</summary>
	public string fnoIsuno2 { get; set; } = string.Empty;

	/// <summary>매매구분2</summary>
	public string bnstp2 { get; set; } = string.Empty;

	/// <summary>체결가2</summary>
	public string execprc2 { get; set; } = string.Empty;

	/// <summary>신규체결수량2</summary>
	public string newqty2 { get; set; } = string.Empty;

	/// <summary>청산체결수량2</summary>
	public string lqdtqty2 { get; set; } = string.Empty;

	/// <summary>전체체결금액2</summary>
	public string allexecamt2 { get; set; } = string.Empty;

	/// <summary>예수금</summary>
	public string dps { get; set; } = string.Empty;

	/// <summary>선물대용지정금액</summary>
	public string ftsubtdsgnamt { get; set; } = string.Empty;

	/// <summary>증거금</summary>
	public string mgn { get; set; } = string.Empty;

	/// <summary>증거금현금</summary>
	public string mnymgn { get; set; } = string.Empty;

	/// <summary>주문가능금액</summary>
	public string ordableamt { get; set; } = string.Empty;

	/// <summary>주문가능현금액</summary>
	public string mnyordableamt { get; set; } = string.Empty;

	/// <summary>잔고 종목번호1</summary>
	public string fnoIsuno_1 { get; set; } = string.Empty;

	/// <summary>잔고 매매구분1</summary>
	public string bnstp_1 { get; set; } = string.Empty;

	/// <summary>미결제수량1</summary>
	public string unsttqty_1 { get; set; } = string.Empty;

	/// <summary>주문가능수량1</summary>
	public string lqdtableqty_1 { get; set; } = string.Empty;

	/// <summary>평균가1</summary>
	public string avrprc_1 { get; set; } = string.Empty;

	/// <summary>잔고 종목번호2</summary>
	public string fnoIsuno_2 { get; set; } = string.Empty;

	/// <summary>잔고 매매구분2</summary>
	public string bnstp_2 { get; set; } = string.Empty;

	/// <summary>미결제수량2</summary>
	public string unsttqty_2 { get; set; } = string.Empty;

	/// <summary>주문가능수량2</summary>
	public string lqdtableqty_2 { get; set; } = string.Empty;

	/// <summary>평균가2</summary>
	public string avrprc_2 { get; set; } = string.Empty;
}