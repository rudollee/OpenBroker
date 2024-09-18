namespace LsOpenApi.Models;
/// <summary>
/// 신규상장종목조회(t1403)
/// </summary>
internal class t1403 : LsResponseCore
{
	public t1403OutBlock t1403OutBlock { get; set; } = new();
	public List<t1403OutBlock1> t1403OutBlock1 { get; set; } = new();
}

/// <summary>
/// 신규상장종목조회(t1403) - InBlock
/// </summary>
internal class t1403InBlock
{
	/// <summary>구분</summary>
	public string gubun { get; set; } = string.Empty;

	/// <summary>시작상장월</summary>
	public string styymm { get; set; } = string.Empty;

	/// <summary>종료상장월</summary>
	public string enyymm { get; set; } = string.Empty;

	/// <summary>IDX</summary>
	public long idx { get; set; }

}

/// <summary>
/// 신규상장종목조회(t1403) - OutBlock
/// </summary>
internal class t1403OutBlock
{
	/// <summary>IDX</summary>
	public long idx { get; set; }

}

/// <summary>
/// 신규상장종목조회(t1403) - OutBlock1
/// </summary>
internal class t1403OutBlock1
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

	/// <summary>공모가</summary>
	public long kmprice { get; set; }

	/// <summary>등록일</summary>
	public string date { get; set; } = string.Empty;

	/// <summary>등록일기준가</summary>
	public long recprice { get; set; }

	/// <summary>기준가등락율</summary>
	public decimal kmdiff { get; set; }

	/// <summary>등록일종가</summary>
	public long close { get; set; }

	/// <summary>등록일등락율</summary>
	public decimal recdiff { get; set; }

	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;

}

