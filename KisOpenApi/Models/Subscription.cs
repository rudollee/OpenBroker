using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static KisOpenApi.Models.KisSubScriptionRequest;

namespace KisOpenApi.Models;

/// <summary>
/// Kis request form for subscription 
/// </summary>
/// <param name="socketKey"></param>
/// <param name="id"></param>
/// <param name="key"></param>
internal class KisSubScriptionRequest(string socketKey, string id, string key, CustomerCode customerCode = CustomerCode.P)
{
	[JsonPropertyName("header")]
	internal KisHeader Header { get; set; } = new KisHeader(socketKey, customerCode);

	[JsonPropertyName("body")]
	internal KisBody Body { get; set; } = new KisBody(id, key);

	internal class KisHeader(string socketKey, CustomerCode customerCode)
	{
		[JsonPropertyName("approval_key")]
		public string SocketKey { get; set; } = socketKey;

		[JsonPropertyName("tr_type")]
		public string TrType { get; set; } = "1";

		[JsonPropertyName("custtype")]
		public string CustomerType { get; set; } = Enum.GetName(typeof(CustomerCode),(int)customerCode) ?? "P";

		[JsonPropertyName("content-type")]
		public string ContentType { get; set; } = "utf-8";
	}

	internal class KisBody(string id, string key)
	{
		[JsonPropertyName("tr_id")]
		public string ID { get; set; } = id;

		[JsonPropertyName("tr_key")]
		public string Key { get; set; } = key;
	}
}

/// <summary>
/// Custome Type Code
/// </summary>
internal enum CustomerCode
{
	/// <summary>
	/// Private
	/// </summary>
	P = 0,

	/// <summary>
	/// Business
	/// </summary>
	B
}