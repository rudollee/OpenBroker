namespace LsOpenApi.Models;
/// <summary>
/// KOSPI시간외단일가호가잔량(DH1)
/// </summary>
internal class DH1
{
	public DH1OutBlock DH1OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI시간외단일가호가잔량(DH1) - InBlock
/// </summary>
internal class DH1InBlock
{
	/// <summary>        단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI시간외단일가호가잔량(DH1) - OutBlock
/// </summary>
internal class DH1OutBlock
{
	/// <summary>시간외단일가호가시간</summary>
	public string dan_hotime { get; set; } = string.Empty;

	/// <summary>시간외단일가장구분</summary>
	public string dan_hstatus { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가1</summary>
	public string dan_offerho1 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가1</summary>
	public string dan_bidho1 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가잔량1</summary>
	public string dan_offerrem1 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가잔량1</summary>
	public string dan_bidrem1 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도대비수량1</summary>
	public string dan_preoffercha1 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수대비수량1</summary>
	public string dan_prebidcha1 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가2</summary>
	public string dan_offerho2 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가2</summary>
	public string dan_bidho2 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가잔량2</summary>
	public string dan_offerrem2 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가잔량2</summary>
	public string dan_bidrem2 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도대비수량2</summary>
	public string dan_preoffercha2 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수대비수량2</summary>
	public string dan_prebidcha2 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가3</summary>
	public string dan_offerho3 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가3</summary>
	public string dan_bidho3 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가잔량3</summary>
	public string dan_offerrem3 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가잔량3</summary>
	public string dan_bidrem3 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도대비수량3</summary>
	public string dan_preoffercha3 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수대비수량3</summary>
	public string dan_prebidcha3 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가4</summary>
	public string dan_offerho4 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가4</summary>
	public string dan_bidho4 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가잔량4</summary>
	public string dan_offerrem4 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가잔량4</summary>
	public string dan_bidrem4 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도대비수량4</summary>
	public string dan_preoffercha4 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수대비수량4</summary>
	public string dan_prebidcha4 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가5</summary>
	public string dan_offerho5 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가5</summary>
	public string dan_bidho5 { get; set; } = string.Empty;

	/// <summary>시간외단일가매도호가잔량5</summary>
	public string dan_offerrem5 { get; set; } = string.Empty;

	/// <summary>시간외단일가매수호가잔량5</summary>
	public string dan_bidrem5 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도대비수량5</summary>
	public string dan_preoffercha5 { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수대비수량5</summary>
	public string dan_prebidcha5 { get; set; } = string.Empty;

	/// <summary>시간외단일가총매도호가잔량</summary>
	public string dan_totofferrem { get; set; } = string.Empty;

	/// <summary>시간외단일가총매수호가잔량</summary>
	public string dan_totbidrem { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매도호가총대비수량</summary>
	public string dan_preoffercha { get; set; } = string.Empty;

	/// <summary>시간외단일가직전매수호가총대비수량</summary>
	public string dan_prebidcha { get; set; } = string.Empty;

	/// <summary>시간외단일가예상체결가격</summary>
	public string dan_yeprice { get; set; } = string.Empty;

	/// <summary>시간외단일가예상체결수량</summary>
	public string dan_yevolume { get; set; } = string.Empty;

	/// <summary>시간외단일가예상가직전가대비구분</summary>
	public string dan_preysign { get; set; } = string.Empty;

	/// <summary>시간외단일가예상가직전가대비</summary>
	public string dan_preychange { get; set; } = string.Empty;

	/// <summary>시간외단일가예상가전일가대비구분</summary>
	public string dan_jnilysign { get; set; } = string.Empty;

	/// <summary>시간외단일가예상가전일가대비</summary>
	public string dan_jnilychange { get; set; } = string.Empty;

	/// <summary>        단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	public string volume { get; set; } = string.Empty;
}

/// <summary>
/// KOSDAQ시간외단일가호가잔량(DHA)
/// </summary>
internal class DHA_ { };