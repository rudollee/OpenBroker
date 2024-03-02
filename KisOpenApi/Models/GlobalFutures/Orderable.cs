using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models.GlobalFutures;
/// <summary>
/// OTFM3304R : 해외선물 주문가능조회
/// </summary>
internal class OTFM3304R : ExecutionBaseResponse
{
    public OTFM3304ROutput Output { get; set; } = new();

    public class OTFM3304ROutput
    {
        /// <summary>종합계좌번호</summary>
        [JsonPropertyName("cano")]
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>계좌상품코드</summary>
        [JsonPropertyName("acnt_prdt_cd")]
        public string AccountNumberSuffix { get; set; } = string.Empty;

        /// <summary>해외선물FX상품번호</summary>
        [JsonPropertyName("ovrs_futr_fx_pdno")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>통화코드</summary>
        [JsonPropertyName("crcy_cd")]
        public string crcy_cd { get; set; } = string.Empty;

        /// <summary>매도매수구분코드</summary>
        [JsonPropertyName("sll_buy_dvsn_cd")]
        public string sll_buy_dvsn_cd { get; set; } = string.Empty;

        /// <summary>FM미결제수량</summary>
        [JsonPropertyName("fm_ustl_qty")]
        public string fm_ustl_qty { get; set; } = string.Empty;

        /// <summary>FM청산가능수량</summary>
        [JsonPropertyName("fm_lqd_psbl_qty")]
        public string fm_lqd_psbl_qty { get; set; } = string.Empty;

        /// <summary>FM신규주문가능수량</summary>
        [JsonPropertyName("fm_new_ord_psbl_qty")]
        public string fm_new_ord_psbl_qty { get; set; } = string.Empty;

        /// <summary>FM총주문가능수량</summary>
        [JsonPropertyName("fm_tot_ord_psbl_qty")]
        public string fm_tot_ord_psbl_qty { get; set; } = string.Empty;

        /// <summary>FM시장가총주문가능수량</summary>
        [JsonPropertyName("fm_mkpr_tot_ord_psbl_qty")]
        public string fm_mkpr_tot_ord_psbl_qty { get; set; } = string.Empty;
    }
}
