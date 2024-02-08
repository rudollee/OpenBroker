using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models;
internal class OrderRequest
{
}

/// <summary>
/// 해외선물옵션 - OTFM3001U
/// </summary>
internal class OTFM3001U : ExecutionBaseResponse
{
	public OTFM3001UOutput Output { get; set; } = new OTFM3001UOutput();
}

/// <summary>
/// 해외선물옵션 - OTFM3001U Output
/// </summary>
internal class OTFM3001UOutput
{
	/// <summary>
	/// 주문일자
	/// </summary>
	[JsonPropertyName("ORD_DT")]
	public string OrderDate8 { get; set; } = string.Empty;

	/// <summary>
	/// 주문번호
	/// </summary>
	[JsonPropertyName("ODNO")]
	public string OrderNumber { get; set; } = string.Empty;
}
