using Microsoft.AspNetCore.Mvc;

namespace LogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public LogController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public LogResponse LogIt()
    {
        return new LogResponse() {Success = true};
    }
}

public class LogResponse
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}