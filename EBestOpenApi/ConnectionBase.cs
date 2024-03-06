using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using OpenBroker.Models;
using Websocket.Client;

namespace EBestOpenApi;
public class ConnectionBase
{
	internal readonly string host = "https://openapi.ebestsec.co.kr:8080";
	internal readonly string hostSocket = "wss://openapi.ebestsec.co.kr:9443/websocket";

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

	#region Connect/disconnect Websocket
	/// <summary>
	/// Connect Websocket & subscribe Order/Contract
	/// </summary>
	/// <returns></returns>
	public async Task<ResponseCore> ConnectAsync()
	{
		try
		{
			var options = new Func<ClientWebSocket>(() => new ClientWebSocket
			{
				Options = { KeepAliveInterval = TimeSpan.Zero }
			});

			Client = new WebsocketClient(new Uri(hostSocket), options)
			{
				Name = "eBest",
				ReconnectTimeout = TimeSpan.FromSeconds(30),
				ErrorReconnectTimeout = TimeSpan.FromSeconds(30),
			};

			//Client.MessageReceived.Subscribe(message => SubscribeCallback(message));
			await Client.Start();

			SetConnect();
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
}
