using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
internal class AccessTokenResponse
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; } = string.Empty;

	[JsonPropertyName("expires_in")]
	public int DateRemained { get; set; }

	public DateTime DateExpired
	{
		get => DateTime.Now.AddSeconds(DateRemained);
	}
}
