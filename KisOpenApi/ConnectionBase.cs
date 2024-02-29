using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker.Models;
using RestSharp;
using Websocket.Client;

namespace KisOpenApi;
public class ConnectionBase
{
    internal readonly string host = "https://openapi.koreainvestment.com:9443";
    internal readonly string hostSocket = "ws://ops.koreainvestment.com:21000";
    internal readonly string grant_type = "client_credentials";

	public KeyPack KeyInfo { get => _keyInfo; }
	private KeyPack _keyInfo = new KeyPack();
	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;

	public Account AccountInfo { get => _accountInfo; }
	private Account _accountInfo = new Account();
	public void SetAccount(Account account) => _accountInfo = account;

	public BankAccount BankAccountInfo { get => _bankAccountInfo; }
	private BankAccount _bankAccountInfo = new BankAccount();
	public void SetBankAccount(BankAccount bankAccount) => _bankAccountInfo = bankAccount;

	public bool IsConnected { get => _connected; }
	private bool _connected = false;
	protected void SetConnect(bool connecting = true) => _connected = connecting;

	public required EventHandler<ResponseCore> Message { get; set; }

	protected IWebsocketClient Client;

	#region Request Access Token using appkey & secret
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
	#endregion

	#region Request Websocket Code using appkey, secret & access token
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
	#endregion


}
