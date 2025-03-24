using OpenBroker;
using OpenBroker.Models;

namespace LsOpenApi.KrxFutures;
public partial class KrxFutures : ConnectionBase, IConnection
{
	public Task<ResponseCore> ConnectAsync() => throw new NotImplementedException();
	public Task<ResponseResult<KeyPack>> RequestApprovalKeyAsync(string appkey, string secretkey) => throw new NotImplementedException();
}
