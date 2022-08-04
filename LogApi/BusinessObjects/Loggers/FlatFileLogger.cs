using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class FlatFileLogger : Logger
{
    public FlatFileLogger() : base(LogDestination.FlatFile)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}