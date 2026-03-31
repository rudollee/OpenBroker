using OpenBroker.Extensions;
using OpenBroker.Models;
using System.Text.Json.Serialization;

namespace LsOpenApi.Models;
internal class AccessTokenResponse
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; } = string.Empty;

	[JsonPropertyName("expires_in")]
	public int DateRemained { get; set; }

	public DateTime DateExpired => MarketZone.Utc.Now().AddSeconds(DateRemained);
}
