using LogApi.Enums;
using LogApi.RequestDtos;

namespace LogApi.BusinessObjects.Loggers;

public abstract class LogApiLogger : ILogApiLogger
{
    protected LogApiLogger(LogDestination destination)
    {
        Destination = destination;
    }

    public LogDestination Destination { get; }

    public virtual LogResponse Log(params LogEntryDto[] logEntryDtos)
    {
        return new LogResponse(false, "Use the full implementation of the logger.");
    }
}