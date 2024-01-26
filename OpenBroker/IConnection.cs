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
    ConnectionInfo ConnectionInfo { get; }

    /// <summary>
    /// 접속 상태
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// 계좌 정보 설정
    /// </summary>
    /// <param name="accountInfo"></param>
    /// <returns></returns>
    Task SetAccountInfoAsync(Account accountInfo);

	/// <summary>
	/// 연결하기
	/// </summary>
	/// <param name="appkey"></param>
	/// <param name="secret"></param>
	/// <param name="accessToken"></param>
	/// <returns></returns>
	Task<ResponseResult<ConnectionInfo>> ConnectAsync(string appkey, string secret, string accessToken = "");

    /// <summary>
    /// 연길 끊기
    /// </summary>
    /// <returns></returns>
    Task<ResponseMessage> DisconnectAsync();
}
