namespace LsOpenApi.Models;
/// <summary>
/// 주식잔고2(t0424)
/// </summary>
internal class t0424 : LsResponseCore
{
	public t0424InBlock t0424InBlock { get; set; } = new();
	public t0424OutBlock t0424OutBlock { get; set; } = new();
	public List<t0424OutBlock1> t0424OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식잔고2(t0424) - InBlock
/// </summary>
internal class t0424InBlock
{
	/// <summary>계좌번호</summary>
	//public string accno { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	//public string passwd { get; set; } = string.Empty;

	/// <summary>단가구분</summary>
	public string prcgb { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	public string chegb { get; set; } = string.Empty;

	/// <summary>단일가구분</summary>
	public string dangb { get; set; } = string.Empty;

	/// <summary>제비용포함여부</summary>
	public string charge { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	public string cts_expcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식잔고2(t0424) - OutBlock
/// </summary>
internal class t0424OutBlock
{
	/// <summary>추정순자산</summary>
	public long sunamt { get; set; }

	/// <summary>실현손익</summary>
	public long dtsunik { get; set; }

	/// <summary>매입금액</summary>
	public long mamt { get; set; }

	/// <summary>추정D2예수금</summary>
	public long sunamt1 { get; set; }

	/// <summary>CTS_종목번호</summary>
	public string cts_expcode { get; set; } = string.Empty;

	/// <summary>평가금액</summary>
	public long tappamt { get; set; }

	/// <summary>평가손익</summary>
	public long tdtsunik { get; set; }

}

/// <summary>
/// 주식잔고2(t0424) - OutBlock1
/// </summary>
internal class t0424OutBlock1
{
	/// <summary>종목번호</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>잔고구분</summary>
	public string jangb { get; set; } = string.Empty;

	/// <summary>잔고수량</summary>
	public long janqty { get; set; }

	/// <summary>매도가능수량</summary>
	public long mdposqt { get; set; }

	/// <summary>평균단가</summary>
	public long pamt { get; set; }

	/// <summary>매입금액</summary>
	public long mamt { get; set; }

	/// <summary>대출금액</summary>
	public long sinamt { get; set; }

	/// <summary>만기일자</summary>
	public string lastdt { get; set; } = string.Empty;

	/// <summary>당일매수금액</summary>
	public long msat { get; set; }

	/// <summary>당일매수단가</summary>
	public long mpms { get; set; }

	/// <summary>당일매도금액</summary>
	public long mdat { get; set; }

	/// <summary>당일매도단가</summary>
	public long mpmd { get; set; }

	/// <summary>전일매수금액</summary>
	public long jsat { get; set; }

	/// <summary>전일매수단가</summary>
	public long jpms { get; set; }

	/// <summary>전일매도금액</summary>
	public long jdat { get; set; }

	/// <summary>전일매도단가</summary>
	public long jpmd { get; set; }

	/// <summary>처리순번</summary>
	public long sysprocseq { get; set; }

	/// <summary>대출일자</summary>
	public string loandt { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>시장구분</summary>
	public string marketgb { get; set; } = string.Empty;

	/// <summary>종목구분</summary>
	public string jonggb { get; set; } = string.Empty;

	/// <summary>보유비중</summary>
	public decimal janrt { get; set; }

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>평가금액</summary>
	public long appamt { get; set; }

	/// <summary>평가손익</summary>
	public long dtsunik { get; set; }

	/// <summary>수익율</summary>
	public decimal sunikrt { get; set; }

	/// <summary>수수료</summary>
	public long fee { get; set; }

	/// <summary>제세금</summary>
	public long tax { get; set; }

	/// <summary>신용이자</summary>
	public long sininter { get; set; }
}