using LogApi.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace LogApi.BusinessObjects.Configuration;

public interface ILogConfigurationProvider
{
    LogDestination GetLoggerDestination();
}

public class LogConfigurationProvider : ILogConfigurationProvider
{
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;

    public LogConfigurationProvider(IConfiguration configuration, IMemoryCache cache)
    {
        _configuration = configuration;
        _cache = cache;
    }

    public LogDestination GetLoggerDestination()
    {
        // Given that this operation will happen on every request, it only make sense to save the config value for at least 60 sec.
        if (_cache.TryGetValue(LogCacheKeys.LogDestination, out LogDestination destination))
        {
            return destination;
        }

        LogDestination logDestinationFromConfig = GetLogDestinationFromConfig();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

        _cache.Set(LogCacheKeys.LogDestination, logDestinationFromConfig, cacheEntryOptions);

        return logDestinationFromConfig;
    }

    private LogDestination GetLogDestinationFromConfig()
    {
        // Check that the value is set and is int in appsettings.json
        if (!int.TryParse(_configuration["LogDestination"], out int destinationFromConfig))
        {
            return LogDestination.None;
        }

        // Check that the value is in the enum.
        if (!Enum.IsDefined(typeof(LogDestination), destinationFromConfig))
        {
            return LogDestination.None;
        }

        return (LogDestination) destinationFromConfig;
    }
}