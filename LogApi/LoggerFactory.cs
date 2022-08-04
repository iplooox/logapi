using LogApi.BusinessObjects.Loggers;
using LogApi.Enums;
using ILogger = LogApi.BusinessObjects.Loggers.ILogger;

namespace LogApi;

public static class LoggerFactory
{
    public static ILogger CreateLogger(LogDestination destination)
    {
        return new KafkaLogger();
        // switch (destination)
        // {
        //     case LogDestination.Kafka:
        //         return new KafkaLogger();
        //         break;
        // }
    }
}