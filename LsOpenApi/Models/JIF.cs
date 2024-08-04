namespace LsOpenApi.Models;
/// <summary>
/// 장운영정보(JIF)
/// </summary>
internal class JIF
{
	public JIFInBlock InBlock { get; set; } = new();
	public JIFOutBlock OutBlock { get; set; } = new();
}

/// <summary>
/// 장운영정보(JIF) - InBlock
/// </summary>
internal class JIFInBlock
{
	/// <summary>장구분</summary>
	public string jangubun { get; set; }

}

/// <summary>
///  장운영정보(JIF) - OutBlock
/// </summary>
internal class JIFOutBlock
{
	/// <summary>장구분</summary>
	public string jangubun { get; set; }

	/// <summary>장상태</summary>
	public string jstatus { get; set; }

}