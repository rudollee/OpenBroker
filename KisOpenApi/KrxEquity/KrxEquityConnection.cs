using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker;
using OpenBroker.Models;
using Websocket.Client;

namespace KisOpenApi.KrxEquity;
public partial class KisKrxEquity : ConnectionBase, IConnection
{
	private IWebsocketClient client;

	private string _iv = string.Empty;
	private string _key = string.Empty;

	public Task<ResponseCore> ConnectAsync() => throw new NotImplementedException();
	public Task<ResponseCore> DisconnectAsync() => throw new NotImplementedException();
	public Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret) => throw new NotImplementedException();
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => throw new NotImplementedException();
}
