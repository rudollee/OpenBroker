namespace LsOpenApi.Models;
internal class CSPAT00701 : LsOrderResponseStandard
{
	public OutBlock1 CSPAT00701OutBlock1 { get; set; } = new();
	public OutBlock2 CSPAT00701OutBlock2 { get; set; } = new();

	public override Int64 OrderNo { get => CSPAT00701OutBlock2.OrdNo; }

	/// <summary>
	/// 현물정정주문 - OutBlock1
	/// </summary>
	internal class OutBlock1 : LsOrderOutBlock1Common
	{
		/// <summary>원주문번호</summary>
		public long OrgOrdNo { get; set; }

		/// <summary>호가유형코드</summary>
		public string OrdprcPtnCode { get; set; } = string.Empty;

		/// <summary>주문조건구분</summary>
		public string OrdCndiTpCode { get; set; } = string.Empty;

		/// <summary>주문가</summary>
		public decimal OrdPrc { get; set; }

		/// <summary>통신매체코드</summary>
		public string CommdaCode { get; set; } = string.Empty;

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

	}

	/// <summary>
	/// 현물정정주문 - OutBlock2
	/// </summary>
	internal class OutBlock2 : LsOrderOutBlock2Common
	{
		/// <summary>모주문번호</summary>
		public long PrntOrdNo { get; set; }

		/// <summary>프로그램호가유형코드</summary>
		public string PrgmOrdprcPtnCode { get; set; } = string.Empty;

		/// <summary>공매도호가구분</summary>
		public string StslOrdprcTpCode { get; set; } = string.Empty;

		/// <summary>공매도가능여부</summary>
		public string StslAbleYn { get; set; } = string.Empty;

		/// <summary>신용거래코드</summary>
		public string MgntrnCode { get; set; } = string.Empty;

		/// <summary>대출일</summary>
		public string LoanDt { get; set; } = string.Empty;

		/// <summary>반대매매주문구분</summary>
		public string CvrgOrdTp { get; set; } = string.Empty;

		/// <summary>유동성공급자여부</summary>
		public string LpYn { get; set; } = string.Empty;

		/// <summary>관리사원번호</summary>
		public string MgempNo { get; set; } = string.Empty;

		/// <summary>주문금액</summary>
		public long OrdAmt { get; set; }

		/// <summary>매매구분</summary>
		public string BnsTpCode { get; set; } = string.Empty;

		/// <summary>예비주문번호</summary>
		public long SpareOrdNo { get; set; }

		/// <summary>반대매매일련번호</summary>
		public long CvrgSeqno { get; set; }

		/// <summary>예약주문번호</summary>
		public long RsvOrdNo { get; set; }

		/// <summary>현금주문금액</summary>
		public long MnyOrdAmt { get; set; }

		/// <summary>대용주문금액</summary>
		public long SubstOrdAmt { get; set; }

		/// <summary>재사용주문금액</summary>
		public long RuseOrdAmt { get; set; }

	}
}

/// <summary>
/// 현물정정주문 - InBlock
/// </summary>
internal class CSPAT00701InBlock1 : LsOrderInBlockCommon
{
	/// <summary>원주문번호</summary>
	public long OrgOrdNo { get; set; }

	/// <summary>호가유형코드</summary>
	public string OrdprcPtnCode { get; set; } = string.Empty;

	/// <summary>주문조건구분</summary>
	public string OrdCndiTpCode { get; set; } = string.Empty;

	/// <summary>주문가</summary>
	public decimal OrdPrc { get; set; }
}