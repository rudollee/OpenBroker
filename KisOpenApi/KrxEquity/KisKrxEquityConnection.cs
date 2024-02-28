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
	public void SetKeyPack(KeyPack keyInfo) => _keyInfo = keyInfo;
	public KeyPack KeyInfo { get => _keyInfo; }
	private KeyPack _keyInfo = new KeyPack();

	public void SetAccount(Account account) => _accountInfo = account;
	public Account AccountInfo { get => _accountInfo; }
	private Account _accountInfo = new Account();

	public void SetBankAccount(BankAccount bankAccount) => _bankAccountInfo = bankAccount;
	public BankAccount BankAccountInfo { get => _bankAccountInfo; }
	private BankAccount _bankAccountInfo = new BankAccount();

	public bool IsConnected { get => _connected; }
	private bool _connected = false;

	private IWebsocketClient client;

	private string _iv = string.Empty;
	private string _key = string.Empty;

	public Task<ResponseCore> ConnectAsync() => throw new NotImplementedException();
	public Task<ResponseCore> DisconnectAsync() => throw new NotImplementedException();
	public Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret) => throw new NotImplementedException();
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => throw new NotImplementedException();
}
