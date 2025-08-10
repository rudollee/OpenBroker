namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션현재가호가조회(t2105)
/// </summary>
internal class t2105 : LsResponseCore
{
	public t2105InBlock t2105InBlock { get; set; } = new();
	public t2105OutBlock t2105OutBlock { get; set; } = new();
}

/// <summary>
/// 선물/옵션현재가호가조회(t2105) - InBlock
/// </summary>
internal class t2105InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션현재가호가조회(t2105) - OutBlock
/// </summary>
internal class t2105OutBlock
{
	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public decimal price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public decimal change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>거래량</summary>
	public long volume { get; set; }

	/// <summary>거래량전일동시간비율</summary>
	public decimal stimeqrt { get; set; }

	/// <summary>전일종가</summary>
	public decimal jnilclose { get; set; }

	/// <summary>매도호가1</summary>
	public decimal offerho1 { get; set; }

	/// <summary>매수호가1</summary>
	public decimal bidho1 { get; set; }

	/// <summary>매도호가수량1</summary>
	public long offerrem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	public long bidrem1 { get; set; }

	/// <summary>매도호가건수1</summary>
	public long dcnt1 { get; set; }

	/// <summary>매수호가건수1</summary>
	public long scnt1 { get; set; }

	/// <summary>매도호가2</summary>
	public decimal offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	public decimal bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	public long offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	public long bidrem2 { get; set; }

	/// <summary>매도호가건수2</summary>
	public long dcnt2 { get; set; }

	/// <summary>매수호가건수2</summary>
	public long scnt2 { get; set; }

	/// <summary>매도호가3</summary>
	public decimal offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	public decimal bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	public long offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	public long bidrem3 { get; set; }

	/// <summary>매도호가건수3</summary>
	public long dcnt3 { get; set; }

	/// <summary>매수호가건수3</summary>
	public long scnt3 { get; set; }

	/// <summary>매도호가4</summary>
	public decimal offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	public decimal bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	public long offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	public long bidrem4 { get; set; }

	/// <summary>매도호가건수4</summary>
	public long dcnt4 { get; set; }

	/// <summary>매수호가건수4</summary>
	public long scnt4 { get; set; }

	/// <summary>매도호가5</summary>
	public decimal offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	public decimal bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	public long offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	public long bidrem5 { get; set; }

	/// <summary>매도호가건수5</summary>
	public long dcnt5 { get; set; }

	/// <summary>매수호가건수5</summary>
	public long scnt5 { get; set; }

	/// <summary>매도호가총수량</summary>
	public long dvol { get; set; }

	/// <summary>매수호가총수량</summary>
	public long svol { get; set; }

	/// <summary>총매도호가건수</summary>
	public long toffernum { get; set; }

	/// <summary>총매수호가건수</summary>
	public long tbidnum { get; set; }

	/// <summary>수신시간</summary>
	public string time { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}
