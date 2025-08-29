namespace LsOpenApi.Models;
/// <summary>
/// KOSPI200선물호가(H0)
/// </summary>
internal class FH0
{
	public FH0InBlock FH0InBlock { get; set; } = new();
	public FH0OutBlock FH0OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI200선물호가(H0) - InBlock
/// </summary>
internal class FH0InBlock
{
	/// <summary>단축코드</summary>
	public string futcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물호가(H0) - OutBlock
/// </summary>
internal class FH0OutBlock
{
	/// <summary>호가시간</summary>
	public string hotime { get; set; } = string.Empty;

	/// <summary>매도호가1</summary>
	public string offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	public string bidho1 { get; set; } = string.Empty;

	/// <summary>매도호가수량1</summary>
	public string offerrem1 { get; set; } = string.Empty;

	/// <summary>매수호가수량1</summary>
	public string bidrem1 { get; set; } = string.Empty;

	/// <summary>매도호가건수1</summary>
	public string offercnt1 { get; set; } = string.Empty;

	/// <summary>매수호가건수1</summary>
	public string bidcnt1 { get; set; } = string.Empty;

	/// <summary>매도호가2</summary>
	public string offerho2 { get; set; } = string.Empty;

	/// <summary>매수호가2</summary>
	public string bidho2 { get; set; } = string.Empty;

	/// <summary>매도호가수량2</summary>
	public string offerrem2 { get; set; } = string.Empty;

	/// <summary>매수호가수량2</summary>
	public string bidrem2 { get; set; } = string.Empty;

	/// <summary>매도호가건수2</summary>
	public string offercnt2 { get; set; } = string.Empty;

	/// <summary>매수호가건수2</summary>
	public string bidcnt2 { get; set; } = string.Empty;

	/// <summary>매도호가3</summary>
	public string offerho3 { get; set; } = string.Empty;

	/// <summary>매수호가3</summary>
	public string bidho3 { get; set; } = string.Empty;

	/// <summary>매도호가수량3</summary>
	public string offerrem3 { get; set; } = string.Empty;

	/// <summary>매수호가수량3</summary>
	public string bidrem3 { get; set; } = string.Empty;

	/// <summary>매도호가건수3</summary>
	public string offercnt3 { get; set; } = string.Empty;

	/// <summary>매수호가건수3</summary>
	public string bidcnt3 { get; set; } = string.Empty;

	/// <summary>매도호가4</summary>
	public string offerho4 { get; set; } = string.Empty;

	/// <summary>매수호가4</summary>
	public string bidho4 { get; set; } = string.Empty;

	/// <summary>매도호가수량4</summary>
	public string offerrem4 { get; set; } = string.Empty;

	/// <summary>매수호가수량4</summary>
	public string bidrem4 { get; set; } = string.Empty;

	/// <summary>매도호가건수4</summary>
	public string offercnt4 { get; set; } = string.Empty;

	/// <summary>매수호가건수4</summary>
	public string bidcnt4 { get; set; } = string.Empty;

	/// <summary>매도호가5</summary>
	public string offerho5 { get; set; } = string.Empty;

	/// <summary>매수호가5</summary>
	public string bidho5 { get; set; } = string.Empty;

	/// <summary>매도호가수량5</summary>
	public string offerrem5 { get; set; } = string.Empty;

	/// <summary>매수호가수량5</summary>
	public string bidrem5 { get; set; } = string.Empty;

	/// <summary>매도호가건수5</summary>
	public string offercnt5 { get; set; } = string.Empty;

	/// <summary>매수호가건수5</summary>
	public string bidcnt5 { get; set; } = string.Empty;

	/// <summary>매도호가총수량</summary>
	public string totofferrem { get; set; } = string.Empty;

	/// <summary>매수호가총수량</summary>
	public string totbidrem { get; set; } = string.Empty;

	/// <summary>매도호가총건수</summary>
	public string totoffercnt { get; set; } = string.Empty;

	/// <summary>매수호가총건수</summary>
	public string totbidcnt { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string futcode { get; set; } = string.Empty;

	/// <summary>단일가호가여부</summary>
	public string danhochk { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	public string alloc_gubun { get; set; } = string.Empty;
}