namespace LsOpenApi.Models;
/// <summary>
/// KRX+NXT통합 호가잔량(UH1)
/// </summary>
internal class UH1
{
	public UH1InBlock UH1InBlock { get; set; } = new();
	public UH1OutBlock UH1OutBlock { get; set; } = new();
}

/// <summary>
/// KRX+NXT통합 호가잔량(UH1) - InBlock
/// </summary>
internal class UH1InBlock
{
	/// <summary>거래소별단축코드</summary>
	public string ex_shcode { get; set; } = string.Empty;
}

/// <summary>
/// KRX+NXT통합 호가잔량(UH1) - OutBlock
/// </summary>
internal class UH1OutBlock
{
	/// <summary>호가시간</summary>
	public string hotime { get; set; } = string.Empty;

	/// <summary>매도호가1</summary>
	public string offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	public string bidho1 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량1</summary>
	public string krx_offerrem1 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량1</summary>
	public string nxt_offerrem1 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량1</summary>
	public string unt_offerrem1 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량1</summary>
	public string krx_bidrem1 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량1</summary>
	public string nxt_bidrem1 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량1</summary>
	public string unt_bidrem1 { get; set; } = string.Empty;

	/// <summary>매도호가2</summary>
	public string offerho2 { get; set; } = string.Empty;

	/// <summary>매수호가2</summary>
	public string bidho2 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량2</summary>
	public string krx_offerrem2 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량2</summary>
	public string nxt_offerrem2 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량2</summary>
	public string unt_offerrem2 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량2</summary>
	public string krx_bidrem2 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량2</summary>
	public string nxt_bidrem2 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량2</summary>
	public string unt_bidrem2 { get; set; } = string.Empty;

	/// <summary>매도호가3</summary>
	public string offerho3 { get; set; } = string.Empty;

	/// <summary>매수호가3</summary>
	public string bidho3 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량3</summary>
	public string krx_offerrem3 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량3</summary>
	public string nxt_offerrem3 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량3</summary>
	public string unt_offerrem3 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량3</summary>
	public string krx_bidrem3 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량3</summary>
	public string nxt_bidrem3 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량3</summary>
	public string unt_bidrem3 { get; set; } = string.Empty;

	/// <summary>매도호가4</summary>
	public string offerho4 { get; set; } = string.Empty;

	/// <summary>매수호가4</summary>
	public string bidho4 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량4</summary>
	public string krx_offerrem4 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량4</summary>
	public string nxt_offerrem4 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량4</summary>
	public string unt_offerrem4 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량4</summary>
	public string krx_bidrem4 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량4</summary>
	public string nxt_bidrem4 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량4</summary>
	public string unt_bidrem4 { get; set; } = string.Empty;

	/// <summary>매도호가5</summary>
	public string offerho5 { get; set; } = string.Empty;

	/// <summary>매수호가5</summary>
	public string bidho5 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량5</summary>
	public string krx_offerrem5 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량5</summary>
	public string nxt_offerrem5 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량5</summary>
	public string unt_offerrem5 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량5</summary>
	public string krx_bidrem5 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량5</summary>
	public string nxt_bidrem5 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량5</summary>
	public string unt_bidrem5 { get; set; } = string.Empty;

	/// <summary>매도호가6</summary>
	public string offerho6 { get; set; } = string.Empty;

	/// <summary>매수호가6</summary>
	public string bidho6 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량6</summary>
	public string krx_offerrem6 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량6</summary>
	public string nxt_offerrem6 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량6</summary>
	public string unt_offerrem6 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량6</summary>
	public string krx_bidrem6 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량6</summary>
	public string nxt_bidrem6 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량6</summary>
	public string unt_bidrem6 { get; set; } = string.Empty;

	/// <summary>매도호가7</summary>
	public string offerho7 { get; set; } = string.Empty;

	/// <summary>매수호가7</summary>
	public string bidho7 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량7</summary>
	public string krx_offerrem7 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량7</summary>
	public string nxt_offerrem7 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량7</summary>
	public string unt_offerrem7 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량7</summary>
	public string krx_bidrem7 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량7</summary>
	public string nxt_bidrem7 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량7</summary>
	public string unt_bidrem7 { get; set; } = string.Empty;

	/// <summary>매도호가8</summary>
	public string offerho8 { get; set; } = string.Empty;

	/// <summary>매수호가8</summary>
	public string bidho8 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량8</summary>
	public string krx_offerrem8 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량8</summary>
	public string nxt_offerrem8 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량8</summary>
	public string unt_offerrem8 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량8</summary>
	public string krx_bidrem8 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량8</summary>
	public string nxt_bidrem8 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량8</summary>
	public string unt_bidrem8 { get; set; } = string.Empty;

	/// <summary>매도호가9</summary>
	public string offerho9 { get; set; } = string.Empty;

	/// <summary>매수호가9</summary>
	public string bidho9 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량9</summary>
	public string krx_offerrem9 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량9</summary>
	public string nxt_offerrem9 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량9</summary>
	public string unt_offerrem9 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량9</summary>
	public string krx_bidrem9 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량9</summary>
	public string nxt_bidrem9 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량9</summary>
	public string unt_bidrem9 { get; set; } = string.Empty;

	/// <summary>매도호가10</summary>
	public string offerho10 { get; set; } = string.Empty;

	/// <summary>매수호가10</summary>
	public string bidho10 { get; set; } = string.Empty;

	/// <summary>KRX매도호가잔량10</summary>
	public string krx_offerrem10 { get; set; } = string.Empty;

	/// <summary>NXT매도호가잔량10</summary>
	public string nxt_offerrem10 { get; set; } = string.Empty;

	/// <summary>통합매도호가잔량10</summary>
	public string unt_offerrem10 { get; set; } = string.Empty;

	/// <summary>KRX매수호가잔량10</summary>
	public string krx_bidrem10 { get; set; } = string.Empty;

	/// <summary>NXT매수호가잔량10</summary>
	public string nxt_bidrem10 { get; set; } = string.Empty;

	/// <summary>통합매수호가잔량10</summary>
	public string unt_bidrem10 { get; set; } = string.Empty;

	/// <summary>KRX총매도호가잔량</summary>
	public string krx_totofferrem { get; set; } = string.Empty;

	/// <summary>NXT총매도호가잔량</summary>
	public string nxt_totofferrem { get; set; } = string.Empty;

	/// <summary>통합총매도호가잔량</summary>
	public string unt_totofferrem { get; set; } = string.Empty;

	/// <summary>KRX총매수호가잔량</summary>
	public string krx_totbidrem { get; set; } = string.Empty;

	/// <summary>NXT총매수호가잔량</summary>
	public string nxt_totbidrem { get; set; } = string.Empty;

	/// <summary>통합총매수호가잔량</summary>
	public string unt_totbidrem { get; set; } = string.Empty;

	/// <summary>        KRX동시호가구분</summary>
	public string krx_donsigubun { get; set; } = string.Empty;

	/// <summary>        NXT동시호가구분</summary>
	public string nxt_donsigubun { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	public string alloc_gubun { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	public string volume { get; set; } = string.Empty;

	/// <summary>KRX중간가격</summary>
	public string krx_midprice { get; set; } = string.Empty;

	/// <summary>KRX매도중간가잔량합계수량</summary>
	public string krx_offermidsumrem { get; set; } = string.Empty;

	/// <summary>KRX매수중간가잔량합계수량</summary>
	public string krx_bidmidsumrem { get; set; } = string.Empty;

	/// <summary>NXT중간가격</summary>
	public string nxt_midprice { get; set; } = string.Empty;

	/// <summary>NXT매도중간가잔량합계수량</summary>
	public string nxt_offermidsumrem { get; set; } = string.Empty;

	/// <summary>NXT매수중간가잔량합계수량</summary>
	public string nxt_bidmidsumrem { get; set; } = string.Empty;

	/// <summary>        KRX중간가잔량합계수량</summary>
	public string krx_midsumrem { get; set; } = string.Empty;

	/// <summary>        KRX중간가잔량구분(' '없음'1'매도'2'매수)</summary>
	public string krx_midsumremgubun { get; set; } = string.Empty;

	/// <summary>        NXT중간가잔량합계수량</summary>
	public string nxt_midsumrem { get; set; } = string.Empty;

	/// <summary>        NXT중간가잔량구분(' '없음'1'매도'2'매수)</summary>
	public string nxt_midsumremgubun { get; set; } = string.Empty;

	/// <summary>거래소별단축코드</summary>
	public string ex_shcode { get; set; } = string.Empty;
}