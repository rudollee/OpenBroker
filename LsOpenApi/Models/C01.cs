using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 선물주문체결
/// </summary>
internal class C01
{
	public C01InBlock C01InBlock { get; set; } = new();
	public C01OutBlock C01OutBlock { get; set; } = new();
}

/// <summary>
/// 선물주문체결 - InBlock
/// </summary>
internal class C01InBlock { }

/// <summary>
/// 선물주문체결 - OutBlock
/// </summary>
internal class C01OutBlock
{
	/// <summary>라인일련번호</summary>
	[JsonPropertyName("lineseq")]
	public string Lineseq { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	[JsonPropertyName("accno")]
	public string Accno { get; set; } = string.Empty;

	/// <summary>조작자ID</summary>
	[JsonPropertyName("user")]
	public string User { get; set; } = string.Empty;

	/// <summary>일련번호</summary>
	[JsonPropertyName("seq")]
	public string Seq { get; set; } = string.Empty;

	/// <summary>trcode</summary>
	[JsonPropertyName("trcode")]
	public string Trcode { get; set; } = string.Empty;

	/// <summary>매칭그룹번호</summary>
	[JsonPropertyName("megrpno")]
	public string Megrpno { get; set; } = string.Empty;

	/// <summary>보드ID</summary>
	[JsonPropertyName("boardid")]
	public string Boardid { get; set; } = string.Empty;

	/// <summary>회원번호</summary>
	[JsonPropertyName("memberno")]
	public string Memberno { get; set; } = string.Empty;

	/// <summary>지점번호</summary>
	[JsonPropertyName("bpno")]
	public string Bpno { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	[JsonPropertyName("ordno")]
	public string Ordno { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	[JsonPropertyName("ordordno")]
	public string Ordordno { get; set; } = string.Empty;

	/// <summary>종목코드</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>약정번호</summary>
	[JsonPropertyName("yakseq")]
	public string Yakseq { get; set; } = string.Empty;

	/// <summary>체결가격</summary>
	[JsonPropertyName("cheprice")]
	public string ChePrice { get; set; } = string.Empty;

	/// <summary>체결수량</summary>
	[JsonPropertyName("chevol")]
	public string CheVol { get; set; } = string.Empty;

	/// <summary>세션ID</summary>
	[JsonPropertyName("sessionid")]
	public string SessionId { get; set; } = string.Empty;

	/// <summary>체결일자</summary>
	[JsonPropertyName("chedate")]
	public string CheDate { get; set; } = string.Empty;

	/// <summary>체결시각</summary>
	[JsonPropertyName("chetime")]
	public string CheTime { get; set; } = string.Empty;

	/// <summary>최근월체결가격</summary>
	[JsonPropertyName("spdprc1")]
	public string SpdPrc1 { get; set; } = string.Empty;

	/// <summary>차근월체결가격</summary>
	[JsonPropertyName("spdprc2")]
	public string SpdPrc2 { get; set; } = string.Empty;

	/// <summary>매도수구분</summary>
	[JsonPropertyName("dosugb")]
	public string DosuGb { get; set; } = string.Empty;

	/// <summary>계좌번호1</summary>
	[JsonPropertyName("accno1")]
	public string Accno1 { get; set; } = string.Empty;

	/// <summary>시장조성호가구분</summary>
	[JsonPropertyName("sihogagb")]
	public string SihogaGb { get; set; } = string.Empty;

	/// <summary>위탁사번호</summary>
	[JsonPropertyName("jakino")]
	public string JakiNo { get; set; } = string.Empty;

	/// <summary>대용주권계좌번호</summary>
	[JsonPropertyName("daeyong")]
	public string Daeyong { get; set; } = string.Empty;

	/// <summary>mem_filler</summary>
	[JsonPropertyName("mem_filler")]
	public string MemFiller { get; set; } = string.Empty;

	/// <summary>mem_accno</summary>
	[JsonPropertyName("mem_accno")]
	public string MemAccno { get; set; } = string.Empty;
}