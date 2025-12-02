using System.ComponentModel;

namespace OpenBroker.Models;
public enum Status
{
    SUCCESS = 200,

    NODATA = 204,

	[Description("partially success")]
	PARTIALLY_SUCCESS = 206,

	BAD_REQUEST = 400,

	[Description("Unauthorized")]
	UNAUTHORIZED = 401,

	FORBIDDEN = 403,

    TIMEOUT = 408,

    TOOMANYREQUESTS = 429,

    INTERNALSERVERERROR = 500,

    NOT_IMPLEMENTED = 501,

    SERVICE_UNAVAILABLE = 503,

	[Description("Repository Error")]
	ERROR_REPOSITORY = 588,

	[Description("open api Error")]
	ERROR_OPEN_API = 589,
}

public enum OrderDirection
{
    NONE,
    LONG,
    SHORT
}

public enum OrderMode
{
    NONE,
    PLACE = 10,
    PLACE_RESPONSE = 11,
    UPDATE = 20,
    UPDATE_RESPONSE = 21,
    CANCEL = 80,
    CANCEL_RESPONSE = 81,
}

public enum OrderType
{
    AUTO = 0,

	/// <summary>at Limit</summary>
	LIMIT = 10,

	/// <summary>at Market</summary>
	MARKET = 20,

	/// <summary>Mid Point</summary>
	MID = 22,

	/// <summary>Stop</summary>
	STOP = 40,

	/// <summary>Stop Limit</summary>
	STOPLIMIT = 41,
}

public enum OrderDuration
{
    AUTO = 0,
    STOP = 2,
    GTD = 5,
    LIMIT = 6
}

public enum ExecutionStatus
{
    None = 0,
    All,
    ExecutedOnly,
    UnexecutedOnly
}

public enum ExecutionSide
{
    ASK = 1,
    NONE = 0,
    BID = -1
}

/// <summary>
/// Discard Status
/// </summary>
public enum DiscardStatus
{
	TRADABLE = 0,
    PAUSE = 80,
	DISCARD = 88,
}

public enum Currency
{
    NONE = 0,

	USD = 100,
	
    /// <summary>
	/// TOT_USD
	/// </summary>
	TUS = 101,

	EUR = 200,

	/// <summary>
	/// Swiss Franc
	/// </summary>
	CHF = 4100,

	GBP = 4400,

	/// <summary>
	/// Singapore Dollar
	/// </summary>
	SGD = 6500,

	JPY = 8100,
	
    KRW = 8200,

	/// <summary>
	/// TOT_KRW
	/// </summary>
	TRK = 8201,
	
    HKD = 85200,
}

public enum Exchange
{
    NONE = 0,
    CME = 10,
	CBOE = 11,
    CBOT = 12,
    COMEX = 14,
    NYMEX = 15,
	ICE = 19,
	EUREX = 20,
    BMF = 550,
	ASX = 610,
	SGX = 650,
	OSE = 810,
	KRX = 820,
    NXT = 825,
	HNX = 840,
	HKEx = 8520,
	FTX = 8860,
}

public enum MarketCode
{
    KOSPI = 1,
    KOSDAQ = 2,
    DERIVATIVES = 5,
    CME = 20,
}

public enum ExchangeSection
{
	NONE = 0,
	CME = 100,
	CBOT = 101,
	NYMEX = 102,
	COMEX = 103,
	EUREX = 200,
	KRX = 820,
	KOSPI = 821,
	KOSDAQ = 822,
}

public enum Brkr
{
    NONE = 0,

	/// <summary>
	/// 교보증권
	/// </summary>
	KY = 100,

	/// <summary>
	/// 한국투자증권
	/// </summary>
	KI = 300,

    /// <summary>
    /// 미래에셋증권
    /// </summary>
    MR = 500,

	/// <summary>
	/// 유안타증권
	/// </summary>
	YU = 2400,

    /// <summary>
    /// SK증권
    /// </summary>
    SK = 2500,

	/// <summary>
	/// DB증권
	/// </summary>
	DB = 3100,

	/// <summary>
	/// 키움증권
	/// </summary>
	KW = 5000,

	/// <summary>
	/// LS증권
	/// </summary>
	LS = 75200,
}

public enum OrderChannel
{
    NONE = 0,

    HTS = 100,

    MTS = 200,

    API = 300,

    ETC = 900,
}

public enum MarketSession
{
    NOTSET = 0,
	PRE = 10,
	REGULAR = 20,
    CLOSED = 30,
    CLOSING = 31,
    EXTENDED = 40,
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

/// <summary>
/// Market Pause Type
/// </summary>
public enum MarketPauseType
{
    /// <summary>
    /// VI Normalized
    /// </summary>
    VI0 = 8210,
    
    /// <summary>
    /// VI Static
    /// </summary>
    VIS = 8211,

    /// <summary>
    /// VI Dynamic
    /// </summary>
    VID = 8212,

}

public enum MessageType
{
    /// <summary>
    /// General Message (default)
    /// </summary>
    SYS = 0,

    /// <summary>
    /// Error,
    /// </summary>
    SYSERR,

    /// <summary>
    /// Connection
    /// </summary>
    CONNECTION,

    /// <summary>
    /// Market Data
    /// </summary>
    MKT,

    /// <summary>
    /// Market Status
    /// </summary>
    MKTS,

    /// <summary>
    /// Execution
    /// </summary>
    EXECUTION,

    /// <summary>
    /// Order
    /// </summary>
    ORDER,

    /// <summary>
    /// Subscribe / Unsubscribe Realtime Data
    /// </summary>
    SUB,

    /// <summary>
    /// Misc.
    /// </summary>
    MISC,

    /// <summary>
    /// Watchlist
    /// </summary>
    WATCH,
}

public enum IntervalUnit
{
    [Description("T")]
	Tick = 11,

    [Description("S")]
	Second = 21,

    [Description("M")]
	Minute = 22,

    [Description("H")]
	Hour = 23,

    [Description("D")]
	Day = 31,

    [Description("W")]
	Week = 32,

    [Description("MM")]
	Month = 33,
}

/// <summary>
/// Instrument Type
/// </summary>
public enum InstrumentType
{
	Spot = 0,
	Futures = 1,
	Call,
    Put,
    FuturesSpread,
}

/// <summary>
/// Asset Class
/// </summary>
public enum AssetClass
{
    [Description("not Classified")]
    NONE = 0,
    
    [Description("Forex")]
	FOREX = 10,

    [Description("Equity Index")]
	EQUITY_INDEX = 20,

    [Description("Metal")]
	METAL = 30,

    [Description("Precious Metal")]
	PRECOUS_METAL = 31,

    [Description("Energy")]
	ENERGY = 40,
    
    [Description("Agriculture")]
	AGRICULTURE = 50,
}

public enum OptionsType
{
    NONE = 0,

    /// <summary>
    /// Regular Monthly
    /// </summary>
    G = 10,

    /// <summary>
    /// Mini Monthly
    /// </summary>
    M = 11,

    /// <summary>
    /// Weekly
    /// </summary>
    W = 20,

    /// <summary>
    /// Binary
    /// </summary>
    B = 30
}