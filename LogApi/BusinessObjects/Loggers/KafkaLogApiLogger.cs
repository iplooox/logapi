using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class KafkaLogApiLogger : LogApiLogger
{
    public KafkaLogApiLogger() : base(LogDestination.Kafka)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}