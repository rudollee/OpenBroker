using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 테마종목별시세조회(t1537)
/// </summary>
internal class T1537 : LsResponseCore
{
	[JsonPropertyName("t1537InBlock")]
	public T1537InBlock T1537InBlock { get; set; } = new();
	[JsonPropertyName("t1537OutBlock")]
	public T1537OutBlock T1537OutBlock { get; set; } = new();
	[JsonPropertyName("t1537OutBlock1")]
	public List<T1537OutBlock1> T1537OutBlock1 { get; set; } = [];
}

/// <summary>
/// 테마종목별시세조회(t1537) - InBlock
/// </summary>
internal class T1537InBlock
{
	/// <summary>테마코드</summary>
	[JsonPropertyName("tmcode")]
	public string TmCode { get; set; } = string.Empty;
}

/// <summary>
/// 테마종목별시세조회(t1537) - OutBlock
/// </summary>
internal class T1537OutBlock
{
	/// <summary>상승종목수</summary>
	[JsonPropertyName("upcnt")]
	public long UpCnt { get; set; }

	/// <summary>테마종목수</summary>
	[JsonPropertyName("tmcnt")]
	public long TmCnt { get; set; }

	/// <summary>상승종목비율</summary>
	[JsonPropertyName("uprate")]
	public long UpRate { get; set; }

	/// <summary>테마명</summary>
	[JsonPropertyName("tmname")]
	public string TmName { get; set; } = string.Empty;
}

/// <summary>
/// 테마종목별시세조회(t1537) - OutBlock1
/// </summary>
internal class T1537OutBlock1
{
	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string HName { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public long Change { get; set; }

	/// <summary>등락율</summary>
	[JsonPropertyName("diff")]
	public decimal Diff { get; set; }

	/// <summary>누적거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>전일동시간</summary>
	[JsonPropertyName("jniltime")]
	public decimal JnilTime { get; set; }

	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>예상체결가</summary>
	[JsonPropertyName("yeprice")]
	public long YePrice { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>누적거래대금(단위:백만)</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>시가총액(단위:백만)</summary>
	[JsonPropertyName("marketcap")]
	public long MarketCap { get; set; }
}