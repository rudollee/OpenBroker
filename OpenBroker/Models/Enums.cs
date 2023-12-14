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


}
