using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KisOpenApi.Models;
using KisOpenApi.Models.GlobalFutures;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IMarket
{
	public required EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get; set; }
	public EventHandler<ResponseResult<News>> NewsPosted { get; set; }
	public required EventHandler<ResponseResult<MarketContract>> MarketContracted { get; set; }

	public async Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol)
	{
		var client = new RestClient($"");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(HHDFC55010100)));

		var body = GenerateParameters(new
		{
			SRS_CD = symbol
		});

		foreach ( var parameter in body)
		{
			request.AddQueryParameter(parameter.Key, parameter.Value);
		}

		try
		{
			var response = await client.GetAsync<HHDFC55010100>(request);
			if (response is null) return new ResponseResult<Instrument>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Info = new Instrument(),
				Message = "response is null"
			};

			var info = new Instrument
			{
				Symbol = symbol,
				Sym = symbol.ToSym(),
				Margin = Convert.ToDecimal(response.Output1.trst_mgn),
				Tick = Convert.ToDecimal(response.Output1.tick_sz),
				TickValue = Convert.ToDecimal(response.Output1.tick_val),
				TimeOpen = response.Output1.mrkt_open_time.ToTime(),
				TimeClosed = response.Output1.mrkt_close_time.ToTime(),
				DateOpened = response.Output1.trd_fr_date.ToDate(),
				DateExpired = response.Output1.expr_date.ToDate(),
			};

			return new ResponseResult<Instrument>
			{
				Info = info,
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<Instrument>
			{
				StatusCode = Status.INTERNALSERVERERROR,
				Info = new Instrument(),
				Message = ex.Message
			};
		}
	}

	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) =>
		await Subscribe(nameof(HDFFF020), symbol, connecting);

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) =>
		await Subscribe(nameof(HDFFF010), symbol, connecting);

	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
}
