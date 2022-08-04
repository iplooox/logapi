using FluentAssertions;
using LogApi.BusinessObjects.Loggers;

namespace LogApiTests;

public class LoggersTests
{
    [Fact]
    public void LoggerSuccessfullyGetCreatedAndLog()
    {
        ILogger[] loggers = {new KafkaLogger(), new FlatFileLogger(), new RabbitMqLogger()};

        foreach (ILogger logger in loggers)
        {
            LogResponse logResponse = logger.Log();

            logResponse.Success.Should().BeTrue();
            logResponse.Error.Should().BeNull();
        }
    }
}