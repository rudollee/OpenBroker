﻿using OpenBroker.Models;

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
    EventHandler<ResponseResult<Contract>> Contracted { get; set; }

    /// <summary>
    /// 체결/미체결 내역
    /// </summary>
    EventHandler<ResponseResult<Order>> Executed { get; set; }

    /// <summary>
    /// 잔고
    /// </summary>
    EventHandler<ResponseResult<Balance>> BalanceAggregated { get; set; }

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
    Task<ResponseCore> AddOrderAsync(OrderCore order);

    /// <summary>
    /// 주문 수정
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<ResponseCore> UpdateOrderAsync(OrderCore order);

	/// <summary>
	/// 주문 취소
	/// </summary>
	/// <param name="bizDate">주문일자</param>
	/// <param name="oid">원주문번호</param>
	/// <param name="volume">취소 수량</param>
	/// <returns></returns>
	Task<ResponseCore> CancelOrderAsync(DateOnly bizDate, long oid, int volume);

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
	Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ExecutedOnly);

    /// <summary>
    /// 체결내역 - 기간별
    /// </summary>
    /// <param name="dateBegun"></param>
    /// <param name="dateFin"></param>
    /// <param name="status"></param>
    /// <param name="exchange"></param>
    /// <returns></returns>
    Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly);

	/// <summary>
	/// 체결내역 통보 - realtime
	/// </summary>
	/// <param name="connecting"></param>
	/// <returns></returns>
	Task<ResponseCore> SubscribeContractAsync(bool connecting = true);

    /// <summary>
    /// 예탁금 및 Positions
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null);

    /// <summary>
    /// 미결제 약정 현황
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<ResponseResults<Position>> RequestPositionsAsync(DateTime? date = null);

    /// <summary>
    /// 손익내역
    /// </summary>
    /// <param name="dateBegin"></param>
    /// <param name="dateFin"></param>
    /// <returns></returns>
    Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX);
}
