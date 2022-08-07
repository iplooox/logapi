using LogApi.Enums;
using LogApi.RequestDtos;

namespace LogApi.BusinessObjects.Loggers;

public class RabbitMqLogApiLogger : LogApiLogger
{
    public RabbitMqLogApiLogger() : base(LogDestination.RabbitMQ)
    {
    }

    public override LogResponse Log(params LogEntryDto[] logEntryDtos)
    {
        // Here go the implementation for Mq topic.
        return new LogResponse(true);
    }
}