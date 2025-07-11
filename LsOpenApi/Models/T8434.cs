namespace LsOpenApi.Models;
/// <summary>
/// 선물/옵션멀티현재가조회(t8434)
/// </summary>
internal class t8434 : LsResponseCore
{
	public t8434InBlock t8434InBlock { get; set; } = new();
	public List<t8434OutBlock1> t8434OutBlock1 { get; set; } = [];
}

/// <summary>
/// 선물/옵션멀티현재가조회(t8434) - InBlock
/// </summary>
internal class t8434InBlock
{
	/// <summary>건수</summary>
	public long qrycnt { get; set; }

	/// <summary>단축코드</summary>
	public string focode { get; set; } = string.Empty;
}

/// <summary>
/// 선물/옵션멀티현재가조회(t8434) - OutBlock1
/// </summary>
internal class t8434OutBlock1
{
	/// <summary>한글명</summary>
	public string hname { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public decimal price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public decimal change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>누적거래량</summary>
	public long volume { get; set; }

	/// <summary>체결건수</summary>
	public long checnt { get; set; }

	/// <summary>단축코드</summary>
	public string focode { get; set; } = string.Empty;
}