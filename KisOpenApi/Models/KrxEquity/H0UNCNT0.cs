namespace KisOpenApi.Models;
/// <summary>
/// 국내주식 실시간 체결가 (통합)
/// </summary>
internal enum H0UNCNT0
{
	/// <summary>유가증권 단축 종목코드</summary>
	MKSC_SHRN_ISCD = 0,

	/// <summary>주식 체결 시간</summary>
	STCK_CNTG_HOUR = 1,

	/// <summary>주식 현재가</summary>
	STCK_PRPR = 2,

	/// <summary>전일 대비 부호</summary>
	PRDY_VRSS_SIGN = 3,

	/// <summary>전일 대비</summary>
	PRDY_VRSS = 4,

	/// <summary>전일 대비율</summary>
	PRDY_CTRT = 5,

	/// <summary>가중 평균 주식 가격</summary>
	WGHN_AVRG_STCK_PRC = 6,

	/// <summary>주식 시가</summary>
	STCK_OPRC = 7,

	/// <summary>주식 최고가</summary>
	STCK_HGPR = 8,

	/// <summary>주식 최저가</summary>
	STCK_LWPR = 9,

	/// <summary>매도호가1</summary>
	ASKP1 = 10,

	/// <summary>매수호가1</summary>
	BIDP1 = 11,

	/// <summary>체결 거래량</summary>
	CNTG_VOL = 12,

	/// <summary>누적 거래량</summary>
	ACML_VOL = 13,

	/// <summary>누적 거래 대금</summary>
	ACML_TR_PBMN = 14,

	/// <summary>매도 체결 건수</summary>
	SELN_CNTG_CSNU = 15,

	/// <summary>매수 체결 건수</summary>
	SHNU_CNTG_CSNU = 16,

	/// <summary>순매수 체결 건수</summary>
	NTBY_CNTG_CSNU = 17,

	/// <summary>체결강도</summary>
	CTTR = 18,

	/// <summary>총 매도 수량</summary>
	SELN_CNTG_SMTN = 19,

	/// <summary>총 매수 수량</summary>
	SHNU_CNTG_SMTN = 20,

	/// <summary>체결구분</summary>
	CNTG_CLS_CODE = 21,

	/// <summary>매수비율</summary>
	SHNU_RATE = 22,

	/// <summary>전일 거래량 대비 등락율</summary>
	PRDY_VOL_VRSS_ACML_VOL_RATE = 23,

	/// <summary>시가 시간</summary>
	OPRC_HOUR = 24,

	/// <summary>시가대비구분</summary>
	OPRC_VRSS_PRPR_SIGN = 25,

	/// <summary>시가대비</summary>
	OPRC_VRSS_PRPR = 26,

	/// <summary>최고가 시간</summary>
	HGPR_HOUR = 27,

	/// <summary>고가대비구분</summary>
	HGPR_VRSS_PRPR_SIGN = 28,

	/// <summary>고가대비</summary>
	HGPR_VRSS_PRPR = 29,

	/// <summary>최저가 시간</summary>
	LWPR_HOUR = 30,

	/// <summary>저가대비구분</summary>
	LWPR_VRSS_PRPR_SIGN = 31,

	/// <summary>저가대비</summary>
	LWPR_VRSS_PRPR = 32,

	/// <summary>영업 일자</summary>
	BSOP_DATE = 33,

	/// <summary>신 장운영 구분 코드</summary>
	NEW_MKOP_CLS_CODE = 34,

	/// <summary>거래정지 여부</summary>
	TRHT_YN = 35,

	/// <summary>매도호가 잔량1</summary>
	ASKP_RSQN1 = 36,

	/// <summary>매수호가 잔량1</summary>
	BIDP_RSQN1 = 37,

	/// <summary>총 매도호가 잔량</summary>
	TOTAL_ASKP_RSQN = 38,

	/// <summary>총 매수호가 잔량</summary>
	TOTAL_BIDP_RSQN = 39,

	/// <summary>거래량 회전율</summary>
	VOL_TNRT = 40,

	/// <summary>전일 동시간 누적 거래량</summary>
	PRDY_SMNS_HOUR_ACML_VOL = 41,

	/// <summary>전일 동시간 누적 거래량 비율</summary>
	PRDY_SMNS_HOUR_ACML_VOL_RATE = 42,

	/// <summary>시간 구분 코드</summary>
	HOUR_CLS_CODE = 43,

	/// <summary>임의종료구분코드</summary>
	MRKT_TRTM_CLS_CODE = 44,

	/// <summary>정적VI발동기준가</summary>
	VI_STND_PRC = 45,
}