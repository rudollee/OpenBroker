using System.Text.Json.Serialization;

namespace KisOpenApi.Models;
internal class AccessTokenResponse : KisResponseBase
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("access_token_token_expired")]
    public string? DateExpiredString { get; set; }

    public DateTime DateExpired => DateTime.UtcNow.AddSeconds(Duration);

    [JsonPropertyName("Bearer")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public int Duration { get; set; }
}
