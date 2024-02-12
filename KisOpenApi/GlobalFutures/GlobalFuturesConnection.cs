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

   // public async Task<ResponseResult<KeyPack>> ConnectAsync(KeyPack keyPack)
   // {
   //     if (string.IsNullOrWhiteSpace(keyPack.AppKey) || string.IsNullOrWhiteSpace(keyPack.SecretKey)) return new ResponseResult<KeyPack>
   //     {
   //         StatusCode = Status.UNAUTHORIZED,
   //         Message = "appkey or secret key is empty"
   //     };

   //     try
   //     {
   //         AccessTokenResponse tokenInfo = new AccessTokenResponse
			//{
			//	AccessToken = keyPack.AccessToken,
			//	DateExpiredString = keyPack.AccessTokenExpired?.ToString("yyyy-MM-dd HH:mm:ss")
			//};

			//if (string.IsNullOrEmpty(keyPack.AccessToken) || DateTime.Now.AddHours(15) > keyPack.AccessTokenExpired )
   //         {
   //             tokenInfo = await RequestAccessTokenAsync(keyPack.AppKey, keyPack.SecretKey);
   //         }

   //         if (tokenInfo is null || string.IsNullOrEmpty(tokenInfo.AccessToken)) return new ResponseResult<KeyPack>
   //         {
   //             StatusCode = Status.ERROR_OPEN_API,
   //             Message = tokenInfo is null ? "tokenInfo is null" : tokenInfo.Message
   //         };

   //         var websocketInfo = await RequestApprovalKeyAsync(keyPack.AppKey, keyPack.SecretKey);

   //         var websocketCode = websocketInfo is null || websocketInfo.Info is null
   //             ? ""
   //             : websocketInfo.Info.WebsocketCode;

			//_keyInfo = new KeyPack
   //         {
   //             AccessToken = tokenInfo.AccessToken,
   //             AccessTokenExpired = tokenInfo.DateExpired,
   //             AppKey = keyPack.AppKey,
   //             SecretKey = keyPack.SecretKey,
   //             WebsocketCode = websocketCode
			//};

   //         return new ResponseResult<KeyPack> 
   //         { 
   //             StatusCode = string.IsNullOrEmpty(_keyInfo.WebsocketCode) ? Status.PARTIALLY_SUCCESS : Status.SUCCESS,
   //             Info = _keyInfo,
   //             Message = string.IsNullOrEmpty(_keyInfo.WebsocketCode) ? websocketInfo?.Message ?? "": ""
   //         };
   //     }
   //     catch (Exception ex)
   //     {
   //         return new ResponseResult<KeyPack> 
   //         { 
   //             StatusCode = Status.INTERNALSERVERERROR,
   //             Message = $"catch error: {ex.Message}"
   //         };
   //     }
   // }

    public async Task<ResponseCore> DisconnectAsync()
    {
        throw new NotImplementedException();
    }

	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;
	public void SetAccountInfo(Account accountInfo) => _accountInfo = accountInfo;
}
