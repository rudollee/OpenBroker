using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models.GlobalFutures;

/// <summary>
/// 해외선물옵션 - 주문 신규/정정/취소 공통
/// </summary>
internal class OTFM300XU : ExecutionBaseResponse
{
    public OTFM300XUOutput Output { get; set; } = new OTFM300XUOutput();
}

/// <summary>
/// 해외선물옵션 - OTFM3001U Output
/// </summary>
internal class OTFM300XUOutput
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


