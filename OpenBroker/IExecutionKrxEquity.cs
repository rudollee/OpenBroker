using OpenBroker.Models;

namespace OpenBroker;
public interface IExecutionKrxEquity
{
	/// <summary>
	/// 일간 매매일지/수수료 집계
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	Task<ResponseResults<Position>> RequestExecutionAgg(DateOnly date);
}
