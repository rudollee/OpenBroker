using System.ComponentModel;
using System.Reflection;

namespace OpenBroker.Models;

public static class EnumHelper
{
	public static string ToDescription(this Enum source)
	{
		var info = source.GetType().GetField(source.ToString());

		if (info is null) return string.Empty;

		var attribute = info.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

		return attribute is null ? source.ToString() : attribute.Description;
	}
}

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

public enum ContractStatus
{
    None = 0,
    All,
    ContractedOnly,
    UncontractedOnly
}

public enum ContractSide
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
    /// LS증권
    /// </summary>
    LS = 1,

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

	/// <summary>
	/// 교보증권
	/// </summary>
	KY,
}

public enum MarketSession
{
    REGULAR = 0,
    CLOSED = 3,
    AFTER = 4,
    PRE = 10,
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
    /// Market Data
    /// </summary>
    MKT,

    /// <summary>
    /// Market Status
    /// </summary>
    MKTS,

    /// <summary>
    /// Contract
    /// </summary>
    CONTRACT,

    /// <summary>
    /// Order execution
    /// </summary>
    EXECUTION,

    /// <summary>
    /// Subscribe / Unsubscribe Realtime Data
    /// </summary>
    SUB,

    /// <summary>
    /// Misc.
    /// </summary>
    MISC
}

public enum IntervalUnit
{
    Tick = 11,
	Second = 21,
	Minute = 22,
	Hour = 23,
	Day = 31,
	Week = 32,
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