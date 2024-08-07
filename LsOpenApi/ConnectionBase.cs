﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LsOpenApi.Models;
using OpenBroker.Models;
using RestSharp;
using Websocket.Client;

namespace LsOpenApi;
public class ConnectionBase
{
	internal readonly string host = "https://openapi.ls-sec.co.kr:8080";
	internal readonly string hostSocket = "wss://openapi.ls-sec.co.kr:9443/websocket";
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

	public async Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret)
	{
		var client = new RestClient($"{host}/oauth2/token");

		var queryParameters = GenerateParameters(new
		{
			grant_type,
			appkey,
			appsecretkey = appsecret,
			scope = "oob",
		});
		var request = new RestRequest()
			.AddHeaders(new Dictionary<string, string>
			{
				{ "content-type", "application/x-www-form-urlencoded" },
			});

		foreach (var param in queryParameters)
		{
			request.AddQueryParameter(param.Key, param.Value);
		}

		try
		{
			var response = await client.PostAsync<AccessTokenResponse>(request);

			if (response is null) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response is null"
			};

			if (string.IsNullOrEmpty(response.AccessToken)) return new ResponseResult<KeyPack>
			{
				StatusCode = Status.UNAUTHORIZED,
				Message = "no token",
			};

			SetKeyPack(new KeyPack
			{
				AppKey = appkey,
				SecretKey = appsecret,
				AccessToken = response.AccessToken,
				AccessTokenExpired = response.DateExpired,
			});

			return new ResponseResult<KeyPack>
			{
				Info = new KeyPack
				{
					AccessToken = response.AccessToken,
					AccessTokenExpired = response.DateExpired
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<KeyPack>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "error catch"
			};
		}
	}

	#region Connect/disconnect Websocket
	/// <summary>
	/// Connect Websocket & subscribe Order/Contract
	/// </summary>
	/// <returns></returns>
	protected async Task<ResponseCore> ConnectAsync(Action<ResponseMessage> callback)
	{
		try
		{
			var options = new Func<ClientWebSocket>(() => new ClientWebSocket
			{
				Options = { KeepAliveInterval = TimeSpan.Zero }
			});

			Client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "LS",
				ReconnectTimeout = TimeSpan.FromSeconds(30),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
			};

			Client.MessageReceived.Subscribe(message => callback(message));
			await Client.Start();

			SetConnect();

			var jifResult = await Subscribe("JIF", "0");
			return new ResponseCore
			{
				StatusCode = Status.SUCCESS,
				Message = "Connected"
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				Remark = "during connect websocket"
			};
		}
	}

	public async Task<ResponseCore> DisconnectAsync()
	{
		await Client.Stop(WebSocketCloseStatus.NormalClosure, "");
		Client.Dispose();
		SetConnect(false);

		return new ResponseCore
		{
			Message = "disconnected"
		};
	}
	#endregion

	#region Subscribe / Unsubscribe
	public async Task<ResponseCore> Subscribe(string trCode, string key, bool connecting = true)
	{
		string GenerateSubscriptionRequest(string id, string key = "", bool connecting = true)
		{
			if (string.IsNullOrWhiteSpace(key)) key = AccountInfo.ID;

			return JsonSerializer.Serialize(new LsSubscriptionRequest(KeyInfo.AccessToken, id, key, connecting));
		}

		try
		{
			var result = await Task.Run(() => Client.Send(GenerateSubscriptionRequest(trCode, key, connecting)));

			return new ResponseCore
			{
				StatusCode = result ? Status.SUCCESS : Status.ERROR_OPEN_API,
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = $"catch error : {ex.Message}",
				Remark = $"from {System.Reflection.MethodBase.GetCurrentMethod()?.Name} connecting is {connecting}"
			};
		};
	}
	#endregion

	#region Websocket Callback
	/// <summary>
	/// Websocket Callback
	/// </summary>
	/// <param name="message"></param>
	protected void SubscribeCallback(ResponseMessage message)
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

		if (root.GetProperty("body").GetType() is null) return;

		ParseCallbackMessage(root.GetProperty("header").GetProperty("tr_cd").GetString(), message.Text);
	}
	#endregion

	#region Parse Callback Message & Response
	/// <summary>
	/// 
	/// </summary>
	/// <param name="trCode"></param>
	/// <param name="callbackTxt"></param>
	protected void ParseCallbackMessage(string trCode, string callbackTxt) { }

	/// <summary>
	/// Parse Callback Response Data
	/// </summary>
	/// <param name="callbackTxt"></param>
	protected virtual void ParseCallbackResponse(string trCode, string callbackTxt) { }
	#endregion

	#region Generate Parameters
	/// <summary>
	/// Generate Parameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string?> GenerateParameters(Dictionary<string, string?> additionalOption)
	{
		var basicParameters = new
		{
		};

		var parameters = basicParameters.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(basicParameters, null)?.ToString());
		foreach (var parameter in additionalOption)
		{
			parameters.Add(parameter.Key, parameter.Value?.ToString());
		}

		return parameters ?? new Dictionary<string, string?>();
	}

	/// <summary>
	/// Generate QueryParameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string?> GenerateParameters(object additionalOption) =>
		GenerateParameters(additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
	#endregion

	#region Generate Headers
	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr, Dictionary<string, string> additionalOption)
	{
		var headers = GenerateHeaders(tr);

		foreach (var header in additionalOption)
		{
			headers.Add(header.Key, header.Value);
		}

		return headers;
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr)
	{
		return new Dictionary<string, string>
		{
			{ "content-type", "application/json; charset=utf-8" },
			{ "authorization", $"Bearer {KeyInfo.AccessToken}"},
			{ "tr_cd", tr},
			{ "tr_cont", "N" },
			{ "tr_cont_key", "" },
			{ "mac_address", ""}
		};
	}

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	protected Dictionary<string, string> GenerateHeaders(string tr, object additionalOption) =>
		GenerateHeaders(tr, additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
	#endregion
}
