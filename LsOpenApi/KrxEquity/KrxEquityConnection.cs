using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using Websocket.Client;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IConnection
{
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) =>
		throw new NotImplementedException();

	protected override void ParseCallbackResponse(string trCode, string callbackTxt)
	{
		switch (trCode)
		{
			case nameof(NWS):
				var response = JsonSerializer.Deserialize<LsSubscriptionCallback<NWS>>(callbackTxt);
				break;
		}
	}

	public async Task<ResponseCore> ConnectAsync() => await ConnectAsync(Callback);

	private void Callback(ResponseMessage message)
	{
		if (message is null || message.MessageType != WebSocketMessageType.Text)
		{
			Message(this, new ResponseCore
			{
				Code = "BINARY",
				Message = "binary message type"
			});
			return;
		}

		if (message.Text is null)
		{
			Message(this, new ResponseCore
			{
				Code = "TEXTNULL",
				Message = "message.Text is null"
			});
			return;
		}

		var document = JsonDocument.Parse(message.Text);
		var root = document.RootElement;

		var trCode = root.GetProperty("header").GetProperty("tr_cd").GetString();
		switch (trCode)
		{
			case nameof(NWS):
				var response = JsonSerializer.Deserialize<LsSubscriptionCallback<NWSOutBlock>>(message.Text);
				if (response is null || response.Body is null) return;
				NewsPosted(this, new ResponseResult<News>
				{
					Info = new News
					{
						Title = response.Body.title,
						TimePosted = DateTime.Now,
						Body = response.Body.realkey
					}
				});
				break;
			case nameof(JIF):
				var jifResponse = JsonSerializer.Deserialize<LsSubscriptionCallback<JIFOutBlock>>(message.Text);
				Message(this, new ResponseCore
				{
					Code = jifResponse?.Body?.jangubun ?? "",
					Message = jifResponse?.Body?.jstatus ?? ""
				});
				break;
		}
	}
}

