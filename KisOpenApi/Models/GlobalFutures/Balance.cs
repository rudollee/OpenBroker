using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models.GlobalFutures;
public class BalanceRequest : ExecutionBaseRequest
{
    public string Currency { get; set; } = "TUS";
}

/// <summary>
/// OTFM1411R.해외선물옵션 예수금현황
/// </summary>
internal class OTFM1411R : ExecutionBaseResponse
{
    public Output output { get; set; } = new Output();

    internal class Output
    {
        [JsonPropertyName("cano")]
        public string Account { get; set; } = string.Empty;
        public string acnt_prdt_cd { get; set; } = string.Empty;
        public string crcy_cd { get; set; } = string.Empty;
        public string resp_dt { get; set; } = string.Empty;

        /// <summary>
        /// 예수금잔액
        /// </summary>
        public decimal fm_dnca_rmnd { get; set; }

        /// <summary>
        /// 청산손익금액
        /// </summary>
        public decimal fm_lqd_pfls_amt { get; set; }

        /// <summary>
        /// 수수료
        /// </summary>
        public decimal fm_fee { get; set; }

        /// <summary>
        /// 익일예수금액
        /// </summary>
        public decimal fm_nxdy_dncl_amt { get; set; }

        /// <summary>
        /// 총자산평가금액
        /// </summary>
        public decimal fm_tot_asst_evlu_amt { get; set; }

        /// <summary>
        /// 선물옵션평가손익금액
        /// </summary>
        public decimal fm_fuop_evlu_pfls_amt { get; set; }

        /// <summary>
        /// 미수금액
        /// </summary>
        public decimal fm_rcvb_amt { get; set; }

        /// <summary>
        /// 위탁증거금액
        /// </summary>
        public decimal fm_brkg_mgn_amt { get; set; }

        /// <summary>
        /// 유지증거금액
        /// </summary>
        public decimal fm_mntn_mgn_amt { get; set; }

        /// <summary>
        /// 추가증거금액
        /// </summary>
        public decimal fm_add_mgn_amt { get; set; }

        /// <summary>
        /// 위험율
        /// </summary>
        public decimal fm_risk_rt { get; set; }

        /// <summary>
        /// 주문가능금액
        /// </summary>
        public decimal fm_ord_psbl_amt { get; set; }

        /// <summary>
        /// 출금가능금액
        /// </summary>
        public decimal fm_drwg_psbl_amt { get; set; }

        /// <summary>
        /// 환전요청금액
        /// </summary>
        public decimal fm_echm_rqrm_amt { get; set; }

        /// <summary>
        /// 출금예정금액
        /// </summary>
        public decimal fm_drwg_prar_amt { get; set; }

        /// <summary>
        /// 옵션거래대금
        /// </summary>
        public decimal fm_opt_tr_chgs { get; set; }

        /// <summary>
        /// 옵션포함자산평가금액
        /// </summary>
        public decimal fm_opt_icld_asst_evlu_amt { get; set; }

        /// <summary>
        /// 옵션평가금액
        /// </summary>
        public decimal fm_opt_evlu_amt { get; set; }

        /// <summary>
        /// 통화대용금액
        /// </summary>
        public decimal fm_crcy_sbst_amt { get; set; }

        /// <summary>
        /// 통화대용사용금액
        /// </summary>
        public decimal fm_crcy_sbst_use_amt { get; set; }

        /// <summary>
        /// 통화대용설정금액
        /// </summary>
        public decimal fm_crcy_sbst_stup_amt { get; set; }
    }
}
