using System.Text.Json.Serialization;

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
    [JsonPropertyName("lineseq")]
    public string Lineseq { get; set; } = string.Empty;

    /// <summary>계좌번호</summary>
    [JsonPropertyName("accno")]
    public string Accno { get; set; } = string.Empty;

    /// <summary>조작자ID</summary>
    [JsonPropertyName("user")]
    public string User { get; set; } = string.Empty;

    /// <summary>헤더길이</summary>
    [JsonPropertyName("len")]
    public string Len { get; set; } = string.Empty;

    /// <summary>헤더구분</summary>
    [JsonPropertyName("gubun")]
    public string Gubun { get; set; } = string.Empty;

    /// <summary>압축구분</summary>
    [JsonPropertyName("compress")]
    public string Compress { get; set; } = string.Empty;

    /// <summary>암호구분</summary>
    [JsonPropertyName("encrypt")]
    public string Encrypt { get; set; } = string.Empty;

    /// <summary>공통시작지점</summary>
    [JsonPropertyName("offset")]
    public string Offset { get; set; } = string.Empty;

    /// <summary>TRCODE</summary>
    [JsonPropertyName("trcode")]
    public string Trcode { get; set; } = string.Empty;

    /// <summary>이용사번호</summary>
    [JsonPropertyName("comid")]
    public string Comid { get; set; } = string.Empty;

    /// <summary>사용자ID</summary>
    [JsonPropertyName("userid")]
    public string Userid { get; set; } = string.Empty;

    /// <summary>접속매체</summary>
    [JsonPropertyName("media")]
    public string Media { get; set; } = string.Empty;

    /// <summary>I/F일련번호</summary>
    [JsonPropertyName("ifid")]
    public string Ifid { get; set; } = string.Empty;

    /// <summary>전문일련번호</summary>
    [JsonPropertyName("seq")]
    public string Seq { get; set; } = string.Empty;

    /// <summary>TR추적ID</summary>
    [JsonPropertyName("trid")]
    public string Trid { get; set; } = string.Empty;

    /// <summary>공인IP</summary>
    [JsonPropertyName("pubip")]
    public string Pubip { get; set; } = string.Empty;

    /// <summary>사설IP</summary>
    [JsonPropertyName("prvip")]
    public string Prvip { get; set; } = string.Empty;

    /// <summary>처리지점번호</summary>
    [JsonPropertyName("pcbpno")]
    public string Pcbpno { get; set; } = string.Empty;

    /// <summary>지점번호</summary>
    [JsonPropertyName("bpno")]
    public string Bpno { get; set; } = string.Empty;

    /// <summary>단말번호</summary>
    [JsonPropertyName("termno")]
    public string Termno { get; set; } = string.Empty;

    /// <summary>언어구분</summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; } = string.Empty;

    /// <summary>AP처리시간</summary>
    [JsonPropertyName("proctm")]
    public string Proctm { get; set; } = string.Empty;

    /// <summary>메세지코드</summary>
    [JsonPropertyName("msgcode")]
    public string Msgcode { get; set; } = string.Empty;

    /// <summary>메세지출력구분</summary>
    [JsonPropertyName("outgu")]
    public string Outgu { get; set; } = string.Empty;

    /// <summary>압축요청구분</summary>
    [JsonPropertyName("compreq")]
    public string Compreq { get; set; } = string.Empty;

    /// <summary>기능키</summary>
    [JsonPropertyName("funckey")]
    public string Funckey { get; set; } = string.Empty;

    /// <summary>요청레코드개수</summary>
    [JsonPropertyName("reqcnt")]
    public string Reqcnt { get; set; } = string.Empty;

    /// <summary>예비영역</summary>
    [JsonPropertyName("filler")]
    public string Filler { get; set; } = string.Empty;

    /// <summary>연속구분</summary>
    [JsonPropertyName("cont")]
    public string Cont { get; set; } = string.Empty;

    /// <summary>연속키값</summary>
    [JsonPropertyName("contkey")]
    public string Contkey { get; set; } = string.Empty;

    /// <summary>가변시스템길이</summary>
    [JsonPropertyName("varlen")]
    public string Varlen { get; set; } = string.Empty;

    /// <summary>가변해더길이</summary>
    [JsonPropertyName("varhdlen")]
    public string Varhdlen { get; set; } = string.Empty;

    /// <summary>가변메시지길이</summary>
    [JsonPropertyName("varmsglen")]
    public string Varmsglen { get; set; } = string.Empty;

    /// <summary>조회발원지</summary>
    [JsonPropertyName("trsrc")]
    public string Trsrc { get; set; } = string.Empty;

    /// <summary>I/F이벤트ID</summary>
    [JsonPropertyName("eventid")]
    public string Eventid { get; set; } = string.Empty;

    /// <summary>I/F정보</summary>
    [JsonPropertyName("ifinfo")]
    public string Ifinfo { get; set; } = string.Empty;

    /// <summary>예비영역</summary>
    [JsonPropertyName("filler1")]
    public string Filler1 { get; set; } = string.Empty;

    /// <summary>tr코드</summary>
    [JsonPropertyName("trcode1")]
    public string Trcode1 { get; set; } = string.Empty;

    /// <summary>회사번호</summary>
    [JsonPropertyName("firmno")]
    public string Firmno { get; set; } = string.Empty;

    /// <summary>계좌번호</summary>
    [JsonPropertyName("acntno")]
    public string Acntno { get; set; } = string.Empty;

    /// <summary>계좌번호</summary>
    [JsonPropertyName("acntno1")]
    public string Acntno1 { get; set; } = string.Empty;

    /// <summary>계좌명</summary>
    [JsonPropertyName("acntnm")]
    public string Acntnm { get; set; } = string.Empty;

    /// <summary>지점번호</summary>
    [JsonPropertyName("brnno")]
    public string Brnno { get; set; } = string.Empty;

    /// <summary>주문시장코드</summary>
    [JsonPropertyName("ordmktcode")]
    public string Ordmktcode { get; set; } = string.Empty;

    /// <summary>주문번호</summary>
    [JsonPropertyName("ordno1")]
    public string Ordno1 { get; set; } = string.Empty;

    /// <summary>주문번호</summary>
    [JsonPropertyName("ordno")]
    public string Ordno { get; set; } = string.Empty;

    /// <summary>원주문번호</summary>
    [JsonPropertyName("orgordno1")]
    public string Orgordno1 { get; set; } = string.Empty;

    /// <summary>원주문번호</summary>
    [JsonPropertyName("orgordno")]
    public string Orgordno { get; set; } = string.Empty;

    /// <summary>모주문번호</summary>
    [JsonPropertyName("prntordno")]
    public string Prntordno { get; set; } = string.Empty;

    /// <summary>모주문번호</summary>
    [JsonPropertyName("prntordno1")]
    public string Prntordno1 { get; set; } = string.Empty;

    /// <summary>종목번호</summary>
    [JsonPropertyName("isuno")]
    public string Isuno { get; set; } = string.Empty;

    /// <summary>선물옵션종목번호</summary>
    [JsonPropertyName("fnoIsuno")]
    public string FnoIsuno { get; set; } = string.Empty;

    /// <summary>선물옵션종목명</summary>
    [JsonPropertyName("fnoIsunm")]
    public string FnoIsunm { get; set; } = string.Empty;

    /// <summary>상품군분류코드</summary>
    [JsonPropertyName("pdgrpcode")]
    public string Pdgrpcode { get; set; } = string.Empty;

    /// <summary>선물옵션종목유형구분</summary>
    [JsonPropertyName("fnoIsuptntp")]
    public string FnoIsuptntp { get; set; } = string.Empty;

    /// <summary>매매구분</summary>
    [JsonPropertyName("bnstp")]
    public string Bnstp { get; set; } = string.Empty;

    /// <summary>정정취소구분</summary>
    [JsonPropertyName("mrctp")]
    public string Mrctp { get; set; } = string.Empty;

    /// <summary>주문수량</summary>
    [JsonPropertyName("ordqty")]
    public string Ordqty { get; set; } = string.Empty;

    /// <summary>호가유형코드</summary>
    [JsonPropertyName("hogatype")]
    public string Hogatype { get; set; } = string.Empty;

    /// <summary>거래유형코드</summary>
    [JsonPropertyName("mmgb")]
    public string Mmgb { get; set; } = string.Empty;

    /// <summary>주문가격</summary>
    [JsonPropertyName("ordprc")]
    public string Ordprc { get; set; } = string.Empty;

    /// <summary>미체결수량</summary>
    [JsonPropertyName("unercqty")]
    public string Unercqty { get; set; } = string.Empty;

    /// <summary>통신매체</summary>
    [JsonPropertyName("commdacode")]
    public string Commdacode { get; set; } = string.Empty;

    /// <summary>수수료합산코드</summary>
    [JsonPropertyName("peeamtcode")]
    public string Peeamtcode { get; set; } = string.Empty;

    /// <summary>관리사원</summary>
    [JsonPropertyName("mgempno")]
    public string Mgempno { get; set; } = string.Empty;

    /// <summary>선물옵션거래단위금액</summary>
    [JsonPropertyName("fnotrdunitamt")]
    public string Fnotrdunitamt { get; set; } = string.Empty;

    /// <summary>처리시각</summary>
    [JsonPropertyName("trxtime")]
    public string Trxtime { get; set; } = string.Empty;

    /// <summary>전략코드</summary>
    [JsonPropertyName("strtgcode")]
    public string Strtgcode { get; set; } = string.Empty;

    /// <summary>그룹Id</summary>
    [JsonPropertyName("grpId")]
    public string GrpId { get; set; } = string.Empty;

    /// <summary>주문회차</summary>
    [JsonPropertyName("ordseqno")]
    public string Ordseqno { get; set; } = string.Empty;

    /// <summary>포트폴리오 번호</summary>
    [JsonPropertyName("ptflno")]
    public string Ptflno { get; set; } = string.Empty;

    /// <summary>바스켓번호</summary>
    [JsonPropertyName("bskno")]
    public string Bskno { get; set; } = string.Empty;

    /// <summary>트렌치번호</summary>
    [JsonPropertyName("trchno")]
    public string Trchno { get; set; } = string.Empty;

    /// <summary>아이템번호</summary>
    [JsonPropertyName("Itemno")]
    public string Itemno { get; set; } = string.Empty;

    /// <summary>주문자Id</summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>운영지시번호</summary>
    [JsonPropertyName("opdrtnno")]
    public string Opdrtnno { get; set; } = string.Empty;

    /// <summary>부적격코드</summary>
    [JsonPropertyName("rjtcode")]
    public string Rjtcode { get; set; } = string.Empty;

    /// <summary>정정취소확인수량</summary>
    [JsonPropertyName("mrccnfqty")]
    public string Mrccnfqty { get; set; } = string.Empty;

    /// <summary>원주문미체결수량</summary>
    [JsonPropertyName("orgordunercqty")]
    public string Orgordunercqty { get; set; } = string.Empty;

    /// <summary>원주문정정취소수량</summary>
    [JsonPropertyName("orgordmrcqty")]
    public string Orgordmrcqty { get; set; } = string.Empty;

    /// <summary>약정시각(체결시각)</summary>
    [JsonPropertyName("ctrcttime")]
    public string Ctrcttime { get; set; } = string.Empty;

    /// <summary>약정번호</summary>
    [JsonPropertyName("ctrctno")]
    public string Ctrctno { get; set; } = string.Empty;

    /// <summary>체결가격</summary>
    [JsonPropertyName("execprc")]
    public string Execprc { get; set; } = string.Empty;

    /// <summary>체결수량</summary>
    [JsonPropertyName("execqty")]
    public string Execqty { get; set; } = string.Empty;

    /// <summary>신규체결수량</summary>
    [JsonPropertyName("newqty")]
    public string Newqty { get; set; } = string.Empty;

    /// <summary>청산체결수량</summary>
    [JsonPropertyName("qdtqty")]
    public string Qdtqty { get; set; } = string.Empty;

    /// <summary>최종결제수량</summary>
    [JsonPropertyName("lastqty")]
    public string Lastqty { get; set; } = string.Empty;

    /// <summary>전체체결수량</summary>
    [JsonPropertyName("lallexecqty")]
    public string Lallexecqty { get; set; } = string.Empty;

    /// <summary>전체체결금액</summary>
    [JsonPropertyName("allexecamt")]
    public string Allexecamt { get; set; } = string.Empty;

    /// <summary>잔고평가구분</summary>
    [JsonPropertyName("fnobalevaltp")]
    public string Fnobalevaltp { get; set; } = string.Empty;

    /// <summary>매매손익금액</summary>
    [JsonPropertyName("bnsplamt")]
    public string Bnsplamt { get; set; } = string.Empty;

    /// <summary>선물옵션종목번호1</summary>
    [JsonPropertyName("fnoIsuno1")]
    public string FnoIsuno1 { get; set; } = string.Empty;

    /// <summary>매매구분1</summary>
    [JsonPropertyName("bnstp1")]
    public string Bnstp1 { get; set; } = string.Empty;

    /// <summary>체결가1</summary>
    [JsonPropertyName("execprc1")]
    public string Execprc1 { get; set; } = string.Empty;

    /// <summary>신규체결수량1</summary>
    [JsonPropertyName("newqty1")]
    public string Newqty1 { get; set; } = string.Empty;

    /// <summary>청산체결수량1</summary>
    [JsonPropertyName("qdtqty1")]
    public string Qdtqty1 { get; set; } = string.Empty;

    /// <summary>전체체결금액1</summary>
    [JsonPropertyName("allexecamt1")]
    public string Allexecamt1 { get; set; } = string.Empty;

    /// <summary>선물옵션종목번호2</summary>
    [JsonPropertyName("fnoIsuno2")]
    public string FnoIsuno2 { get; set; } = string.Empty;

    /// <summary>매매구분2</summary>
    [JsonPropertyName("bnstp2")]
    public string Bnstp2 { get; set; } = string.Empty;

    /// <summary>체결가2</summary>
    [JsonPropertyName("execprc2")]
    public string Execprc2 { get; set; } = string.Empty;

    /// <summary>신규체결수량2</summary>
    [JsonPropertyName("newqty2")]
    public string Newqty2 { get; set; } = string.Empty;

    /// <summary>청산체결수량2</summary>
    [JsonPropertyName("lqdtqty2")]
    public string Lqdtqty2 { get; set; } = string.Empty;

    /// <summary>전체체결금액2</summary>
    [JsonPropertyName("allexecamt2")]
    public string Allexecamt2 { get; set; } = string.Empty;

    /// <summary>예수금</summary>
    [JsonPropertyName("dps")]
    public string Dps { get; set; } = string.Empty;

    /// <summary>선물대용지정금액</summary>
    [JsonPropertyName("ftsubtdsgnamt")]
    public string Ftsubtdsgnamt { get; set; } = string.Empty;

    /// <summary>증거금</summary>
    [JsonPropertyName("mgn")]
    public string Mgn { get; set; } = string.Empty;

    /// <summary>증거금현금</summary>
    [JsonPropertyName("mnymgn")]
    public string Mnymgn { get; set; } = string.Empty;

    /// <summary>주문가능금액</summary>
    [JsonPropertyName("ordableamt")]
    public string Ordableamt { get; set; } = string.Empty;

    /// <summary>주문가능현금액</summary>
    [JsonPropertyName("mnyordableamt")]
    public string Mnyordableamt { get; set; } = string.Empty;

    /// <summary>미결제수량1</summary>
    [JsonPropertyName("unsttqty_1")]
    public string Unsttqty1 { get; set; } = string.Empty;

    /// <summary>주문가능수량1</summary>
    [JsonPropertyName("lqdtableqty_1")]
    public string Lqdtableqty1 { get; set; } = string.Empty;

    /// <summary>평균가1</summary>
    [JsonPropertyName("avrprc_1")]
    public string Avrprc1 { get; set; } = string.Empty;

    /// <summary>미결제수량2</summary>
    [JsonPropertyName("unsttqty_2")]
    public string Unsttqty2 { get; set; } = string.Empty;

    /// <summary>주문가능수량2</summary>
    [JsonPropertyName("lqdtableqty_2")]
    public string Lqdtableqty2 { get; set; } = string.Empty;

    /// <summary>평균가2</summary>
    [JsonPropertyName("avrprc_2")]
    public string Avrprc2 { get; set; } = string.Empty;
}

/// <summary>
/// KRX야간파생 선물접수
/// </summary>
internal class O02
{
    public O01InBlock O02InBlock { get; set; } = new();
    public O01OutBlock O02OutBlock { get; set; } = new();
}