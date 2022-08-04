using LogApi.Enums;
using LogApi.RequestDtos;

namespace LogApi.BusinessObjects.Loggers;

public interface ILogApiLogger
{
    LogDestination Destination { get; }
    LogResponse Log(params LogEntryDto[] logEntryDtos);
}