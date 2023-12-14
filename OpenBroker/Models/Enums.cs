using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models
{
    public enum OrderMode
    {
        Long = 11,
        Short = 10,
        Update = 20,
        Cancel = 88
    }

    public enum ContractStatus
    {
        None = 0,
        All,
        ExecutedOnly,
        UnexecutedOnly
    }

    public enum Currency
    {
        NA = -1,

        /// <summary>
        /// TOT_USD
        /// </summary>
        TUS = 0,

        /// <summary>
        /// TOT_KRW
        /// </summary>
        TRK = 1,
        USD,
        KRW,
        EUR,
        JPY,
        GBP,
        HKD,

        /// <summary>
        /// Swiss Franc
        /// </summary>
        CHF,

        /// <summary>
        /// Singapore Dollar
        /// </summary>
        SGD,
    }

    public enum Exchange
    {
        KRX = 0,
        CME = 10,
        EUREX = 20
    }

    public enum MarketCode
    {
        KOSPI = 1,
        KOSDAQ = 2,
        DERIVATIVES = 5,
        CME = 20,
    }

    public enum Brkr
    {
        /// <summary>
        /// 교보증권
        /// </summary>
        KY = 0,

        /// <summary>
        /// eBest증권
        /// </summary>
        EB = 1,

        /// <summary>
        /// 유안타증권
        /// </summary>
        YU,

        /// <summary>
        /// SK증권
        /// </summary>
        SK,

        /// <summary>
        /// 키움증권
        /// </summary>
        KW,

        /// <summary>
        /// DB금융투자
        /// </summary>
        DB,

        /// <summary>
        /// 한국투자증권
        /// </summary>
        KI,
    }

    public enum AccountType
    {
        /// <summary>
        /// N/A
        /// </summary>
        N0 = 0,

        /// <summary>
        /// 해외 주식계좌
        /// </summary>
        G0 = 11,

        /// <summary>
        /// Derivatives / 해외 파생상품계좌
        /// </summary>
        GD = 12,

        /// <summary>
        /// General KRX / 국내 주식계좌 또는 국내 종합매매계좌
        /// </summary>
        K0 = 21,

        /// <summary>
        /// Derivatives KRX / 국내 파생상품계좌
        /// </summary>
        KD = 22,

    }
}
