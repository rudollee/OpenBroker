using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// KOSPI체결(S3)
/// </summary>
internal class S3_
{
	public S3_InBlock S3InBlock { get; set; } = new();
	public S3_OutBlock S3_OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI체결(S3) - InBlock
/// </summary>
internal class S3_InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI체결(S3) - OutBlock
/// </summary>
internal class S3_OutBlock
{
	/// <summary>체결시간</summary>
	[JsonPropertyName("chetime")]
	public string Chetime { get; set; } = string.Empty;

	/// <summary>전일대비구분</summary>
	[JsonPropertyName("sign")]
	public string Sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	[JsonPropertyName("change")]
	public string Change { get; set; } = string.Empty;

	/// <summary>등락율</summary>
	[JsonPropertyName("drate")]
	public string Drate { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public string Price { get; set; } = string.Empty;

	/// <summary>시가시간</summary>
	[JsonPropertyName("opentime")]
	public string Opentime { get; set; } = string.Empty;

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public string Open { get; set; } = string.Empty;

	/// <summary>고가시간</summary>
	[JsonPropertyName("hightime")]
	public string Hightime { get; set; } = string.Empty;

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public string High { get; set; } = string.Empty;

	/// <summary>저가시간</summary>
	[JsonPropertyName("lowtime")]
	public string Lowtime { get; set; } = string.Empty;

	/// <summary>저가</summary>
	[JsonPropertyName("low")]
	public string Low { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	[JsonPropertyName("cgubun")]
	public string Cgubun { get; set; } = string.Empty;

	/// <summary>체결량</summary>
	[JsonPropertyName("cvolume")]
	public string Cvolume { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	[JsonPropertyName("volume")]
	public string Volume { get; set; } = string.Empty;

	/// <summary>누적거래대금</summary>
	[JsonPropertyName("value")]
	public string Value { get; set; } = string.Empty;

	/// <summary>매도누적체결량</summary>
	[JsonPropertyName("mdvolume")]
	public string Mdvolume { get; set; } = string.Empty;

	/// <summary>매도누적체결건수</summary>
	[JsonPropertyName("mdchecnt")]
	public string Mdchecnt { get; set; } = string.Empty;

	/// <summary>매수누적체결량</summary>
	[JsonPropertyName("msvolume")]
	public string Msvolume { get; set; } = string.Empty;

	/// <summary>매수누적체결건수</summary>
	[JsonPropertyName("mschecnt")]
	public string Mschecnt { get; set; } = string.Empty;

	/// <summary>체결강도</summary>
	[JsonPropertyName("cpower")]
	public string Cpower { get; set; } = string.Empty;

	/// <summary>가중평균가</summary>
	[JsonPropertyName("w_avrg")]
	public string WAvrg { get; set; } = string.Empty;

	/// <summary>매도호가</summary>
	[JsonPropertyName("offerho")]
	public string Offerho { get; set; } = string.Empty;

	/// <summary>매수호가</summary>
	[JsonPropertyName("bidho")]
	public string Bidho { get; set; } = string.Empty;

	/// <summary>장정보</summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	/// <summary>전일동시간대거래량</summary>
	[JsonPropertyName("jnilvolume")]
	public string Jnilvolume { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("shcode")]
	public string Shcode { get; set; } = string.Empty;

	/// <summary>거래소명</summary>
	[JsonPropertyName("exchname")]
	public string Exchname { get; set; } = string.Empty;
}

/// <summary>
/// KOSDAQ체결(K3)
/// </summary>
internal class K3_
{
	public K3_OutBlock K3_OutBlock { get; set; } = new();
}

/// <summary>
/// KOSDAQ체결(K3) - Inblock
/// </summary>
internal class K3_InBlock : S3_InBlock { }

/// <summary>
/// KOSDAQ체결(K3) - OutBlock
/// </summary>
internal class K3_OutBlock : S3_OutBlock { }

/// <summary>
/// NXT KOSPI + KOSDAQ 체결(NS3)
/// </summary>
internal class NS3
{
	//public NS3InBlock NS3InBlock { get; set; } = new();
	public NS3OutBlock NS3OutBlock { get; set; } = new();
}

/// <summary>
/// NXT KOSPI + KOSDAQ 체결(NS3) - InBlock
/// </summary>
internal class NS3InBlock
{
	/// <summary>거래소별단축코드</summary>
	[JsonPropertyName("ex_shcode")]
	public string ExShcode { get; set; } = string.Empty;
}

/// <summary>
/// NXT KOSPI + KOSDAQ 체결(NS3) - OutBlock
/// </summary>
internal class NS3OutBlock : S3_OutBlock
{
	/// <summary>거래소별단축코드</summary>
	[JsonPropertyName("ex_shcode")]
	public string ExShcode { get; set; } = string.Empty;
}

/// <summary>
/// KRX+NXT 통합 체결(US3)
/// </summary>
internal class US3
{
	//public US3InBlock US3InBlock { get; set; } = new();
	public US3OutBlock US3OutBlock { get; set; } = new();
}

/// <summary>
/// KRX+NXT 통합 체결(US3) - InBlock
/// </summary>
internal class US3InBlock
{
	/// <summary>거래소별단축코드</summary>
	[JsonPropertyName("ex_shcode")]
	public string ExShcode { get; set; } = string.Empty;
}

/// <summary>
/// KRX+NXT 통합 체결(US3) - OutBlock
/// </summary>
internal class US3OutBlock : S3_OutBlock
{
	/// <summary>거래소별단축코드</summary>
	[JsonPropertyName("ex_shcode")]
	public string ExShcode { get; set; } = string.Empty;
}