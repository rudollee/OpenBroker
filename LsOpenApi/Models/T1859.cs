namespace LsOpenApi.Models;
/// <summary>
/// 서버저장조건 조건검색
/// </summary>
internal class t1859 : LsResponseCore
{
	public t1859InBlock t1859InBlock { get; set; } = new();
	public t1859OutBlock t1859OutBlock { get; set; } = new();
	public List<t1859OutBlock1> t1859OutBlock1 { get; set; } = new();
}

/// <summary>
/// 서버저장조건 조건검색 - InBlock
/// </summary>
internal class t1859InBlock
{
	/// <summary>종목검색입력값</summary>
	public string query_index { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건 조건검색 - OutBlock
/// </summary>
internal class t1859OutBlock
{
	/// <summary>검색종목수</summary>
	public long result_count { get; set; }

	/// <summary>포착시간</summary>
	public string result_time { get; set; } = string.Empty;

	/// <summary>전략설명</summary>
	public string text { get; set; } = string.Empty;
}

/// <summary>
/// 서버저장조건 조건검색 - OutBlock1
/// </summary>
internal class t1859OutBlock1
{
	/// <summary>종목코드</summary>
	public string shcode { get; set; } = string.Empty;

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
}