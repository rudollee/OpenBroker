using System.Collections;

namespace OpenBroker.Models;

public class ResponseCore
{
    /// <summary>
    /// Message Type
    /// </summary>
    public MessageType Typ { get; set; } = MessageType.SYS;

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

public class ResponseResult<T> : ResponseCore where T : class
{
    public T? Info { get; set; }
}

public class ResponseResults<T> : ResponseCore where T : class
{
    public required IEnumerable<T> List { get; set; }
}

public class ResponseResultsWithPaging<T> : ResponseCore where T : class
{
	public IEnumerable<T> List { get; set; } = new List<T>();

	public int Total { get; set; } = 0;

	public int PageSize { get; set; } = 10;

	public int Page { get; set; } = 1;

	public IEnumerable<string>? RefData { get; set; }
}

public class ResponseDictionary<TKey, TValue> : ResponseCore where TKey : notnull
{
    public Dictionary<TKey, TValue> Dic { get; set; } = new(); 
}
