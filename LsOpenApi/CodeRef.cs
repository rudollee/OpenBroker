﻿using LsOpenApi.Models;

namespace LsOpenApi;

internal static class CodeRef
{
	/// <summary>
	/// 거래소/시장
	/// </summary>
	internal static Dictionary<string, string> MarketSectionDic { get; set; } = new()
	{
		{"1", "코스피"},
		{"2", "코스닥"},
		{"5", "선물/옵션"},
		{"7", "CME야간선물"},
		{"8", "EUREX야간옵션선물"},
		{"9", "미국주식"},
		{"A", "중국주식오전"},
		{"B", "중국주식오후"},
		{"C", "홍콩주식오전"},
		{"D", "홍콩주식오후"},
	};

	/// <summary>
	/// 장운영정보
	/// </summary>
	internal static Dictionary<string, string> MarketStatusDic { get; set; } = new()
	{
		{"11", "장전동시호가개시"},
		{"21", "장시작"},
		{"22", "장개시10초전"},
		{"23", "장개시1분전"},
		{"24", "장개시5분전"},
		{"25", "장개시10분전"},
		{"31", "장후동시호가개시"},
		{"41", "장마감"},
		{"42", "장마감10초전"},
		{"43", "장마감1분전"},
		{"44", "장마감5분전"},
		{"51", "시간외종가매매개시"},
		{"52", "시간외종가매매종료,시간외단일가매매개시"},
		{"53", "사용안함"},
		{"54", "시간외단일가매매종료"},
		{"61", "서킷브레이크1단계발동"},
		{"62", "서킷브레이크1단계해제,호가접수개시"},
		{"63", "서킷브레이크1단계,동시호가종료"},
		{"64", "사이드카 매도발동"},
		{"65", "사이드카 매도해제"},
		{"66", "사이드카 매수발동"},
		{"67", "사이드카 매수해제"},
		{"68", "서킷브레이크2단계발동"},
		{"69", "서킷브레이크3단계발동,당일 장종료"},
		{"70", "서킷브레이크2단계해제,호가접수개시"},
		{"71", "서킷브레이크2단계,동시호가종료"}
	};

	/// <summary>
	/// 언론사
	/// </summary>
	internal static Dictionary<int, string> NewsPublishers { get; set; } = new()
	{
		{ 11, "연합뉴스" },
		{ 14, "이데일리" },
		{ 15, "공시" },
		{ 20, "머니투데이" },
		{ 21, "인포스탁" },
		{ 22, "이베스트" },
		{ 23, "아시아경제" },
		{ 24, "뉴스핌" },
		{ 25, "매일경제" },
		{ 26, "한국경제" },
		{ 27, "헤럴드경제" },
		{ 28, "로이터" },
		{ 29, "코리아헤럴드" },
		{ 30, "파이낸셜뉴스" },
		{ 31, "이투데이" },
		{ 32, "조선비즈" },
		{ 33, "데이터투자" },
		{ 34, "연합인포맥스" },
		{ 35, "서울경제" },
		{ 36, "포춘코리아" },
		{ 37, "뉴스웨이" }
	};

	/// <summary>
	/// 초당 전송 건수
	/// </summary>
	internal static Dictionary<string, int> RequestIntervals { get; set; } = new()
	{
		{ nameof(CSPAQ12300), 1 },
		{ nameof(CSPAQ13700), 1 },
		{ nameof(CSPAQ22200), 1 },
		{ nameof(CSPAT00601), 10 },
		{ nameof(CSPAT00701), 3 },
		{ nameof(CSPAT00801), 3 },
		{ nameof(CSPBQ00200), 1 },
		{ nameof(t0424), 1 },
		{ nameof(t0425), 1 },
		{ nameof(t1101), 3 },
		{ nameof(t1102), 3 },
		{ nameof(t1301), 2 },
		{ nameof(t1403), 1 },
		{ nameof(t3102), 1 },
		{ nameof(t8407), 2 },
		{ nameof(t8436), 2 },
		{ nameof(t1531), 1 },
		{ nameof(t1532), 1 },
		{ nameof(t1537), 1 },
		{ nameof(t8410), 1 },
		{ nameof(t8411), 1 },
		{ nameof(t8412), 1 },
	};
}
