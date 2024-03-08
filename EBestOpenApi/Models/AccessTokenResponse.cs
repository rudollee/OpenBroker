using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EBestOpenApi.Models;
internal class AccessTokenResponse
{
	[JsonPropertyName("token")]
	public string AccessToken { get; set; } = string.Empty;

	[JsonPropertyName("expire_in")]
	public string? DateExpiredString { get; set; }

	public DateTime DateExpired
	{
		get => DateTime.Now.AddSeconds(Convert.ToInt32(DateExpiredString));
	}
}
