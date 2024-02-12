using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Models;
/// <summary>
/// 계좌 정보
/// </summary>
public class BankAccount
{
    /// <summary>
    /// AccounT Type
    /// </summary>
    public AccountType AccountTyp { get; set; }

    /// <summary>
    /// 계좌번호
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// 계좌번호 뒷자리 optional
    /// </summary>
    public string AccountNumberSuffix { get; set; } = string.Empty;

    /// <summary>
    /// 계좌 비밀번호 optional
    /// </summary>
    public string AccountPassword { get; set; } = string.Empty;

}
