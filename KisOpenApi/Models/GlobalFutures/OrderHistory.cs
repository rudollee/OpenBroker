using System.Text.Json.Serialization;

namespace KisOpenApi.Models.GlobalFutures;
internal class OrderHistory
{
}

/// <summary>
/// OTFM3116R :
/// 해외선물옵션 당일주문내역조회
/// </summary>
internal class OTFM3116R : KisResponseBase
{
    public List<OTFM3116ROutput> Output { get; set; } = new List<OTFM3116ROutput>();

    internal class OTFM3116ROutput : OrderHistoryOutputBaseResponse
    {
        /// <summary>접수구분코드</summary>
        [JsonPropertyName("rcit_dvsn_cd")]
        public string rcit_dvsn_cd { get; set; } = string.Empty;

        /// <summary>매도매수구분코드</summary>
        [JsonPropertyName("sll_buy_dvsn_cd")]
        public string sll_buy_dvsn_cd { get; set; } = string.Empty;

        /// <summary>매매전략구분코드</summary>
        [JsonPropertyName("trad_stgy_dvsn_cd")]
        public string trad_stgy_dvsn_cd { get; set; } = string.Empty;

        /// <summary>기준가격유형코드</summary>
        [JsonPropertyName("bass_pric_type_cd")]
        public string bass_pric_type_cd { get; set; } = string.Empty;

        /// <summary>주문상태코드</summary>
        [JsonPropertyName("ord_stat_cd")]
        public string ord_stat_cd { get; set; } = string.Empty;

        /// <summary>예약구분</summary>
        [JsonPropertyName("rsvn_dvsn")]
        public string rsvn_dvsn { get; set; } = string.Empty;

        /// <summary>등록상세일시</summary>
        [JsonPropertyName("erlm_dtl_dtime")]
        public string erlm_dtl_dtime { get; set; } = string.Empty;

        /// <summary>주문직원번호</summary>
        [JsonPropertyName("ord_stfno")]
        public string ord_stfno { get; set; } = string.Empty;

        /// <summary>비고1</summary>
        [JsonPropertyName("rmks1")]
        public string rmks1 { get; set; } = string.Empty;

        /// <summary>신규청산구분코드</summary>
        [JsonPropertyName("new_lqd_dvsn_cd")]
        public string new_lqd_dvsn_cd { get; set; } = string.Empty;

        /// <summary>FM청산LIMIT주문가격</summary>
        [JsonPropertyName("fm_lqd_lmt_ord_pric")]
        public string fm_lqd_lmt_ord_pric { get; set; } = string.Empty;

        /// <summary>FM청산STOP가격</summary>
        [JsonPropertyName("fm_lqd_stop_pric")]
        public string fm_lqd_stop_pric { get; set; } = string.Empty;

        /// <summary>체결조건코드</summary>
        [JsonPropertyName("ccld_cndt_cd")]
        public string ccld_cndt_cd { get; set; } = string.Empty;

        /// <summary>게시유효일자</summary>
        [JsonPropertyName("noti_vald_dt")]
        public string noti_vald_dt { get; set; } = string.Empty;

        /// <summary>계좌유형코드</summary>
        [JsonPropertyName("acnt_type_cd")]
        public string acnt_type_cd { get; set; } = string.Empty;

        /// <summary>선물옵션구분</summary>
        [JsonPropertyName("fuop_dvsn")]
        public string fuop_dvsn { get; set; } = string.Empty;
    }

}

/// <summary>
/// OTFM3120R: 
/// 해외선물옵션 일별 주문내역
/// </summary>
internal class OTFM3120R : KisResponseBase
{
    public List<OTFM3120ROutput> Output { get; set; } = new();

    /// <summary>
    /// 해외선물옵션 일별 주문내역 Output
    /// </summary>
    internal class OTFM3120ROutput : OrderHistoryOutputBaseResponse
    {
        /// <summary>일자</summary>
        [JsonPropertyName("dt")]
        public string OrderBizDate8 { get; set; } = string.Empty;

        /// <summary>정정취소구분코드</summary>
        [JsonPropertyName("rvse_cncl_dvsn_cd")]
        public string rvse_cncl_dvsn_cd { get; set; } = string.Empty;

        /// <summary>매도매수구분코드</summary>
        [JsonPropertyName("sll_buy_dvsn_cd")]
        public string sll_buy_dvsn_cd { get; set; } = string.Empty;

        /// <summary>복합주문구분코드</summary>
        [JsonPropertyName("cplx_ord_dvsn_cd")]
        public string cplx_ord_dvsn_cd { get; set; } = string.Empty;

        /// <summary>가격구분코드</summary>
        [JsonPropertyName("pric_dvsn_cd")]
        public string pric_dvsn_cd { get; set; } = string.Empty;

        /// <summary>접수구분코드</summary>
        [JsonPropertyName("rcit_dvsn_cd")]
        public string rcit_dvsn_cd { get; set; } = string.Empty;

        /// <summary>행사예약주문여부</summary>
        [JsonPropertyName("ecis_rsvn_ord_yn")]
        public string ecis_rsvn_ord_yn { get; set; } = string.Empty;

        /// <summary>접수상세일시</summary>
        [JsonPropertyName("rcit_dtl_dtime")]
        public string OrderDateTime863 { get; set; } = string.Empty;

        /// <summary>주문자사원번호</summary>
        [JsonPropertyName("ordr_emp_no")]
        public string ordr_emp_no { get; set; } = string.Empty;

        /// <summary>거부사유명</summary>
        [JsonPropertyName("rjct_rson_name")]
        public string MessageRejected { get; set; } = string.Empty;

        /// <summary>체결조건코드</summary>
        [JsonPropertyName("ccld_cndt_cd")]
        public string ccld_cndt_cd { get; set; } = string.Empty;

        /// <summary>매매종료일자</summary>
        [JsonPropertyName("trad_end_dt")]
        public string trad_end_dt { get; set; } = string.Empty;
    }
}

