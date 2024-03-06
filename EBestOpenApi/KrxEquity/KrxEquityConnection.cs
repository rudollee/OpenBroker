using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBroker;
using OpenBroker.Models;

namespace EBestOpenApi.KrxEquity;
public partial class EBestKrxEquity : ConnectionBase, IConnection
{
	public Task<ResponseResult<KeyPack>> RequestAccessTokenAsync(string appkey, string appsecret) => 
		throw new NotImplementedException();
	
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => 
		throw new NotImplementedException();
}
