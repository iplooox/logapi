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
        // Here go the implementation for Kafka topic.
        return new LogResponse(true);
    }
}