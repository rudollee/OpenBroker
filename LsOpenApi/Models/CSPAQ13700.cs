﻿namespace LsOpenApi.Models;
/// <summary>
/// 현물계좌주문체결내역조회
/// </summary>
internal class CSPAQ13700
{
	public CSPAQ13700InBlock1 InBlock { get; set; } = new();
	public CSPAQ13700OutBlock1 OutBlock1 { get; set; } = new();
	public CSPAQ13700OutBlock2 OutBlock2 { get; set; } = new();
	public List<CSPAQ13700OutBlock3> OutBlock3 { get; set; } = new();
}

/// <summary>
/// 현물계좌주문체결내역조회 - InBlock
/// </summary>
internal class CSPAQ13700InBlock1
{
	public string OrdMktCode { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; }

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; }

	/// <summary>체결여부</summary>
	public string ExecYn { get; set; }

	/// <summary>주문일</summary>
	public string OrdDt { get; set; }

	/// <summary>시작주문번호2</summary>
	public long SrtOrdNo2 { get; set; }

	/// <summary>역순구분</summary>
	public string BkseqTpCode { get; set; }

	/// <summary>주문유형코드</summary>
	public string OrdPtnCode { get; set; }
}

/// <summary>
/// 현물계좌주문체결내역조회 - OutBlock1
/// </summary>
internal class CSPAQ13700OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; }

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; }

	/// <summary>주문시장코드</summary>
	public string OrdMktCode { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; }

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; }

	/// <summary>체결여부</summary>
	public string ExecYn { get; set; }

	/// <summary>주문일</summary>
	public string OrdDt { get; set; }

	/// <summary>시작주문번호2</summary>
	public long SrtOrdNo2 { get; set; }

	/// <summary>역순구분</summary>
	public string BkseqTpCode { get; set; }

	/// <summary>주문유형코드</summary>
	public string OrdPtnCode { get; set; }

}

/// <summary>
/// 현물계좌주문체결내역조회 - OutBlock2
/// </summary>
internal class CSPAQ13700OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>매도체결금액</summary>
	public long SellExecAmt { get; set; }

	/// <summary>매수체결금액</summary>
	public long BuyExecAmt { get; set; }

	/// <summary>매도체결수량</summary>
	public long SellExecQty { get; set; }

	/// <summary>매수체결수량</summary>
	public long BuyExecQty { get; set; }

	/// <summary>매도주문수량</summary>
	public long SellOrdQty { get; set; }

	/// <summary>매수주문수량</summary>
	public long BuyOrdQty { get; set; }

}

/// <summary>
/// 현물계좌주문체결내역조회 - OutBlock3
/// </summary>
internal class CSPAQ13700OutBlock3
{
	/// <summary>주문일</summary>
	public string OrdDt { get; set; }

	/// <summary>관리지점번호</summary>
	public string MgmtBrnNo { get; set; }

	/// <summary>주문시장코드</summary>
	public string OrdMktCode { get; set; }

	/// <summary>주문번호</summary>
	public long OrdNo { get; set; }

	/// <summary>원주문번호</summary>
	public long OrgOrdNo { get; set; }

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; }

	/// <summary>종목명</summary>
	public string IsuNm { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpNm { get; set; }

	/// <summary>주문유형코드</summary>
	public string OrdPtnCode { get; set; }

	/// <summary>주문유형명</summary>
	public string OrdPtnNm { get; set; }

	/// <summary>주문처리유형코드</summary>
	public long OrdTrxPtnCode { get; set; }

	/// <summary>주문처리유형명</summary>
	public string OrdTrxPtnNm { get; set; }

	/// <summary>정정취소구분</summary>
	public string MrcTpCode { get; set; }

	/// <summary>정정취소구분명</summary>
	public string MrcTpNm { get; set; }

	/// <summary>정정취소수량</summary>
	public long MrcQty { get; set; }

	/// <summary>정정취소가능수량</summary>
	public long MrcAbleQty { get; set; }

	/// <summary>주문수량</summary>
	public long OrdQty { get; set; }

	/// <summary>주문가격</summary>
	public decimal OrdPrc { get; set; }

	/// <summary>체결수량</summary>
	public long ExecQty { get; set; }

	/// <summary>체결가</summary>
	public decimal ExecPrc { get; set; }

	/// <summary>체결처리시각</summary>
	public string ExecTrxTime { get; set; }

	/// <summary>최종체결시각</summary>
	public string LastExecTime { get; set; }

	/// <summary>호가유형코드</summary>
	public string OrdprcPtnCode { get; set; }

	/// <summary>호가유형명</summary>
	public string OrdprcPtnNm { get; set; }

	/// <summary>주문조건구분</summary>
	public string OrdCndiTpCode { get; set; }

	/// <summary>전체체결수량</summary>
	public long AllExecQty { get; set; }

	/// <summary>통신매체코드</summary>
	public string RegCommdaCode { get; set; }

	/// <summary>통신매체명</summary>
	public string CommdaNm { get; set; }

	/// <summary>회원번호</summary>
	public string MbrNo { get; set; }

	/// <summary>예약주문여부</summary>
	public string RsvOrdYn { get; set; }

	/// <summary>대출일</summary>
	public string LoanDt { get; set; }

	/// <summary>주문시각</summary>
	public string OrdTime { get; set; }

	/// <summary>운용지시번호</summary>
	public string OpDrtnNo { get; set; }

	/// <summary>주문자ID</summary>
	public string OdrrId { get; set; }

}

