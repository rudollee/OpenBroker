using System.IO.Compression;
using System.Net;
using KisOpenApi.Models;
using KisOpenApi.Models.GlobalFutures;
using OpenBroker;
using OpenBroker.Extensions;
using OpenBroker.Models;
using RestSharp;

namespace KisOpenApi;
public partial class KisGlobalFutures : ConnectionBase, IMarket
{
	public required EventHandler<ResponseResult<OrderBook>>? OrderBookTaken { get; set; }
	public EventHandler<ResponseResult<News>>? NewsPosted { get; set; }
	public required EventHandler<ResponseResult<MarketContract>>? MarketContracted { get; set; }
	public EventHandler<ResponseResult<MarketPause>>? MarketPaused { get; set; }

	public async Task<ResponseResult<Instrument>> RequestInstrumentInfo(string symbol)
	{
		var client = new RestClient($"{host}/uapi/overseas-futureoption/v1/quotations/stock-detail");
		var request = new RestRequest().AddHeaders(GenerateHeaders(nameof(HHDFC55010100)));

		request.AddQueryParameter("SRS_CD", symbol);

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
				ExchangeCode = (Exchange)Enum.Parse(typeof(Exchange), response.Output1.exch_cd),
				Symbol = symbol,
				Sym = symbol.ToSym(),
				Margin = Convert.ToDecimal(response.Output1.trst_mgn),
				Tick = Convert.ToDecimal(response.Output1.tick_sz),
				TickValue = Convert.ToDecimal(response.Output1.tick_val),
				TimeOpen = response.Output1.mrkt_open_time.ToTime(),
				TimeClosed = response.Output1.mrkt_close_time.ToTime(),
				DateOpened = response.Output1.trd_fr_date.ToDate(),
				DateExpired = response.Output1.expr_date.ToDate(),
				Currency = (Currency)Enum.Parse(typeof(Currency), response.Output1.crc_cd),
				NumeralSystem = Convert.ToInt32(response.Output1.disp_digit.Trim()),
				Tradable = response.Output1.stat_tp == "1",
			};

			return new ResponseResult<Instrument>
			{
				Info = info,
				Remark = $"clas_cd: {response.Output1.clas_cd}, crc_cd: {response.Output1.crc_cd}"
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

	public async Task<ResponseResults<Instrument>> RequestInstruments(int option)
	{
		var instruments = new List<Instrument>();
		using (var client = new HttpClient())
		{
			var url = "https://new.real.download.dws.co.kr/common/master/ffcode.mst.zip";
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
			var zipData = await client.GetByteArrayAsync(url);

			using (var zipStream = new MemoryStream(zipData))
			{
				using (var archive = new ZipArchive(zipStream))
				{
					var entry = archive.GetEntry("ffcode.mst");
					if (entry is null) return new ResponseResults<Instrument> 
					{ 
						StatusCode = Status.NODATA,
						Message = "ffcode.mst is null",
						List = new List<Instrument>() 
					};

					using (var entryStream = entry.Open())
					{
						using (var reader = new StreamReader(entryStream, System.Text.Encoding.GetEncoding("cp949")))
						{
							string? line;
							while ((line = reader.ReadLine()) != null)
							{
								// TODO: Implement the logic to parse the line and create an Instrument object

								/*
                                DataRow row = dataTable.NewRow();
                                row["종목코드"] = line.Substring(0, 32).Trim();
                                row["서버자동주문 가능 종목 여부"] = line.Substring(32, 1).Trim();
                                row["서버자동주문 TWAP 가능 종목 여부"] = line.Substring(33, 1).Trim();
                                row["서버자동 경제지표 주문 가능 종목 여부"] = line.Substring(34, 1).Trim();
                                row["필러"] = line.Substring(35, 47).Trim();
                                row["종목한글명"] = line.Substring(82, 25).Trim();
                                row["거래소코드 (ISAM KEY 1)"] = line.Substring(107, 10).Trim();
                                row["품목코드 (ISAM KEY 2)"] = line.Substring(117, 10).Trim();
                                row["품목종류"] = line.Substring(127, 3).Trim();
                                row["출력 소수점"] = line.Substring(130, 5).Trim();
                                row["계산 소수점"] = line.Substring(135, 5).Trim();
                                row["틱사이즈"] = line.Substring(140, 14).Trim();
                                row["틱가치"] = line.Substring(154, 14).Trim();
                                row["계약크기"] = line.Substring(168, 10).Trim();
                                row["가격표시진법"] = line.Substring(178, 4).Trim();
                                row["환산승수"] = line.Substring(182, 10).Trim();
                                row["최다월물여부 0:원월물 1:최다월물"] = line.Substring(192, 1).Trim();
                                row["최근월물여부 0:원월물 1:최근월물"] = line.Substring(193, 1).Trim();
                                row["스프레드여부"] = line.Substring(194, 1).Trim();
                                row["스프레드기준종목 LEG1 여부"] = line.Substring(195, 1).Trim();
                                row["서브 거래소 코드"] = line.Substring(196, 3).Trim();
                                dataTable.Rows.Add(row);
								*/

								if (line.Substring(192, 1).Trim() == "0") continue; // 최다월물여부 0:원월물 1:최다월물
								if (line.Substring(194, 1).Trim() == "Y") continue; // 스프레드여부

								instruments.Add(new Instrument
								{
									Symbol = line.Substring(0, 32).Trim(),
									Sym = line.Substring(117, 10).Trim(),
									SymD = line.Substring(0, 32).Trim().Substring(2, 3),
									InstrumentName = line.Substring(82, 25).Trim(),
									Tick = Convert.ToDecimal(line.Substring(140, 14).Trim()),
									TickValue = Convert.ToDecimal(line.Substring(154, 14).Trim()),
									ExchangeCode = (Exchange)Enum.Parse(typeof(Exchange), line.Substring(196, 3).Trim()),
									Precision = Convert.ToInt32(line.Substring(130, 5).Trim()),
									Tradable = true,
									NumeralSystem = Convert.ToInt32(line.Substring(178, 4).Trim()),
									DiscardStatus = DiscardStatus.TRADABLE,
								});
							}
						}
					}
				}
			}
		}

		return new ResponseResults<Instrument> 
		{ 
			List = instruments
		};
	}

	public async Task<ResponseCore> SubscribeMarketContract(string symbol, bool connecting = true, string subscriber = "SYS") =>
		await SubscribeAsync(nameof(HDFFF020), symbol, connecting, subscriber);

	public async Task<ResponseCore> SubscribeMarketDepth(string symbol, bool connecting = true, string subscriber = "SYS") =>
		await SubscribeAsync(nameof(HDFFF010), symbol, connecting, subscriber);

	public Task<ResponseResult<MarketContract>> RequestMarketContract(string symbol) => throw new NotImplementedException();
	public Task<ResponseResult<News>> RequestNews(string id) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContract(IEnumerable<string> symbols) => throw new NotImplementedException();
	public Task<ResponseResults<MarketContract>> RequestMarketContractHistory(string symbol, string begin = "", string end = "", decimal baseVolume = 0) => throw new NotImplementedException();
	public Task<ResponseResult<PricePack>> RequestPricePack(PricePackRequest request) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeNews(bool connecting = true) => throw new NotImplementedException();
	public Task<ResponseCore> SubscribeMarketPause(string symbol = "000000") => throw new NotImplementedException();
}
