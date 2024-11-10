namespace LsOpenApi.Models;
/// <summary>
/// 현물계좌예수금 주문가능금액 총평가2
/// </summary>
internal class CSPAQ22200 : LsResponseCore
{
	public CSPAQ22200InBlock1 CSPAQ22200InBlock { get; set; } = new();
	public CSPAQ22200OutBlock1 CSPAQ22200OutBlock1 { get; set; } = new();
	public CSPAQ22200OutBlock2 CSPAQ22200OutBlock2 { get; set; } = new();
}

/// <summary>
/// 현물계좌예수금 주문가능금액 총평가2 - InBlock
/// </summary>
internal class CSPAQ22200InBlock1
{
	/// <summary>잔고생성구분</summary>
	public string BalCreTp { get; set; } = string.Empty;
}

/// <summary>
/// 현물계좌예수금 주문가능금액 총평가2 - OutBlock1
/// </summary>
internal class CSPAQ22200OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>관리지점번호</summary>
	public string MgmtBrnNo { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	public string Pwd { get; set; } = string.Empty;

	/// <summary>잔고생성구분</summary>
	public string BalCreTp { get; set; } = string.Empty;

}

/// <summary>
/// 현물계좌예수금 주문가능금액 총평가2 - OutBlock2
/// </summary>
internal class CSPAQ22200OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>지점명</summary>
	public string BrnNm { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>대용주문가능금액</summary>
	public long SubstOrdAbleAmt { get; set; }

	/// <summary>거래소금액</summary>
	public long SeOrdAbleAmt { get; set; }

	/// <summary>코스닥금액</summary>
	public long KdqOrdAbleAmt { get; set; }

	/// <summary>신용담보주문금액</summary>
	public long CrdtPldgOrdAmt { get; set; }

	/// <summary>증거금률100퍼센트주문가능금액</summary>
	public long MgnRat100pctOrdAbleAmt { get; set; }

	/// <summary>증거금률35%주문가능금액</summary>
	public long MgnRat35ordAbleAmt { get; set; }

	/// <summary>증거금률50%주문가능금액</summary>
	public long MgnRat50ordAbleAmt { get; set; }

	/// <summary>신용주문가능금액</summary>
	public long CrdtOrdAbleAmt { get; set; }

	/// <summary>예수금</summary>
	public long Dps { get; set; }

	/// <summary>대용금액</summary>
	public long SubstAmt { get; set; }

	/// <summary>증거금현금</summary>
	public long MgnMny { get; set; }

	/// <summary>증거금대용</summary>
	public long MgnSubst { get; set; }

	/// <summary>D1예수금</summary>
	public long D1Dps { get; set; }

	/// <summary>D2예수금</summary>
	public long D2Dps { get; set; }

	/// <summary>미수금액</summary>
	public long RcvblAmt { get; set; }

	/// <summary>D1연체변제소요금액</summary>
	public long D1ovdRepayRqrdAmt { get; set; }

	/// <summary>D2연체변제소요금액</summary>
	public long D2ovdRepayRqrdAmt { get; set; }

	/// <summary>융자금액</summary>
	public long MloanAmt { get; set; }

	/// <summary>변경후담보비율</summary>
	public decimal ChgAfPldgRat { get; set; }

	/// <summary>소요담보금액</summary>
	public long RqrdPldgAmt { get; set; }

	/// <summary>담보부족금액</summary>
	public long PdlckAmt { get; set; }

	/// <summary>원담보합계금액</summary>
	public long OrgPldgSumAmt { get; set; }

	/// <summary>부담보합계금액</summary>
	public long SubPldgSumAmt { get; set; }

	/// <summary>신용담보금현금</summary>
	public long CrdtPldgAmtMny { get; set; }

	/// <summary>신용담보대용금액</summary>
	public long CrdtPldgSubstAmt { get; set; }

	/// <summary>신용설정보증금</summary>
	public long Imreq { get; set; }

	/// <summary>신용담보재사용금액</summary>
	public long CrdtPldgRuseAmt { get; set; }

	/// <summary>처분제한금액</summary>
	public long DpslRestrcAmt { get; set; }

	/// <summary>전일매도정산금액</summary>
	public long PrdaySellAdjstAmt { get; set; }

	/// <summary>전일매수정산금액</summary>
	public long PrdayBuyAdjstAmt { get; set; }

	/// <summary>금일매도정산금액</summary>
	public long CrdaySellAdjstAmt { get; set; }

	/// <summary>금일매수정산금액</summary>
	public long CrdayBuyAdjstAmt { get; set; }

	/// <summary>매도대금담보대출금액</summary>
	public long CslLoanAmtdt1 { get; set; }
}