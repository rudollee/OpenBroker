namespace LsOpenApi.Models;
/// <summary>
/// 주식선물호가조회(API용)(t8403)
/// </summary>
internal class t8403 : LsResponseCore
{
	public t8403InBlock t8403InBlock { get; set; } = new();
	public t8403OutBlock t8403OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물호가조회(API용)(t8403) - InBlock
/// </summary>
internal class t8403InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물호가조회(API용)(t8403) - OutBlock
/// </summary>
internal class t8403OutBlock
{
	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>거래량</summary>
	public long volume { get; set; }

	/// <summary>거래량전일동시간비율</summary>
	public decimal stimeqrt { get; set; }

	/// <summary>전일종가</summary>
	public long jnilclose { get; set; }

	/// <summary>매도호가1</summary>
	public long offerho1 { get; set; }

	/// <summary>매수호가1</summary>
	public long bidho1 { get; set; }

	/// <summary>매도호가수량1</summary>
	public long offerrem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	public long bidrem1 { get; set; }

	/// <summary>매도호가건수1</summary>
	public long dcnt1 { get; set; }

	/// <summary>매수호가건수1</summary>
	public long scnt1 { get; set; }

	/// <summary>매도호가2</summary>
	public long offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	public long bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	public long offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	public long bidrem2 { get; set; }

	/// <summary>매도호가건수2</summary>
	public long dcnt2 { get; set; }

	/// <summary>매수호가건수2</summary>
	public long scnt2 { get; set; }

	/// <summary>매도호가3</summary>
	public long offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	public long bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	public long offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	public long bidrem3 { get; set; }

	/// <summary>매도호가건수3</summary>
	public long dcnt3 { get; set; }

	/// <summary>매수호가건수3</summary>
	public long scnt3 { get; set; }

	/// <summary>매도호가4</summary>
	public long offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	public long bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	public long offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	public long bidrem4 { get; set; }

	/// <summary>매도호가건수4</summary>
	public long dcnt4 { get; set; }

	/// <summary>매수호가건수4</summary>
	public long scnt4 { get; set; }

	/// <summary>매도호가5</summary>
	public long offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	public long bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	public long offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	public long bidrem5 { get; set; }

	/// <summary>매도호가건수5</summary>
	public long dcnt5 { get; set; }

	/// <summary>매수호가건수5</summary>
	public long scnt5 { get; set; }

	/// <summary>매도호가6</summary>
	public long offerho6 { get; set; }

	/// <summary>매수호가6</summary>
	public long bidho6 { get; set; }

	/// <summary>매도호가수량6</summary>
	public long offerrem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	public long bidrem6 { get; set; }

	/// <summary>매도호가건수6</summary>
	public long dcnt6 { get; set; }

	/// <summary>매수호가건수6</summary>
	public long scnt6 { get; set; }

	/// <summary>매도호가7</summary>
	public long offerho7 { get; set; }

	/// <summary>매수호가7</summary>
	public long bidho7 { get; set; }

	/// <summary>매도호가수량7</summary>
	public long offerrem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	public long bidrem7 { get; set; }

	/// <summary>매도호가건수7</summary>
	public long dcnt7 { get; set; }

	/// <summary>매수호가건수7</summary>
	public long scnt7 { get; set; }

	/// <summary>매도호가8</summary>
	public long offerho8 { get; set; }

	/// <summary>매수호가8</summary>
	public long bidho8 { get; set; }

	/// <summary>매도호가수량8</summary>
	public long offerrem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	public long bidrem8 { get; set; }

	/// <summary>매도호가건수8</summary>
	public long dcnt8 { get; set; }

	/// <summary>매수호가건수8</summary>
	public long scnt8 { get; set; }

	/// <summary>매도호가9</summary>
	public long offerho9 { get; set; }

	/// <summary>매수호가9</summary>
	public long bidho9 { get; set; }

	/// <summary>매도호가수량9</summary>
	public long offerrem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	public long bidrem9 { get; set; }

	/// <summary>매도호가건수9</summary>
	public long dcnt9 { get; set; }

	/// <summary>매수호가건수9</summary>
	public long scnt9 { get; set; }

	/// <summary>매도호가10</summary>
	public long offerho10 { get; set; }

	/// <summary>매수호가10</summary>
	public long bidho10 { get; set; }

	/// <summary>매도호가수량10</summary>
	public long offerrem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	public long bidrem10 { get; set; }

	/// <summary>매도호가건수10</summary>
	public long dcnt10 { get; set; }

	/// <summary>매수호가건수10</summary>
	public long scnt10 { get; set; }

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