using LogApi.BusinessObjects.Loggers;
using LogApi.Enums;
using ILogger = LogApi.BusinessObjects.Loggers.ILogger;

namespace LogApi;

public static class LoggerFactory
{
    public static ILogger CreateLogger(LogDestination destination)
    {
        switch (destination)
        {
            case LogDestination.Kafka:
                return new KafkaLogger();
            case LogDestination.FlatFile:
                return new FlatFileLogger();
            case LogDestination.RabbitMQ:
                return new RabbitMqLogger();
            default:
                throw new ArgumentException($"Cannot create Logger for type {destination}", nameof(destination));
        }
    }
}