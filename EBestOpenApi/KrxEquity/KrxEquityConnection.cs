using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EBestOpenApi.Models;
using OpenBroker;
using OpenBroker.Models;
using Websocket.Client;

namespace EBestOpenApi.KrxEquity;
public partial class EBestKrxEquity : ConnectionBase, IConnection
{
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => 
		throw new NotImplementedException();

	protected override void ParseCallbackResponse(string trCode, string callbackTxt)
	{
		switch (trCode)
		{
			case nameof(NWS):
				var response = JsonSerializer.Deserialize<EBestSubscriptionCallback<NWS>>(callbackTxt);
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
				var response = JsonSerializer.Deserialize<EBestSubscriptionCallback<NWSOutBlock>>(message.Text);
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
				var jifResponse = JsonSerializer.Deserialize<EBestSubscriptionCallback<JIFOutBlock>>(message.Text);
				Message(this, new ResponseCore
				{
					Code = jifResponse?.Body?.jangubun ?? "",
					Message = jifResponse?.Body?.jstatus ?? ""
				});
				break;
		}
	}

}
