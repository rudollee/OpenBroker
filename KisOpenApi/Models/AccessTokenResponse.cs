using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi;
internal class AccessTokenResponse : ResponseCommon
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("access_token_token_expired")]
    public string? DateExpiredString { get; set; }

    public DateTime DateExpired
    {
        get
        {
            DateTime result;
            return DateTime.TryParse(DateExpiredString, out result) ? result : DateTime.Now.AddDays(-1);
        }
    }

    [JsonPropertyName("Bearer")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public int Duration { get; set; }
}
