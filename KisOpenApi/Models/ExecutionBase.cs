using System.Text.Json.Serialization;

namespace KisOpenApi.Models;
public class ExecutionBaseRequest
{
	public string AccountNumber { get; set; } = string.Empty;
}

internal class ExecutionHistoryOutputBaseResponse
{
	/// <summary>종합계좌번호</summary>
	[JsonPropertyName("cano")]
	public string BankAccountNumber { get; set; } = string.Empty;

	/// <summary>계좌상품코드</summary>
	[JsonPropertyName("acnt_prdt_cd")]
	public string BankAccountNumberSuffix { get; set; } = string.Empty;
}

internal class OrderHistoryOutputBaseResponse : ExecutionHistoryOutputBaseResponse
{
	/// <summary>주문일자</summary>
	[JsonPropertyName("ord_dt")]
	public string ord_dt { get; set; } = string.Empty;

	/// <summary>주문번호</summary>
	[JsonPropertyName("odno")]
	public int OID { get; set; }

	/// <summary>원주문일자</summary>
	[JsonPropertyName("orgn_ord_dt")]
	public string OrderDateOrigined8 { get; set; } = string.Empty;

	/// <summary>원주문번호</summary>
	[JsonPropertyName("orgn_odno")]
	public string OrderNumberOrigin { get; set; } = string.Empty;

	/// <summary>해외선물FX상품번호</summary>
	[JsonPropertyName("ovrs_futr_fx_pdno")]
	public string Symbol { get; set; } = string.Empty;

	/// <summary>FM주문수량</summary>
	[JsonPropertyName("fm_ord_qty")]
	public int VolumeOrdered { get; set; }

	/// <summary>FM주문가격</summary>
	[JsonPropertyName("fm_ord_pric")]
	public decimal PriceOrdered { get; set; }

	/// <summary>FMSTOP주문가격</summary>
	[JsonPropertyName("fm_stop_ord_pric")]
	public decimal PriceStopOrdered { get; set; }

	/// <summary>FM체결수량</summary>
	[JsonPropertyName("fm_ccld_qty")]
	public int VolumeContracted { get; set; }

	/// <summary>FM체결가격</summary>
	[JsonPropertyName("fm_ccld_pric")]
	public decimal PriceContracted { get; set; }

	/// <summary>FM주문잔여수량</summary>
	[JsonPropertyName("fm_ord_rmn_qty")]
	public int VolumeLeft { get; set; }

	/// <summary>주문그룹명</summary>
	[JsonPropertyName("ord_grp_name")]
	public string GroupName { get; set; } = string.Empty;

	/// <summary>체결상세일시</summary>
	[JsonPropertyName("ccld_dtl_dtime")]
	public string ContractDateTime863 { get; set; } = string.Empty;


}