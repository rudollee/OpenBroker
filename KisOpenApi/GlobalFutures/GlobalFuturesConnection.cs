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
    public Connection ConnectionInfo { get => _connection; }
    private Connection _connection;

    public bool IsConnected => throw new NotImplementedException();

    private AccessTokenResponse RequestAccessToken(string appkey, string appsecret)
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
            var response = client.Post<AccessTokenResponse>(request);

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

    private string RequestApprovalKey(string appkey, string appsecret)
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
            var response = client.Post<ApprovalKeyResponse>(request);

            return response?.ApprovalKey ?? string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public ResponseMessage Connect(string appkey, string appsecret)
    {
        if (string.IsNullOrWhiteSpace(appkey) || string.IsNullOrWhiteSpace(appsecret)) return new ResponseMessage
        {
            StatusCode = Status.UNAUTHORIZED,
            Message = "appkey or secret key is empty"
        };

        try
        {
            var tokenInfo = RequestAccessToken(appkey, appsecret);
            var approvalKey = RequestApprovalKey(appkey, appsecret);

            _connection = new Connection
            {
                AccessToken = tokenInfo.AccessToken,
                AccessTokenExpired = tokenInfo.DateExpired,
                AppKey = appkey,
                SecretKey = appsecret,
                WebsocketToken = approvalKey
            };

            return new ResponseMessage { };
        }
        catch (Exception ex)
        {
            return new ResponseMessage 
            { 
                StatusCode = Status.INTERNALSERVERERROR,
                Message = ex.Message
            };
        }
    }

    public ResponseMessage Disconnect()
    {
        throw new NotImplementedException();
    }

    public ResponseMessage SetAccountInfo(Account accountInfo)
    {
        throw new NotImplementedException();
    }
}
