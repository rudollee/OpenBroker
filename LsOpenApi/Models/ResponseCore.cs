using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LsOpenApi.Models;
internal class LsResponseCore
{
	[JsonPropertyName("tr_cd")]
	public string TrCode { get; set; } = string.Empty;

	[JsonPropertyName("rsp_cd")]
	public string Code { get; set; } = string.Empty;

	[JsonPropertyName("rsp_msg")]
	public string Message { get; set; } = string.Empty;
}
