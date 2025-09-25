using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식시간대별체결조회(t1301)
/// </summary>
internal class T1301 : LsResponseCore
{
	[JsonPropertyName("t1301InBlock")]
	public T1301InBlock T1301InBlock { get; set; } = new();
	[JsonPropertyName("t1301OutBlock")]
	public T1301OutBlock T1301OutBlock { get; set; } = new();
	[JsonPropertyName("t1301OutBlock1")]
	public List<T1301OutBlock1> T1301OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식시간대별체결조회(t1301) - InBlock
/// </summary>
internal class T1301InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>특이거래량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>시작시간</summary>
	[JsonPropertyName("starttime")]
	public string Starttime { get; set; } = string.Empty;

	/// <summary>종료시간</summary>
	[JsonPropertyName("endtime")]
	public string Endtime { get; set; } = string.Empty;

	/// <summary>시간CTS</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;
}

/// <summary>
/// 주식시간대별체결조회(t1301) - OutBlock
/// </summary>
internal class T1301OutBlock
{
	/// <summary>시간CTS</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;
}

/// <summary>
/// 주식시간대별체결조회(t1301) - OutBlock1
/// </summary>
internal class T1301OutBlock1
{
	/// <summary>시간</summary>
	[JsonPropertyName("chetime")]
	public string Chetime { get; set; } = string.Empty;

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

	/// <summary>체결수량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>체결강도</summary>
	[JsonPropertyName("chdegree")]
	public decimal Chdegree { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public long Volume { get; set; }

	/// <summary>매도체결수량</summary>
	[JsonPropertyName("mdvolume")]
	public long Mdvolume { get; set; }

	/// <summary>매도체결건수</summary>
	[JsonPropertyName("mdchecnt")]
	public long Mdchecnt { get; set; }

	/// <summary>매수체결수량</summary>
	[JsonPropertyName("msvolume")]
	public long Msvolume { get; set; }

	/// <summary>매수체결건수</summary>
	[JsonPropertyName("mschecnt")]
	public long Mschecnt { get; set; }

	/// <summary>순체결량</summary>
	[JsonPropertyName("revolume")]
	public long Revolume { get; set; }

	/// <summary>순체결건수</summary>
	[JsonPropertyName("rechecnt")]
	public long Rechecnt { get; set; }
}