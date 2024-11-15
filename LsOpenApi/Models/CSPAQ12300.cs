namespace LsOpenApi.Models;
/// <summary>
/// BEP단가조회
/// </summary>
internal class CSPAQ12300 : LsResponseCore
{
	public CSPAQ12300InBlock1 CSPAQ12300InBlock { get; set; } = new();
	public CSPAQ12300OutBlock1 CSPAQ12300OutBlock1 { get; set; } = new();
	public CSPAQ12300OutBlock2 CSPAQ12300OutBlock2 { get; set; } = new();
	public List<CSPAQ12300OutBlock3> CSPAQ12300OutBlock3 { get; set; } = new();
}

/// <summary>
/// BEP단가조회 - InBlock
/// </summary>
internal class CSPAQ12300InBlock1
{
	/// <summary>잔고생성구분</summary>
	public string BalCreTp { get; set; } = string.Empty;

	/// <summary>수수료적용구분</summary>
	public string CmsnAppTpCode { get; set; } = string.Empty;

	/// <summary>D2잔고기준조회구분</summary>
	public string D2balBaseQryTp { get; set; } = string.Empty;

	/// <summary>단가구분</summary>
	public string UprcTpCode { get; set; } = string.Empty;
}

/// <summary>
/// BEP단가조회 - OutBlock1
/// </summary>
internal class CSPAQ12300OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	public string Pwd { get; set; } = string.Empty;

	/// <summary>잔고생성구분</summary>
	public string BalCreTp { get; set; } = string.Empty;

	/// <summary>수수료적용구분</summary>
	public string CmsnAppTpCode { get; set; } = string.Empty;

	/// <summary>D2잔고기준조회구분</summary>
	public string D2balBaseQryTp { get; set; } = string.Empty;

	/// <summary>단가구분</summary>
	public string UprcTpCode { get; set; } = string.Empty;

}

/// <summary>
/// BEP단가조회 - OutBlock2
/// </summary>
internal class CSPAQ12300OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>지점명</summary>
	public string BrnNm { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>출금가능금액</summary>
	public long MnyoutAbleAmt { get; set; }

	/// <summary>거래소금액</summary>
	public long SeOrdAbleAmt { get; set; }

	/// <summary>코스닥금액</summary>
	public long KdqOrdAbleAmt { get; set; }

	/// <summary>HTS주문가능금액</summary>
	public long HtsOrdAbleAmt { get; set; }

	/// <summary>증거금률100퍼센트주문가능금액</summary>
	public long MgnRat100pctOrdAbleAmt { get; set; }

	/// <summary>잔고평가금액</summary>
	public long BalEvalAmt { get; set; }

	/// <summary>매입금액</summary>
	public long PchsAmt { get; set; }

	/// <summary>미수금액</summary>
	public long RcvblAmt { get; set; }

	/// <summary>손익율</summary>
	public decimal PnlRat { get; set; }

	/// <summary>투자원금</summary>
	public long InvstOrgAmt { get; set; }

	/// <summary>투자손익금액</summary>
	public long InvstPlAmt { get; set; }

	/// <summary>신용담보주문금액</summary>
	public long CrdtPldgOrdAmt { get; set; }

	/// <summary>예수금</summary>
	public long Dps { get; set; }

	/// <summary>D1예수금</summary>
	public long D1Dps { get; set; }

	/// <summary>D2예수금</summary>
	public long D2Dps { get; set; }

	/// <summary>주문일</summary>
	public string OrdDt { get; set; } = string.Empty;

	/// <summary>현금증거금액</summary>
	public long MnyMgn { get; set; }

	/// <summary>대용증거금액</summary>
	public long SubstMgn { get; set; }

	/// <summary>대용금액</summary>
	public long SubstAmt { get; set; }

	/// <summary>전일매수체결금액</summary>
	public long PrdayBuyExecAmt { get; set; }

	/// <summary>전일매도체결금액</summary>
	public long PrdaySellExecAmt { get; set; }

	/// <summary>금일매수체결금액</summary>
	public long CrdayBuyExecAmt { get; set; }

	/// <summary>금일매도체결금액</summary>
	public long CrdaySellExecAmt { get; set; }

	/// <summary>평가손익합계</summary>
	public long EvalPnlSum { get; set; }

	/// <summary>예탁자산총액</summary>
	public long DpsastTotamt { get; set; }

	/// <summary>제비용</summary>
	public long Evrprc { get; set; }

	/// <summary>재사용금액</summary>
	public long RuseAmt { get; set; }

	/// <summary>기타대여금액</summary>
	public long EtclndAmt { get; set; }

	/// <summary>가정산금액</summary>
	public long PrcAdjstAmt { get; set; }

	/// <summary>D1수수료</summary>
	public long D1CmsnAmt { get; set; }

	/// <summary>D2수수료</summary>
	public long D2CmsnAmt { get; set; }

	/// <summary>D1제세금</summary>
	public long D1EvrTax { get; set; }

	/// <summary>D2제세금</summary>
	public long D2EvrTax { get; set; }

	/// <summary>D1결제예정금액</summary>
	public long D1SettPrergAmt { get; set; }

	/// <summary>D2결제예정금액</summary>
	public long D2SettPrergAmt { get; set; }

	/// <summary>전일KSE현금증거금</summary>
	public long PrdayKseMnyMgn { get; set; }

	/// <summary>전일KSE대용증거금</summary>
	public long PrdayKseSubstMgn { get; set; }

	/// <summary>전일KSE신용현금증거금</summary>
	public long PrdayKseCrdtMnyMgn { get; set; }

	/// <summary>전일KSE신용대용증거금</summary>
	public long PrdayKseCrdtSubstMgn { get; set; }

	/// <summary>금일KSE현금증거금</summary>
	public long CrdayKseMnyMgn { get; set; }

	/// <summary>금일KSE대용증거금</summary>
	public long CrdayKseSubstMgn { get; set; }

	/// <summary>금일KSE신용현금증거금</summary>
	public long CrdayKseCrdtMnyMgn { get; set; }

	/// <summary>금일KSE신용대용증거금</summary>
	public long CrdayKseCrdtSubstMgn { get; set; }

	/// <summary>전일코스닥현금증거금</summary>
	public long PrdayKdqMnyMgn { get; set; }

	/// <summary>전일코스닥대용증거금</summary>
	public long PrdayKdqSubstMgn { get; set; }

	/// <summary>전일코스닥신용현금증거금</summary>
	public long PrdayKdqCrdtMnyMgn { get; set; }

	/// <summary>전일코스닥신용대용증거금</summary>
	public long PrdayKdqCrdtSubstMgn { get; set; }

	/// <summary>금일코스닥현금증거금</summary>
	public long CrdayKdqMnyMgn { get; set; }

	/// <summary>금일코스닥대용증거금</summary>
	public long CrdayKdqSubstMgn { get; set; }

	/// <summary>금일코스닥신용현금증거금</summary>
	public long CrdayKdqCrdtMnyMgn { get; set; }

	/// <summary>금일코스닥신용대용증거금</summary>
	public long CrdayKdqCrdtSubstMgn { get; set; }

	/// <summary>전일프리보드현금증거금</summary>
	public long PrdayFrbrdMnyMgn { get; set; }

	/// <summary>전일프리보드대용증거금</summary>
	public long PrdayFrbrdSubstMgn { get; set; }

	/// <summary>금일프리보드현금증거금</summary>
	public long CrdayFrbrdMnyMgn { get; set; }

	/// <summary>금일프리보드대용증거금</summary>
	public long CrdayFrbrdSubstMgn { get; set; }

	/// <summary>전일장외현금증거금</summary>
	public long PrdayCrbmkMnyMgn { get; set; }

	/// <summary>전일장외대용증거금</summary>
	public long PrdayCrbmkSubstMgn { get; set; }

	/// <summary>금일장외현금증거금</summary>
	public long CrdayCrbmkMnyMgn { get; set; }

	/// <summary>금일장외대용증거금</summary>
	public long CrdayCrbmkSubstMgn { get; set; }

	/// <summary>예탁담보수량</summary>
	public long DpspdgQty { get; set; }

	/// <summary>매수정산금(D+2)</summary>
	public long BuyAdjstAmtD2 { get; set; }

	/// <summary>매도정산금(D+2)</summary>
	public long SellAdjstAmtD2 { get; set; }

	/// <summary>변제소요금(D+1)</summary>
	public long RepayRqrdAmtD1 { get; set; }

	/// <summary>변제소요금(D+2)</summary>
	public long RepayRqrdAmtD2 { get; set; }

	/// <summary>대출금액</summary>
	public long LoanAmt { get; set; }

}

/// <summary>
/// BEP단가조회 - OutBlock3
/// </summary>
internal class CSPAQ12300OutBlock3
{
	/// <summary>종목번호</summary>
	public string IsuNo { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string IsuNm { get; set; } = string.Empty;

	/// <summary>유가증권잔고유형코드</summary>
	public string SecBalPtnCode { get; set; } = string.Empty;

	/// <summary>유가증권잔고유형명</summary>
	public string SecBalPtnNm { get; set; } = string.Empty;

	/// <summary>잔고수량</summary>
	public long BalQty { get; set; }

	/// <summary>매매기준잔고수량</summary>
	public long BnsBaseBalQty { get; set; }

	/// <summary>금일매수체결수량</summary>
	public long CrdayBuyExecQty { get; set; }

	/// <summary>금일매도체결수량</summary>
	public long CrdaySellExecQty { get; set; }

	/// <summary>매도가</summary>
	public decimal SellPrc { get; set; }

	/// <summary>매수가</summary>
	public decimal BuyPrc { get; set; }

	/// <summary>매도손익금액</summary>
	public long SellPnlAmt { get; set; }

	/// <summary>손익율</summary>
	public decimal PnlRat { get; set; }

	/// <summary>현재가</summary>
	public decimal NowPrc { get; set; }

	/// <summary>신용금액</summary>
	public long CrdtAmt { get; set; }

	/// <summary>만기일</summary>
	public string DueDt { get; set; } = string.Empty;

	/// <summary>전일매도체결가</summary>
	public decimal PrdaySellExecPrc { get; set; }

	/// <summary>전일매도수량</summary>
	public long PrdaySellQty { get; set; }

	/// <summary>전일매수체결가</summary>
	public decimal PrdayBuyExecPrc { get; set; }

	/// <summary>전일매수수량</summary>
	public long PrdayBuyQty { get; set; }

	/// <summary>대출일</summary>
	public string LoanDt { get; set; } = string.Empty;

	/// <summary>평균단가</summary>
	public decimal AvrUprc { get; set; }

	/// <summary>매도가능수량</summary>
	public long SellAbleQty { get; set; }

	/// <summary>매도주문수량</summary>
	public long SellOrdQty { get; set; }

	/// <summary>금일매수체결금액</summary>
	public long CrdayBuyExecAmt { get; set; }

	/// <summary>금일매도체결금액</summary>
	public long CrdaySellExecAmt { get; set; }

	/// <summary>전일매수체결금액</summary>
	public long PrdayBuyExecAmt { get; set; }

	/// <summary>전일매도체결금액</summary>
	public long PrdaySellExecAmt { get; set; }

	/// <summary>잔고평가금액</summary>
	public long BalEvalAmt { get; set; }

	/// <summary>평가손익</summary>
	public long EvalPnl { get; set; }

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>주문가능금액</summary>
	public long OrdAbleAmt { get; set; }

	/// <summary>매도미체결수량</summary>
	public long SellUnercQty { get; set; }

	/// <summary>매도미결제수량</summary>
	public long SellUnsttQty { get; set; }

	/// <summary>매수미체결수량</summary>
	public long BuyUnercQty { get; set; }

	/// <summary>매수미결제수량</summary>
	public long BuyUnsttQty { get; set; }

	/// <summary>미결제수량</summary>
	public long UnsttQty { get; set; }

	/// <summary>미체결수량</summary>
	public long UnercQty { get; set; }

	/// <summary>전일종가</summary>
	public decimal PrdayCprc { get; set; }

	/// <summary>매입금액</summary>
	public long PchsAmt { get; set; }

	/// <summary>등록시장코드</summary>
	public string RegMktCode { get; set; } = string.Empty;

	/// <summary>대출상세분류코드</summary>
	public string LoanDtlClssCode { get; set; } = string.Empty;

	/// <summary>예탁담보대출수량</summary>
	public long DpspdgLoanQty { get; set; }
}