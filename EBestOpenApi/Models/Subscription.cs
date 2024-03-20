using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EBestOpenApi.Models;
/// <summary>
/// eBest request form for subscription 
/// </summary>
/// <param name="token"></param>
/// <param name="trCode"></param>
/// <param name="key"></param>
/// <param name="connecting"></param>
internal class EBestSubscriptionRequest(string token, string trCode, string key, bool connecting = true)
{
	[JsonPropertyName("header")]
	public EBestHeader Header { get; set; } = new (token, connecting);

	[JsonPropertyName("body")]
	public EBestBody Body { get; set; } = new (trCode, key);

	public class EBestHeader(string token, bool connecting)
	{
		[JsonPropertyName("token")]
		public string Token { get; set; } = token;

		[JsonPropertyName("tr_type")]
		public string TrType { get; set; } = connecting ? "3" : "4";

	}

	public class EBestBody(string trCode, string key)
	{
		[JsonPropertyName("tr_cd")]
		public string TrCd { get; set; } = trCode;

		[JsonPropertyName("tr_key")]
		public string Key { get; set; } = key;
	}
}

