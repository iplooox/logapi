using LogApi.Enums;
using LogApi.RequestDtos;

namespace LogApi.BusinessObjects.Loggers;

public class FlatFileLogApiLogger : LogApiLogger
{
    public FlatFileLogApiLogger() : base(LogDestination.FlatFile)
    {
    }

    public override LogResponse Log(params LogEntryDto[] logEntryDtos)
    {
        // Here go the implementation for Flat file.
        return new LogResponse(true);
    }
}