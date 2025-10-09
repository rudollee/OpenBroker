using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// API용주식멀티현재가조회(t8407)
/// </summary>
internal class T8407 : LsResponseCore
{
	[JsonPropertyName("t8407OutBlock1")]
	public List<T8407OutBlock1> T8407OutBlock1 { get; set; } = [];
}

/// <summary>
/// API용주식멀티현재가조회(t8407) - InBlock
/// </summary>
internal class T8407InBlock
{
	/// <summary>건수</summary>
	[JsonPropertyName("nrec")]
	public long Nrec { get; set; }

	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// API용주식멀티현재가조회(t8407) - OutBlock1
/// </summary>
internal class T8407OutBlock1
{
	/// <summary>종목코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

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

	/// <summary>매도호가</summary>
	[JsonPropertyName("offerho")]
	public long Offerho { get; set; }

	/// <summary>매수호가</summary>
	[JsonPropertyName("bidho")]
	public long Bidho { get; set; }

	/// <summary>체결수량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>체결강도</summary>
	[JsonPropertyName("chdegree")]
	public decimal Chdegree { get; set; }

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>거래대금(백만)</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>우선매도잔량</summary>
	[JsonPropertyName("offerrem")]
	public long Offerrem { get; set; }

	/// <summary>우선매수잔량</summary>
	[JsonPropertyName("bidrem")]
	public long Bidrem { get; set; }

	/// <summary>총매도잔량</summary>
	[JsonPropertyName("totofferrem")]
	public long Totofferrem { get; set; }

	/// <summary>총매수잔량</summary>
	[JsonPropertyName("totbidrem")]
	public long Totbidrem { get; set; }

	/// <summary>전일종가</summary>
	[JsonPropertyName("jnilclose")]
	public long Jnilclose { get; set; }

	/// <summary>상한가</summary>
	[JsonPropertyName("uplmtprice")]
	public long Uplmtprice { get; set; }

	/// <summary>하한가</summary>
	[JsonPropertyName("dnlmtprice")]
	public long Dnlmtprice { get; set; }
}