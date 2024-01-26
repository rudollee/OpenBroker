using OpenBroker;
using OpenBroker.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IConnection
{
    public KeyPack KeyInfo { get => _keyInfo; }
    private KeyPack _keyInfo;

    public bool IsConnected => throw new NotImplementedException();

    /// <summary>
    /// Request Access Token using appkey & secret
    /// </summary>
    /// <param name="appkey"></param>
    /// <param name="appsecret"></param>
    /// <returns></returns>
    private async Task<AccessTokenResponse> RequestAccessTokenAsync(string appkey, string appsecret)
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

            return response ?? new AccessTokenResponse { AccessToken = "" };
        }
        catch (Exception ex)
        {
            return new AccessTokenResponse
            {
                AccessToken = "",
                DateExpiredString = DateTime.Now.ToString(),
                Code = "ERR",
                Message = ex.Message
            };
        }
    }

	/// <summary>
	/// Request Websocket Code using appkey, secret & access token
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="appsecret"></param>
	/// <param name="token"></param>
	/// <returns></returns>
	private async Task<string> RequestApprovalKeyAsync(string appkey, string appsecret, string token)
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
            var response = await client.PostAsync<ApprovalKeyResponse>(request);

            return response?.ApprovalKey ?? string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public async Task<ResponseResult<KeyPack>> ConnectAsync(KeyPack keyPack)
    {
        if (string.IsNullOrWhiteSpace(keyPack.AppKey) || string.IsNullOrWhiteSpace(keyPack.SecretKey)) return new ResponseResult<KeyPack>
        {
            StatusCode = Status.UNAUTHORIZED,
            Message = "appkey or secret key is empty"
        };

        try
        {
            var tokenInfo = string.IsNullOrEmpty(keyPack.AccessToken)
                ? await RequestAccessTokenAsync(keyPack.AppKey, keyPack.SecretKey)
                : new AccessTokenResponse
                {
                    AccessToken = keyPack.AccessToken,
                    DateExpiredString = DateTime.Now.AddHours(15).ToString("yyyy-MM-dd HH:mm:ss")
                };

            _keyInfo = new KeyPack
            {
                AccessToken = tokenInfo.AccessToken,
                AccessTokenExpired = tokenInfo.DateExpired,
                AppKey = keyPack.AppKey,
                SecretKey = keyPack.SecretKey,
                WebsocketCode = await RequestApprovalKeyAsync(keyPack.AppKey, keyPack.SecretKey, tokenInfo.AccessToken)
			};

            return new ResponseResult<KeyPack> 
            { 
                StatusCode = Status.SUCCESS,
                Info = _keyInfo
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<KeyPack> 
            { 
                StatusCode = Status.INTERNALSERVERERROR,
                Message = ex.Message
            };
        }
    }

    public async Task<ResponseMessage> DisconnectAsync()
    {
        throw new NotImplementedException();
    }

	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;
	public void SetAccountInfo(Account accountInfo) => _accountInfo = accountInfo;
}
