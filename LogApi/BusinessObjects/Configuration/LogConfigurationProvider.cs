using LogApi.Enums;

namespace LogApi.BusinessObjects.Configuration;

public interface ILogConfigurationProvider
{
    LogDestination GetLoggerDestination();
}

public class LogLogConfigurationProvider : ILogConfigurationProvider
{
    private readonly IConfiguration _configuration;

    public LogLogConfigurationProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public LogDestination GetLoggerDestination()
    {
        if (!int.TryParse(_configuration["LogDestination"], out int destination))
        {
            return LogDestination.None;
        }

        return (LogDestination) destination;
    }
}