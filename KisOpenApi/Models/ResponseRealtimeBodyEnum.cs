﻿namespace KisOpenApi.Models;

#region 해외선물옵션 실시간체결가
/// <summary>
/// 해외선물옵션 실시간체결가
/// </summary>
internal enum HDFFF020
{
	/// <summary>종목코드</summary>
	series_cd = 0,

	/// <summary>영업일자</summary>
	bsns_date = 1,

	/// <summary>장개시일자</summary>
	mrkt_open_date = 2,

	/// <summary>장개시시각</summary>
	mrkt_open_time = 3,

	/// <summary>장종료일자</summary>
	mrkt_close_date = 4,

	/// <summary>장종료시각</summary>
	mrkt_close_time = 5,

	/// <summary>전일종가</summary>
	prev_price = 6,

	/// <summary>수신일자</summary>
	recv_date = 7,

	/// <summary>수신시각</summary>
	recv_time = 8,

	/// <summary>본장_전산장구분</summary>
	active_flag = 9,

	/// <summary>체결가격</summary>
	last_price = 10,

	/// <summary>체결수량</summary>
	last_qntt = 11,

	/// <summary>전일대비가</summary>
	prev_diff_price = 12,

	/// <summary>등락률</summary>
	prev_diff_rate = 13,

	/// <summary>시가</summary>
	open_price = 14,

	/// <summary>고가</summary>
	high_price = 15,

	/// <summary>저가</summary>
	low_price = 16,

	/// <summary>누적거래량</summary>
	vol = 17,

	/// <summary>전일대비부호</summary>
	prev_sign = 18,

	/// <summary>체결구분</summary>
	quotsign = 19,

	/// <summary>수신시각2 만분의일초</summary>
	recv_time2 = 20,

	/// <summary>전일정산가</summary>
	psttl_price = 21,

	/// <summary>전일정산가대비</summary>
	psttl_sign = 22,

	/// <summary>전일정산가대비가격</summary>
	psttl_diff_price = 23,

	/// <summary>전일정산가대비율</summary>
	psttl_diff_rate = 24,

}
#endregion

#region 해외선물옵션 실시간호가
/// <summary>
/// 해외선물옵션 실시간호가
/// </summary>
internal enum HDFFF010
{
	/// <summary>종목코드</summary>
	series_cd = 0,

	/// <summary>수신일자</summary>
	recv_date = 1,

	/// <summary>수신시각</summary>
	recv_time = 2,

	/// <summary>전일종가</summary>
	prev_price = 3,

	/// <summary>매수1수량</summary>
	bid_qntt_1 = 4,

	/// <summary>매수1번호</summary>
	bid_num_1 = 5,

	/// <summary>매수1호가</summary>
	bid_price_1 = 6,

	/// <summary>매도1수량</summary>
	ask_qntt_1 = 7,

	/// <summary>매도1번호</summary>
	ask_num_1 = 8,

	/// <summary>매도1호가</summary>
	ask_price_1 = 9,

	/// <summary>매수2수량</summary>
	bid_qntt_2 = 10,

	/// <summary>매수2번호</summary>
	bid_num_2 = 11,

	/// <summary>매수2호가</summary>
	bid_price_2 = 12,

	/// <summary>매도2수량</summary>
	ask_qntt_2 = 13,

	/// <summary>매도2번호</summary>
	ask_num_2 = 14,

	/// <summary>매도2호가</summary>
	ask_price_2 = 15,

	/// <summary>매수3수량</summary>
	bid_qntt_3 = 16,

	/// <summary>매수3번호</summary>
	bid_num_3 = 17,

	/// <summary>매수3호가</summary>
	bid_price_3 = 18,

	/// <summary>매도3수량</summary>
	ask_qntt_3 = 19,

	/// <summary>매도3번호</summary>
	ask_num_3 = 20,

	/// <summary>매도3호가</summary>
	ask_price_3 = 21,

	/// <summary>매수4수량</summary>
	bid_qntt_4 = 22,

	/// <summary>매수4번호</summary>
	bid_num_4 = 23,

	/// <summary>매수4호가</summary>
	bid_price_4 = 24,

	/// <summary>매도4수량</summary>
	ask_qntt_4 = 25,

	/// <summary>매도4번호</summary>
	ask_num_4 = 26,

	/// <summary>매도4호가</summary>
	ask_price_4 = 27,

	/// <summary>매수5수량</summary>
	bid_qntt_5 = 28,

	/// <summary>매수5번호</summary>
	bid_num_5 = 29,

	/// <summary>매수5호가</summary>
	bid_price_5 = 30,

	/// <summary>매도5수량</summary>
	ask_qntt_5 = 31,

	/// <summary>매도5번호</summary>
	ask_num_5 = 32,

	/// <summary>매도5호가</summary>
	ask_price_5 = 33,

	/// <summary>전일정산가</summary>
	sttl_price = 34,
}
#endregion

#region 해외선물옵션 실시간주문내역통보
/// <summary>
/// 해외선물옵션 실시간주문내역통보
/// </summary>
internal enum HDFFF1C0
{
	/// <summary>유저ID</summary>
	user_id = 0,

	/// <summary>계좌번호</summary>
	acct_no = 1,

	/// <summary>주문일자</summary>
	ord_dt = 2,

	/// <summary>주문번호</summary>
	odno = 3,

	/// <summary>원주문일자</summary>
	orgn_ord_dt = 4,

	/// <summary>원주문번호</summary>
	orgn_odno = 5,

	/// <summary>종목명</summary>
	series = 6,

	/// <summary>정정취소구분코드</summary>
	rvse_cncl_dvsn_cd = 7,

	/// <summary>매도매수구분코드: 01.매도, 02.매수</summary>
	sll_buy_dvsn_cd = 8,

	/// <summary>복합주문구분코드</summary>
	cplx_ord_dvsn_cd = 9,

	/// <summary>가격구분코드: 1.Limit, 2.Market, 3.Stop(Stop가격시 시장가)</summary>
	prce_tp = 10,

	/// <summary>FM거래소접수구분코드: 01.접수전, 02.응답, 03.거부</summary>
	fm_excg_rcit_dvsn_cd = 11,

	/// <summary>주문수량</summary>
	ord_qty = 12,

	/// <summary>FMLIMIT가격</summary>
	fm_lmt_pric = 13,

	/// <summary>FMSTOP주문가격</summary>
	fm_stop_ord_pric = 14,

	/// <summary>총체결수량</summary>
	tot_ccld_qty = 15,

	/// <summary>총체결단가</summary>
	tot_ccld_uv = 16,

	/// <summary>잔량</summary>
	ord_remq = 17,

	/// <summary>FM주문그룹일자</summary>
	fm_ord_grp_dt = 18,

	/// <summary>주문그룹번호</summary>
	ord_grp_stno = 19,

	/// <summary>주문상세일시</summary>
	ord_dtl_dtime = 20,

	/// <summary>조작상세일시</summary>
	oprt_dtl_dtime = 21,

	/// <summary>주문자</summary>
	work_empl = 22,

	/// <summary>통화코드</summary>
	crcy_cd = 23,

	/// <summary>청산여부(Y/N)</summary>
	lqd_yn = 24,

	/// <summary>청산LIMIT가격</summary>
	lqd_lmt_pric = 25,

	/// <summary>청산STOP가격</summary>
	lqd_stop_pric = 26,

	/// <summary>체결조건코드</summary>
	trd_cond = 27,

	/// <summary>기간주문유효상세일시</summary>
	term_ord_vald_dtime = 28,

	/// <summary>계좌청산유형구분코드</summary>
	spec_tp = 29,

	/// <summary>행사예약주문여부</summary>
	ecis_rsvn_ord_yn = 30,

	/// <summary>선물옵션종목구분코드</summary>
	fuop_item_dvsn_cd = 31,

	/// <summary>자동주문 전략구분</summary>
	auto_ord_dvsn_cd = 32,
}
#endregion

#region 해외선물옵션 실시간체결내역통보
/// <summary>
/// 해외선물옵션 실시간체결내역통보
/// </summary>
internal enum HDFFF2C0
{
	/// <summary>유저ID</summary>
	user_id = 0,

	/// <summary>계좌번호</summary>
	acct_no = 1,

	/// <summary>주문일자</summary>
	ord_dt = 2,

	/// <summary>주문번호</summary>
	odno = 3,

	/// <summary>원주문일자</summary>
	orgn_ord_dt = 4,

	/// <summary>원주문번호</summary>
	orgn_odno = 5,

	/// <summary>종목명</summary>
	series = 6,

	/// <summary>정정취소구분코드</summary>
	rvse_cncl_dvsn_cd = 7,

	/// <summary>매도매수구분코드</summary>
	sll_buy_dvsn_cd = 8,

	/// <summary>복합주문구분코드</summary>
	cplx_ord_dvsn_cd = 9,

	/// <summary>가격구분코드</summary>
	prce_tp = 10,

	/// <summary>FM거래소접수구분코드</summary>
	fm_excg_rcit_dvsn_cd = 11,

	/// <summary>주문수량</summary>
	ord_qty = 12,

	/// <summary>FMLIMIT가격</summary>
	fm_lmt_pric = 13,

	/// <summary>FMSTOP주문가격</summary>
	fm_stop_ord_pric = 14,

	/// <summary>총체결수량</summary>
	tot_ccld_qty = 15,

	/// <summary>총체결단가</summary>
	tot_ccld_uv = 16,

	/// <summary>잔량</summary>
	ord_remq = 17,

	/// <summary>FM주문그룹일자</summary>
	fm_ord_grp_dt = 18,

	/// <summary>주문그룹번호</summary>
	ord_grp_stno = 19,

	/// <summary>주문상세일시</summary>
	ord_dtl_dtime = 20,

	/// <summary>조작상세일시</summary>
	oprt_dtl_dtime = 21,

	/// <summary>주문자</summary>
	work_empl = 22,

	/// <summary>체결일자</summary>
	ccld_dt = 23,

	/// <summary>체결번호</summary>
	ccno = 24,

	/// <summary>API 체결번호</summary>
	api_ccno = 25,

	/// <summary>체결수량</summary>
	ccld_qty = 26,

	/// <summary>FM체결가격</summary>
	fm_ccld_pric = 27,

	/// <summary>통화코드</summary>
	crcy_cd = 28,

	/// <summary>위탁수수료</summary>
	trst_fee = 29,

	/// <summary>주문매체온라인여부</summary>
	ord_mdia_online_yn = 30,

	/// <summary>FM체결금액</summary>
	fm_ccld_amt = 31,

	/// <summary>선물옵션종목구분코드</summary>
	fuop_item_dvsn_cd = 32,
}
#endregion

#region 국내주식 실시간 호가
/// <summary>
/// 국내주식 실시간 호가
/// </summary>
internal enum H0STASP0
{
	/// <summary>유가증권 단축 종목코드</summary>
	MKSC_SHRN_ISCD = 0,

	/// <summary>영업 시간</summary>
	BSOP_HOUR = 1,

	/// <summary>시간 구분 코드</summary>
	HOUR_CLS_CODE = 2,

	/// <summary>매도호가1</summary>
	ASKP1 = 3,

	/// <summary>매도호가2</summary>
	ASKP2 = 4,

	/// <summary>매도호가3</summary>
	ASKP3 = 5,

	/// <summary>매도호가4</summary>
	ASKP4 = 6,

	/// <summary>매도호가5</summary>
	ASKP5 = 7,

	/// <summary>매도호가6</summary>
	ASKP6 = 8,

	/// <summary>매도호가7</summary>
	ASKP7 = 9,

	/// <summary>매도호가8</summary>
	ASKP8 = 10,

	/// <summary>매도호가9</summary>
	ASKP9 = 11,

	/// <summary>매도호가10</summary>
	ASKP10 = 12,

	/// <summary>매수호가1</summary>
	BIDP1 = 13,

	/// <summary>매수호가2</summary>
	BIDP2 = 14,

	/// <summary>매수호가3</summary>
	BIDP3 = 15,

	/// <summary>매수호가4</summary>
	BIDP4 = 16,

	/// <summary>매수호가5</summary>
	BIDP5 = 17,

	/// <summary>매수호가6</summary>
	BIDP6 = 18,

	/// <summary>매수호가7</summary>
	BIDP7 = 19,

	/// <summary>매수호가8</summary>
	BIDP8 = 20,

	/// <summary>매수호가9</summary>
	BIDP9 = 21,

	/// <summary>매수호가10</summary>
	BIDP10 = 22,

	/// <summary>매도호가 잔량1</summary>
	ASKP_RSQN1 = 23,

	/// <summary>매도호가 잔량2</summary>
	ASKP_RSQN2 = 24,

	/// <summary>매도호가 잔량3</summary>
	ASKP_RSQN3 = 25,

	/// <summary>매도호가 잔량4</summary>
	ASKP_RSQN4 = 26,

	/// <summary>매도호가 잔량5</summary>
	ASKP_RSQN5 = 27,

	/// <summary>매도호가 잔량6</summary>
	ASKP_RSQN6 = 28,

	/// <summary>매도호가 잔량7</summary>
	ASKP_RSQN7 = 29,

	/// <summary>매도호가 잔량8</summary>
	ASKP_RSQN8 = 30,

	/// <summary>매도호가 잔량9</summary>
	ASKP_RSQN9 = 31,

	/// <summary>매도호가 잔량10</summary>
	ASKP_RSQN10 = 32,

	/// <summary>매수호가 잔량1</summary>
	BIDP_RSQN1 = 33,

	/// <summary>매수호가 잔량2</summary>
	BIDP_RSQN2 = 34,

	/// <summary>매수호가 잔량3</summary>
	BIDP_RSQN3 = 35,

	/// <summary>매수호가 잔량4</summary>
	BIDP_RSQN4 = 36,

	/// <summary>매수호가 잔량5</summary>
	BIDP_RSQN5 = 37,

	/// <summary>매수호가 잔량6</summary>
	BIDP_RSQN6 = 38,

	/// <summary>매수호가 잔량7</summary>
	BIDP_RSQN7 = 39,

	/// <summary>매수호가 잔량8</summary>
	BIDP_RSQN8 = 40,

	/// <summary>매수호가 잔량9</summary>
	BIDP_RSQN9 = 41,

	/// <summary>매수호가 잔량10</summary>
	BIDP_RSQN10 = 42,

	/// <summary>총 매도호가 잔량</summary>
	TOTAL_ASKP_RSQN = 43,

	/// <summary>총 매수호가 잔량</summary>
	TOTAL_BIDP_RSQN = 44,

	/// <summary>시간외 총 매도호가 잔량</summary>
	OVTM_TOTAL_ASKP_RSQN = 45,

	/// <summary>시간외 총 매수호가 잔량</summary>
	OVTM_TOTAL_BIDP_RSQN = 46,

	/// <summary>예상 체결가</summary>
	ANTC_CNPR = 47,

	/// <summary>예상 체결량</summary>
	ANTC_CNQN = 48,

	/// <summary>예상 거래량</summary>
	ANTC_VOL = 49,

	/// <summary>예상 체결 대비</summary>
	ANTC_CNTG_VRSS = 50,

	/// <summary>예상 체결 대비 부호</summary>
	ANTC_CNTG_VRSS_SIGN = 51,

	/// <summary>예상 체결 전일 대비율</summary>
	ANTC_CNTG_PRDY_CTRT = 52,

	/// <summary>누적 거래량</summary>
	ACML_VOL = 53,

	/// <summary>총 매도호가 잔량 증감</summary>
	TOTAL_ASKP_RSQN_ICDC = 54,

	/// <summary>총 매수호가 잔량 증감</summary>
	TOTAL_BIDP_RSQN_ICDC = 55,

	/// <summary>시간외 총 매도호가 증감</summary>
	OVTM_TOTAL_ASKP_ICDC = 56,

	/// <summary>시간외 총 매수호가 증감</summary>
	OVTM_TOTAL_BIDP_ICDC = 57,

	/// <summary>주식 매매 구분 코드</summary>
	STCK_DEAL_CLS_CODE = 58,
}
#endregion
