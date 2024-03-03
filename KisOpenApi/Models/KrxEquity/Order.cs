using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models.KrxEquity;
/// <summary>
/// 국내주식 - 주문 신규/정정/취소 공통
/// </summary>
internal class TTTC080XU : ExecutionBaseResponse
{
	public TTTC080XUOutput Output { get; set; } = new();
}

/// <summary>
/// 국내주식 TTTC080XU Output
/// </summary>
internal class TTTC080XUOutput
{
	/// <summary>
	/// 한국거래소전송주문조직번호
	/// </summary>
	[JsonPropertyName("KRX_FWDG_ORD_ORGNO")]
	public string KrxFwdgOrdOrgno { get; set; } = string.Empty;

	/// <summary>
	/// 주문시각
	/// </summary>
	[JsonPropertyName("ORD_TMD")]
	public string OrderTime6 { get; set; } = string.Empty;

	/// <summary>
	/// 주문번호
	/// </summary>
	[JsonPropertyName("ODNO")]
	public string OrderNumber { get; set; } = string.Empty;
}