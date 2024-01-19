using OpenBroker;
using OpenBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IExecution
{
    public Account AccountInfo { get => _account; }
    private Account _account;

    public EventHandler<IList<Contract>> Contracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<IList<Order>> Executed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<Balance> BalanceAggregated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<ResponseMessage> Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public Task<ResponseMessage> RequestOrderableAsync(Order order)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseMessage> AddOrderAsync(Order order)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseMessage> UpdateOrderAsync(Order order)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseMessage> CancelOrderAsync(string symbol, long oid, long volume)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Position>> RequestPositionsAsync(DateTime? date = null)
	{
		throw new NotImplementedException();
	}

	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX)
	{
		throw new NotImplementedException();
	}

	#region Generate QueryParameters
	/// <summary>
	/// Generate QueryParameters
	/// </summary>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string?> GenerateQueryParameters(Dictionary<string, string?> additionalOption)
    {
        var basicParameters = new
        {
            CANO = AccountInfo.AccountNumber,
            ACNT_PRDT_CD = AccountInfo.AccountNumberSuffix,
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
	private Dictionary<string, string?> GenerateQueryParameters(object additionalOption) =>
		GenerateQueryParameters(additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));

	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string> GenerateHeaders(string tr, Dictionary<string, string> additionalOption)
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
	private Dictionary<string, string> GenerateHeaders(string tr)
	{
		return new Dictionary<string, string>
				{
					{ "content-type", "application/json" },
					{ "authorization", $"Bearer {_connection.AccessToken}"},
					{ "appkey", _connection.AppKey },
					{ "appsecret", _connection.SecretKey},
					{ "tr_id", tr},
					{ "custtype", "P" }
				};
	}
	/// <summary>
	/// Generate Headers
	/// </summary>
	/// <param name="tr"></param>
	/// <param name="additionalOption"></param>
	/// <returns></returns>
	private Dictionary<string, string> GenerateHeaders(string tr, object additionalOption) =>
		GenerateHeaders(tr, additionalOption.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(additionalOption, null)?.ToString()));
	#endregion
}
