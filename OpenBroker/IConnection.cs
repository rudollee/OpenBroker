using OpenBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker;

/// <summary>
/// 연결 및 기본 설정
/// </summary>
public interface IConnection
{
    /// <summary>
    /// 접속 정보
    /// </summary>
    KeyPack KeyInfo { get; }

    /// <summary>
    /// 계좌 정보
    /// </summary>
    BankAccount BankAccountInfo { get; }

    /// <summary>
    /// 접속 상태
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// 접속 Key 강제 설정
    /// </summary>
    /// <param name="keyInfo"></param>
    /// <returns></returns>
    void SetKeyPack(KeyPack keyInfo);

    /// <summary>
    /// 접속 정보 설정
    /// </summary>
    /// <param name="account"></param>
    void SetAccount(Account account);

	/// <summary>
	/// 계좌 정보 설정
	/// </summary>
	/// <param name="bankAccount"></param>
	/// <returns></returns>
	void SetBankAccount(BankAccount bankAccount);

	/// <summary>
	/// 일반 메시지 Callback
	/// </summary>
	EventHandler<ResponseCore> Message { get; set; }

    /// <summary>
    /// 연결 Callback
    /// </summary>
    EventHandler<ResponseCore> Connected { get; set; }

	/// <summary>
	/// WebsocketCode 요청
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="secretkey"></param>
	/// <returns></returns>
	Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey);

    /// <summary>
    /// Access Token 요청
    /// </summary>
    /// <param name="appkey"></param>
    /// <param name="appsecret"></param>
    /// <returns></returns>
    Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret);

    /// <summary>
    /// Websocket 연결하기
    /// </summary>
    /// <returns></returns>
    Task<ResponseCore> ConnectAsync();

    /// <summary>
    /// 연길 끊기
    /// </summary>
    /// <returns></returns>
    Task<ResponseCore> DisconnectAsync();
}
