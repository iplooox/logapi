using LogApi.Enums;

namespace LogApi.BusinessObjects;

public class LogEntry
{
    public Guid ApplicationId { get; set; }
    public Guid TraceId { get; set; }
    public Guid RequestId { get; set; }
    public LogSeverity Severity { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Message { get; set; }
    public string? ComponentName { get; set; }
}