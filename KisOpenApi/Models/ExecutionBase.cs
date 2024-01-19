using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models;
public class ExecutionBaseRequest
{
	public string AccountNumber { get; set; } = string.Empty;
}

internal class ExecutionBaseResponse
{
	[JsonPropertyName("rt_cd")]
	public string ResultCode { get; set; } = string.Empty;

	[JsonPropertyName("msg_cd")]
	public string ResponseCode { get; set; } = string.Empty;

	[JsonPropertyName("msg1")]
	public string ResponseMessage { get; set; } = string.Empty;

}
