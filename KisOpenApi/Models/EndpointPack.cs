using System.ComponentModel;
using RestSharp;

namespace KisOpenApi.Models;
internal class EndpointPack
{
	public TrId ID { get; set; }
	public EndpointPrefix Prefix { get; set; }
	public EndpointType Type { get; set; }
	public string Endpoint { get; set; } = string.Empty;
	public Method HttpMethod { get; set; } = Method.Get;
}

/// <summary>
/// TR ID
/// </summary>
internal enum TrId
{
	/// <summary>국내주식 주식주문(현금) - 매수</summary>
	TTTC0012U,

	/// <summary>국내주식 주식주문(현금) - 매도</summary>
	TTTC0011U,

	/// <summary>국내주식 주식주문(신용) - 매수</summary>
	TTTC0052U,

	/// <summary>국내주식 주식주문(신용) - 매도</summary>
	TTTC0051U,

	/// <summary>국내주식 주식주문(정정취소)</summary>
	TTTC0013U,

	/// <summary>국내주식 정정취소가능주문조회</summary>
	TTTC0084R,

	/// <summary>국내주식 일별주문체결조회 - 최근 3개월</summary>
	TTTC0081R, // TTTC8001R

	/// <summary>국내주식 일별주문체결조회 - 3개월 이전</summary>
	CTSC9215R, // CTSC9115R 

	/// <summary>국내주식 잔고조회</summary>
	TTTC8434R,

	/// <summary>국내주식 매수가능조회</summary>
	TTTC8908R,

	/// <summary>국내주식 예약주문</summary>
	CTSC0008U,

	/// <summary>국내주식 현재가(시세)</summary>
	FHKST01010100,

	/// <summary>국내주식 현재가(호가)</summary>
	FHKST01010200,

	/// <summary>국내주식 현재가(체결)</summary>
	FHKST01010400,

	/// <summary>국내주식 일자별주문</summary>
	FHKST01010300,

	/// <summary>국내주식 기간별시세(일/주/월/년)</summary>
	FHKST03010100,

	/// <summary>국내주식 당일분봉조회</summary>
	FHKST03010200,

	/// <summary>국내주식 일별분봉조회</summary>
	FHKST03010230,

	/// <summary>국내주식 종목조회</summary>
	FHPST01710000,

	/// <summary>국내주식 투자자별 매매동향</summary>
	FHPST02310000,

	/// <summary>국내주식 업종별 투자자 매매동향</summary>
	FHPST02320000,

	/// <summary>국내주식 상품기본조회</summary>
	CTPF1604R,

	/// <summary>국내주식 주식기본조회</summary>
	CTPF1002R,

	/// <summary>국내주식 대차대조표</summary>
	FHKST66430100,

	/// <summary>국내주식 손익계산서</summary>
	FHKST66430200,

	/// <summary>국내주식 재무비율</summary>
	FHKST66430300,

	/// <summary>국내주식 수익성비율</summary>
	FHKST66430400,

	/// <summary>국내주식 기타주요비율</summary>
	FHKST66430500,

	/// <summary>국내주식 안정성비율</summary>
	FHKST66430600,

	/// <summary>국내주식 성장성비율</summary>
	FHKST66430800,

	/// <summary>국내주식 당사 신용가능종목</summary>
	FHPST04770000,

	/// <summary>국내주식 예탁원정보(배당일정)</summary>
	HHKDB669102C0,

	/// <summary>국내주식 예탁원정보(주식매수청구일정)</summary>
	HHKDB669103C0,

	/// <summary>국내주식 예탁원정보(합병/분할일정)</summary>
	HHKDB669104C0,

	/// <summary>국내주식 예탁원정보(액면교체일정)</summary>
	HHKDB669105C0,

	/// <summary>국내주식 예탁원정보(자본감소일정)</summary>
	HHKDB669106C0,

	/// <summary>국내주식 예탁원정보(상장정보일정)</summary>
	HHKDB669107C0,

	/// <summary>국내주식 예탁원정보(공모주청약일정)</summary>
	HHKDB669108C0,

	/// <summary>국내주식 예탁원정보(실권주일정)</summary>
	HHKDB669109C0,

	/// <summary>국내주식 예탁원정보(의무예치일정)</summary>
	HHKDB669110C0,

	/// <summary>국내주식 예탁원정보(유상증자일정)</summary>
	HHKDB669100C0,

	/// <summary>국내주식 예탁원정보(무상증자일정)</summary>
	HHKDB669101C0,

	/// <summary>국내주식 예탁원정보(주주총회일정)</summary>
	HHKDB669111C0,

	/// <summary>국내주식 종목추정실적</summary>
	HHKST668300C0,

	/// <summary>국내주식 당사 대주가능 종목</summary>
	CTSC2702R,

	/// <summary>국내주식 종목투자의견</summary>
	FHKST663300C0,

	/// <summary>국내주식 증권사별 투자의견</summary>
	FHKST663400C0,

	/// <summary>장내채권 매수주문</summary>
	TTTC0952U,

	/// <summary>장내채권 매도주문</summary>
	TTTC0958U,

	/// <summary>장내채권 정정취소주문</summary>
	TTTC0953U,

	/// <summary>장내채권 정정취소가능주문조회</summary>
	CTSC8035R,

	/// <summary>장내채권 주문체결내역</summary>
	CTSC8013R,

	/// <summary>장내채권 잔고조회</summary>
	CTSC8407R,

	/// <summary>장내채권 매수가능조회</summary>
	TTTC8910R,

	/// <summary>장내채권 발행정보</summary>
	CTPF1101R,

	/// <summary>장내채권 현재가(호가)</summary>
	FHKBJ773401C0,

	/// <summary>장내채권 평균단가조회</summary>
	CTPF2005R,

	/// <summary>장내채권 기간별시세(일)</summary>
	FHKBJ773701C0,

	/// <summary>장내채권 현재가(시세)</summary>
	FHKBJ773400C0,

	/// <summary>장내채권 현재가(체결)</summary>
	FHKBJ773403C0,

	/// <summary>장내채권 현재가(일별)</summary>
	FHKBJ773404C0,

	/// <summary>장내채권 기본조회</summary>
	CTPF1114R,

	/// <summary>해외주식 주문</summary>
	TTTS0308U,

	/// <summary>해외주식 정정취소주문</summary>
	TTTS0302U,

	/// <summary>해외주식 잔고조회</summary>
	TTTS0318R,

	/// <summary>해외주식 주문체결내역</summary>
	TTTS0307R,

	/// <summary>해외주식 매수가능조회</summary>
	TTTS0311R,

	/// <summary>해외주식 현재가</summary>
	HHDFS00000300,

	/// <summary>해외주식 일자별시세</summary>
	HHDFS76240000,

	/// <summary>해외주식 종목검색</summary>
	HHDFS76200100,

	/// <summary>선물옵션 주문 / 해외선물옵션 주문국내</summary>
	OTFM3001U,

	/// <summary>선물옵션 취소주문 / 해외선물옵션 취소주문국내</summary>
	OTFM3003U,

	/// <summary>선물옵션 잔고조회 / 해외선물옵션 미결제내역조회(건)</summary>
	OTFM1412R,

	/// <summary>선물옵션 체결내역조회 / 해외선물옵션 체결내역조회</summary>
	OTFM3121R,

	/// <summary>선물옵션 현재가 / 해외선물옵션현재가</summary>
	HHDFC5510000,

	/// <summary>선물옵션 호가 / 해외선물옵션 호가</summary>
	HHDFC0860000000,

	/// <summary>선물옵션 일자별시세 / 해외선물옵션 차트주문(일간)</summary>
	HHDFC5520100,

	/// <summary>펀드 매수주문</summary>
	TTTC0501U,

	/// <summary>펀드 매도주문</summary>
	TTTC0502U,

	/// <summary>펀드 잔고조회</summary>
	TTTC0510R,

	/// <summary>펀드 현재가</summary>
	FHPFUND01000000,

	/// <summary>해외선물옵션 당일주문내역조회</summary>
	OTFM316R,

	/// <summary>해외선물옵션 주문가능조회</summary>
	OTFM304R,

	/// <summary>해외선물옵션 잔고계좌수익률</summary>
	OTFM3118R,

	/// <summary>해외선물옵션 일별계좌수익률</summary>
	OTFM3122R,

	/// <summary>해외선물옵션 예수금조회</summary>
	OTFM1411R,

	/// <summary>해외선물옵션 일별주문내역</summary>
	OTFM3120R,

	/// <summary>해외선물옵션 기간계좌손익조회</summary>
	OTFM3114R,

	/// <summary>해외선물옵션증거금상세</summary>
	OTFM3115R,

	/// <summary>해외선물옵션종목상세</summary>
	HHDFC5510100,

	/// <summary>해외선물옵션 시간외주문(조건)</summary>
	HHDFC5520400,

	/// <summary>해외선물옵션 차트주문(틱)</summary>
	HHDFC5520200,

	/// <summary>해외선물옵션 차트주문(월간)</summary>
	HHDFC5520300,

	/// <summary>해외선물옵션 상장종목조회</summary>
	HHDFC8600000,

	/// <summary>해외선물옵션 잔고계좌수익률</summary>
	HHDFC5520000,

	/// <summary>해외선물옵션 매각체결이</summary>
	OTFM2229R,

	/// <summary>해외선물옵션종목현재가</summary>
	HHDFC0550100,

	/// <summary>해외선물옵션 차트주문(조건)</summary>
	HHDFC0550200,

	/// <summary>해외선물옵션 차트주문(일간)</summary>
	HHDFC0550210,

	/// <summary>해외선물옵션 차트주문(틱)</summary>
	HHDFC0550220,

	/// <summary>해외선물옵션 차트주문(월간)</summary>
	HHDFC0550230,

	/// <summary>해외선물옵션 분봉조회</summary>
	HHDFC0550240,

	/// <summary>해외선물옵션 종목검색</summary>
	HHDFC0552000,

	/// <summary>해외선물옵션 주문가능금액조회</summary>
	OTFM3041R,

	/// <summary>해외선물옵션 계좌별예탁자산조회</summary>
	OTFM1410R,

	/// <summary>해외선물옵션 종목검색</summary>
	HHDFC0552100
}

/// <summary>
/// Endpoint Prefix
/// </summary>
internal enum EndpointPrefix
{
	[Description("overseas-futureoption/v1")]
	GlobalV1,

	[Description("overseas-stock/v1")]
	GlobalEquityV1,

	[Description("domestic-futureoption/v1")]
	KrxV1,

	[Description("domestic-stock/v1")]
	KrxEquityV1,

	[Description("domestic-bond/v1")]
	KrxBondV1,

	[Description("domestic-fund/v1")]
	KrxFundV1,
}

/// <summary>
/// Endpoint Type
/// </summary>
internal enum EndpointType
{
	[Description("trading")]
	Trading,

	[Description("quotations")]
	Quote, // Corrected typo from Quate to Quote

	[Description("account")]
	Account,

	[Description("watchlist")]
	Watchlist,

	[Description("investment-info")]
	InvestmentInfo,

	[Description("ticker-analysis")]
	TickerAnalysis,

	[Description("market-info")]
	MarketInfo,

	[Description("index")]
	Index,

	[Description("realtime")]
	Realtime // For WebSocket APIs
}