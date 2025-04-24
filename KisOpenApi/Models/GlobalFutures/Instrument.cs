using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KisOpenApi.Models.GlobalFutures;
/// <summary>
/// 해외선물종목상세 response
/// </summary>
internal class HHDFC55010100 : KisResponseBase
{
	public HHDFC55010100Output Output1 { get; set; } = new();

	/// <summary>
	/// 해외선물종목상세 response output
	/// </summary>
	internal class HHDFC55010100Output
	{
		/// <summary>거래소코드</summary>
		[JsonPropertyName("exch_cd")]
		public string exch_cd { get; set; } = string.Empty;

		/// <summary>틱사이즈</summary>
		[JsonPropertyName("tick_sz")]
		public string tick_sz { get; set; } = string.Empty;

		/// <summary>가격표시진법</summary>
		[JsonPropertyName("disp_digit")]
		public string disp_digit { get; set; } = string.Empty;

		/// <summary>증거금</summary>
		[JsonPropertyName("trst_mgn")]
		public string trst_mgn { get; set; } = string.Empty;

		/// <summary>정산일</summary>
		[JsonPropertyName("sttl_date")]
		public string sttl_date { get; set; } = string.Empty;

		/// <summary>전일종가</summary>
		[JsonPropertyName("prev_price")]
		public string prev_price { get; set; } = string.Empty;

		/// <summary>거래통화</summary>
		[JsonPropertyName("crc_cd")]
		public string crc_cd { get; set; } = string.Empty;

		/// <summary>품목종류</summary>
		[JsonPropertyName("clas_cd")]
		public string clas_cd { get; set; } = string.Empty;

		/// <summary>틱가치</summary>
		[JsonPropertyName("tick_val")]
		public string tick_val { get; set; } = string.Empty;

		/// <summary>장개시일자</summary>
		[JsonPropertyName("mrkt_open_date")]
		public string mrkt_open_date { get; set; } = string.Empty;

		/// <summary>장개시시각</summary>
		[JsonPropertyName("mrkt_open_time")]
		public string mrkt_open_time { get; set; } = string.Empty;

		/// <summary>장마감일자</summary>
		[JsonPropertyName("mrkt_close_date")]
		public string mrkt_close_date { get; set; } = string.Empty;

		/// <summary>장마감시각</summary>
		[JsonPropertyName("mrkt_close_time")]
		public string mrkt_close_time { get; set; } = string.Empty;

		/// <summary>상장일</summary>
		[JsonPropertyName("trd_fr_date")]
		public string trd_fr_date { get; set; } = string.Empty;

		/// <summary>만기일</summary>
		[JsonPropertyName("expr_date")]
		public string expr_date { get; set; } = string.Empty;

		/// <summary>최종거래일</summary>
		[JsonPropertyName("trd_to_date")]
		public string trd_to_date { get; set; } = string.Empty;

		/// <summary>잔존일수</summary>
		[JsonPropertyName("remn_cnt")]
		public string remn_cnt { get; set; } = string.Empty;

		/// <summary>매매여부</summary>
		[JsonPropertyName("stat_tp")]
		public string stat_tp { get; set; } = string.Empty;

		/// <summary>계약크기</summary>
		[JsonPropertyName("ctrt_size")]
		public string ctrt_size { get; set; } = string.Empty;

		/// <summary>최종결제구분</summary>
		[JsonPropertyName("stl_tp")]
		public string stl_tp { get; set; } = string.Empty;

		/// <summary>최초식별일</summary>
		[JsonPropertyName("frst_noti_date")]
		public string frst_noti_date { get; set; } = string.Empty;

		/// <summary></summary>
		[JsonPropertyName("sprd_srs_cd1")]
		public string sprd_srs_cd1 { get; set; } = string.Empty;

		/// <summary></summary>
		[JsonPropertyName("sprd_srs_cd2")]
		public string sprd_srs_cd2 { get; set; } = string.Empty;
	}
}


