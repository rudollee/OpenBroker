namespace LsOpenApi.Models;
/// <summary>
/// KOSPI200선물체결(C0)
/// </summary>
internal class FC0
{
	public FC0InBlock FC0InBlock { get; set; } = new();
	public FC0OutBlock FC0OutBlock { get; set; } = new();
}

/// <summary>
/// KOSPI200선물체결(C0) - InBlock
/// </summary>
internal class FC0InBlock
{
	/// <summary>단축코드</summary>
	public string futcode { get; set; } = string.Empty;
}

/// <summary>
/// KOSPI200선물체결(C0) - OutBlock
/// </summary>
internal class FC0OutBlock
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

	/// <summary>시가</summary>
	public string open { get; set; } = string.Empty;

	/// <summary>고가</summary>
	public string high { get; set; } = string.Empty;

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

	/// <summary>매도호가1</summary>
	public string offerho1 { get; set; } = string.Empty;

	/// <summary>매수호가1</summary>
	public string bidho1 { get; set; } = string.Empty;

	/// <summary>미결제약정수량</summary>
	public string openyak { get; set; } = string.Empty;

	/// <summary>KOSPI200지수</summary>
	public string k200jisu { get; set; } = string.Empty;

	/// <summary>이론가</summary>
	public string theoryprice { get; set; } = string.Empty;

	/// <summary>괴리율</summary>
	public string kasis { get; set; } = string.Empty;

	/// <summary>시장BASIS</summary>
	public string sbasis { get; set; } = string.Empty;

	/// <summary>이론BASIS</summary>
	public string ibasis { get; set; } = string.Empty;

	/// <summary>미결제약정증감</summary>
	public string openyakcha { get; set; } = string.Empty;

	/// <summary>장운영정보</summary>
	public string jgubun { get; set; } = string.Empty;

	/// <summary>전일동시간대거래량</summary>
	public string jnilvolume { get; set; } = string.Empty;

	/// <summary>단축코드</summary>
	public string futcode { get; set; } = string.Empty;
}

/// <summary>
/// 주식선물체결(JC0)
/// </summary>
internal class JC0
{
	public JC0InBlock JC0InBlock { get; set; } = new();
	public JC0OutBlock JC0OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물체결(JC0) - InBlock
/// </summary>
internal class JC0InBlock : FC0InBlock { }

/// <summary>
/// 주식선물체결(JC0) - OutBlock
/// </summary>
internal class JC0OutBlock : FC0OutBlock
{
	/// <summary>기초자산현재가</summary>
	public string basprice { get; set; } = string.Empty;
}

/// <summary>
/// KRX야간파생 체결(DC0)
/// </summary>
internal class DC0
{
	public DC0InBlock DC0InBlock { get; set; } = new();
	public DC0OutBlock DC0OutBlock { get; set; } = new();
}

/// <summary>
/// KRX야간파생 체결(DC0) - InBlock
/// </summary>
internal class DC0InBlock : FC0InBlock { }

/// <summary>
/// KRX야간파생 체결(DC0) - OutBlock
/// </summary>
internal class DC0OutBlock : FC0OutBlock
{
	/// <summary>일자</summary>
	public string date { get; set; } = string.Empty;

	/// <summary>배분적용구분</summary>
	public string alloc_gubun { get; set; } = string.Empty;

	/// <summary>KOSPI등가</summary>
	public string eqva { get; set; } = string.Empty;

	/// <summary>내재변동성</summary>
	public string impv { get; set; } = string.Empty;

	/// <summary>시간가치</summary>
	public string timevalue { get; set; } = string.Empty;
}