namespace LsOpenApi.Models;
/// <summary>
/// 주식시간대별체결조회(t1301)
/// </summary>
internal class t1301 : LsResponseCore
{
	public t1301InBlock t1301InBlock { get; set; } = new();
	public t1301OutBlock t1301OutBlock { get; set; } = new();
	public List<t1301OutBlock1> t1301OutBlock1 { get; set; } = new();
}

/// <summary>
/// 주식시간대별체결조회(t1301) - InBlock
/// </summary>
internal class t1301InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>특이거래량</summary>
	public long cvolume { get; set; }

	/// <summary>시작시간</summary>
	public string starttime { get; set; } = string.Empty;

	/// <summary>종료시간</summary>
	public string endtime { get; set; } = string.Empty;

	/// <summary>시간CTS</summary>
	public string cts_time { get; set; } = string.Empty;
}

/// <summary>
/// 주식시간대별체결조회(t1301) - OutBlock
/// </summary>
internal class t1301OutBlock
{
	/// <summary>시간CTS</summary>
	public string cts_time { get; set; } = string.Empty;
}

/// <summary>
/// 주식시간대별체결조회(t1301) - OutBlock1
/// </summary>
internal class t1301OutBlock1
{
	/// <summary>시간</summary>
	public string chetime { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal diff { get; set; }

	/// <summary>체결수량</summary>
	public long cvolume { get; set; }

	/// <summary>체결강도</summary>
	public decimal chdegree { get; set; }

	/// <summary>거래량</summary>
	public long volume { get; set; }

	/// <summary>매도체결수량</summary>
	public long mdvolume { get; set; }

	/// <summary>매도체결건수</summary>
	public long mdchecnt { get; set; }

	/// <summary>매수체결수량</summary>
	public long msvolume { get; set; }

	/// <summary>매수체결건수</summary>
	public long mschecnt { get; set; }

	/// <summary>순체결량</summary>
	public long revolume { get; set; }

	/// <summary>순체결건수</summary>
	public long rechecnt { get; set; }
}