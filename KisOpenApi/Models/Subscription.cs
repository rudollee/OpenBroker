using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static KisOpenApi.Models.KisSubscriptionRequest;

namespace KisOpenApi.Models;

/// <summary>
/// Kis request form for subscription 
/// </summary>
/// <param name="socketKey"></param>
/// <param name="id"></param>
/// <param name="key"></param>
internal class KisSubscriptionRequest(string socketKey, string id, string key, bool connecting = true, CustomerCode customerCode = CustomerCode.P)
{
	[JsonPropertyName("header")]
	public KisHeader Header { get; set; } = new KisHeader(socketKey, connecting, customerCode);

	[JsonPropertyName("body")]
	public KisSubscriptionRequestBody Body { get; set; } = new KisSubscriptionRequestBody(id, key);

	public class KisHeader(string socketKey, bool connecting, CustomerCode customerCode)
	{
		[JsonPropertyName("approval_key")]
		public string SocketKey { get; set; } = socketKey;

		[JsonPropertyName("tr_type")]
		public string TrType { get; set; } = connecting ? "1" : "2";

		[JsonPropertyName("custtype")]
		public string CustomerType { get; set; } = Enum.GetName(typeof(CustomerCode),(int)customerCode) ?? "P";

		[JsonPropertyName("content-type")]
		public string ContentType { get; set; } = "utf-8";
	}

	public class KisSubscriptionRequestBody(string id, string key)
	{
		public KisSubscriptionPair Input { get; set; } = new KisSubscriptionPair(id, key);
	}
}

/// <summary>
/// Kis Subscription Response
/// </summary>
internal class KisSubscriptionResponse
{
	[JsonPropertyName("header")]
	public KisSubscriptionPair Header { get; set; } = new();

	[JsonPropertyName("body")]
	public KisBody Body { get; set; } = new();

	internal class KisBody
	{
		[JsonPropertyName("tr_id")]
		public int ResultCode { get; set; } = -1;

		[JsonPropertyName("msg_cd")]
		public string MessageCode { get; set; } = string.Empty;

		[JsonPropertyName("msg1")]
		public string Message { get; set; } = string.Empty;

		[JsonPropertyName("output")]
		public EncryptionKeyPair Output { get; set; } = new();

		internal class EncryptionKeyPair
		{
			[JsonPropertyName("iv")]
			public string IV { get; set; } = string.Empty;

			[JsonPropertyName("key")]
			public string Key { get; set; } = string.Empty;
		}
	}
}

/// <summary>
/// ID / Key
/// </summary>
/// <param name="id"></param>
/// <param name="key"></param>
internal class KisSubscriptionPair(string id = "", string key = "")
{
	[JsonPropertyName("tr_id")]
	public string ID { get; set; } = id;

	[JsonPropertyName("tr_key")]
	public string Key { get; set; } = key;
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

/// <summary>
/// Subscription Mode
/// </summary>
internal enum SubscriptionMode
{
	NONE,
	CONNECT,
	DISCONNECT
}