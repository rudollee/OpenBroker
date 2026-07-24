using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물옵션시간대별체결조회_9자리(t2212)
/// </summary>
internal class T2212 : LsResponseCore
{
	[JsonPropertyName("t2212InBlock")]
	public T2212InBlock T2212InBlock { get; set; } = new();
	[JsonPropertyName("t2212OutBlock")]
	public T2212OutBlock T2212OutBlock { get; set; } = new();
	[JsonPropertyName("t2212OutBlock1")]
	public List<T2212OutBlock1> T2212OutBlock1 { get; set; } = [];
}

/// <summary>
/// 선물옵션시간대별체결조회_9자리(t2212) - InBlock
/// </summary>
internal class T2212InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("focode")]
	public string Focode { get; set; } = string.Empty;

	/// <summary>특이거래량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>시작시간</summary>
	[JsonPropertyName("stime")]
	public string StartTime { get; set; } = string.Empty;

	/// <summary>종료시간</summary>
	[JsonPropertyName("etime")]
	public string EndTime { get; set; } = string.Empty;

	/// <summary>시간CTS</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션시간대별체결조회_9자리(t2212) - OutBlock
/// </summary>
internal class T2212OutBlock
{
	/// <summary>시간CTS</summary>
	[JsonPropertyName("cts_time")]
	public string CtsTime { get; set; } = string.Empty;
}

/// <summary>
/// 선물옵션시간대별체결조회_9자리(t2212) - OutBlock1
/// </summary>
internal class T2212OutBlock1
{
	/// <summary>시간</summary>
	[JsonPropertyName("chetime")]
	public string Chetime { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public decimal Price { get; set; }

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public decimal Change { get; set; }

	/// <summary>체결수량</summary>
	[JsonPropertyName("cvolume")]
	public long Cvolume { get; set; }

	/// <summary>체결강도</summary>
	[JsonPropertyName("chdegree")]
	public decimal Chdegree { get; set; }

	/// <summary>매도호가</summary>
	[JsonPropertyName("offerho")]
	public decimal Offerho { get; set; }

	/// <summary>매수호가</summary>
	[JsonPropertyName("bidho")]
	public decimal Bidho { get; set; }

	/// <summary>거래량</summary>
	[JsonPropertyName("volume")]
	public decimal Volume { get; set; }

	/// <summary>미결수량</summary>
	[JsonPropertyName("openyak")]
	public long Openyak { get; set; }

	/// <summary>미결전일증감</summary>
	[JsonPropertyName("jnilopenupdn")]
	public long Jnilopenupdn { get; set; }

	/// <summary>이론BASIS</summary>
	[JsonPropertyName("ibasis")]
	public decimal Ibasis { get; set; }

	/// <summary>시장BASIS</summary>
	[JsonPropertyName("sbasis")]
	public decimal Sbasis { get; set; }

	/// <summary>괴리율</summary>
	[JsonPropertyName("kasis")]
	public decimal Kasis { get; set; }

	/// <summary>거래대금</summary>
	[JsonPropertyName("value")]
	public decimal Value { get; set; }

	/// <summary>미결직전증감</summary>
	[JsonPropertyName("j_openupdn")]
	public long JOpenupdn { get; set; }

	/// <summary>누적매수체결량</summary>
	[JsonPropertyName("n_msvolume")]
	public decimal NMsvolume { get; set; }

	/// <summary>누적매도체결량</summary>
	[JsonPropertyName("n_mdvolume")]
	public decimal NMdvolume { get; set; }

	/// <summary>누적순매수체결량</summary>
	[JsonPropertyName("s_msvolume")]
	public decimal SMsvolume { get; set; }

	/// <summary>누적매수체결건수</summary>
	[JsonPropertyName("n_mschecnt")]
	public long NMschecnt { get; set; }

	/// <summary>누적매도체결건수</summary>
	[JsonPropertyName("n_mdchecnt")]
	public long NMdchecnt { get; set; }

	/// <summary>누적순매수체결건수</summary>
	[JsonPropertyName("s_mschecnt")]
	public long SMschecnt { get; set; }
}