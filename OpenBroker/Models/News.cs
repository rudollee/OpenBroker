﻿namespace OpenBroker.Models;

public class News
{
    public required string Code { get; set; }
    public DateTime TimePosted { get; set; }
    public string Media { get; set; } = string.Empty;
    public required string Title { get; set; }
    public string Body { get; set; } = string.Empty;
    public string Remark { get; set; } = string.Empty;
    public string[] SymbolList { get; set; }
}
