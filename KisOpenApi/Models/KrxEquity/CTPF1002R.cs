using System.Text.Json.Serialization;

namespace KisOpenApi.Models.KrxEquity;
/// <summary>
/// 주식기본조회
/// </summary>
internal class CTPF1002R : KisResponseBase
{
	/// <summary>응답상세1</summary>
	[JsonPropertyName("output")]
	public CTPF1002ROutput Output { get; set; } = new();

	internal class CTPF1002ROutput
	{
		/// <summary>상품번호</summary>
		[JsonPropertyName("pdno")]
		public string Pdno { get; set; } = string.Empty;

		/// <summary>상품유형코드</summary>
		[JsonPropertyName("prdt_type_cd")]
		public string PrdtTypeCd { get; set; } = string.Empty;

		/// <summary>시장ID코드</summary>
		[JsonPropertyName("mket_id_cd")]
		public string MketIdCd { get; set; } = string.Empty;

		/// <summary>증권그룹ID코드</summary>
		[JsonPropertyName("scty_grp_id_cd")]
		public string SctyGrpIdCd { get; set; } = string.Empty;

		/// <summary>거래소구분코드</summary>
		[JsonPropertyName("excg_dvsn_cd")]
		public string ExcgDvsnCd { get; set; } = string.Empty;

		/// <summary>결산월일</summary>
		[JsonPropertyName("setl_mmdd")]
		public string SetlMmdd { get; set; } = string.Empty;

		/// <summary>상장주수</summary>
		[JsonPropertyName("lstg_stqt")]
		public string LstgStqt { get; set; } = string.Empty;

		/// <summary>상장자본금액</summary>
		[JsonPropertyName("lstg_cptl_amt")]
		public string LstgCptlAmt { get; set; } = string.Empty;

		/// <summary>자본금</summary>
		[JsonPropertyName("cpta")]
		public string Cpta { get; set; } = string.Empty;

		/// <summary>액면가</summary>
		[JsonPropertyName("papr")]
		public string Papr { get; set; } = string.Empty;

		/// <summary>발행가격</summary>
		[JsonPropertyName("issu_pric")]
		public string IssuPric { get; set; } = string.Empty;

		/// <summary>코스피200종목여부</summary>
		[JsonPropertyName("kospi200_item_yn")]
		public string Kospi200ItemYn { get; set; } = string.Empty;

		/// <summary>유가증권시장상장일자</summary>
		[JsonPropertyName("scts_mket_lstg_dt")]
		public string SctsMketLstgDt { get; set; } = string.Empty;

		/// <summary>유가증권시장상장폐지일자</summary>
		[JsonPropertyName("scts_mket_lstg_abol_dt")]
		public string SctsMketLstgAbolDt { get; set; } = string.Empty;

		/// <summary>코스닥시장상장일자</summary>
		[JsonPropertyName("kosdaq_mket_lstg_dt")]
		public string KosdaqMketLstgDt { get; set; } = string.Empty;

		/// <summary>코스닥시장상장폐지일자</summary>
		[JsonPropertyName("kosdaq_mket_lstg_abol_dt")]
		public string KosdaqMketLstgAbolDt { get; set; } = string.Empty;

		/// <summary>프리보드시장상장일자</summary>
		[JsonPropertyName("frbd_mket_lstg_dt")]
		public string FrbdMketLstgDt { get; set; } = string.Empty;

		/// <summary>프리보드시장상장폐지일자</summary>
		[JsonPropertyName("frbd_mket_lstg_abol_dt")]
		public string FrbdMketLstgAbolDt { get; set; } = string.Empty;

		/// <summary>리츠종류코드</summary>
		[JsonPropertyName("reits_kind_cd")]
		public string ReitsKindCd { get; set; } = string.Empty;

		/// <summary>ETF구분코드</summary>
		[JsonPropertyName("etf_dvsn_cd")]
		public string EtfDvsnCd { get; set; } = string.Empty;

		/// <summary>유전펀드여부</summary>
		[JsonPropertyName("oilf_fund_yn")]
		public string OilfFundYn { get; set; } = string.Empty;

		/// <summary>지수업종대분류코드</summary>
		[JsonPropertyName("idx_bztp_lcls_cd")]
		public string IdxBztpLclsCd { get; set; } = string.Empty;

		/// <summary>지수업종중분류코드</summary>
		[JsonPropertyName("idx_bztp_mcls_cd")]
		public string IdxBztpMclsCd { get; set; } = string.Empty;

		/// <summary>지수업종소분류코드</summary>
		[JsonPropertyName("idx_bztp_scls_cd")]
		public string IdxBztpSclsCd { get; set; } = string.Empty;

		/// <summary>주식종류코드</summary>
		[JsonPropertyName("stck_kind_cd")]
		public string StckKindCd { get; set; } = string.Empty;

		/// <summary>뮤추얼펀드개시일자</summary>
		[JsonPropertyName("mfnd_opng_dt")]
		public string MfndOpngDt { get; set; } = string.Empty;

		/// <summary>뮤추얼펀드종료일자</summary>
		[JsonPropertyName("mfnd_end_dt")]
		public string MfndEndDt { get; set; } = string.Empty;

		/// <summary>예탁등록취소일자</summary>
		[JsonPropertyName("dpsi_erlm_cncl_dt")]
		public string DpsiErlmCnclDt { get; set; } = string.Empty;

		/// <summary>ETFCU수량</summary>
		[JsonPropertyName("etf_cu_qty")]
		public string EtfCuQty { get; set; } = string.Empty;

		/// <summary>상품명</summary>
		[JsonPropertyName("prdt_name")]
		public string PrdtName { get; set; } = string.Empty;

		/// <summary>상품명120</summary>
		[JsonPropertyName("prdt_name120")]
		public string PrdtName120 { get; set; } = string.Empty;

		/// <summary>상품약어명</summary>
		[JsonPropertyName("prdt_abrv_name")]
		public string PrdtAbrvName { get; set; } = string.Empty;

		/// <summary>표준상품번호</summary>
		[JsonPropertyName("std_pdno")]
		public string StdPdno { get; set; } = string.Empty;

		/// <summary>상품영문명</summary>
		[JsonPropertyName("prdt_eng_name")]
		public string PrdtEngName { get; set; } = string.Empty;

		/// <summary>상품영문명120</summary>
		[JsonPropertyName("prdt_eng_name120")]
		public string PrdtEngName120 { get; set; } = string.Empty;

		/// <summary>상품영문약어명</summary>
		[JsonPropertyName("prdt_eng_abrv_name")]
		public string PrdtEngAbrvName { get; set; } = string.Empty;

		/// <summary>예탁지정등록여부</summary>
		[JsonPropertyName("dpsi_aptm_erlm_yn")]
		public string DpsiAptmErlmYn { get; set; } = string.Empty;

		/// <summary>ETF과세유형코드</summary>
		[JsonPropertyName("etf_txtn_type_cd")]
		public string EtfTxtnTypeCd { get; set; } = string.Empty;

		/// <summary>ETF유형코드</summary>
		[JsonPropertyName("etf_type_cd")]
		public string EtfTypeCd { get; set; } = string.Empty;

		/// <summary>상장폐지일자</summary>
		[JsonPropertyName("lstg_abol_dt")]
		public string LstgAbolDt { get; set; } = string.Empty;

		/// <summary>신주구주구분코드</summary>
		[JsonPropertyName("nwst_odst_dvsn_cd")]
		public string NwstOdstDvsnCd { get; set; } = string.Empty;

		/// <summary>대용가격</summary>
		[JsonPropertyName("sbst_pric")]
		public string SbstPric { get; set; } = string.Empty;

		/// <summary>당사대용가격</summary>
		[JsonPropertyName("thco_sbst_pric")]
		public string ThcoSbstPric { get; set; } = string.Empty;

		/// <summary>당사대용가격변경일자</summary>
		[JsonPropertyName("thco_sbst_pric_chng_dt")]
		public string ThcoSbstPricChngDt { get; set; } = string.Empty;

		/// <summary>거래정지여부</summary>
		[JsonPropertyName("tr_stop_yn")]
		public string TrStopYn { get; set; } = string.Empty;

		/// <summary>관리종목여부</summary>
		[JsonPropertyName("admn_item_yn")]
		public string AdmnItemYn { get; set; } = string.Empty;

		/// <summary>당일종가</summary>
		[JsonPropertyName("thdt_clpr")]
		public string ThdtClpr { get; set; } = string.Empty;

		/// <summary>전일종가</summary>
		[JsonPropertyName("bfdy_clpr")]
		public string BfdyClpr { get; set; } = string.Empty;

		/// <summary>종가변경일자</summary>
		[JsonPropertyName("clpr_chng_dt")]
		public string ClprChngDt { get; set; } = string.Empty;

		/// <summary>표준산업분류코드</summary>
		[JsonPropertyName("std_idst_clsf_cd")]
		public string StdIdstClsfCd { get; set; } = string.Empty;

		/// <summary>표준산업분류코드명</summary>
		[JsonPropertyName("std_idst_clsf_cd_name")]
		public string StdIdstClsfCdName { get; set; } = string.Empty;

		/// <summary>지수업종대분류코드명</summary>
		[JsonPropertyName("idx_bztp_lcls_cd_name")]
		public string IdxBztpLclsCdName { get; set; } = string.Empty;

		/// <summary>지수업종중분류코드명</summary>
		[JsonPropertyName("idx_bztp_mcls_cd_name")]
		public string IdxBztpMclsCdName { get; set; } = string.Empty;

		/// <summary>지수업종소분류코드명</summary>
		[JsonPropertyName("idx_bztp_scls_cd_name")]
		public string IdxBztpSclsCdName { get; set; } = string.Empty;

		/// <summary>OCR번호</summary>
		[JsonPropertyName("ocr_no")]
		public string OcrNo { get; set; } = string.Empty;

		/// <summary>크라우드펀딩종목여부</summary>
		[JsonPropertyName("crfd_item_yn")]
		public string CrfdItemYn { get; set; } = string.Empty;

		/// <summary>전자증권여부</summary>
		[JsonPropertyName("elec_scty_yn")]
		public string ElecSctyYn { get; set; } = string.Empty;

		/// <summary>발행기관코드</summary>
		[JsonPropertyName("issu_istt_cd")]
		public string IssuIsttCd { get; set; } = string.Empty;

		/// <summary>ETF추적수익율배수</summary>
		[JsonPropertyName("etf_chas_erng_rt_dbnb")]
		public string EtfChasErngRtDbnb { get; set; } = string.Empty;

		/// <summary>ETFETN투자유의종목여부</summary>
		[JsonPropertyName("etf_etn_ivst_heed_item_yn")]
		public string EtfEtnIvstHeedItemYn { get; set; } = string.Empty;

		/// <summary>대주이자율구분코드</summary>
		[JsonPropertyName("stln_int_rt_dvsn_cd")]
		public string StlnIntRtDvsnCd { get; set; } = string.Empty;

		/// <summary>외국인개인한도비율</summary>
		[JsonPropertyName("frnr_psnl_lmt_rt")]
		public string FrnrPsnlLmtRt { get; set; } = string.Empty;

		/// <summary>상장신청인발행기관코드</summary>
		[JsonPropertyName("lstg_rqsr_issu_istt_cd")]
		public string LstgRqsrIssuIsttCd { get; set; } = string.Empty;

		/// <summary>상장신청인종목코드</summary>
		[JsonPropertyName("lstg_rqsr_item_cd")]
		public string LstgRqsrItemCd { get; set; } = string.Empty;

		/// <summary>신탁기관발행기관코드</summary>
		[JsonPropertyName("trst_istt_issu_istt_cd")]
		public string TrstIsttIssuIsttCd { get; set; } = string.Empty;

		/// <summary>NXT 거래종목여부</summary>
		[JsonPropertyName("cptt_trad_tr_psbl_yn")]
		public string CpttTradTrPsblYn { get; set; } = string.Empty;

		/// <summary>NXT 거래정지여부</summary>
		[JsonPropertyName("nxt_tr_stop_yn")]
		public string NxtTrStopYn { get; set; } = string.Empty;
	}
}