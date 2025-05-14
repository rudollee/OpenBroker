namespace LsOpenApi.Models;
/// <summary>
/// 유렉스 예탁금 및 통합잔고조회
/// </summary>
internal class CEXAQ31200 : LsResponseCore
{
	public CEXAQ31200InBlock1 CEXAQ31200InBlock { get; set; } = new();
	public CEXAQ31200OutBlock1 CEXAQ31200OutBlock1 { get; set; } = new();
	public CEXAQ31200OutBlock2 CEXAQ31200OutBlock2 { get; set; } = new();
	public List<CEXAQ31200OutBlock3> CEXAQ31200OutBlock3 { get; set; } = new();
}

/// <summary>
/// 유렉스 예탁금 및 통합잔고조회 - InBlock
/// </summary>
internal class CEXAQ31200InBlock1
{
	/// <summary>잔고평가구분</summary>
	public string BalEvalTp { get; set; } = "0";

	/// <summary>선물가격평가구분</summary>
	public string FutsPrcEvalTp { get; set; } = "1";
}

/// <summary>
/// 유렉스 예탁금 및 통합잔고조회 - OutBlock1
/// </summary>
internal class CEXAQ31200OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; } = string.Empty;

	/// <summary>잔고평가구분</summary>
	public string BalEvalTp { get; set; } = string.Empty;

	/// <summary>선물가격평가구분</summary>
	public string FutsPrcEvalTp { get; set; } = string.Empty;
}

/// <summary>
/// 유렉스 예탁금 및 통합잔고조회 - OutBlock2
/// </summary>
internal class CEXAQ31200OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

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

	/// <summary>인출가능총금액</summary>
	public long PsnOutAbleTotAmt { get; set; }

	/// <summary>인출가능현금액</summary>
	public long PsnOutAbleCurAmt { get; set; }

	/// <summary>주문가능총금액</summary>
	public long OrdAbleTotAmt { get; set; }

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>위탁증거금총액</summary>
	public long CsgnMgnTotamt { get; set; }

	/// <summary>현금위탁증거금액</summary>
	public long MnyCsgnMgn { get; set; }

	/// <summary>추가증거금총액</summary>
	public long AddMgnTotamt { get; set; }

	/// <summary>현금추가증거금액</summary>
	public long MnyAddMgn { get; set; }

	/// <summary>수수료</summary>
	public long CmsnAmt { get; set; }

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

	/// <summary>총손익금액</summary>
	public long TotPnlAmt { get; set; }

	/// <summary>순손익금액</summary>
	public long NetPnlAmt { get; set; }

	/// <summary>총평가금액</summary>
	public long TotEvalAmt { get; set; }

	/// <summary>입금금액</summary>
	public long MnyinAmt { get; set; }

	/// <summary>출금금액</summary>
	public long MnyoutAmt { get; set; }

	/// <summary>선물수수료금액</summary>
	public long FutsCmsnAmt { get; set; }
}

/// <summary>
/// 유렉스 예탁금 및 통합잔고조회 - OutBlock3
/// </summary>
internal class CEXAQ31200OutBlock3
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

	/// <summary>현재가</summary>
	public decimal NowPrc { get; set; }

	/// <summary>대비가</summary>
	public decimal CmpPrc { get; set; }

	/// <summary>평가손익</summary>
	public long EvalPnl { get; set; }

	/// <summary>손익률</summary>
	public decimal PnlRat { get; set; }

	/// <summary>평가금액</summary>
	public long EvalAmt { get; set; }

	/// <summary>청산가능수량</summary>
	public long LqdtAbleQty { get; set; }
}