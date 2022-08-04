using LogApi.Enums;

namespace LogApi.BusinessObjects.Loggers;

public class RabbitMqLogger : Logger
{
    public RabbitMqLogger() : base(LogDestination.RabbitMQ)
    {
    }

    public override LogResponse Log()
    {
        return new LogResponse(true);
    }
}