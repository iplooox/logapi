using LogApi.BusinessObjects.Configuration;
using LogApi.BusinessObjects.Loggers;
using LogApi.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace LogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogApiLogger _logger;
    public LogController(ILogApiLogger logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public LogResponseDto LogIt(LogEntryDto entry)
    {
        LogResponse response = _logger.Log(entry);
        return new LogResponseDto() {Success = response.Success, Error = response.Error};
    }

    [HttpPost("batch")]
    public LogResponseDto LogItBatch(LogEntryDto[] entries)
    {
        LogResponse response = _logger.Log(entries);
        return new LogResponseDto() {Success = response.Success, Error = response.Error};
    }
}

public class LogResponseDto
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}