using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models;
/// <summary>
/// 증권사/거래소 계정 정보
/// </summary>
public class Account
{
	/// <summary>
	/// ID
	/// </summary>
	public string ID { get; set; } = string.Empty;

	/// <summary>
	/// 비밀번호
	/// </summary>
	public string Password { get; set; } = string.Empty;

	/// <summary>
	/// 공인인증서 비밀번호
	/// </summary>
	public string PasswordCert { get; set; } = string.Empty;
}
