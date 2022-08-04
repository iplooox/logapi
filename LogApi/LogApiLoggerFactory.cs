using LogApi.BusinessObjects.Loggers;
using LogApi.Enums;

namespace LogApi;

public static class LogApiLoggerFactory
{
    public static ILogApiLogger CreateLogger(LogDestination destination)
    {
        switch (destination)
        {
            case LogDestination.Kafka:
                return new KafkaLogApiLogger();
            case LogDestination.FlatFile:
                return new FlatFileLogApiLogger();
            case LogDestination.RabbitMQ:
                return new RabbitMqLogApiLogger();
            default:
                throw new ArgumentException($"Cannot create Logger for type {destination}", nameof(destination));
        }
    }
}