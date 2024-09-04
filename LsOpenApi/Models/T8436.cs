namespace LsOpenApi.Models;
/// <summary>
/// 주식종목조회 API용(t8436)
/// </summary>
internal class t8436 : LsResponseCore
{
	public t8436InBlock t8436InBlock { get; set; } = new();
	public List<t8436OutBlock> t8436OutBlock { get; set; } = new();
}

/// <summary>
/// 주식종목조회 API용(t8436) - InBlock
/// </summary>
internal class t8436InBlock
{
	/// <summary>구분(0:전체1:코스피2:코스닥)</summary>
	public string gubun { get; set; } = string.Empty;
}

/// <summary>
/// 주식종목조회 API용(t8436) - OutBlock
/// </summary>
internal class t8436OutBlock
{
	/// <summary>종목명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>확장코드</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>ETF구분(1:ETF2:ETN)</summary>
	public string etfgubun { get; set; } = string.Empty;

	/// <summary>상한가</summary>
	public long uplmtprice { get; set; }

	/// <summary>하한가</summary>
	public long dnlmtprice { get; set; }

	/// <summary>전일가</summary>
	public long jnilclose { get; set; }

	/// <summary>주문수량단위</summary>
	public string memedan { get; set; } = string.Empty;

	/// <summary>기준가</summary>
	public long recprice { get; set; }

	/// <summary>구분(1:코스피2:코스닥)</summary>
	public string gubun { get; set; } = string.Empty;

	/// <summary>증권그룹(01.주식; 03.예탁증서(DR); 04.증권투자회사(뮤추얼펀드); 06.Reits종목; 08.상장지수펀드(ETF); 10.선박투자회사; 12.인프라투융자회사; 13.해외ETF; 14.해외원주; 15.ETN)</summary>
	public string bu12gubun { get; set; } = string.Empty;

	/// <summary>기업인수목적회사여부(Y/N)</summary>
	public string spac_gubun { get; set; } = string.Empty;

	/// <summary>filler(미사용)</summary>
	public string filler { get; set; } = string.Empty;
}

