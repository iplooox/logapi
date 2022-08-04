using System.ComponentModel.DataAnnotations;
using LogApi.Enums;

namespace LogApi.RequestDtos;

public class LogEntryDto
{
    [Required]
    public Guid ApplicationId { get; set; }

    [Required]
    public Guid TraceId { get; set; }
    
    public Guid? RequestId { get; set; }
    
    [Required]
    [Range(0,4)]
    public LogSeverity Severity { get; set; }
    
    [Required]
    public DateTime TimeStamp { get; set; }
    
    [Required]
    public string? Message { get; set; }

    public string? ComponentName { get; set; }
}