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
	public long change { get; set; }

	/// <summary>등락율</summary>
	public decimal drate { get; set; }

	/// <summary>현재가</summary>
	public long price { get; set; }

	/// <summary>시가시간</summary>
	public string opentime { get; set; } = string.Empty;

	/// <summary>시가</summary>
	public long open { get; set; }

	/// <summary>고가시간</summary>
	public string hightime { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public long high { get; set; }

	/// <summary>저가시간</summary>
	public string lowtime { get; set; } = string.Empty;

	/// <summary>저가</summary>
	public long low { get; set; }

	/// <summary>체결구분</summary>
	public string cgubun { get; set; } = string.Empty;

	/// <summary>체결량</summary>
	public long cvolume { get; set; }

	/// <summary>누적거래량</summary>
	public long volume { get; set; }

	/// <summary>누적거래대금</summary>
	public long value { get; set; }

	/// <summary>매도누적체결량</summary>
	public long mdvolume { get; set; }

	/// <summary>매도누적체결건수</summary>
	public long mdchecnt { get; set; }

	/// <summary>매수누적체결량</summary>
	public long msvolume { get; set; }

	/// <summary>매수누적체결건수</summary>
	public long mschecnt { get; set; }

	/// <summary>체결강도</summary>
	public decimal cpower { get; set; }

	/// <summary>가중평균가</summary>
	public long w_avrg { get; set; }

	/// <summary>매도호가</summary>
	public long offerho { get; set; }

	/// <summary>매수호가</summary>
	public long bidho { get; set; }

	/// <summary>장정보</summary>
	public string status { get; set; } = string.Empty;

	/// <summary>전일동시간대거래량</summary>
	public long jnilvolume { get; set; }

	/// <summary>단축코드</summary>
	public string shcode { get; set; } = string.Empty;

}

