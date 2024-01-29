using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi;
internal class ResponseCommon
{
	/// <summary>
	/// return code
	/// </summary>
	[JsonPropertyName("rt-cd")]
	public string ReturnCode { get; set; } = string.Empty;

	/// <summary>
	/// MSG Code
	/// </summary>
	[JsonPropertyName("msg_cd")]
	public string Code { get; set; } = string.Empty;

	/// <summary>
	/// Error Message
	/// </summary>
	[JsonPropertyName("msg1")]
	public string Message { get; set; } = string.Empty;
}
