namespace LsOpenApi.Models;
/// <summary>
/// KOSPI체결(S3)
/// </summary>
internal class S3_
{
	public S3_OutBlock S3_OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI체결(S3) - InBlock
/// </summary>
internal class S3_InBlock
{
	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

}

/// <summary>
/// KOSPI체결(S3) - OutBlock
/// </summary>
internal class S3_OutBlock
{
	/// <summary>체결시간</summary>
	public string chetime { get; set; } = string.Empty;

	/// <summary>전일대비구분</summary>
	public string sign { get; set; } = string.Empty;

	/// <summary>전일대비</summary>
	public string change { get; set; } = string.Empty;

	/// <summary>등락율</summary>
	public string drate { get; set; } = string.Empty;

	/// <summary>현재가</summary>
	public string price { get; set; } = string.Empty;

	/// <summary>시가시간</summary>
	public string opentime { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public string open { get; set; } = string.Empty;

	/// <summary>고가시간</summary>
	public string hightime { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public string high { get; set; } = string.Empty;

	/// <summary>저가시간</summary>
	public string lowtime { get; set; } = string.Empty;

	/// <summary>저가</summary>
	public string low { get; set; } = string.Empty;

	/// <summary>체결구분</summary>
	public string cgubun { get; set; } = string.Empty;

	/// <summary>체결량</summary>
	public string cvolume { get; set; } = string.Empty;

	/// <summary>누적거래량</summary>
	public string volume { get; set; } = string.Empty;

	/// <summary>누적거래대금</summary>
	public string value { get; set; } = string.Empty;

	/// <summary>매도누적체결량</summary>
	public string mdvolume { get; set; } = string.Empty;

	/// <summary>매도누적체결건수</summary>
	public string mdchecnt { get; set; } = string.Empty;

	/// <summary>매수누적체결량</summary>
	public string msvolume { get; set; } = string.Empty;

	/// <summary>매수누적체결건수</summary>
	public string mschecnt { get; set; } = string.Empty;

	/// <summary>체결강도</summary>
	public string cpower { get; set; } = string.Empty;

	/// <summary>가중평균가</summary>
	public string w_avrg { get; set; } = string.Empty;

	/// <summary>매도호가</summary>
	public string offerho { get; set; }	= string.Empty;

	/// <summary>매수호가</summary>
	public string bidho { get; set; } = string.Empty;

	/// <summary>장정보</summary>
	public string status { get; set; } = string.Empty;

	/// <summary>전일동시간대거래량</summary>
	public string jnilvolume { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

}

/// <summary>
/// KOSDAQ체결(K3)
/// </summary>
internal class K3_
{
	public K3_OutBlock K3_OutBlock { get; set; } = new();
}

/// <summary>
/// KOSDAQ체결(K3) - Inblock
/// </summary>
internal class K3_InBlock : S3_InBlock { }

/// <summary>
/// KOSDAQ체결(K3) - OutBlock
/// </summary>
internal class K3_OutBlock : S3_OutBlock { }
