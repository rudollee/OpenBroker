namespace LsOpenApi.Models;
/// <summary>
/// 선물주문정정취소
/// </summary>
internal class H01
{
	public H01InBlock H01InBlock { get; set; } = new();
	public H01OutBlock H01OutBlock { get; set; } = new();
}

/// <summary>
/// 선물주문정정취소 - InBlock
/// </summary>
internal class H01InBlock { }

/// <summary>
/// 선물주문정정취소 - OutBlock
/// </summary>
internal class H01OutBlock
{
	/// <summary>라인일련번호</summary>
	public string lineseq { get; set; } = string.Empty;

	/// <summary>계좌번호</summary>
	public string accno { get; set; } = string.Empty;

	/// <summary>조작자ID</summary>
	public string user { get; set; } = string.Empty;

	/// <summary>일련번호</summary>
	public string seq { get; set; } = string.Empty;

	/// <summary>trcode</summary>
	public string trcode { get; set; } = string.Empty;

	/// <summary>매칭그룹번호</summary>
	public string megrpno { get; set; } = string.Empty;

	/// <summary>보드ID</summary>
	public string boardid { get; set; } = string.Empty;

	/// <summary>회원번호</summary>
	public string memberno { get; set; } = string.Empty;

	/// <summary>지점번호</summary>
	public string bpno { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	public string ordno { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	public string ordordno { get; set; } = string.Empty;

	/// <summary>종목코드</summary>
	public string expcode { get; set; } = string.Empty;

	/// <summary>매도수구분</summary>
	public string dosugb { get; set; } = string.Empty;

	/// <summary>정정취소구분</summary>
	public string mocagb { get; set; } = string.Empty;

	/// <summary>계좌번호1</summary>
	public string accno1 { get; set; } = string.Empty;

	/// <summary>호가수량</summary>
	public string qty2 { get; set; } = string.Empty;

	/// <summary>호가가격</summary>
	public string price { get; set; } = string.Empty;

	/// <summary>주문유형</summary>
	public string ordgb { get; set; } = string.Empty;

	/// <summary>호가구분</summary>
	public string hogagb { get; set; } = string.Empty;

	/// <summary>시장조성호가구분</summary>
	public string sihogagb { get; set; } = string.Empty;

	/// <summary>자사주신고서ID</summary>
	public string treaid { get; set; } = string.Empty;

	/// <summary>자사주매매방법</summary>
	public string treacode { get; set; } = string.Empty;

	/// <summary>매도유형코드</summary>
	public string askcode { get; set; } = string.Empty;

	/// <summary>신용구분코드</summary>
	public string creditcode { get; set; } = string.Empty;

	/// <summary>위탁자기구분</summary>
	public string jakigb { get; set; } = string.Empty;

	/// <summary>위탁사번호</summary>
	public string trustnum { get; set; } = string.Empty;

	/// <summary>프로그램구분</summary>
	public string ptgb { get; set; } = string.Empty;

	/// <summary>대용주권계좌번호</summary>
	public string substocnum { get; set; } = string.Empty;

	/// <summary>계좌구분코드</summary>
	public string accgb { get; set; } = string.Empty;

	/// <summary>계좌증거금코드</summary>
	public string accmarggb { get; set; } = string.Empty;

	/// <summary>국가코드</summary>
	public string nationcode { get; set; } = string.Empty;

	/// <summary>투자자구분</summary>
	public string investgb { get; set; } = string.Empty;

	/// <summary>외국인코드</summary>
	public string forecode { get; set; } = string.Empty;

	/// <summary>주문매체구분</summary>
	public string medcode { get; set; } = string.Empty;

	/// <summary>주문식별자번호</summary>
	public string ordid { get; set; } = string.Empty;

	/// <summary>MAC주소</summary>
	public string macid { get; set; } = string.Empty;

	/// <summary>호가일자</summary>
	public string orddate { get; set; } = string.Empty;

	/// <summary>회원사주문시각</summary>
	public string rcvtime { get; set; } = string.Empty;

	/// <summary>mem_filler</summary>
	public string mem_filler { get; set; } = string.Empty;

	/// <summary>mem_accno</summary>
	public string mem_accno { get; set; } = string.Empty;

	/// <summary>mem_filler1</summary>
	public string mem_filler1 { get; set; } = string.Empty;

	/// <summary>매칭접수시간</summary>
	public string ordacpttm { get; set; } = string.Empty;

	/// <summary>실정정취소수량</summary>
	public string qty { get; set; } = string.Empty;

	/// <summary>자동취소구분</summary>
	public string autogb { get; set; } = string.Empty;

	/// <summary>거부사유</summary>
	public string rejcode { get; set; } = string.Empty;

	/// <summary>프로그램호가신고</summary>
	public string prgordde { get; set; } = string.Empty;
}