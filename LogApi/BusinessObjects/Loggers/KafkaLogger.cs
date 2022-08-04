using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class KafkaLogger : Logger
{
    public KafkaLogger() : base(LogDestination.Kafka)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}