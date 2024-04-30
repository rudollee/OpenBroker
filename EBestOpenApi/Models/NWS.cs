using System.Collections.Generic;

namespace EBestOpenApi.Models;
/// <summary>
/// 실시간 뉴스 제목 패킷(NWS)
/// </summary>
internal class NWS
{
	public NWSOutBlock Body { get; set; } = new();

	/// <summary>
	/// 실시간 뉴스 제목 패킷(NWS) - InBlock
	/// </summary>
	internal class NWSInBlock
	{
		/// <summary>뉴스코드</summary>
		public string nwcode { get; set; }
	}

}

/// <summary>
/// 실시간 뉴스 제목 패킷(NWS) - OutBlock
/// </summary>
internal class NWSOutBlock
{
	/// <summary>날짜</summary>
	public string date { get; set; }

	/// <summary>시간</summary>
	public string time { get; set; }

	/// <summary>뉴스구분자</summary>
	public string id { get; set; }

	/// <summary>키값</summary>
	public string realkey { get; set; }

	/// <summary>제목</summary>
	public string title { get; set; }

	/// <summary>단축종목코드</summary>
	public string code { get; set; }

	/// <summary>BODY길이</summary>
	public string bodysize { get; set; }
}
