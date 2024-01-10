using OpenBroker;
using OpenBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisOpenApi;
public partial class KisGlobalFutures : IExecution
{
    public Account AccountInfo { get => _account; }
    private Account _account;

    public EventHandler<IList<Contract>> Contracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<IList<Order>> Executed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<Balance> BalanceAggregated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public EventHandler<ResponseMessage> Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ResponseMessage AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public ResponseMessage CancelOrder(string symbol, long oid, long volume)
    {
        throw new NotImplementedException();
    }

    public ResponseResult<Balance> RequestBalances(DateTime? date = null)
    {
        throw new NotImplementedException();
    }

    public ResponseResults<Contract> RequestContracts(ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX)
    {
        throw new NotImplementedException();
    }

    public ResponseResults<Contract> RequestContracts(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX)
    {
        throw new NotImplementedException();
    }

    public ResponseResults<Earning> RequestEarning(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX)
    {
        throw new NotImplementedException();
    }

    public ResponseMessage RequestOrderable(Order order)
    {
        throw new NotImplementedException();
    }

    public ResponseResults<Position> RequestPositions(DateTime? date = null)
    {
        throw new NotImplementedException();
    }

    public ResponseMessage UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }
}
