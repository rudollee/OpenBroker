namespace OpenBroker.Models;

public class ResponseMessage
{
    /// <summary>
    /// 상태 코드
    /// </summary>
    public Status StatusCode { get; set; } = Status.SUCCESS;

    /// <summary>
    /// 상세 코드
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

public class ResponseResult<T> : ResponseMessage where T : class
{
    public required T Data { get; set; }
}

public class ResponseResults<T> : ResponseMessage where T : class
{
    public required List<T> List { get; set; }
}