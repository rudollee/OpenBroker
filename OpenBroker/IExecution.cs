using OpenBroker.Models;

namespace OpenBroker;

/// <summary>
/// 계좌 및 주문
/// </summary>
public interface IExecution
{
    /// <summary>
    /// 계좌 번호 정보
    /// </summary>
    public BankAccount BankAccountInfo { get; }

    /// <summary>
    /// 체결 내역
    /// </summary>
    EventHandler<ResponseResult<Execution>> Executed { get; set; }

    /// <summary>
    /// 체결/미체결 내역
    /// </summary>
    EventHandler<ResponseResult<Order>> OrderReceived { get; set; }

    /// <summary>
    /// 잔고
    /// </summary>
    EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

    /// <summary>
    /// 주문가능금액
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<ResponseCore> RequestOrderableAsync(Order order);

    /// <summary>
    /// 주문
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<ResponseCore> PlaceOrderAsync(OrderCore order);

    /// <summary>
    /// 주문 수정
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<ResponseCore> UpdateOrderAsync(OrderCore order);

	/// <summary>
	/// 주문 취소
	/// </summary>
	/// <param name="order"></param>
	/// <returns></returns>
	Task<ResponseCore> CancelOrderAsync(OrderCore order);

	/// <summary>
	/// 주문내역 - 당일
	/// </summary>
	/// <returns></returns>
	Task<ResponseResults<Order>> RequestOrdersAsync();

	/// <summary>
	/// 주문내역 - 기간별
	/// </summary>
	/// <param name="dateBegun"></param>
	/// <param name="dateFin"></param>
	/// <returns></returns>
	Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin);

	/// <summary>
	/// 주문내역 통보 - realtime
	/// </summary>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeOrderAsync(bool connecting = true);

	/// <summary>
	/// 체결내역 - 당일
	/// </summary>
	/// <param name="status"></param>
	/// <returns></returns>
	Task<ResponseResults<Execution>> RequestExecutionsAsync(ExecutionStatus status = ExecutionStatus.ExecutedOnly, string symbol = "");

    /// <summary>
    /// 체결내역 - 기간별
    /// </summary>
    /// <param name="dateBegun"></param>
    /// <param name="dateFin"></param>
    /// <param name="status"></param>
    /// <param name="exchange"></param>
    /// <returns></returns>
    Task<ResponseResults<Execution>> RequestExecutionsAsync(DateTime dateBegun, DateTime dateFin, ExecutionStatus status = ExecutionStatus.ExecutedOnly);

	/// <summary>
	/// 체결내역 통보 - realtime
	/// </summary>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeExecutionAsync(bool connecting = true);

	/// <summary>
	/// 예탁금 및 Positions
	/// </summary>
	/// <param name="date"></param>
	/// <param name="currency"></param>
	/// <returns></returns>
	Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.TUS);

    /// <summary>
    /// 미결제 약정 현황
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<ResponseResults<Position>> RequestPositionsAsync();

    /// <summary>
    /// 손익내역
    /// </summary>
    /// <param name="dateBegin"></param>
    /// <param name="dateFin"></param>
    /// <returns></returns>
    Task<ResponseResults<Pnl>> RequestPnlAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX);
}
