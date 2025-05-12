namespace LsOpenApi.Models;
/// <summary>
/// 선물옵션 계좌잔고 및 평가현황3
/// </summary>
internal class CFOAQ50600 : LsResponseCore
{
	public CFOAQ50600InBlock1 CFOAQ50600InBlock { get; set; } = new();
	public CFOAQ50600OutBlock1 CFOAQ50600OutBlock1 { get; set; } = new();
	public CFOAQ50600OutBlock2 CFOAQ50600OutBlock2 { get; set; } = new();
	public List<CFOAQ50600OutBlock3> CFOAQ50600OutBlock3 { get; set; } = new();
}

/// <summary>
/// 선물옵션 계좌잔고 및 평가현황3 - InBlock
/// </summary>
internal class CFOAQ50600InBlock1
{
	/// <summary>레코드갯수</summary>
	public int RecCnt { get; set; } = 1;

	/// <summary>주문일</summary>
	public string OrdDt { get; set; } = DateTime.UtcNow.AddHours(9).ToString("yyyyMMdd");

	/// <summary>잔고평가구분: 0.기본설정, 1.이동평균법, 2.선입선출법</summary>
	public string BalEvalTp { get; set; } = "0";

	/// <summary>선물가격평가구분: 1.당초가, 2.전일종가</summary>
	public string FutsPrcEvalTp { get; set; } = "2";

	/// <summary>청산수량조회구분</summary>
	public string LqdtQtyQryTp { get; set; } = "1";
}

/// <summary>
/// 선물옵션 계좌잔고 및 평가현황3 - OutBlock1
/// </summary>
internal class CFOAQ50600OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; } = string.Empty;

	/// <summary>주문일</summary>
	public string OrdDt { get; set; } = string.Empty;

	/// <summary>잔고평가구분</summary>
	public string BalEvalTp { get; set; } = string.Empty;

	/// <summary>선물가격평가구분</summary>
	public string FutsPrcEvalTp { get; set; } = string.Empty;

	/// <summary>청산수량조회구분</summary>
	public string LqdtQtyQryTp { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션 계좌잔고 및 평가현황3 - OutBlock2
/// </summary>
internal class CFOAQ50600OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>평가예탁금총액</summary>
	public long EvalDpsamtTotamt { get; set; }

	/// <summary>현금평가예탁금액</summary>
	public long MnyEvalDpstgAmt { get; set; }

	/// <summary>예탁금총액</summary>
	public long DpsamtTotamt { get; set; }

	/// <summary>예탁현금</summary>
	public long DpstgMny { get; set; }

	/// <summary>예탁대용</summary>
	public long DpstgSubst { get; set; }

	/// <summary>외화대용금액</summary>
	public long FcurrSubstAmt { get; set; }

	/// <summary>인출가능총금액</summary>
	public long PsnOutAbleTotAmt { get; set; }

	/// <summary>인출가능현금액</summary>
	public long PsnOutAbleCurAmt { get; set; }

	/// <summary>인출가능대용금액</summary>
	public long PsnOutAbleSubstAmt { get; set; }

	/// <summary>주문가능총금액</summary>
	public long OrdAbleTotAmt { get; set; }

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>위탁증거금총액</summary>
	public long CsgnMgnTotamt { get; set; }

	/// <summary>현금위탁증거금액</summary>
	public long MnyCsgnMgn { get; set; }

	/// <summary>유지증거금총액</summary>
	public long MtmgnTotamt { get; set; }

	/// <summary>현금유지증거금액</summary>
	public long MnyMaintMgn { get; set; }

	/// <summary>추가증거금총액</summary>
	public long AddMgnTotamt { get; set; }

	/// <summary>현금추가증거금액</summary>
	public long MnyAddMgn { get; set; }

	/// <summary>수수료</summary>
	public long CmsnAmt { get; set; }

	/// <summary>미수금액</summary>
	public long RcvblAmt { get; set; }

	/// <summary>미수연체료</summary>
	public long RcvblOdpnt { get; set; }

	/// <summary>선물평가손익금액</summary>
	public long FutsEvalPnlAmt { get; set; }

	/// <summary>옵션평가손익금액</summary>
	public long OptEvalPnlAmt { get; set; }

	/// <summary>옵션평가금액</summary>
	public long OptEvalAmt { get; set; }

	/// <summary>옵션매매손익금액</summary>
	public long OptBnsplAmt { get; set; }

	/// <summary>선물정산차금</summary>
	public long FutsAdjstDfamt { get; set; }

	/// <summary>옵션매매금액</summary>
	public long OptBnsAmt { get; set; }

	/// <summary>총손익금액</summary>
	public long TotPnlAmt { get; set; }

	/// <summary>순손익금액</summary>
	public long NetPnlAmt { get; set; }

	/// <summary>기준평가금액</summary>
	public long BaseEvalAmt { get; set; }

	/// <summary>계좌평가비율</summary>
	public decimal AcntEvalRat { get; set; }

	/// <summary>평가비율</summary>
	public decimal EvalRat { get; set; }
}

/// <summary>
/// 선물옵션 계좌잔고 및 평가현황3 - OutBlock3
/// </summary>
internal class CFOAQ50600OutBlock3
{
	/// <summary>선물옵션종목번호</summary>
	public string FnoIsuNo { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string IsuNm { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string BnsTpNm { get; set; } = string.Empty;

	/// <summary>미결제수량</summary>
	public long UnsttQty { get; set; }

	/// <summary>평균가</summary>
	public decimal FnoAvrPrc { get; set; }

	/// <summary>선물옵션현재가</summary>
	public decimal FnoNowPrc { get; set; }

	/// <summary>선물옵션대비가</summary>
	public decimal FnoCmpPrc { get; set; }

	/// <summary>평가손익</summary>
	public long EvalPnl { get; set; }

	/// <summary>손익율</summary>
	public decimal PnlRat { get; set; }

	/// <summary>평가금액</summary>
	public long EvalAmt { get; set; }

	/// <summary>평가비율</summary>
	public decimal EvalRat { get; set; }

	/// <summary>청산가능수량</summary>
	public long LqdtAbleQty { get; set; }

	/// <summary>매매손익금액</summary>
	public long BnsplAmt { get; set; }
}