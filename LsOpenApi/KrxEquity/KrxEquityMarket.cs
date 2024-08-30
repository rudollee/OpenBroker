using OpenBroker.Models;
using OpenBroker;
using RestSharp;
using LsOpenApi.Models;
using System.Text.Json;
using System.Text;

namespace LsOpenApi.KrxEquity;
public partial class LsKrxEquity : ConnectionBase, IMarket
{
	public EventHandler<ResponseResult<MarketContract>> MarketContracted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public EventHandler<ResponseResult<MarketDepth>> MarketDepthListed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public EventHandler<ResponseResult<News>> NewsPosted { get; set; }

	public Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true) => throw new NotImplementedException();

	public async Task<ResponseCore> SubscribeNews(bool connecting = true) => await Subscribe("NWS", "NWS001", connecting);

	public async Task<ResponseResult<News>> RequestNews(string id)
	{
		var client = new RestClient($"{host}/stock/investinfo");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(t3102)));

		request.AddBody(JsonSerializer.Serialize(new
		{
			t3102InBlock = new t3102InBlock
			{
				sNewsno = id
			}
		}));

		try
		{
			var response = await client.PostAsync<t3102>(request) ?? new t3102();

			return new ResponseResult<News>
			{
				Info = new News
				{
					Code = id,
					Title = response.OutBlock2.sTitle,
					Body = string.Join("", response.OutBlock1.Select(s => s.sBody).ToArray()),
					SymbolList = response.OutBlock.Select(s => s.sJongcode).ToArray()
				}
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult<News>
			{
				StatusCode = Status.ERROR_OPEN_API,
				Message = ex.Message,
			};
		}
	}

}
