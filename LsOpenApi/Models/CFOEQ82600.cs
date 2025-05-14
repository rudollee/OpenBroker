namespace LsOpenApi.Models;
/// <summary>
/// 선물옵션 일별 계좌손익내역
/// </summary>
internal class CFOEQ82600 : LsResponseCore
{
	public CFOEQ82600InBlock1 CFOEQ82600InBlock { get; set; } = new();
	public CFOEQ82600OutBlock1 CFOEQ82600OutBlock1 { get; set; } = new();
	public CFOEQ82600OutBlock2 CFOEQ82600OutBlock2 { get; set; } = new();
	public List<CFOEQ82600OutBlock3> CFOEQ82600OutBlock3 { get; set; } = new();
}

/// <summary>
/// 선물옵션 일별 계좌손익내역 - InBlock
/// </summary>
internal class CFOEQ82600InBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	public string Pwd { get; set; } = string.Empty;

	/// <summary>조회시작일</summary>
	public string QrySrtDt { get; set; } = string.Empty;

	/// <summary>조회종료일</summary>
	public string QryEndDt { get; set; } = string.Empty;

	/// <summary>조회구분</summary>
	public string QryTp { get; set; } = string.Empty;

	/// <summary>정렬순서구분</summary>
	public string StnlnSeqTp { get; set; } = string.Empty;

	/// <summary>선물옵션잔고평가구분코드</summary>
	public string FnoBalEvalTpCode { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션 일별 계좌손익내역 - OutBlock1
/// </summary>
internal class CFOEQ82600OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	public string Pwd { get; set; } = string.Empty;

	/// <summary>조회시작일</summary>
	public string QrySrtDt { get; set; } = string.Empty;

	/// <summary>조회종료일</summary>
	public string QryEndDt { get; set; } = string.Empty;

	/// <summary>조회구분</summary>
	public string QryTp { get; set; } = string.Empty;

	/// <summary>정렬순서구분</summary>
	public string StnlnSeqTp { get; set; } = string.Empty;

	/// <summary>선물옵션잔고평가구분코드</summary>
	public string FnoBalEvalTpCode { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션 일별 계좌손익내역 - OutBlock2
/// </summary>
internal class CFOEQ82600OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>선물정산차금</summary>
	public long FutsAdjstDfamt { get; set; }

	/// <summary>옵션매매손익금액</summary>
	public long OptBnsplAmt { get; set; }

	/// <summary>선물옵션수수료</summary>
	public long FnoCmsnAmt { get; set; }

	/// <summary>손익합계금액</summary>
	public long PnlSumAmt { get; set; }

	/// <summary>입금합계금액</summary>
	public long MnyinSumAmt { get; set; }

	/// <summary>출금합계금액</summary>
	public long MnyoutSumAmt { get; set; }

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션 일별 계좌손익내역 - OutBlock3
/// </summary>
internal class CFOEQ82600OutBlock3
{
	/// <summary>조회일</summary>
	public string QryDt { get; set; } = string.Empty;

	/// <summary>예탁총액</summary>
	public long DpstgTotamt { get; set; }

	/// <summary>예탁현금</summary>
	public long DpstgMny { get; set; }

	/// <summary>선물옵션증거금액</summary>
	public long FnoMgn { get; set; }

	/// <summary>선물손익금액</summary>
	public long FutsPnlAmt { get; set; }

	/// <summary>옵션매매손익금액</summary>
	public long OptBsnPnlAmt { get; set; }

	/// <summary>옵션평가손익금액</summary>
	public long OptEvalPnlAmt { get; set; }

	/// <summary>수수료</summary>
	public long CmsnAmt { get; set; }

	/// <summary>합계금액1</summary>
	public long SumAmt1 { get; set; }

	/// <summary>합계금액</summary>
	public long SumAmt2 { get; set; }

	/// <summary>손익합계금액</summary>
	public long PnlSumAmt { get; set; }

	/// <summary>선물매수금액</summary>
	public long FutsBuyAmt { get; set; }

	/// <summary>선물매도금액</summary>
	public long FutsSellAmt { get; set; }

	/// <summary>옵션매수금액</summary>
	public long OptBuyAmt { get; set; }

	/// <summary>옵션매도금액</summary>
	public long OptSellAmt { get; set; }

	/// <summary>입금액</summary>
	public long InAmt { get; set; }

	/// <summary>출금액</summary>
	public long OutAmt { get; set; }

	/// <summary>평가금액</summary>
	public long EvalAmt { get; set; }

	/// <summary>합산평가금액</summary>
	public long AddupEvalAmt { get; set; }

	/// <summary>금액2</summary>
	public long Amt2 { get; set; }
}