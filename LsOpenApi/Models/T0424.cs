using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
/// <summary>
/// 주식잔고2(t0424)
/// </summary>
internal class T0424 : LsResponseCore
{
	[JsonPropertyName("t0424InBlock")]
	public T0424InBlock T0424InBlock { get; set; } = new();
	[JsonPropertyName("t0424OutBlock")]
	public T0424OutBlock T0424OutBlock { get; set; } = new();
	[JsonPropertyName("t0424OutBlock1")]
	public List<T0424OutBlock1> T0424OutBlock1 { get; set; } = [];
}

/// <summary>
/// 주식잔고2(t0424) - InBlock
/// </summary>
internal class T0424InBlock
{
	/// <summary>계좌번호</summary>
	[JsonPropertyName("accno")]
	public string Accno { get; set; } = string.Empty;

	/// <summary>비밀번호</summary>
	[JsonPropertyName("passwd")]
	public string Passwd { get; set; } = string.Empty;

	/// <summary>단가구분</summary>
	[JsonPropertyName("prcgb")]
	public string Prcgb { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	[JsonPropertyName("chegb")]
	public string Chegb { get; set; } = string.Empty;

	/// <summary>단일가구분</summary>
	[JsonPropertyName("dangb")]
	public string Dangb { get; set; } = string.Empty;

	/// <summary>제비용포함여부</summary>
	[JsonPropertyName("charge")]
	public string Charge { get; set; } = string.Empty;

	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식잔고2(t0424) - OutBlock
/// </summary>
internal class T0424OutBlock
{
	/// <summary>추정순자산</summary>
	[JsonPropertyName("sunamt")]
	public long Sunamt { get; set; }

	/// <summary>실현손익</summary>
	[JsonPropertyName("dtsunik")]
	public long Dtsunik { get; set; }

	/// <summary>매입금액</summary>
	[JsonPropertyName("mamt")]
	public long Mamt { get; set; }

	/// <summary>추정D2예수금</summary>
	[JsonPropertyName("sunamt1")]
	public long Sunamt1 { get; set; }

	/// <summary>CTS_종목번호</summary>
	[JsonPropertyName("cts_expcode")]
	public string CtsExpcode { get; set; } = string.Empty;

	/// <summary>평가금액</summary>
	[JsonPropertyName("tappamt")]
	public long Tappamt { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("tdtsunik")]
	public long Tdtsunik { get; set; }
}

/// <summary>
/// 주식잔고2(t0424) - OutBlock1
/// </summary>
internal class T0424OutBlock1
{
	/// <summary>종목번호</summary>
	[JsonPropertyName("expcode")]
	public string Expcode { get; set; } = string.Empty;

	/// <summary>잔고구분</summary>
	[JsonPropertyName("jangb")]
	public string Jangb { get; set; } = string.Empty;

	/// <summary>잔고수량</summary>
	[JsonPropertyName("janqty")]
	public long Janqty { get; set; }

	/// <summary>매도가능수량</summary>
	[JsonPropertyName("mdposqt")]
	public long Mdposqt { get; set; }

	/// <summary>평균단가</summary>
	[JsonPropertyName("pamt")]
	public long Pamt { get; set; }

	/// <summary>매입금액</summary>
	[JsonPropertyName("mamt")]
	public long Mamt { get; set; }

	/// <summary>대출금액</summary>
	[JsonPropertyName("sinamt")]
	public long Sinamt { get; set; }

	/// <summary>만기일자</summary>
	[JsonPropertyName("lastdt")]
	public string Lastdt { get; set; } = string.Empty;

	/// <summary>당일매수금액</summary>
	[JsonPropertyName("msat")]
	public long Msat { get; set; }

	/// <summary>당일매수단가</summary>
	[JsonPropertyName("mpms")]
	public long Mpms { get; set; }

	/// <summary>당일매도금액</summary>
	[JsonPropertyName("mdat")]
	public long Mdat { get; set; }

	/// <summary>당일매도단가</summary>
	[JsonPropertyName("mpmd")]
	public long Mpmd { get; set; }

	/// <summary>전일매수금액</summary>
	[JsonPropertyName("jsat")]
	public long Jsat { get; set; }

	/// <summary>전일매수단가</summary>
	[JsonPropertyName("jpms")]
	public long Jpms { get; set; }

	/// <summary>전일매도금액</summary>
	[JsonPropertyName("jdat")]
	public long Jdat { get; set; }

	/// <summary>전일매도단가</summary>
	[JsonPropertyName("jpmd")]
	public long Jpmd { get; set; }

	/// <summary>처리순번</summary>
	[JsonPropertyName("sysprocseq")]
	public long Sysprocseq { get; set; }

	/// <summary>대출일자</summary>
	[JsonPropertyName("loandt")]
	public string Loandt { get; set; } = string.Empty;

	/// <summary>종목명</summary>
	[JsonPropertyName("hname")]
	public string Hname { get; set; } = string.Empty;

	/// <summary>시장구분</summary>
	[JsonPropertyName("marketgb")]
	public string Marketgb { get; set; } = string.Empty;

	/// <summary>종목구분</summary>
	[JsonPropertyName("jonggb")]
	public string Jonggb { get; set; } = string.Empty;

	/// <summary>보유비중</summary>
	[JsonPropertyName("janrt")]
	public decimal Janrt { get; set; }

	/// <summary>현재가</summary>
	[JsonPropertyName("price")]
	public long Price { get; set; }

	/// <summary>평가금액</summary>
	[JsonPropertyName("appamt")]
	public long Appamt { get; set; }

	/// <summary>평가손익</summary>
	[JsonPropertyName("dtsunik")]
	public long Dtsunik { get; set; }

	/// <summary>수익율</summary>
	[JsonPropertyName("sunikrt")]
	public decimal Sunikrt { get; set; }

	/// <summary>수수료</summary>
	[JsonPropertyName("fee")]
	public long Fee { get; set; }

	/// <summary>제세금</summary>
	[JsonPropertyName("tax")]
	public long Tax { get; set; }

	/// <summary>신용이자</summary>
	[JsonPropertyName("sininter")]
	public long Sininter { get; set; }
}