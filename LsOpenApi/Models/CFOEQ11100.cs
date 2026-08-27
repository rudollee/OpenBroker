using OpenBroker.Extensions;
using OpenBroker.Models;

namespace LsOpenApi.Models;
/// <summary>
/// 선물옵션가정산예탁금상세
/// </summary>
internal class CFOEQ11100 : LsResponseCore
{
	public CFOEQ11100InBlock1 CFOEQ11100InBlock { get; set; } = new();
	public CFOEQ11100OutBlock1 CFOEQ11100OutBlock1 { get; set; } = new();
	public CFOEQ11100OutBlock2 CFOEQ11100OutBlock2 { get; set; } = new();
}

/// <summary>
/// 선물옵션가정산예탁금상세 - InBlock
/// </summary>
internal class CFOEQ11100InBlock1
{
	/// <summary>매매일</summary>
	public string BnsDt { get; set; } = DateTime.UtcNow.ToMarketTime(MarketZone.Seoul).ToDate8Txt();
}

/// <summary>
/// 선물옵션가정산예탁금상세 - OutBlock1
/// </summary>
internal class CFOEQ11100OutBlock1
{
	/// <summary>매매일</summary>
	public string BnsDt { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션가정산예탁금상세 - OutBlock2
/// </summary>
internal class CFOEQ11100OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>개장시예탁금총액</summary>
	public long OpnmkDpsamtTotamt { get; set; }

	/// <summary>개장시예수금</summary>
	public long OpnmkDps { get; set; }

	/// <summary>개장시현금미수금</summary>
	public long OpnmkMnyrclAmt { get; set; }

	/// <summary>개장시대용금액</summary>
	public long OpnmkSubstAmt { get; set; }

	/// <summary>총금액</summary>
	public long TotAmt { get; set; }

	/// <summary>예수금</summary>
	public long Dps { get; set; }

	/// <summary>현금미수금액</summary>
	public long MnyrclAmt { get; set; }

	/// <summary>대용지정금액</summary>
	public long SubstDsgnAmt { get; set; }

	/// <summary>위탁증거금액</summary>
	public long CsgnMgn { get; set; }

	/// <summary>현금위탁증거금액</summary>
	public long MnyCsgnMgn { get; set; }

	/// <summary>유지증거금액</summary>
	public long MaintMgn { get; set; }

	/// <summary>현금유지증거금액</summary>
	public long MnyMaintMgn { get; set; }

	/// <summary>출금가능총액</summary>
	public long OutAbleAmt { get; set; }

	/// <summary>출금가능금액</summary>
	public long MnyoutAbleAmt { get; set; }

	/// <summary>출금가능대용</summary>
	public long SubstOutAbleAmt { get; set; }

	/// <summary>주문가능금액</summary>
	public long OrdAbleAmt { get; set; }

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>추가증거금구분</summary>
	public string AddMgnOcrTpCode { get; set; } = string.Empty;

	/// <summary>추가증거금액</summary>
	public long AddMgn { get; set; }

	/// <summary>현금추가증거금액</summary>
	public long MnyAddMgn { get; set; }

	/// <summary>익일예탁총액</summary>
	public long NtdayTotAmt { get; set; }

	/// <summary>익일예탁현금</summary>
	public long NtdayDps { get; set; }

	/// <summary>익일미수금</summary>
	public long NtdayMnyrclAmt { get; set; }

	/// <summary>익일예탁대용</summary>
	public long NtdaySubstAmt { get; set; }

	/// <summary>익일위탁증거금</summary>
	public long NtdayCsgnMgn { get; set; }

	/// <summary>익일위탁증거금현금</summary>
	public long NtdayMnyCsgnMgn { get; set; }

	/// <summary>익일유지증거금</summary>
	public long NtdayMaintMgn { get; set; }

	/// <summary>익일유지증거금현금</summary>
	public long NtdayMnyMaintMgn { get; set; }

	/// <summary>익일인출가능금액</summary>
	public long NtdayOutAbleAmt { get; set; }

	/// <summary>익일인출가능금액</summary>
	public long NtdayMnyoutAbleAmt { get; set; }

	/// <summary>익일인출가능대용</summary>
	public long NtdaySubstOutAbleAmt { get; set; }

	/// <summary>익일주문가능금액</summary>
	public long NtdayOrdAbleAmt { get; set; }

	/// <summary>익일주문가능현금</summary>
	public long NtdayMnyOrdAbleAmt { get; set; }

	/// <summary>익일추가증거금구분</summary>
	public string NtdayAddMgnTp { get; set; } = string.Empty;

	/// <summary>익일추가증거금</summary>
	public long NtdayAddMgn { get; set; }

	/// <summary>익일추가증거금현금</summary>
	public long NtdayMnyAddMgn { get; set; }

	/// <summary>익일결제금액</summary>
	public long NtdaySettAmt { get; set; }

	/// <summary>평가예탁금총액</summary>
	public long EvalDpsamtTotamt { get; set; }

	/// <summary>현금평가예탁금액</summary>
	public long MnyEvalDpstgAmt { get; set; }

	/// <summary>예탁금이용료지급예정금액</summary>
	public long DpsamtUtlfeeGivPrergAmt { get; set; }

	/// <summary>세금</summary>
	public long TaxAmt { get; set; }

	/// <summary>위탁증거금 비율</summary>
	public decimal CsgnMgnrat { get; set; }

	/// <summary>위탁증거금현금비율</summary>
	public decimal CsgnMnyMgnrat { get; set; }

	/// <summary>예탁총액부족금액(위탁증거금기준)</summary>
	public long DpstgTotamtLackAmt { get; set; }

	/// <summary>예탁현금부족금액(위탁증거금기준)</summary>
	public long DpstgMnyLackAmt { get; set; }

	/// <summary>실입금액</summary>
	public long RealInAmt { get; set; }

	/// <summary>입금액</summary>
	public long InAmt { get; set; }

	/// <summary>출금액</summary>
	public long OutAmt { get; set; }

	/// <summary>선물정산차금</summary>
	public long FutsAdjstDfamt { get; set; }

	/// <summary>선물당일차금</summary>
	public long FutsThdayDfamt { get; set; }

	/// <summary>선물갱신차금</summary>
	public long FutsUpdtDfamt { get; set; }

	/// <summary>선물최종결제차금</summary>
	public long FutsLastSettDfamt { get; set; }

	/// <summary>옵션결제차금</summary>
	public long OptSettDfamt { get; set; }

	/// <summary>옵션매수금액</summary>
	public long OptBuyAmt { get; set; }

	/// <summary>옵션매도금액</summary>
	public long OptSellAmt { get; set; }

	/// <summary>옵션행사차금</summary>
	public long OptXrcDfamt { get; set; }

	/// <summary>옵션배정차금</summary>
	public long OptAsgnDfamt { get; set; }

	/// <summary>실물인수도금액</summary>
	public long RealGdsUndAmt { get; set; }

	/// <summary>실물인수도배정대금</summary>
	public long RealGdsUndAsgnAmt { get; set; }

	/// <summary>실물인수도행사대금</summary>
	public long RealGdsUndXrcAmt { get; set; }

	/// <summary>수수료</summary>
	public long CmsnAmt { get; set; }

	/// <summary>선물수수료</summary>
	public long FutsCmsn { get; set; }

	/// <summary>옵션수수료</summary>
	public long OptCmsn { get; set; }

	/// <summary>선물약정수량</summary>
	public long FutsCtrctQty { get; set; }

	/// <summary>선물약정금액</summary>
	public long FutsCtrctAmt { get; set; }

	/// <summary>옵션약정수량</summary>
	public long OptCtrctQty { get; set; }

	/// <summary>옵션약정금액</summary>
	public long OptCtrctAmt { get; set; }

	/// <summary>선물미결제수량</summary>
	public long FutsUnsttQty { get; set; }

	/// <summary>선물미결제금액</summary>
	public long FutsUnsttAmt { get; set; }

	/// <summary>옵션미결제수량</summary>
	public long OptUnsttQty { get; set; }

	/// <summary>옵션미결제금액</summary>
	public long OptUnsttAmt { get; set; }

	/// <summary>선물매수미결제수량</summary>
	public long FutsBuyUnsttQty { get; set; }

	/// <summary>선물매수미결제금액</summary>
	public long FutsBuyUnsttAmt { get; set; }

	/// <summary>선물매도미결제수량</summary>
	public long FutsSellUnsttQty { get; set; }

	/// <summary>선물매도미결제금액</summary>
	public long FutsSellUnsttAmt { get; set; }

	/// <summary>옵션매수미결제수량</summary>
	public long OptBuyUnsttQty { get; set; }

	/// <summary>옵션매수미결제금액</summary>
	public long OptBuyUnsttAmt { get; set; }

	/// <summary>옵션매도미결제수량</summary>
	public long OptSellUnsttQty { get; set; }

	/// <summary>옵션매도미결제금액</summary>
	public long OptSellUnsttAmt { get; set; }

	/// <summary>선물매수약정수량</summary>
	public long FutsBuyctrQty { get; set; }

	/// <summary>선물매수약정금액</summary>
	public long FutsBuyctrAmt { get; set; }

	/// <summary>선물매도약정수량</summary>
	public long FutsSlctrQty { get; set; }

	/// <summary>선물매도약정금액</summary>
	public long FutsSlctrAmt { get; set; }

	/// <summary>옵션매수약정수량</summary>
	public long OptBuyctrQty { get; set; }

	/// <summary>옵션매수약정금액</summary>
	public long OptBuyctrAmt { get; set; }

	/// <summary>옵션매도약정수량</summary>
	public long OptSlctrQty { get; set; }

	/// <summary>옵션매도약정금액</summary>
	public long OptSlctrAmt { get; set; }

	/// <summary>선물매매손익금액</summary>
	public long FutsBnsplAmt { get; set; }

	/// <summary>옵션매매손익금액</summary>
	public long OptBnsplAmt { get; set; }

	/// <summary>선물평가손익금액</summary>
	public long FutsEvalPnlAmt { get; set; }

	/// <summary>옵션평가손익금액</summary>
	public long OptEvalPnlAmt { get; set; }

	/// <summary>선물평가금액</summary>
	public long FutsEvalAmt { get; set; }

	/// <summary>옵션평가금액</summary>
	public long OptEvalAmt { get; set; }

	/// <summary>장종료후현금입금금액</summary>
	public long MktEndAfMnyInAmt { get; set; }

	/// <summary>장종료후현금출금금액</summary>
	public long MktEndAfMnyOutAmt { get; set; }

	/// <summary>장종료후대용지정금액</summary>
	public long MktEndAfSubstDsgnAmt { get; set; }

	/// <summary>장종료후대용해지금액</summary>
	public long MktEndAfSubstAbndAmt { get; set; }
}