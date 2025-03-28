namespace LsOpenApi.Models;
/// <summary>
/// 파생상품증거금율조회
/// </summary>
internal class MMDAQ91200 : LsResponseCore
{
	public MMDAQ91200InBlock1 MMDAQ91200InBlock { get; set; } = new();
	public MMDAQ91200OutBlock1 MMDAQ91200OutBlock1 { get; set; } = new();
	public List<MMDAQ91200OutBlock2> MMDAQ91200OutBlock2 { get; set; } = new();
}

/// <summary>
/// 파생상품증거금율조회 - InBlock
/// </summary>
internal class MMDAQ91200InBlock1
{
	/// <summary>종목대분류코드</summary>
	public string IsuLgclssCode { get; set; } = "11";

	/// <summary>종목중분류코드</summary>
	public string IsuMdclssCode { get; set; } = "02";
}

/// <summary>
/// 파생상품증거금율조회 - OutBlock1
/// </summary>
internal class MMDAQ91200OutBlock1
{
	/// <summary>레코드갯수</summary>
	public long RecCnt { get; set; }

	/// <summary>종목대분류코드</summary>
	public string IsuLgclssCode { get; set; } = string.Empty;

	/// <summary>종목중분류코드</summary>
	public string IsuMdclssCode { get; set; } = string.Empty;
}

/// <summary>
/// 파생상품증거금율조회 - OutBlock2
/// </summary>
internal class MMDAQ91200OutBlock2
{
	/// <summary>종목소분류코드</summary>
	public string IsuSmclssCode { get; set; } = string.Empty;

	/// <summary>종목중분류코드</summary>
	public string IsuMdclssCode { get; set; } = string.Empty;

	/// <summary>종목대중분류명</summary>
	public string IsuLrgMdclssNm { get; set; } = string.Empty;

	/// <summary>종목대중소분류명</summary>
	public string IsuLrgMidSmclssNm { get; set; } = string.Empty;

	/// <summary>단축한글종목명</summary>
	public string ShtnHanglIsuNm { get; set; } = string.Empty;

	/// <summary>위탁증거금율</summary>
	public decimal CsgnMgnrt { get; set; }

	/// <summary>유지증거금율</summary>
	public decimal MaintMgnrt { get; set; }

	/// <summary>현금증거금율</summary>
	public decimal MnyMgnrt { get; set; }

	/// <summary>잔여일수</summary>
	public long RmndDays { get; set; }

	/// <summary>1계약당주문증거금</summary>
	public long OnePrcntrOrdMgn { get; set; }
}