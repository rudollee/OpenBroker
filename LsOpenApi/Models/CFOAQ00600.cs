namespace LsOpenApi.Models;
/// <summary>
/// 선물옵션 계좌주문체결내역조회
/// </summary>
internal class CFOAQ00600 : LsResponseCore
{
	public CFOAQ00600InBlock1 CFOAQ00600InBlock { get; set; } = new();
	public CFOAQ00600OutBlock1 CFOAQ00600OutBlock1 { get; set; } = new();
	public CFOAQ00600OutBlock2 CFOAQ00600OutBlock2 { get; set; } = new();
	public List<CFOAQ00600OutBlock3> CFOAQ00600OutBlock3 { get; set; } = new();
}

/// <summary>
/// 선물옵션 계좌주문체결내역조회 - InBlock
/// </summary>
internal class CFOAQ00600InBlock1
{
	/// <summary>조회시작일</summary>
	public string QrySrtDt { get; set; } = string.Empty;

	/// <summary>조회종료일</summary>
	public string QryEndDt { get; set; } = string.Empty;

	/// <summary>선물옵션분류코드</summary>
	public string FnoClssCode { get; set; } = "00";

	/// <summary>상품군코드</summary>
	public string PrdgrpCode { get; set; } = "00";

	/// <summary>체결구분</summary>
	public string PrdtExecTpCode { get; set; } = "1";

	/// <summary>정렬순서구분</summary>
	public string StnlnSeqTp { get; set; } = "4";

	/// <summary>통신매체코드</summary>
	public string CommdaCode { get; set; } = "99";
}

/// <summary>
/// 선물옵션 계좌주문체결내역조회 - OutBlock1
/// </summary>
internal class CFOAQ00600OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; } = string.Empty;

	/// <summary>조회시작일</summary>
	public string QrySrtDt { get; set; } = string.Empty;

	/// <summary>조회종료일</summary>
	public string QryEndDt { get; set; } = string.Empty;

	/// <summary>선물옵션분류코드</summary>
	public string FnoClssCode { get; set; } = string.Empty;

	/// <summary>상품군코드</summary>
	public string PrdgrpCode { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	public string PrdtExecTpCode { get; set; } = string.Empty;

	/// <summary>정렬순서구분</summary>
	public string StnlnSeqTp { get; set; } = string.Empty;

	/// <summary>통신매체코드</summary>
	public string CommdaCode { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션 계좌주문체결내역조회 - OutBlock2
/// </summary>
internal class CFOAQ00600OutBlock2
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>선물주문수량</summary>
	public long FutsOrdQty { get; set; }

	/// <summary>선물체결수량</summary>
	public long FutsExecQty { get; set; }

	/// <summary>옵션주문수량</summary>
	public long OptOrdQty { get; set; }

	/// <summary>옵션체결수량</summary>
	public long OptExecQty { get; set; }
}

/// <summary>
/// 선물옵션 계좌주문체결내역조회 - OutBlock3
/// </summary>
internal class CFOAQ00600OutBlock3
{
	/// <summary>주문일</summary>
	public string OrdDt { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public long OrdNo { get; set; }

	/// <summary>원주문번호</summary>
	public long OrgOrdNo { get; set; }

	/// <summary>주문시각</summary>
	public string OrdTime { get; set; } = string.Empty;

	/// <summary>선물옵션종목번호</summary>
	public string FnoIsuNo { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string IsuNm { get; set; } = string.Empty;

	/// <summary>매매구분</summary>
	public string BnsTpNm { get; set; } = string.Empty;

	/// <summary>정정취소구분명</summary>
	public string MrcTpNm { get; set; } = string.Empty;

	/// <summary>선물옵션호가유형코드</summary>
	public string FnoOrdprcPtnCode { get; set; } = string.Empty;

	/// <summary>선물옵션호가유형명</summary>
	public string FnoOrdprcPtnNm { get; set; } = string.Empty;

	/// <summary>주문가</summary>
	public decimal OrdPrc { get; set; }

	/// <summary>주문수량</summary>
	public long OrdQty { get; set; }

	/// <summary>주문구분명</summary>
	public string OrdTpNm { get; set; } = string.Empty;

	/// <summary>체결구분명</summary>
	public string ExecTpNm { get; set; } = string.Empty;

	/// <summary>체결가</summary>
	public decimal ExecPrc { get; set; }

	/// <summary>체결수량</summary>
	public long ExecQty { get; set; }

	/// <summary>약정시각</summary>
	public string CtrctTime { get; set; } = string.Empty;

	/// <summary>약정번호</summary>
	public long CtrctNo { get; set; }

	/// <summary>체결번호</summary>
	public long ExecNo { get; set; }

	/// <summary>매매손익금액</summary>
	public long BnsplAmt { get; set; }

	/// <summary>미체결수량</summary>
	public long UnercQty { get; set; }

	/// <summary>사용자ID</summary>
	public string UserId { get; set; } = string.Empty;

	/// <summary>통신매체코드</summary>
	public string CommdaCode { get; set; } = string.Empty;

	/// <summary>통신매체코드명</summary>
	public string CommdaCodeNm { get; set; } = string.Empty;
}