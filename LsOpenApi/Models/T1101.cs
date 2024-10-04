namespace LsOpenApi.Models;
/// <summary>
/// 주식현재가호가조회(t1101)
/// </summary>
internal class t1101
{
	public t1101InBlock t1101InBlock { get; set; } = new();
	public t1101OutBlock t1101OutBlock { get; set; } = new();
}

/// <summary>
/// 주식현재가호가조회(t1101) - InBlock
/// </summary>
internal class t1101InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식현재가호가조회(t1101) - OutBlock
/// </summary>
internal class t1101OutBlock
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

	/// <summary>직전매도대비수량1</summary>
	public long preoffercha1 { get; set; }

	/// <summary>직전매수대비수량1</summary>
	public long prebidcha1 { get; set; }

	/// <summary>매도호가2</summary>
	public long offerho2 { get; set; }

	/// <summary>매수호가2</summary>
	public long bidho2 { get; set; }

	/// <summary>매도호가수량2</summary>
	public long offerrem2 { get; set; }

	/// <summary>매수호가수량2</summary>
	public long bidrem2 { get; set; }

	/// <summary>직전매도대비수량2</summary>
	public long preoffercha2 { get; set; }

	/// <summary>직전매수대비수량2</summary>
	public long prebidcha2 { get; set; }

	/// <summary>매도호가3</summary>
	public long offerho3 { get; set; }

	/// <summary>매수호가3</summary>
	public long bidho3 { get; set; }

	/// <summary>매도호가수량3</summary>
	public long offerrem3 { get; set; }

	/// <summary>매수호가수량3</summary>
	public long bidrem3 { get; set; }

	/// <summary>직전매도대비수량3</summary>
	public long preoffercha3 { get; set; }

	/// <summary>직전매수대비수량3</summary>
	public long prebidcha3 { get; set; }

	/// <summary>매도호가4</summary>
	public long offerho4 { get; set; }

	/// <summary>매수호가4</summary>
	public long bidho4 { get; set; }

	/// <summary>매도호가수량4</summary>
	public long offerrem4 { get; set; }

	/// <summary>매수호가수량4</summary>
	public long bidrem4 { get; set; }

	/// <summary>직전매도대비수량4</summary>
	public long preoffercha4 { get; set; }

	/// <summary>직전매수대비수량4</summary>
	public long prebidcha4 { get; set; }

	/// <summary>매도호가5</summary>
	public long offerho5 { get; set; }

	/// <summary>매수호가5</summary>
	public long bidho5 { get; set; }

	/// <summary>매도호가수량5</summary>
	public long offerrem5 { get; set; }

	/// <summary>매수호가수량5</summary>
	public long bidrem5 { get; set; }

	/// <summary>직전매도대비수량5</summary>
	public long preoffercha5 { get; set; }

	/// <summary>직전매수대비수량5</summary>
	public long prebidcha5 { get; set; }

	/// <summary>매도호가6</summary>
	public long offerho6 { get; set; }

	/// <summary>매수호가6</summary>
	public long bidho6 { get; set; }

	/// <summary>매도호가수량6</summary>
	public long offerrem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	public long bidrem6 { get; set; }

	/// <summary>직전매도대비수량6</summary>
	public long preoffercha6 { get; set; }

	/// <summary>직전매수대비수량6</summary>
	public long prebidcha6 { get; set; }

	/// <summary>매도호가7</summary>
	public long offerho7 { get; set; }

	/// <summary>매수호가7</summary>
	public long bidho7 { get; set; }

	/// <summary>매도호가수량7</summary>
	public long offerrem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	public long bidrem7 { get; set; }

	/// <summary>직전매도대비수량7</summary>
	public long preoffercha7 { get; set; }

	/// <summary>직전매수대비수량7</summary>
	public long prebidcha7 { get; set; }

	/// <summary>매도호가8</summary>
	public long offerho8 { get; set; }

	/// <summary>매수호가8</summary>
	public long bidho8 { get; set; }

	/// <summary>매도호가수량8</summary>
	public long offerrem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	public long bidrem8 { get; set; }

	/// <summary>직전매도대비수량8</summary>
	public long preoffercha8 { get; set; }

	/// <summary>직전매수대비수량8</summary>
	public long prebidcha8 { get; set; }

	/// <summary>매도호가9</summary>
	public long offerho9 { get; set; }

	/// <summary>매수호가9</summary>
	public long bidho9 { get; set; }

	/// <summary>매도호가수량9</summary>
	public long offerrem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	public long bidrem9 { get; set; }

	/// <summary>직전매도대비수량9</summary>
	public long preoffercha9 { get; set; }

	/// <summary>직전매수대비수량9</summary>
	public long prebidcha9 { get; set; }

	/// <summary>매도호가10</summary>
	public long offerho10 { get; set; }

	/// <summary>매수호가10</summary>
	public long bidho10 { get; set; }

	/// <summary>매도호가수량10</summary>
	public long offerrem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	public long bidrem10 { get; set; }

	/// <summary>직전매도대비수량10</summary>
	public long preoffercha10 { get; set; }

	/// <summary>직전매수대비수량10</summary>
	public long prebidcha10 { get; set; }

	/// <summary>매도호가수량합</summary>
	public long offer { get; set; }

	/// <summary>매수호가수량합</summary>
	public long bid { get; set; }

	/// <summary>직전매도대비수량합</summary>
	public long preoffercha { get; set; }

	/// <summary>직전매수대비수량합</summary>
	public long prebidcha { get; set; }

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
}