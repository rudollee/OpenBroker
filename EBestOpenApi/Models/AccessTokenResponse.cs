using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EBestOpenApi.Models;
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
