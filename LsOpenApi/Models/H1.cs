namespace LsOpenApi.Models;
/// <summary>
/// KOSPI호가잔량(H1)
/// </summary>
internal class H1_
{
	public H1_OutBlock H1_OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI호가잔량(H1) - InBlock
/// </summary>
internal class H1_InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI호가잔량(H1) - OutBlock
/// </summary>
internal class H1_OutBlock
{
	/// <summary>호가시간</summary>
	public string hotime { get; set; } = string.Empty;

	/// <summary>매도호가1</summary>
	public string offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	public string bidho1 { get; set; } = string.Empty;

	/// <summary>매도호가잔량1</summary>
	public string offerrem1 { get; set; } = string.Empty;

	/// <summary>매수호가잔량1</summary>
	public string bidrem1 { get; set; } = string.Empty;

	/// <summary>매도호가2</summary>
	public string offerho2 { get; set; } = string.Empty;

	/// <summary>매수호가2</summary>
	public string bidho2 { get; set; } = string.Empty;

	/// <summary>매도호가잔량2</summary>
	public string offerrem2 { get; set; } = string.Empty;

	/// <summary>매수호가잔량2</summary>
	public string bidrem2 { get; set; } = string.Empty;

	/// <summary>매도호가3</summary>
	public string offerho3 { get; set; } = string.Empty;

	/// <summary>매수호가3</summary>
	public string bidho3 { get; set; } = string.Empty;

	/// <summary>매도호가잔량3</summary>
	public string offerrem3 { get; set; } = string.Empty;

	/// <summary>매수호가잔량3</summary>
	public string bidrem3 { get; set; } = string.Empty;

	/// <summary>매도호가4</summary>
	public string offerho4 { get; set; } = string.Empty;

	/// <summary>매수호가4</summary>
	public string bidho4 { get; set; } = string.Empty;

	/// <summary>매도호가잔량4</summary>
	public string offerrem4 { get; set; } = string.Empty;

	/// <summary>매수호가잔량4</summary>
	public string bidrem4 { get; set; } = string.Empty;

	/// <summary>매도호가5</summary>
	public string offerho5 { get; set; } = string.Empty;

	/// <summary>매수호가5</summary>
	public string bidho5 { get; set; } = string.Empty;

	/// <summary>매도호가잔량5</summary>
	public string offerrem5 { get; set; } = string.Empty;

	/// <summary>매수호가잔량5</summary>
	public string bidrem5 { get; set; } = string.Empty;

	/// <summary>매도호가6</summary>
	public string offerho6 { get; set; } = string.Empty;

	/// <summary>매수호가6</summary>
	public string bidho6 { get; set; } = string.Empty;

	/// <summary>매도호가잔량6</summary>
	public string offerrem6 { get; set; } = string.Empty;

	/// <summary>매수호가잔량6</summary>
	public string bidrem6 { get; set; } = string.Empty;

	/// <summary>매도호가7</summary>
	public string offerho7 { get; set; } = string.Empty;

	/// <summary>매수호가7</summary>
	public string bidho7 { get; set; } = string.Empty;

	/// <summary>매도호가잔량7</summary>
	public string offerrem7 { get; set; } = string.Empty;

	/// <summary>매수호가잔량7</summary>
	public string bidrem7 { get; set; } = string.Empty;

	/// <summary>매도호가8</summary>
	public string offerho8 { get; set; } = string.Empty;

	/// <summary>매수호가8</summary>
	public string bidho8 { get; set; } = string.Empty;

	/// <summary>매도호가잔량8</summary>
	public string offerrem8 { get; set; } = string.Empty;

	/// <summary>매수호가잔량8</summary>
	public string bidrem8 { get; set; } = string.Empty;

	/// <summary>매도호가9</summary>
	public string offerho9 { get; set; } = string.Empty;

	/// <summary>매수호가9</summary>
	public string bidho9 { get; set; } = string.Empty;

	/// <summary>매도호가잔량9</summary>
	public string offerrem9 { get; set; } = string.Empty;

	/// <summary>매수호가잔량9</summary>
	public string bidrem9 { get; set; } = string.Empty;

	/// <summary>매도호가10</summary>
	public string offerho10 { get; set; } = string.Empty;

	/// <summary>매수호가10</summary>
	public string bidho10 { get; set; } = string.Empty;

	/// <summary>매도호가잔량10</summary>
	public string offerrem10 { get; set; } = string.Empty;

	/// <summary>매수호가잔량10</summary>
	public string bidrem10 { get; set; } = string.Empty;

	/// <summary>총매도호가잔량</summary>
	public string totofferrem { get; set; } = string.Empty;

	/// <summary>총매수호가잔량</summary>
	public string totbidrem { get; set; } = string.Empty;

	/// <summary>동시호가구분</summary>
	public string donsigubun { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	public string alloc_gubun { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	public string volume { get; set; } = string.Empty;

	/// <summary>중간가격</summary>
	public string midprice { get; set; } = string.Empty;

	/// <summary>매도중간가잔량합계수량</summary>
	public string offermidsumrem { get; set; } = string.Empty;

	/// <summary>매수중간가잔량합계수량</summary>
	public string bidmidsumrem { get; set; } = string.Empty;

	/// <summary>중간가잔량합계수량</summary>
	public string midsumrem { get; set; } = string.Empty;

	/// <summary>중간가잔량구분</summary>
	public string midsumremgubun { get; set; } = string.Empty;
}

/// <summary>
/// KOSDAQ 호가잔량(HA)
/// </summary>
internal class HA_ { };