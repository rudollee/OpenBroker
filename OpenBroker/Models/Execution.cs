using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models
{
    public class Order : Instrument
    {
        public string BrokerCo { get; set; } = string.Empty;
        public OrderMode Mode { get; set; }
        public DateOnly DateBiz { get; set; }
        public long OID { get; set; }
        public long IdOrigin { get; set; }
        public decimal VolumeOrdered { get; set; }
        public decimal VolumeOrdable { get; set; }
        public decimal VolumeUpdatable { get; set; }
        public decimal VolumeCancelable { get; set; }
        public decimal PriceOrdered { get; set; }

        /// <summary>
        /// 주문 금액
        /// </summary>
		public decimal Aggregation { get; set; }
        public bool IsLong { get; set; }
        public DateTime TimeOrdered { get; set; }
    }

    public class Contract : Order
    {
        public Exchange ExchangeCode { get; set; } = Exchange.CME;
        public long CID { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public decimal VolumeLeft { get; set; }
        public DateTime TimeContracted { get; set; }
    }

    public class Balance
    {
        /// <summary>
        /// 증권사 코드
        /// </summary>
        public string BrokerCode { get; set; } = string.Empty;

        /// <summary>
        /// 증권사 계좌번호
        /// </summary>
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// 기본 통화단위
        /// </summary> 
        public Currency CurBased { get; set; } = Currency.TUS;

        /// <summary>
        /// 통화 별 예탁자산
        /// </summary>
        public IList<AssetCashable> Deposit { get; set; } = new List<AssetCashable>();

        /// <summary>
        /// (기본 통화단위로 환산한) 예탁금 : 평가예탁금 + Option Value
        /// </summary>
        public decimal DepositConverted { get; set; }

        /// <summary>
        /// 평가예탁금
        /// </summary>
        public decimal DepositEst { get; set; }

        /// <summary>
        /// 주문가능금액
        /// </summary>
        public decimal CashAvailable { get; set; }

        /// <summary>
        /// 위탁증거금
        /// </summary>
        public decimal MarginInitial { get; set; }

        /// <summary>
        /// 유지증거금
        /// </summary>
        public decimal Margin { get; set; }

        /// <summary>
        /// 보유 포지션
        /// </summary>
        public IList<Position> Positions { get; set; } = new List<Position>();
    }

    public class AssetCashable
    {
        public Currency Cur { get; set; }
        public decimal Cash { get; set; }
        public decimal ExchangeRate { get; set; }
    }

    public class Position : Instrument
    {
        public decimal VolumeEntry { get; set; }
        public decimal PriceEntry { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public DateTime DateEntry { get; set; }
    }

    public class Earning
    {
        public DateTime Date { get; set; }
        public decimal EarningAgg { get; set; }
        public decimal Brokerage { get; set; }
    }

    internal class Execution { }
    
}
