using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class RabbitMqLogApiLogger : LogApiLogger
{
    public RabbitMqLogApiLogger() : base(LogDestination.RabbitMQ)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}