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
    public ConnectionInfo ConnectionInfo { get => _connection; }
    private ConnectionInfo _connection;

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
            appkey,
            appsecret,
            token
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

    public async Task<ResponseResult<ConnectionInfo>> ConnectAsync(string appkey, string appsecret, string accessToken = "")
    {
        if (string.IsNullOrWhiteSpace(appkey) || string.IsNullOrWhiteSpace(appsecret)) return new ResponseResult<ConnectionInfo>
        {
            StatusCode = Status.UNAUTHORIZED,
            Message = "appkey or secret key is empty"
        };

        try
        {
            var tokenInfo = string.IsNullOrEmpty(accessToken)
                ? await RequestAccessTokenAsync(appkey, appsecret)
                : new AccessTokenResponse
                {
                    AccessToken = accessToken,
                    DateExpiredString = DateTime.Now.AddHours(10).ToString("yyyyMMdd")
                };

            var approvalKey = await RequestApprovalKeyAsync(appkey, appsecret, tokenInfo.AccessToken);
            _connection = new ConnectionInfo
            {
                AccessToken = tokenInfo.AccessToken,
                AccessTokenExpired = tokenInfo.DateExpired,
                AppKey = appkey,
                SecretKey = appsecret,
                WebsocketToken = approvalKey
            };

            return new ResponseResult<ConnectionInfo> 
            { 
                StatusCode = Status.SUCCESS,
                Info = _connection
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<ConnectionInfo> 
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

    public async Task SetAccountInfoAsync(Account accountInfo) => throw new NotImplementedException();

}
