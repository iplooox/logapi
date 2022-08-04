using LogApi.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace LogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public LogResponse LogIt(LogEntryDto entry)
    {
        return new LogResponse() {Success = true};
    }
    
    [HttpPost("batch")]
    public LogResponse LogItBatch(LogEntryDto[] entries)
    {
        return new LogResponse() {Success = true};
    }
}

public class LogResponse
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}