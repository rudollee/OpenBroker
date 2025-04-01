namespace LsOpenApi.Models;
/// <summary>
/// 옵션전광판(t2301)
/// </summary>
internal class t2301 : LsResponseCore
{
	public t2301InBlock t2301InBlock { get; set; } = new();
	public t2301OutBlock t2301OutBlock { get; set; } = new();
	public List<t2301OutBlock1> t2301OutBlock1 { get; set; } = new();
	public List<t2301OutBlock2> t2301OutBlock2 { get; set; } = new();
}

/// <summary>
/// 옵션전광판(t2301) - InBlock
/// </summary>
internal class t2301InBlock
{
	/// <summary>월물</summary>
	public string yyyymm { get; set; } = string.Empty;

	/// <summary>미니구분(M:미니G:정규)</summary>
	public string gubun { get; set; } = "G";
}

/// <summary>
/// 옵션전광판(t2301) - OutBlock
/// </summary>
internal class t2301OutBlock
{
	/// <summary>역사적변동성</summary>
	public long histimpv { get; set; }

	/// <summary>옵션잔존일</summary>
	public long jandatecnt { get; set; }

	/// <summary>콜옵션대표IV</summary>
	public decimal cimpv { get; set; }

	/// <summary>풋옵션대표IV</summary>
	public decimal pimpv { get; set; }

	/// <summary>근월물현재가</summary>
	public decimal gmprice { get; set; }

	/// <summary>근월물전일대비구분</summary>
	public string gmsign { get; set; } = string.Empty;

	/// <summary>근월물전일대비</summary>
	public decimal gmchange { get; set; }

	/// <summary>근월물등락율</summary>
	public decimal gmdiff { get; set; }

	/// <summary>근월물거래량</summary>
	public long gmvolume { get; set; }

	/// <summary>근월물선물코드</summary>
	public string gmshcode { get; set; } = string.Empty;
}

/// <summary>
/// 옵션전광판(t2301) - OutBlock1
/// </summary>
internal class t2301OutBlock1
{
	/// <summary>행사가</summary>
	public decimal actprice { get; set; }

	/// <summary>콜옵션코드</summary>
	public string optcode { get; set; } = string.Empty;

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

	/// <summary>IV</summary>
	public decimal iv { get; set; }

	/// <summary>미결제약정</summary>
	public long mgjv { get; set; }

	/// <summary>미결제약정증감</summary>
	public long mgjvupdn { get; set; }

	/// <summary>매도호가</summary>
	public decimal offerho1 { get; set; }

	/// <summary>매수호가</summary>
	public decimal bidho1 { get; set; }

	/// <summary>체결량</summary>
	public long cvolume { get; set; }

	/// <summary>델타</summary>
	public decimal delt { get; set; }

	/// <summary>감마</summary>
	public decimal gama { get; set; }

	/// <summary>베가</summary>
	public decimal vega { get; set; }

	/// <summary>쎄타</summary>
	public decimal ceta { get; set; }

	/// <summary>로우</summary>
	public decimal rhox { get; set; }

	/// <summary>이론가</summary>
	public decimal theoryprice { get; set; }

	/// <summary>내재가치</summary>
	public decimal impv { get; set; }

	/// <summary>시간가치</summary>
	public decimal timevl { get; set; }

	/// <summary>잔고수량</summary>
	public long jvolume { get; set; }

	/// <summary>평가손익</summary>
	public long parpl { get; set; }

	/// <summary>청산가능수량</summary>
	public long jngo { get; set; }

	/// <summary>매도잔량</summary>
	public long offerrem1 { get; set; }

	/// <summary>매수잔량</summary>
	public long bidrem1 { get; set; }

	/// <summary>시가</summary>
	public decimal open { get; set; }

	/// <summary>고가</summary>
	public decimal high { get; set; }

	/// <summary>저가</summary>
	public decimal low { get; set; }

	/// <summary>ATM구분</summary>
	public string atmgubun { get; set; } = string.Empty;

	/// <summary>지수환산</summary>
	public decimal jisuconv { get; set; }

	/// <summary>거래대금</summary>
	public decimal value { get; set; }

}

/// <summary>
/// 옵션전광판(t2301) - OutBlock2
/// </summary>
internal class t2301OutBlock2
{
	/// <summary>행사가</summary>
	public decimal actprice { get; set; }

	/// <summary>풋옵션코드</summary>
	public string optcode { get; set; } = string.Empty;

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

	/// <summary>IV</summary>
	public decimal iv { get; set; }

	/// <summary>미결제약정</summary>
	public long mgjv { get; set; }

	/// <summary>미결제약정증감</summary>
	public long mgjvupdn { get; set; }

	/// <summary>매도호가</summary>
	public decimal offerho1 { get; set; }

	/// <summary>매수호가</summary>
	public decimal bidho1 { get; set; }

	/// <summary>체결량</summary>
	public long cvolume { get; set; }

	/// <summary>델타</summary>
	public decimal delt { get; set; }

	/// <summary>감마</summary>
	public decimal gama { get; set; }

	/// <summary>베가</summary>
	public decimal vega { get; set; }

	/// <summary>쎄타</summary>
	public decimal ceta { get; set; }

	/// <summary>로우</summary>
	public decimal rhox { get; set; }

	/// <summary>이론가</summary>
	public decimal theoryprice { get; set; }

	/// <summary>내재가치</summary>
	public decimal impv { get; set; }

	/// <summary>시간가치</summary>
	public decimal timevl { get; set; }

	/// <summary>잔고수량</summary>
	public long jvolume { get; set; }

	/// <summary>평가손익</summary>
	public long parpl { get; set; }

	/// <summary>청산가능수량</summary>
	public long jngo { get; set; }

	/// <summary>매도잔량</summary>
	public long offerrem1 { get; set; }

	/// <summary>매수잔량</summary>
	public long bidrem1 { get; set; }

	/// <summary>시가</summary>
	public decimal open { get; set; }

	/// <summary>고가</summary>
	public decimal high { get; set; }

	/// <summary>저가</summary>
	public decimal low { get; set; }

	/// <summary>ATM구분</summary>
	public string atmgubun { get; set; } = string.Empty;

	/// <summary>지수환산</summary>
	public decimal jisuconv { get; set; }

	/// <summary>거래대금</summary>
	public decimal value { get; set; }
}