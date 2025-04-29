namespace LsOpenApi.Models;
/// <summary>
/// 주식현재가호가조회(t8450)
/// </summary>
internal class t8450 : LsResponseCore
{
	public t8450InBlock t8450InBlock { get; set; } = new();
	public t8450OutBlock t8450OutBlock { get; set; } = new();
}

/// <summary>
/// 주식현재가호가조회(t8450) - InBlock
/// </summary>
internal class t8450InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>거래소구분코드</summary>
	public string exchgubun { get; set; } = string.Empty;
}

/// <summary>
/// 주식현재가호가조회(t8450) - OutBlock
/// </summary>
internal class t8450OutBlock
{
	/// <summary>한글명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>누적거래량</summary>
	public long volume { get; set; }

	/// <summary>전일종가(기준가)</summary>
	public long jnilclose { get; set; }

	/// <summary>매도호가1</summary>
	public long offerho1 { get; set; }

	/// <summary>매수호가1</summary>
	public long bidho1 { get; set; }

	/// <summary>매도호가수량1</summary>
	public long offerrem1 { get; set; }

	/// <summary>매수호가수량1</summary>
	public long bidrem1 { get; set; }

	/// <summary>매도호가2</summary>
	public long offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	public long bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	public long offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	public long bidrem2 { get; set; }

	/// <summary>매도호가3</summary>
	public long offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	public long bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	public long offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	public long bidrem3 { get; set; }

	/// <summary>매도호가4</summary>
	public long offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	public long bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	public long offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	public long bidrem4 { get; set; }

	/// <summary>매도호가5</summary>
	public long offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	public long bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	public long offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	public long bidrem5 { get; set; }

	/// <summary>매도호가6</summary>
	public long offerho6 { get; set; }

	/// <summary>매수호가6</summary>
	public long bidho6 { get; set; }

	/// <summary>매도호가수량6</summary>
	public long offerrem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	public long bidrem6 { get; set; }

	/// <summary>매도호가7</summary>
	public long offerho7 { get; set; }

	/// <summary>매수호가7</summary>
	public long bidho7 { get; set; }

	/// <summary>매도호가수량7</summary>
	public long offerrem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	public long bidrem7 { get; set; }

	/// <summary>매도호가8</summary>
	public long offerho8 { get; set; }

	/// <summary>매수호가8</summary>
	public long bidho8 { get; set; }

	/// <summary>매도호가수량8</summary>
	public long offerrem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	public long bidrem8 { get; set; }

	/// <summary>매도호가9</summary>
	public long offerho9 { get; set; }

	/// <summary>매수호가9</summary>
	public long bidho9 { get; set; }

	/// <summary>매도호가수량9</summary>
	public long offerrem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	public long bidrem9 { get; set; }

	/// <summary>매도호가10</summary>
	public long offerho10 { get; set; }

	/// <summary>매수호가10</summary>
	public long bidho10 { get; set; }

	/// <summary>매도호가수량10</summary>
	public long offerrem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	public long bidrem10 { get; set; }

	/// <summary>매도호가수량합</summary>
	public long offer { get; set; }

	/// <summary>매수호가수량합</summary>
	public long bid { get; set; }

	/// <summary>수신시간</summary>
	public string hotime { get; set; } = string.Empty;

	/// <summary>예상체결가격</summary>
	public long yeprice { get; set; }

	/// <summary>예상체결수량</summary>
	public long yevolume { get; set; }

	/// <summary>예상체결전일구분</summary>
	public string yesign { get; set; } = string.Empty;

	/// <summary>예상체결전일대비</summary>
	public long yechange { get; set; }

	/// <summary>예상체결등락율</summary>
	public decimal yediff { get; set; }

	/// <summary>시간외매도잔량</summary>
	public long tmoffer { get; set; }

	/// <summary>시간외매수잔량</summary>
	public long tmbid { get; set; }

	/// <summary>동시구분</summary>
	public string ho_status { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>상한가</summary>
	public long uplmtprice { get; set; }

	/// <summary>하한가</summary>
	public long dnlmtprice { get; set; }

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>NXT매도호가수량1</summary>
	public long nxt_offerrem1 { get; set; }

	/// <summary>NXT매수호가수량1</summary>
	public long nxt_bidrem1 { get; set; }

	/// <summary>NXT매도호가수량2</summary>
	public long nxt_offerrem2 { get; set; }

	/// <summary>NXT매수호가수량2</summary>
	public long nxt_bidrem2 { get; set; }

	/// <summary>NXT매도호가수량3</summary>
	public long nxt_offerrem3 { get; set; }

	/// <summary>NXT매수호가수량3</summary>
	public long nxt_bidrem3 { get; set; }

	/// <summary>NXT매도호가수량4</summary>
	public long nxt_offerrem4 { get; set; }

	/// <summary>NXT매수호가수량4</summary>
	public long nxt_bidrem4 { get; set; }

	/// <summary>NXT매도호가수량5</summary>
	public long nxt_offerrem5 { get; set; }

	/// <summary>NXT매수호가수량5</summary>
	public long nxt_bidrem5 { get; set; }

	/// <summary>NXT매도호가수량6</summary>
	public long nxt_offerrem6 { get; set; }

	/// <summary>NXT매수호가수량6</summary>
	public long nxt_bidrem6 { get; set; }

	/// <summary>NXT매도호가수량7</summary>
	public long nxt_offerrem7 { get; set; }

	/// <summary>NXT매수호가수량7</summary>
	public long nxt_bidrem7 { get; set; }

	/// <summary>NXT매도호가수량8</summary>
	public long nxt_offerrem8 { get; set; }

	/// <summary>NXT매수호가수량8</summary>
	public long nxt_bidrem8 { get; set; }

	/// <summary>NXT매도호가수량9</summary>
	public long nxt_offerrem9 { get; set; }

	/// <summary>NXT매수호가수량9</summary>
	public long nxt_bidrem9 { get; set; }

	/// <summary>NXT매도호가수량10</summary>
	public long nxt_offerrem10 { get; set; }

	/// <summary>NXT매수호가수량10</summary>
	public long nxt_bidrem10 { get; set; }

	/// <summary>NXT매도호가수량합</summary>
	public long nxt_offer { get; set; }

	/// <summary>NXT매수호가수량합</summary>
	public long nxt_bid { get; set; }

	/// <summary>NXT예상체결가격</summary>
	public long nxt_yeprice { get; set; }

	/// <summary>NXT예상체결수량</summary>
	public long nxt_yevolume { get; set; }

	/// <summary>NXT예상체결전일구분</summary>
	public string nxt_yesign { get; set; } = string.Empty;

	/// <summary>NXT예상체결전일대비</summary>
	public long nxt_yechange { get; set; }

	/// <summary>NXT예상체결등락율</summary>
	public decimal nxt_yediff { get; set; }

	/// <summary>NXT동시구분</summary>
	public string nxt_ho_status { get; set; } = string.Empty;

	/// <summary>통합매도호가수량1</summary>
	public long unx_offerrem1 { get; set; }

	/// <summary>통합매수호가수량1</summary>
	public long unx_bidrem1 { get; set; }

	/// <summary>통합매도호가수량2</summary>
	public long unx_offerrem2 { get; set; }

	/// <summary>통합매수호가수량2</summary>
	public long unx_bidrem2 { get; set; }

	/// <summary>통합매도호가수량3</summary>
	public long unx_offerrem3 { get; set; }

	/// <summary>통합매수호가수량3</summary>
	public long unx_bidrem3 { get; set; }

	/// <summary>통합매도호가수량4</summary>
	public long unx_offerrem4 { get; set; }

	/// <summary>통합매수호가수량4</summary>
	public long unx_bidrem4 { get; set; }

	/// <summary>통합매도호가수량5</summary>
	public long unx_offerrem5 { get; set; }

	/// <summary>통합매수호가수량5</summary>
	public long unx_bidrem5 { get; set; }

	/// <summary>통합매도호가수량6</summary>
	public long unx_offerrem6 { get; set; }

	/// <summary>통합매수호가수량6</summary>
	public long unx_bidrem6 { get; set; }

	/// <summary>통합매도호가수량7</summary>
	public long unx_offerrem7 { get; set; }

	/// <summary>통합매수호가수량7</summary>
	public long unx_bidrem7 { get; set; }

	/// <summary>통합매도호가수량8</summary>
	public long unx_offerrem8 { get; set; }

	/// <summary>통합매수호가수량8</summary>
	public long unx_bidrem8 { get; set; }

	/// <summary>통합매도호가수량9</summary>
	public long unx_offerrem9 { get; set; }

	/// <summary>통합매수호가수량9</summary>
	public long unx_bidrem9 { get; set; }

	/// <summary>통합매도호가수량10</summary>
	public long unx_offerrem10 { get; set; }

	/// <summary>통합매수호가수량10</summary>
	public long unx_bidrem10 { get; set; }

	/// <summary>통합매도호가수량합</summary>
	public long unx_offer { get; set; }

	/// <summary>통합매수호가수량합</summary>
	public long unx_bid { get; set; }

	/// <summary>KRX중간가격</summary>
	public long krx_midprice { get; set; }

	/// <summary>KRX매도중간가잔량합계수량</summary>
	public long krx_offermidsumrem { get; set; }

	/// <summary>KRX매수중간가잔량합계수량</summary>
	public long krx_bidmidsumrem { get; set; }

	/// <summary>NXT중간가격</summary>
	public long nxt_midprice { get; set; }

	/// <summary>NXT매도중간가잔량합계수량</summary>
	public long nxt_offermidsumrem { get; set; }

	/// <summary>NXT매수중간가잔량합계수량</summary>
	public long nxt_bidmidsumrem { get; set; }

	/// <summary>거래소별단축코드</summary>
	public string ex_shcode { get; set; } = string.Empty;

	/// <summary>KRX중간가잔량합계수량</summary>
	public long krx_midsumrem { get; set; }

	/// <summary>KRX중간가잔량구분(' '없음'1'매도'2'매수)</summary>
	public string krx_midsumremgubun { get; set; } = string.Empty;

	/// <summary>NXT중간가잔량합계수량</summary>
	public long nxt_midsumrem { get; set; }

	/// <summary>NXT중간가잔량구분(' '없음'1'매도'2'매수)</summary>
	public string nxt_midsumremgubun { get; set; } = string.Empty;
}