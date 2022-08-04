using LogApi.Enums;
using LogApi.RequestDtos;

namespace LogApi.BusinessObjects.Loggers;

public class KafkaLogApiLogger : LogApiLogger
{
    public KafkaLogApiLogger() : base(LogDestination.Kafka)
    {
    }

    public override LogResponse Log(params LogEntryDto[] logEntryDtos)
    {
        return new LogResponse(true);
    }
}