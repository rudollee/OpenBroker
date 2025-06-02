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
internal class C01InBlock {}

/// <summary>
/// 선물주문체결 - OutBlock
/// </summary>
internal class C01OutBlock
{
	/// <summary>라인일련번호</summary>
	public string lineseq { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno { get; set; } = string.Empty;

	/// <summary>조작자ID</summary>
	public string user { get; set; } = string.Empty;

	/// <summary>일련번호</summary>
	public string seq { get; set; } = string.Empty;

	/// <summary>trcode</summary>
	public string trcode { get; set; } = string.Empty;

	/// <summary>매칭그룹번호</summary>
	public string megrpno { get; set; } = string.Empty;

	/// <summary>보드ID</summary>
	public string boardid { get; set; } = string.Empty;

	/// <summary>회원번호</summary>
	public string memberno { get; set; } = string.Empty;

	/// <summary>지점번호</summary>
	public string bpno { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string ordordno { get; set; } = string.Empty;

	/// <summary>종목코드</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>약정번호</summary>
	public string yakseq { get; set; } = string.Empty;

	/// <summary>체결가격</summary>
	public string cheprice { get; set; } = string.Empty;

	/// <summary>체결수량</summary>
	public string chevol { get; set; } = string.Empty;

	/// <summary>세션ID</summary>
	public string sessionid { get; set; } = string.Empty;

	/// <summary>체결일자</summary>
	public string chedate { get; set; } = string.Empty;

	/// <summary>체결시각</summary>
	public string chetime { get; set; } = string.Empty;

	/// <summary>최근월체결가격</summary>
	public string spdprc1 { get; set; } = string.Empty;

	/// <summary>차근월체결가격</summary>
	public string spdprc2 { get; set; } = string.Empty;

	/// <summary>매도수구분</summary>
	public string dosugb { get; set; } = string.Empty;

	/// <summary>계좌번호1</summary>
	public string accno1 { get; set; } = string.Empty;

	/// <summary>시장조성호가구분</summary>
	public string sihogagb { get; set; } = string.Empty;

	/// <summary>위탁사번호</summary>
	public string jakino { get; set; } = string.Empty;

	/// <summary>대용주권계좌번호</summary>
	public string daeyong { get; set; } = string.Empty;

	/// <summary>mem_filler</summary>
	public string mem_filler { get; set; } = string.Empty;

	/// <summary>mem_accno</summary>
	public string mem_accno { get; set; } = string.Empty;

	/// <summary>mem_filler1</summary>
	public string mem_filler1 { get; set; } = string.Empty;
}