using OpenBroker.Models;

namespace OpenBroker;

public interface IExecution
{
    /// <summary>
    /// 체결 내역
    /// </summary>
    EventHandler<IList<Contract>> Contracted { get; set; }

    /// <summary>
    /// 체결/미체결 내역
    /// </summary>
    EventHandler<IList<Order>> Executed { get; set; }

    /// <summary>
    /// 잔고
    /// </summary>
    EventHandler<Balance> BalanceAggregated { get; set; }

    /// <summary>
    /// 메시지
    /// </summary>
    EventHandler<ResponseMessage> Message { get; set; }

    /// <summary>
    /// 주문가능금액
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    bool RequestOrderable(Order order);

    /// <summary>
    /// 주문
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    bool AddOrder(Order order);

    /// <summary>
    /// 주문 수정
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    bool UpdateOrder(Order order);

    /// <summary>
    /// 주문 취소
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="oid">원주문번호</param>
    /// <param name="volume">취소 수량</param>
    /// <returns></returns>
    bool CancelOrder(string symbol, long oid, long volume);

    /// <summary>
    /// 체결내역 - 당일
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    bool RequestContracts(ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX);

    /// <summary>
    /// 체결내역 - 기간별
    /// </summary>
    /// <param name="dateBegun"></param>
    /// <param name="dateFin"></param>
    /// <param name="status"></param>
    /// <param name="exchange"></param>
    /// <returns></returns>
    bool RequestContracts(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly, Exchange exchange = Exchange.KRX);

    /// <summary>
    /// 예탁금 및 Positions
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    bool RequestBalances(DateTime? date = null);

    /// <summary>
    /// 미결제 약정 현황
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    bool RequestPositions(DateTime? date = null);

    /// <summary>
    /// 손익내역
    /// </summary>
    /// <param name="dateBegin"></param>
    /// <param name="dateFin"></param>
    /// <returns></returns>
    bool RequestEarning(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX);
}
