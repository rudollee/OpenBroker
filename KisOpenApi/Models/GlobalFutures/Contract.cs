using System.Text.Json.Serialization;

namespace KisOpenApi.Models.GlobalFutures;
internal class ExecutionRequeasst
{
    public DateTime DateBegin { get; set; }

    public DateTime DateFin { get; set; }
}

/// <summary>
/// 일별 체결내역 - OTFM3122R
/// </summary>
internal class OTFM3122R : KisResponseBase
{
    public string ctx_area_fk200 { get; set; } = string.Empty;
    public string ctx_area_nk200 { get; set; } = string.Empty;
    public List<Output1> output1 { get; set; } = new List<Output1>();
    public Output2 output2 { get; set; } = new Output2();

    internal class Output1
    {
        [JsonPropertyName("dt")]
        public string DateBizTxt8 { get; set; } = string.Empty;

        /// <summary>
        /// 체결번호
        /// </summary>
        [JsonPropertyName("ccno")]
        public int CID { get; set; }

        [JsonPropertyName("ovrs_futr_fx_pdno")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// 01.Buy, 02.Sell
        /// </summary>
        [JsonPropertyName("sll_buy_dvsn_cd")]
        public string DirectionCode { get; set; } = string.Empty;

        /// <summary>
        /// 체결량
        /// </summary>
        [JsonPropertyName("fm_ccld_qty")]
        public int Volume { get; set; }

        /// <summary>
        /// 체결단가
        /// </summary>
        [JsonPropertyName("fm_ccld_amt")]
        public decimal Price { get; set; }

        /// <summary>
        /// 체결단가 * Multiple (Futures)
        /// </summary>
        public decimal fm_futr_ccld_amt { get; set; }

        /// <summary>
        /// 체결단가 * Multiple (Options)
        /// </summary>
        public decimal fm_opt_ccld_amt { get; set; }

        /// <summary>
        /// 통화
        /// </summary>
        public string crcy_cd { get; set; } = string.Empty;

        /// <summary>
        /// 수수료
        /// </summary>
        [JsonPropertyName("fm_fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// 체결단가 * Multiple + 수수료 (Futures)
        /// </summary>
        public decimal fm_futr_pure_agrm_amt { get; set; }

        /// <summary>
        /// 체결단가 * Multiple + 수수료 (options)
        /// </summary>
        public decimal fm_opt_pure_agrm_amt { get; set; }

        /// <summary>
        /// 체결시각 yyyyMMddHHmmsssss
        /// </summary>
        public string ccld_dtl_dtime { get; set; } = string.Empty;

        /// <summary>
        /// 주문일자
        /// </summary>
        public string ord_dt { get; set; } = string.Empty;

        /// <summary>
        /// 주문번호
        /// </summary>
        [JsonPropertyName("odno")]
        public int OID { get; set; }

        /// <summary>
        /// 주문매체
        /// </summary>
        public string ord_mdia_dvsn_name { get; set; } = string.Empty;
    }

    internal class Output2
    {
        /// <summary>
        /// FM총체결수량
        /// </summary>
        public string fm_tot_ccld_qty { get; set; } = "0";

        /// <summary>
        /// FM총선물약정금액
        /// </summary>
        public string fm_tot_futr_agrm_amt { get; set; } = "0";

        /// <summary>
        /// FM총옵션약정금액
        /// </summary>
        public string fm_tot_opt_agrm_amt { get; set; } = "0";

        /// <summary>
        /// FM수수료합계
        /// </summary>
        public string fm_fee_smtl { get; set; } = "0";
    }

}
