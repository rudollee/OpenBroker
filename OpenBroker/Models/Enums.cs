using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    PLACE_LQ = 11,
    UPDATE = 20,
    UPDATE_LQ = 21,
    CANCEL = 88
}

public enum OrderType
{
    AUTO = 0,
    LIMIT = 1,
    MARKET = 2,
    STOP = 3,
    STOPLIMIT = 4,
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
    ExecutedOnly,
    UnexecutedOnly
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
    EUREX = 20,
    OSE = 30,
	KRX = 820,
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