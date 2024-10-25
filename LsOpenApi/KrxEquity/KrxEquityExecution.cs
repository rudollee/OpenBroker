﻿using System.Text.Json;
using LsOpenApi.Models;
using OpenBroker.Models;
using OpenBroker;
using OpenBroker.Extensions;
using RestSharp;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IExecution
{
	public required EventHandler<ResponseResult<Contract>> Contracted { get; set; }
	public required EventHandler<ResponseResult<Order>> Executed { get; set; }
	public EventHandler<ResponseResult<Balance>>? BalanceAggregated { get; set; }

	#region 주문/정정/취소 - CSPAT00601/CSPAT00701/CSPAT00801
	public async Task<ResponseCore> AddOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00601>(new
		{
			CSPAT00601InBlock1 = new CSPAT00601InBlock1
			{
				IsuNo = $"A{order.Symbol}",
				OrdQty = order.VolumeOrdered,
				OrdPrc = order.PriceOrdered,
				BnsTpCode = order.IsLong ? "2" : "1",
				OrdprcPtnCode = order.OrderType switch
				{
					OrderType.LIMIT => "00",
					OrderType.MARKET => "03",
					_ => "03"
				},
				MgntrnCode = "000",
				LoanDt = "",
				OrdCndiTpCode = "0"
			}
		});

	public async Task<ResponseCore> UpdateOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00701>(new
		{
			CSPAT00701InBlock1 = new CSPAT00701InBlock1
			{
				OrgOrdNo = order.IdOrigin,
				IsuNo = $"A{order.Symbol}",
				OrdQty = order.VolumeOrdered,
				OrdPrc = order.PriceOrdered,
				OrdprcPtnCode = order.OrderType switch
				{
					OrderType.LIMIT => "00",
					OrderType.MARKET => "03",
					_ => "00"
				},
				OrdCndiTpCode = "0"
			}
		});

	public async Task<ResponseCore> CancelOrderAsync(OrderCore order) =>
		await RequestOrderAsync<CSPAT00801>(new
		{
			CSPAT00801InBlock1 = new CSPAT00801InBlock1
			{
				OrgOrdNo = order.IdOrigin,
				IsuNo = order.Symbol,
				OrdQty = order.VolumeOrdered,
			}
		});

	private async Task<ResponseCore> RequestOrderAsync<T>(object parameters) where T : LsOrderResponseStandard
	{
		var client = new RestClient($"{host}/stock/order");
		var request = new RestRequest().AddHeaders(GenerateHeaders(typeof(T).Name));

		request.AddBody(JsonSerializer.Serialize(parameters));

		try
		{
			var response = await client.PostAsync<T>(request);
			if (response is null) return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = "response is null",
			};

			return new ResponseCore
			{
				Code = response.Code,
				Message = response.Message,
				Remark = response.OrderNo.ToString()
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "exception"
			};
		}
	}

	#endregion

	#region 체결/미체결 - t0425
	public Task<ResponseResult<Balance>> RequestBalancesAsync(DateTime? date = null, Currency currency = Currency.NONE) => throw new NotImplementedException();

	public async Task<ResponseResults<Contract>> RequestContractsAsync(ContractStatus status = ContractStatus.ExecutedOnly)
	{
		var contracts = new List<Contract>();
		var client = new RestClient($"{host}/stock/accno");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t0425)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t0425InBlock = new t0425InBlock
			{
				expcode = "",
				chegb = status switch
				{
					ContractStatus.All => "0",
					ContractStatus.ExecutedOnly => "1",
					ContractStatus.UnexecutedOnly => "2",
					_ => "0"
				},
				medosu = "0",
				sortgb = "1",
				cts_ordno = "",
			}
		}));

		try
		{
			var response = await client.PostAsync<t0425>(request) ?? new t0425();

			contracts.Capacity = response.t0425OutBlock1.Count;
			response.t0425OutBlock1.ForEach(contract =>
			{
				contracts.Add(new Contract
				{
					BrokerCo = "EB",
					OID = contract.ordno,
					CID = contract.sysprocseq,
					Currency = Currency.KRW,
					DateBiz = DateOnly.FromDateTime(DateTime.Now),
					ExchangeCode = Exchange.KRX,
					IdOrigin = contract.orgordno,
					PriceOrdered = contract.price,
					Price = contract.cheprice,
					Symbol = contract.expcode,
					TimeOrdered = contract.ordtime.ToDateTime(),
				});
			});

			return new ResponseResults<Contract>
			{
				List = contracts,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Contract>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Message = ex.Message,
				List = new List<Contract>()
			};
		}
	} 
	#endregion

	public Task<ResponseResults<Contract>> RequestContractsAsync(DateTime dateBegun, DateTime dateFin, ContractStatus status = ContractStatus.ExecutedOnly) => throw new NotImplementedException();
	public Task<ResponseResults<Earning>> RequestEarningAsync(DateTime dateBegin, DateTime dateFin, Exchange exchange = Exchange.KRX) => throw new NotImplementedException();

	#region 주문가능금액 - CSPBQ00200
	public async Task<ResponseCore> RequestOrderableAsync(Order order)
	{
		var client = new RestClient($"{host}/stock/accno");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(CSPBQ00200)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			CSPBQ00200InBlock1 = new CSPBQ00200InBlock1
			{
				BnsTpCode = order.IsLong ? "2" : "1",
				IsuNo = order.Symbol,
				OrdPrc = order.PriceOrdered
			}
		}));

		try
		{
			var response = await client.PostAsync<CSPBQ00200>(request) ?? new CSPBQ00200();

			return new ResponseCore
			{
				Code = response.CSPBQ00200OutBlock2.TrdMgnrt.ToString(),
				Remark = response.CSPBQ00200OutBlock2.OrdAbleQty.ToString()
			};
		}
		catch (Exception ex)
		{
			return new ResponseCore
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				Remark = "catch area"
			};
		}
	} 
	#endregion

	#region 주문 내역 - CSPAQ13700
	public async Task<ResponseResults<Order>> RequestOrdersAsync() =>
	await RequestOrdersAsync(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now));

	public async Task<ResponseResults<Order>> RequestOrdersAsync(DateOnly dateBegun, DateOnly dateFin)
	{
		var client = new RestClient($"{host}/stock/accno");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(CSPAQ13700)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			CSPAQ13700InBlock1 = new CSPAQ13700InBlock1
			{
				OrdMktCode = "00",
				BnsTpCode = "0",
				IsuNo = string.Empty,
				ExecYn = "0",
				OrdDt = dateBegun.ToString("yyyyMMdd"),
				SrtOrdNo2 = 0,
				BkseqTpCode = "1",
				OrdPtnCode = "00"
			}
		}));

		var orders = new List<Order>();
		try
		{
			var response = await client.PostAsync<CSPAQ13700>(request) ?? new CSPAQ13700();
			orders.Capacity = response.CSPAQ13700OutBlock3.Count;
			response.CSPAQ13700OutBlock3.ForEach(order =>
			{
				orders.Add(new Order
				{
					BrokerCo = "LS",
					DateBiz = order.OrdDt.ToDate(),
					TimeOrdered = (DateTime.Now.ToString("yyyyMMdd") + order.OrdTime).ToDateTimeMicro(),
					Symbol = order.IsuNo.Substring(1),
					InstrumentName = order.IsuNm,
					OID = order.OrdNo,
					IdOrigin = order.OrgOrdNo,
					Currency = Currency.KRW,
					NumeralSystem = 10,
					Precision = 0,
					IsLong = order.BnsTpCode.Equals("2"),
					Mode = order.MrcTpCode switch
					{
						"0" => OrderMode.PLACE,
						"1" => OrderMode.UPDATE,
						"2" => OrderMode.CANCEL,
						_ => OrderMode.NONE,
					},
					PriceOrdered = order.OrdPrc,
					VolumeOrdered = order.OrdQty,
					Aggregation = order.OrdPrc * order.OrdQty,
					Section = order.OrdMktCode == "10" ? ExchangeSection.KOSPI : ExchangeSection.KOSDAQ
				});
			});

			return new ResponseResults<Order>
			{
				List = orders,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Order>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
				List = new List<Order>(),
				Remark = "catch area"
			};
			throw;
		}
	}
	#endregion

	#region 잔고 - t0424
	public async Task<ResponseResults<Position>> RequestPositionsAsync()
	{
		var client = new RestClient($"{host}/stock/accno");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t0424)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t0424InBlock = new t0424InBlock
			{
				prcgb = "1",
				chegb = "2",
				dangb = "0",
				charge = "1",
				cts_expcode = ""
			}
		}));

		var positions = new List<Position>();

		try
		{
			var response = await client.PostAsync<t0424>(request) ?? new t0424();
			positions.Capacity = response.t0424OutBlock1.Count;
			response.t0424OutBlock1.ForEach(position =>
			{
				positions.Add(new Position
				{
					Currency = Currency.KRW,
					Symbol = position.expcode,
					InstrumentName = position.hname,
					NumeralSystem = 10,
					Precision = 0,
					PriceEntry = position.pamt,
					Price = position.price,
					VolumeEntry = position.janqty,
					Volume = position.janqty,
					Tradable = true,
					Tax = position.tax,
					Fee = position.fee,
				});
			});

			return new ResponseResults<Position>
			{
				List = positions,
				Remark = response.t0424OutBlock.dtsunik.ToString()
			};
		}
		catch (Exception ex)
		{
			return new ResponseResults<Position>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Code = "ERROR - T0424",
				Message = ex.Message,
				List = positions,
			};
		}
	} 
	#endregion

	public async Task<ResponseCore> SubscribeContractAsync(bool connecting = true) => await SubscribeAsync("SYS", "SC1", "", connecting);

	public async Task<ResponseCore> SubscribeOrderAsync(bool connecting = true)
	{
		foreach (var trCode in new string[] { "SC0", "SC2", "SC3", "SC4" })
		{
			var response = await SubscribeAsync("SYS", trCode, "", connecting) ?? new ResponseCore
			{
				Code = trCode,
				StatusCode = Status.ERROR_OPEN_API,
			};

			if (response.StatusCode != Status.SUCCESS) return response;
		}

		return new ResponseCore
		{
			StatusCode = Status.SUCCESS,
		};
	}
}
