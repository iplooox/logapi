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
        // We can add validation/logging and what ever shared logic we want in here for all the destinations.
        return new LogResponse(false, "Use the full implementation of the logger.");
    }
}