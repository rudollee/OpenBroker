namespace OpenBroker.Models
{
    public class ResponseMessage
    {
        /// <summary>
        /// 상태 코드
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 상태 메시지
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 비고
        /// </summary>
        public string Remark { get; set; } = string.Empty;
    }
}
