using System.Text.Json.Serialization;

namespace KisOpenApi;
internal class KisResponseBase
{
	/// <summary>
	/// return code
	/// </summary>
	[JsonPropertyName("rt_cd")]
	public string ReturnCode { get; set; } = string.Empty;

	/// <summary>
	/// MSG Code
	/// </summary>
	[JsonPropertyName("msg_cd")]
	public string MessageCode { get; set; } = string.Empty;

	/// <summary>
	/// Error Message
	/// </summary>
	[JsonPropertyName("msg1")]
	public string Message { get; set; } = string.Empty;
}
