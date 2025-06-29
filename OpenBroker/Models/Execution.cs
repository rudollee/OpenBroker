namespace OpenBroker.Models;

public class Order : InstrumentCore
{
    public string BrokerCo { get; set; } = string.Empty;
    public OrderMode Mode { get; set; }
    public DateOnly DateBiz { get; set; }
    public long OID { get; set; }
    public long IdOrigin { get; set; }
    public decimal VolumeOrdered { get; set; }
    public decimal VolumeOrderable { get; set; }
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

public class OrderCore
{
    public Exchange ExchangeCode { get; set; } = Exchange.NONE;
    public OrderMode Mode { get; set; } = OrderMode.PLACE;
    public DateOnly DateOrdered { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public long IdOrigin { get; set; }
	public string Symbol { get; set; } = string.Empty;
	public decimal VolumeOrdered { get; set; }
	public decimal PriceOrdered { get; set; }
    public bool IsLong { get; set; } = true;
    public OrderType OrderType { get; set; } = OrderType.AUTO;
    public OrderDuration OrderDuration { get; set; } = OrderDuration.AUTO;
}

public class Contract : Order, ICloneable
{
    public Exchange ExchangeCode { get; set; } = Exchange.CME;
    public long CID { get; set; }
    public decimal Volume { get; set; }
    public decimal Price { get; set; }
    public decimal VolumeLeft { get; set; }
    public DateTime TimeContracted { get; set; }

    public object Clone() => this.MemberwiseClone();
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
    /// 청산손익
    /// </summary>
    public decimal ProfitLiquidated { get; set; }

    /// <summary>
    /// 평가손익
    /// </summary>
    public decimal ProfitEst { get; set; }

    /// <summary>
    /// 예탁금 : 평가이익 및 당일청산손익 제외
    /// </summary>
    public decimal DepositInit { get; set; }

    /// <summary>
    /// 예탁금 : KRX D+1
    /// </summary>
    public decimal DepositD1 { get; set; }

    /// <summary>
    /// 예탁금 : Deposit + 청산손익 + 평가손익
    /// </summary>
    public decimal DepositEst { get; set; }

    /// <summary>
    /// 주문가능금액
    /// </summary>
    public decimal CashTradable { get; set; }

    /// <summary>
    /// 위탁증거금
    /// </summary>
    public decimal MarginInitial { get; set; }

    /// <summary>
    /// 유지증거금
    /// </summary>
    public decimal Margin { get; set; }

    /// <summary>
    /// 수수료 총액
    /// </summary>
    public decimal CommissionAgg { get; set; }

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

public class Position : InstrumentCore
{
    public decimal VolumeEntry { get; set; }
    public decimal PriceEntry { get; set; }
    public decimal Volume { get; set; }
    public decimal Price { get; set; }
    public DateTime DateEntry { get; set; }
    public decimal Tax { get; set; }
    public decimal Commission { get; set; }
}

public class Pnl
{
    public DateTime Date { get; set; }
    public decimal PnlAgg { get; set; }
    public decimal Commission { get; set; }
    public decimal Tax { get; set; }
}

internal class Execution { }

