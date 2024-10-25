namespace LsOpenApi.Models;
/// <summary>
/// 현물계좌증거금률별주문가능수량조회
/// </summary>
internal class CSPBQ00200 : LsResponseCore
{
	public CSPBQ00200InBlock1 CSPBQ00200InBlock { get; set; } = new();
	public CSPBQ00200OutBlock1 CSPBQ00200OutBlock1 { get; set; } = new();
	public CSPBQ00200OutBlock2 CSPBQ00200OutBlock2 { get; set; } = new();
}

/// <summary>
/// 현물계좌증거금률별주문가능수량조회 - InBlock
/// </summary>
internal class CSPBQ00200InBlock1
{
	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; } = string.Empty;

	/// <summary>주문가격</summary>
	public decimal OrdPrc { get; set; }
}

/// <summary>
/// 현물계좌증거금률별주문가능수량조회 - OutBlock1
/// </summary>
internal class CSPBQ00200OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; } = string.Empty;

	/// <summary>주문가격</summary>
	public decimal OrdPrc { get; set; }

	/// <summary>통신매체코드</summary>
	public string RegCommdaCode { get; set; } = string.Empty;
}

/// <summary>
/// 현물계좌증거금률별주문가능수량조회 - OutBlock2
/// </summary>
internal class CSPBQ00200OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string IsuNm { get; set; } = string.Empty;

	/// <summary>예수금</summary>
	public long Dps { get; set; }

	/// <summary>대용금액</summary>
	public long SubstAmt { get; set; }

	/// <summary>신용담보재사용금액</summary>
	public long CrdtPldgRuseAmt { get; set; }

	/// <summary>현금주문가능금액</summary>
	public long MnyOrdAbleAmt { get; set; }

	/// <summary>대용주문가능금액</summary>
	public long SubstOrdAbleAmt { get; set; }

	/// <summary>현금증거금액</summary>
	public long MnyMgn { get; set; }

	/// <summary>대용증거금액</summary>
	public long SubstMgn { get; set; }

	/// <summary>거래소금액</summary>
	public long SeOrdAbleAmt { get; set; }

	/// <summary>코스닥금액</summary>
	public long KdqOrdAbleAmt { get; set; }

	/// <summary>추정예수금(D+1)</summary>
	public long PrsmptDpsD1 { get; set; }

	/// <summary>추정예수금(D+2)</summary>
	public long PrsmptDpsD2 { get; set; }

	/// <summary>출금가능금액</summary>
	public long MnyoutAbleAmt { get; set; }

	/// <summary>미수금액</summary>
	public long RcvblAmt { get; set; }

	/// <summary>수수료율</summary>
	public decimal CmsnRat { get; set; }

	/// <summary>추가징수금액</summary>
	public long AddLevyAmt { get; set; }

	/// <summary>재사용대상금액</summary>
	public long RuseObjAmt { get; set; }

	/// <summary>현금재사용대상금액</summary>
	public long MnyRuseObjAmt { get; set; }

	/// <summary>이용사증거금률</summary>
	public decimal FirmMgnRat { get; set; }

	/// <summary>대용재사용대상금액</summary>
	public long SubstRuseObjAmt { get; set; }

	/// <summary>종목증거금률</summary>
	public decimal IsuMgnRat { get; set; }

	/// <summary>계좌증거금률</summary>
	public decimal AcntMgnRat { get; set; }

	/// <summary>거래증거금률</summary>
	public decimal TrdMgnrt { get; set; }

	/// <summary>수수료</summary>
	public long Cmsn { get; set; }

	/// <summary>증거금률20퍼센트주문가능금액</summary>
	public long MgnRat20pctOrdAbleAmt { get; set; }

	/// <summary>증거금률100퍼센트현금주문가능수량?</summary>
	public long MgnRat20OrdAbleQty { get; set; }

	/// <summary>증거금률30퍼센트주문가능금액</summary>
	public long MgnRat30pctOrdAbleAmt { get; set; }

	/// <summary>증거금률30퍼센트주문가능수량??</summary>
	public long MgnRat30OrdAbleQty { get; set; }

	/// <summary>증거금률40퍼센트주문가능금액</summary>
	public long MgnRat40pctOrdAbleAmt { get; set; }

	/// <summary>증거금률40퍼센트주문가능수량??</summary>
	public long MgnRat40OrdAbleQty { get; set; }

	/// <summary>증거금률100퍼센트주문가능금액</summary>
	public long MgnRat100pctOrdAbleAmt { get; set; }

	/// <summary>증거금률100퍼센트주문가능수량??</summary>
	public long MgnRat100OrdAbleQty { get; set; }

	/// <summary>증거금률100퍼센트현금주문가능금액?</summary>
	public long MgnRat100MnyOrdAbleAmt { get; set; }

	/// <summary>증거금률100퍼센트현금주문가능수량</summary>
	public long MgnRat100MnyOrdAbleQty { get; set; }

	/// <summary>증거금률20퍼센트재사용가능금액</summary>
	public long MgnRat20pctRuseAbleAmt { get; set; }

	/// <summary>증거금률30퍼센트재사용가능금액</summary>
	public long MgnRat30pctRuseAbleAmt { get; set; }

	/// <summary>증거금률40퍼센트재사용가능금액</summary>
	public long MgnRat40pctRuseAbleAmt { get; set; }

	/// <summary>증거금률100퍼센트재사용가능금액</summary>
	public long MgnRat100pctRuseAbleAmt { get; set; }

	/// <summary>주문가능수량</summary>
	public long OrdAbleQty { get; set; }

	/// <summary>주문가능금액</summary>
	public long OrdAbleAmt { get; set; }
}