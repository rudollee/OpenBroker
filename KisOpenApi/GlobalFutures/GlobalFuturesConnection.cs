using OpenBroker;
using OpenBroker.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Websocket.Client;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IConnection
{
    public KeyPack KeyInfo { get => _keyInfo; }
    private KeyPack _keyInfo = new KeyPack();

    public bool IsConnected => throw new NotImplementedException();
	private IWebsocketClient client;

	/// <summary>
	/// Request Access Token using appkey & secret
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="appsecret"></param>
	/// <returns></returns>
	public async Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret)
    {
        var body = new
        {
            grant_type,
            appkey,
            appsecret
        };

        try
        {
            var client = new RestClient($"{host}/oauth2/tokenP");
            var request = new RestRequest()
                .AddHeaders(new Dictionary<string, string>
                {
                    { "Content-Type", "application/json; charset=UTF-8" },
                })
                .AddJsonBody(body);
            var response = await client.PostAsync<AccessTokenResponse>(request);

            if (response is null) return new ResponseResult<KeyPack>
            {
                StatusCode = Status.ERROR_OPEN_API,
                Message = "response is null"
            };

            if (string.IsNullOrEmpty(response.AccessToken)) return new ResponseResult<KeyPack>
            {
                StatusCode = Status.UNAUTHORIZED,
                Code = response.Code,
                Message = response.Message,
                Remark = response.ReturnCode
            };

            return new ResponseResult<KeyPack> 
            { 
                StatusCode = Status.SUCCESS,
                Info = new KeyPack
                {
                    AccessToken = response.AccessToken,
                    AccessTokenExpired = response.DateExpired
                },
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<KeyPack>
            {
                StatusCode = Status.INTERNALSERVERERROR,
                Message = $"catch error: {ex.Message}"
            };
        }
    }

	/// <summary>
	/// Request Websocket Code using appkey, secret & access token
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="secretkey"></param>
	/// <param name="token"></param>
	/// <returns></returns>
	public async Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey)
    {
        var body = new
        {
			grant_type,
			appkey,
			secretkey
		};

        try
        {
            var client = new RestClient($"{host}/oauth2/Approval");
            var request = new RestRequest()
                .AddHeaders(new Dictionary<string, string>
                {
                    { "Content-Type", "application/json; charset=UTF-8" },
                })
                .AddJsonBody(body);
            var response = await client.PostAsync<ApprovalKeyResponse>(request);

            if (response is null) return new ResponseResult<KeyPack>
            {
                StatusCode = Status.ERROR_OPEN_API,
                Message = "/auth2/approval: response is null",
            };

            if (string.IsNullOrEmpty(response.ApprovalKey)) return new ResponseResult<KeyPack>
            {
                StatusCode = Status.UNAUTHORIZED,
                Code = response.Code,
                Message = response.Message,
                Remark = response.ReturnCode
            };

            return new ResponseResult<KeyPack>
            {
                StatusCode = Status.SUCCESS,
                Code = response.Code,
                Message = response.Message,
                Remark = response.ReturnCode,
                Info = new KeyPack { WebsocketCode = response.ApprovalKey },
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<KeyPack> 
            {
                StatusCode = Status.INTERNALSERVERERROR,
                Message = $"catch error from /oauth2/Approval: ${ex.Message}"
            };
        }
    }

    public async Task<ResponseCore> ConnectAsync()
    {
        var options = new Func<ClientWebSocket>(() => new ClientWebSocket
        {
            Options = { KeepAliveInterval = TimeSpan.Zero }
        });

		using var client = new WebsocketClient(new Uri(hostSocket), options)
		{
			Name = "KIS",
			ReconnectTimeout = TimeSpan.FromSeconds(30),
			ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
		};

		client.MessageReceived.Subscribe(message => SubscribeCallback(message));
		await client.Start();

		return new ResponseCore
		{
			StatusCode = Status.SUCCESS,
			Message = "Connected"
		};
	}

    /// <summary>
    /// Websocket Callback
    /// </summary>
    /// <param name="message"></param>
	private void SubscribeCallback(ResponseMessage message)
	{
		if (message is null) return;
		if (message.MessageType == WebSocketMessageType.Text)
		{
			if (message.Text is null) return;
			if (message.Text.IndexOf("PINGPONG") > -1) // to keep connection
			{
				var document = JsonDocument.Parse(message.Text);
				var root = document.RootElement;

				client.Send(message.Text);
			}
			else
			{
                //TODO: real data
				Console.WriteLine(message.Text);
			}
		}
		else
		{

		}
	}

	public async Task<ResponseCore> DisconnectAsync()
    {
        throw new NotImplementedException();
    }

	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;
    public void SetAccount(Account account) => _accountInfo = account;
	public void SetBankAccount(BankAccount bankAccount) => _bankAccountInfo = bankAccount;
}
