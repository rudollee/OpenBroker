namespace KisOpenApi.Models;
/// <summary>
/// 국내주식 실시간체결통보
/// </summary>
internal enum H0STCNI0
{
	/// <summary>고객 ID</summary>
	CUST_ID,

	/// <summary>계좌번호</summary>
	ACNT_NO,

	/// <summary>주문번호</summary>
	ODER_NO,

	/// <summary>원주문번호</summary>
	OODER_NO,

	/// <summary>매도매수구분</summary>
	SELN_BYOV_CLS,

	/// <summary>정정구분</summary>
	RCTF_CLS,

	/// <summary>주문종류</summary>
	ODER_KIND,

	/// <summary>주문조건</summary>
	ODER_COND,

	/// <summary>주식 단축 종목코드</summary>
	STCK_SHRN_ISCD,

	/// <summary>체결 수량</summary>
	CNTG_QTY,

	/// <summary>체결단가</summary>
	CNTG_UNPR,

	/// <summary>주식 체결 시간</summary>
	STCK_CNTG_HOUR,

	/// <summary>거부여부</summary>
	RFUS_YN,

	/// <summary>체결여부</summary>
	CNTG_YN,

	/// <summary>접수여부</summary>
	ACPT_YN,

	/// <summary>지점번호</summary>
	BRNC_NO,

	/// <summary>주문수량</summary>
	ODER_QTY,

	/// <summary>계좌명</summary>
	ACNT_NAME,

	/// <summary>호가조건가격</summary>
	ORD_COND_PRC,

	/// <summary>주문거래소 구분</summary>
	ORD_EXG_GB,

	/// <summary>실시간체결창 표시여부</summary>
	POPUP_YN,

	/// <summary>필러</summary>
	FILLER,

	/// <summary>신용구분</summary>
	CRDT_CLS,

	/// <summary>신용대출일자</summary>
	CRDT_LOAN_DATE,

	/// <summary>체결종목명</summary>
	CNTG_ISNM40,

	/// <summary>주문가격</summary>
	ODER_PRC,
}