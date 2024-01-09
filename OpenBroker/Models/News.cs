namespace OpenBroker.Models;

public class News
{
    public string Code { get; set; } = string.Empty;
    public DateTime TimePosted { get; set; }
    public string Media { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
