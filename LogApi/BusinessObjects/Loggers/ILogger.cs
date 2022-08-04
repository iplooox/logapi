using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public interface ILogger
{
    LogDestination Destination { get; }
    LogResponse Log();
}