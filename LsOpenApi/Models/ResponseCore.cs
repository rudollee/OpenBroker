using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
internal class LsResponseCore
{
	[JsonPropertyName("tr_cd")]
	public string TrCode { get; set; } = string.Empty;

	[JsonPropertyName("rsp_cd")]
	public string Code { get; set; } = string.Empty;

	[JsonPropertyName("rsp_msg")]
	public string Message { get; set; } = string.Empty;

	/// <summary>
	/// key for continuous request
	/// </summary>
	internal string NextKey { get; set; } = string.Empty;
}
