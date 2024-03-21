namespace EBestOpenApi.Models;
/// <summary>
/// 현물주문
/// </summary>
internal class CSPAT00601 : EBestOrderResponseStandard
{
	public OutBlock1 CSPAT00601OutBlock1 { get; set; } = new();
	public OutBlock2 CSPAT00601OutBlock2 { get; set; } = new();

	public override Int64 OrderNo { get => CSPAT00601OutBlock2.OrdNo; }

	/// <summary>
	/// 현물주문 - OutBlock1
	/// </summary>
	internal class OutBlock1 : EBestOrderOutBlock1Common
	{
		/// <summary>주문가</summary>
		public decimal OrdPrc { get; set; }

		/// <summary>매매구분</summary>
		public string BnsTpCode { get; set; } = string.Empty;

		/// <summary>호가유형코드</summary>
		public string OrdprcPtnCode { get; set; } = string.Empty;

		/// <summary>프로그램호가유형코드</summary>
		public string PrgmOrdprcPtnCode { get; set; } = string.Empty;

		/// <summary>공매도가능여부</summary>
		public string StslAbleYn { get; set; } = string.Empty;

		/// <summary>공매도호가구분</summary>
		public string StslOrdprcTpCode { get; set; } = string.Empty;

		/// <summary>통신매체코드</summary>
		public string CommdaCode { get; set; } = string.Empty;

		/// <summary>신용거래코드</summary>
		public string MgntrnCode { get; set; } = string.Empty;

		/// <summary>대출일</summary>
		public string LoanDt { get; set; } = string.Empty;

		/// <summary>회원번호</summary>
		public string MbrNo { get; set; } = string.Empty;

		/// <summary>주문조건구분</summary>
		public string OrdCndiTpCode { get; set; } = string.Empty;

		/// <summary>전략코드</summary>
		public string StrtgCode { get; set; } = string.Empty;

		/// <summary>그룹ID</summary>
		public string GrpId { get; set; } = string.Empty;

		/// <summary>주문회차</summary>
		public long OrdSeqNo { get; set; }

		/// <summary>포트폴리오번호</summary>
		public long PtflNo { get; set; }

		/// <summary>바스켓번호</summary>
		public long BskNo { get; set; }

		/// <summary>트렌치번호</summary>
		public long TrchNo { get; set; }

		/// <summary>아이템번호</summary>
		public long ItemNo { get; set; }

		/// <summary>운용지시번호</summary>
		public string OpDrtnNo { get; set; } = string.Empty;

		/// <summary>유동성공급자여부</summary>
		public string LpYn { get; set; } = string.Empty;

		/// <summary>반대매매구분</summary>
		public string CvrgTpCode { get; set; } = string.Empty;

	}

	/// <summary>
	/// 현물주문 - OutBlock2
	/// </summary>
	internal class OutBlock2 : EBestOrderOutBlock2Common
	{
		/// <summary>관리사원번호</summary>
		public string MgempNo { get; set; } = string.Empty;

		/// <summary>주문금액</summary>
		public long OrdAmt { get; set; }

		/// <summary>예비주문번호</summary>
		public long SpareOrdNo { get; set; }

		/// <summary>반대매매일련번호</summary>
		public long CvrgSeqno { get; set; }

		/// <summary>예약주문번호</summary>
		public long RsvOrdNo { get; set; }

		/// <summary>실물주문수량</summary>
		public long SpotOrdQty { get; set; }

		/// <summary>재사용주문수량</summary>
		public long RuseOrdQty { get; set; }

		/// <summary>현금주문금액</summary>
		public long MnyOrdAmt { get; set; }

		/// <summary>대용주문금액</summary>
		public long SubstOrdAmt { get; set; }

		/// <summary>재사용주문금액</summary>
		public long RuseOrdAmt { get; set; }

	}
}

/// <summary>
/// 현물주문 - InBlock
/// </summary>
internal class CSPAT00601InBlock1 : EBestOrderInBlockCommon
{
	/// <summary>주문가</summary>
	public decimal OrdPrc { get; set; }

	/// <summary>매매구분</summary>
	public string BnsTpCode { get; set; } = string.Empty;

	/// <summary>호가유형코드</summary>
	public string OrdprcPtnCode { get; set; } = string.Empty;

	/// <summary>신용거래코드</summary>
	public string MgntrnCode { get; set; } = string.Empty;

	/// <summary>대출일</summary>
	public string LoanDt { get; set; } = string.Empty;

	/// <summary>주문조건구분</summary>
	public string OrdCndiTpCode { get; set; } = string.Empty;
}


internal class EBestOrderInBlockCommon
{
	/// <summary>종목번호</summary>
	public string IsuNo { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public decimal OrdQty { get; set; }
}

internal class EBestOrderOutBlock1Common
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>계좌번호</summary>
	public string AcntNo { get; set; } = string.Empty;

	/// <summary>입력비밀번호</summary>
	public string InptPwd { get; set; } = string.Empty;

	/// <summary>종목번호</summary>
	public string IsuNo { get; set; } = string.Empty;

	/// <summary>주문수량</summary>
	public long OrdQty { get; set; }
}

internal class EBestOrderOutBlock2Common
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>주문번호</summary>
	public long OrdNo { get; set; }

	/// <summary>주문시각</summary>
	public string OrdTime { get; set; } = string.Empty;

	/// <summary>주문시장코드</summary>
	public string OrdMktCode { get; set; } = string.Empty;

	/// <summary>주문유형코드</summary>
	public string OrdPtnCode { get; set; } = string.Empty;

	/// <summary>단축종목번호</summary>
	public string ShtnIsuNo { get; set; } = string.Empty;

	/// <summary>계좌명</summary>
	public string AcntNm { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string IsuNm { get; set; } = string.Empty;

}

internal class EBestOrderResponseStandard : EBestResponseCore 
{
	public virtual Int64 OrderNo { get; set; }
}