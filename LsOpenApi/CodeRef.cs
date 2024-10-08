﻿namespace LsOpenApi;

internal static class CodeRef
{
	internal static Dictionary<string, string> MarketSectionDic { get; set; } = new Dictionary<string, string>
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

	internal static Dictionary<string, string> MarketStatusDic { get; set; } = new Dictionary<string, string>
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

}
