using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class FlatFileLogApiLogger : LogApiLogger
{
    public FlatFileLogApiLogger() : base(LogDestination.FlatFile)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}