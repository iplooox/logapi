using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public abstract class Logger : ILogger
{
    protected Logger(LogDestination destination)
    {
        Destination = destination;
    }

    public LogDestination Destination { get; }

    public virtual LogResponse Log()
    {
        return new LogResponse(false, "Use the full implementation of the logger.");
    }
}