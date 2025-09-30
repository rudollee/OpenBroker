using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// KOSPI200선물체결(C0)
/// </summary>
internal class FC0
{
	public FC0InBlock FC0InBlock { get; set; } = new();
	public FC0OutBlock FC0OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI200선물체결(C0) - InBlock
/// </summary>
internal class FC0InBlock
{
	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물체결(C0) - OutBlock
/// </summary>
internal class FC0OutBlock
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

	/// <summary>시가</summary>
	[JsonPropertyName("open")]
	public string Open { get; set; } = string.Empty;

	/// <summary>고가</summary>
	[JsonPropertyName("high")]
	public string High { get; set; } = string.Empty;

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

	/// <summary>매도호가1</summary>
	[JsonPropertyName("offerho1")]
	public string Offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	[JsonPropertyName("bidho1")]
	public string Bidho1 { get; set; } = string.Empty;

	/// <summary>미결제약정수량</summary>
	[JsonPropertyName("openyak")]
	public string Openyak { get; set; } = string.Empty;

	/// <summary>KOSPI200지수</summary>
	[JsonPropertyName("k200jisu")]
	public string K200jisu { get; set; } = string.Empty;

	/// <summary>이론가</summary>
	[JsonPropertyName("theoryprice")]
	public string Theoryprice { get; set; } = string.Empty;

	/// <summary>괴리율</summary>
	[JsonPropertyName("kasis")]
	public string Kasis { get; set; } = string.Empty;

	/// <summary>시장BASIS</summary>
	[JsonPropertyName("sbasis")]
	public string Sbasis { get; set; } = string.Empty;

	/// <summary>이론BASIS</summary>
	[JsonPropertyName("ibasis")]
	public string Ibasis { get; set; } = string.Empty;

	/// <summary>미결제약정증감</summary>
	[JsonPropertyName("openyakcha")]
	public string Openyakcha { get; set; } = string.Empty;

	/// <summary>장운영정보</summary>
	[JsonPropertyName("jgubun")]
	public string Jgubun { get; set; } = string.Empty;

	/// <summary>전일동시간대거래량</summary>
	[JsonPropertyName("jnilvolume")]
	public string Jnilvolume { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	[JsonPropertyName("futcode")]
	public string Futcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물체결(JC0)
/// </summary>
internal class JC0
{
	public JC0InBlock JC0InBlock { get; set; } = new();
	public JC0OutBlock JC0OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물체결(JC0) - InBlock
/// </summary>
internal class JC0InBlock : FC0InBlock { }

/// <summary>
/// 주식선물체결(JC0) - OutBlock
/// </summary>
internal class JC0OutBlock : FC0OutBlock
{
	/// <summary>기초자산현재가</summary>
	public string basprice { get; set; } = string.Empty;
}

/// <summary>
/// KRX야간파생 체결(DC0)
/// </summary>
internal class DC0
{
	public DC0InBlock DC0InBlock { get; set; } = new();
	public DC0OutBlock DC0OutBlock { get; set; } = new();
}

/// <summary>
/// KRX야간파생 체결(DC0) - InBlock
/// </summary>
internal class DC0InBlock : FC0InBlock { }

/// <summary>
/// KRX야간파생 체결(DC0) - OutBlock
/// </summary>
internal class DC0OutBlock : FC0OutBlock
{
	/// <summary>배분적용구분</summary>
	[JsonPropertyName("alloc_gubun")]
	public string AllocGubun { get; set; } = string.Empty;

	/// <summary>KOSPI등가</summary>
	[JsonPropertyName("eqva")]
	public string Eqva { get; set; } = string.Empty;

	/// <summary>내재변동성</summary>
	[JsonPropertyName("impv")]
	public string Impv { get; set; } = string.Empty;

	/// <summary>시간가치</summary>
	[JsonPropertyName("timevalue")]
	public string Timevalue { get; set; } = string.Empty;
}