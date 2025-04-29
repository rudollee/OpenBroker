using System.Text.Json.Serialization;

namespace KisOpenApi.Models.KrxEquity;
/// <summary>
/// 국내주식기간별시세(일_주_월_년)
/// </summary>
internal class FHKST03010100 : KisResponseBase
{
	public FHKST03010100Output1 Output1 { get; set; } = new();
	public List<FHKST03010100Output2> Output2 { get; set; } = [];

	internal class FHKST03010100Output1
	{
		/// <summary>전일 대비</summary>
		[JsonPropertyName("prdy_vrss")]
		public string prdy_vrss { get; set; } = string.Empty;

		/// <summary>전일 대비 부호</summary>
		[JsonPropertyName("prdy_vrss_sign")]
		public string prdy_vrss_sign { get; set; } = string.Empty;

		/// <summary>전일 대비율</summary>
		[JsonPropertyName("prdy_ctrt")]
		public string prdy_ctrt { get; set; } = string.Empty;

		/// <summary>주식 전일 종가</summary>
		[JsonPropertyName("stck_prdy_clpr")]
		public string stck_prdy_clpr { get; set; } = string.Empty;

		/// <summary>누적 거래량</summary>
		[JsonPropertyName("acml_vol")]
		public string acml_vol { get; set; } = string.Empty;

		/// <summary>누적 거래 대금</summary>
		[JsonPropertyName("acml_tr_pbmn")]
		public string acml_tr_pbmn { get; set; } = string.Empty;

		/// <summary>HTS 한글 종목명</summary>
		[JsonPropertyName("hts_kor_isnm")]
		public string hts_kor_isnm { get; set; } = string.Empty;

		/// <summary>주식 현재가</summary>
		[JsonPropertyName("stck_prpr")]
		public string stck_prpr { get; set; } = string.Empty;

		/// <summary>주식 단축 종목코드</summary>
		[JsonPropertyName("stck_shrn_iscd")]
		public string stck_shrn_iscd { get; set; } = string.Empty;

		/// <summary>전일 거래량</summary>
		[JsonPropertyName("prdy_vol")]
		public string prdy_vol { get; set; } = string.Empty;

		/// <summary>주식 상한가</summary>
		[JsonPropertyName("stck_mxpr")]
		public string stck_mxpr { get; set; } = string.Empty;

		/// <summary>주식 하한가</summary>
		[JsonPropertyName("stck_llam")]
		public string stck_llam { get; set; } = string.Empty;

		/// <summary>주식 시가2</summary>
		[JsonPropertyName("stck_oprc")]
		public string stck_oprc { get; set; } = string.Empty;

		/// <summary>주식 최고가</summary>
		[JsonPropertyName("stck_hgpr")]
		public string stck_hgpr { get; set; } = string.Empty;

		/// <summary>주식 최저가</summary>
		[JsonPropertyName("stck_lwpr")]
		public string stck_lwpr { get; set; } = string.Empty;

		/// <summary>주식 전일 시가</summary>
		[JsonPropertyName("stck_prdy_oprc")]
		public string stck_prdy_oprc { get; set; } = string.Empty;

		/// <summary>주식 전일 최고가</summary>
		[JsonPropertyName("stck_prdy_hgpr")]
		public string stck_prdy_hgpr { get; set; } = string.Empty;

		/// <summary>주식 전일 최저가</summary>
		[JsonPropertyName("stck_prdy_lwpr")]
		public string stck_prdy_lwpr { get; set; } = string.Empty;

		/// <summary>매도호가</summary>
		[JsonPropertyName("askp")]
		public string askp { get; set; } = string.Empty;

		/// <summary>매수호가</summary>
		[JsonPropertyName("bidp")]
		public string bidp { get; set; } = string.Empty;

		/// <summary>전일 대비 거래량</summary>
		[JsonPropertyName("prdy_vrss_vol")]
		public string prdy_vrss_vol { get; set; } = string.Empty;

		/// <summary>거래량 회전율</summary>
		[JsonPropertyName("vol_tnrt")]
		public string vol_tnrt { get; set; } = string.Empty;

		/// <summary>주식 액면가</summary>
		[JsonPropertyName("stck_fcam")]
		public string stck_fcam { get; set; } = string.Empty;

		/// <summary>상장 주수</summary>
		[JsonPropertyName("lstn_stcn")]
		public string lstn_stcn { get; set; } = string.Empty;

		/// <summary>자본금</summary>
		[JsonPropertyName("cpfn")]
		public string cpfn { get; set; } = string.Empty;

		/// <summary>HTS 시가총액</summary>
		[JsonPropertyName("hts_avls")]
		public string hts_avls { get; set; } = string.Empty;

		/// <summary>PER</summary>
		[JsonPropertyName("per")]
		public string per { get; set; } = string.Empty;

		/// <summary>EPS</summary>
		[JsonPropertyName("eps")]
		public string eps { get; set; } = string.Empty;

		/// <summary>PBR</summary>
		[JsonPropertyName("pbr")]
		public string pbr { get; set; } = string.Empty;

		/// <summary>전체 융자 잔고 비율</summary>
		[JsonPropertyName("itewhol_loan_rmnd_ratem")]
		public string itewhol_loan_rmnd_ratem { get; set; } = string.Empty;
	}

	internal class FHKST03010100Output2
	{
		/// <summary>주식 영업 일자</summary>
		public string stck_bsop_date { get; set; } = string.Empty;

		/// <summary>주식 종가</summary>
		public string stck_clpr { get; set; } = string.Empty;

		/// <summary>주식 시가2</summary>
		public string stck_oprc { get; set; } = string.Empty;

		/// <summary>주식 최고가</summary>
		public string stck_hgpr { get; set; } = string.Empty;

		/// <summary>주식 최저가</summary>
		public string stck_lwpr { get; set; } = string.Empty;

		/// <summary>누적 거래량</summary>
		public string acml_vol { get; set; } = string.Empty;

		/// <summary>누적 거래 대금</summary>
		public string acml_tr_pbmn { get; set; } = string.Empty;

		/// <summary>락 구분 코드</summary>
		public string flng_cls_code { get; set; } = string.Empty;

		/// <summary>분할 비율</summary>
		public string prtt_rate { get; set; } = string.Empty;

		/// <summary>변경 여부</summary>
		public string mod_yn { get; set; } = string.Empty;

		/// <summary>전일 대비 부호</summary>
		public string prdy_vrss_sign { get; set; } = string.Empty;

		/// <summary>전일 대비</summary>
		public string prdy_vrss { get; set; } = string.Empty;

		/// <summary>재평가사유코드</summary>
		public string revl_issu_reas { get; set; } = string.Empty;
	}
}

