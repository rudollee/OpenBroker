namespace OpenBroker.Models;
public class ResponseCore
{
	/// <summary>
	/// Response Time
	/// </summary>
	public DateTime Time { get; set; } = DateTime.UtcNow;

	/// <summary>
	/// Message Type
	/// </summary>
	public MessageType Typ { get; set; } = MessageType.SYS;

    /// <summary>
    /// 상태 코드
    /// </summary>
    public Status StatusCode { get; set; } = Status.SUCCESS;

	/// <summary>
	/// 중요도
	/// </summary>
	public MessageSeverity Severity { get; set; } = MessageSeverity.Medium;

	/// <summary>
	/// 상세 코드
	/// </summary>
	public string Code { get; set; } = string.Empty;

	/// <summary>
	/// 상태 메시지
	/// </summary>
	public string Message { get; set; } = string.Empty;

	/// <summary>
	/// 추가 데이터
	/// </summary>
	public Dictionary<string, decimal> ExtraData { get; set; } = [];

	/// <summary>
	/// 비고
	/// </summary>
	public string Remark { get; set; } = string.Empty;

	/// <summary>
	/// 증권사/Broker
	/// </summary>
	public Brkr Broker { get; set; } = Brkr.NONE;
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
	public IEnumerable<T> List { get; set; } = [];

	public int Total { get; set; } = 0;

	public int PageSize { get; set; } = 10;

	public int Page { get; set; } = 1;

	public IEnumerable<string>? RefData { get; set; }
}

public class ResponseDictionary<TKey, TValue> : ResponseCore where TKey : notnull
{
	public Dictionary<TKey, TValue> Dic { get; set; } = [];
}
