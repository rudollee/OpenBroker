using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식챠트(N분)(t8412)
/// </summary>
internal class T8412 : LsResponseCore
{
	[JsonPropertyName("t8412InBlock")]
	public T841XInBlock T8412InBlock { get; set; } = new();
	[JsonPropertyName("t8412OutBlock")]
	public T841XOutBlock T8412OutBlock { get; set; } = new();
	[JsonPropertyName("t8412OutBlock1")]
	public List<T8412OutBlock1> T8412OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식챠트(N분)(t8412) - OutBlock1
/// </summary>
internal class T8412OutBlock1
{
	/// <summary>날짜</summary>
	[JsonPropertyName("date")]
	public string Date { get; set; } = string.Empty;

	/// <summary>시간</summary>
	[JsonPropertyName("time")]
	public string Time { get; set; } = string.Empty;

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public long Open { get; set; }

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public long High { get; set; }

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public long Low { get; set; }

	/// <summary>종가</summary>
	[JsonPropertyName("close")]
	public long Close { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("jdiff_vol")]
	public long JdiffVol { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public long Value { get; set; }

	/// <summary>수정구분</summary>
	[JsonPropertyName("jongchk")]
	public long Jongchk { get; set; }

	/// <summary>수정비율</summary>
	[JsonPropertyName("rate")]
	public decimal Rate { get; set; }

	/// <summary>종가등락구분(1:상한2:상승3:보합4:하한5:하락)</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;
}