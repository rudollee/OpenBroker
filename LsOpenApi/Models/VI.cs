namespace LsOpenApi.Models;
/// <summary>
/// VI발동해제(VI_)
/// </summary>
internal class VI_
{
	public VI_InBlock VI_InBlock { get; set; } = new();
	public VI_OutBlock VI_OutBlock { get; set; } = new();
}

/// <summary>
/// VI발동해제(VI_) - InBlock
/// </summary>
internal class VI_InBlock
{
	/// <summary>단축코드(KEY)</summary>
	public string shcode { get; set; } = string.Empty;

}

/// <summary>
/// VI발동해제(VI_) - OutBlock
/// </summary>
internal class VI_OutBlock
{
	/// <summary>구분(0:해제 1:정적발동 2:동적발동 3:정적&동적)</summary>
	public string vi_gubun { get; set; } = string.Empty;

	/// <summary>정적VI발동기준가격</summary>
	public string svi_recprice { get; set; } = "0";

	/// <summary>동적VI발동기준가격</summary>
	public string dvi_recprice { get; set; } = "0";

	/// <summary>VI발동가격</summary>
	public string vi_trgprice { get; set; } = "0";

	/// <summary>단축코드(KEY)</summary>
	public string shcode { get; set; } = string.Empty;

	/// <summary>참조코드</summary>
	public string ref_shcode { get; set; } = string.Empty;

	/// <summary>시간</summary>
	public string time { get; set; } = string.Empty;

}

