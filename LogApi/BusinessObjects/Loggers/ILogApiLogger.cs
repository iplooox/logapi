using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public interface ILogApiLogger
{
    LogDestination Destination { get; }
    LogResponse Log();
}