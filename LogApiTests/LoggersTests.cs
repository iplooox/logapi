using FluentAssertions;
using LogApi;
using LogApi.BusinessObjects.Loggers;
using LogApi.Enums;

namespace LogApiTests;

public class LoggersTests
{
    private readonly HashSet<int> _allowedLoggerTypes = new() {1,2,3};

    [Fact]
    public void LoggerSuccessfullyGetCreatedAndLog()
    {
        ILogApiLogger[] loggers = {new KafkaLogApiLogger(), new FlatFileLogApiLogger(), new RabbitMqLogApiLogger()};

        foreach (ILogApiLogger logger in loggers)
        {
            LogResponse logResponse = logger.Log();

            logResponse.Success.Should().BeTrue();
            logResponse.Error.Should().BeNull();
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void FactoryReturnCorrectLogger(int destinationInput)
    {
        LogDestination destination = (LogDestination)destinationInput;

        var createLogger = () => LogApiLoggerFactory.CreateLogger(destination);

        if (!_allowedLoggerTypes.Contains(destinationInput))
        {
            createLogger.Should().Throw<Exception>();
            return;
        }
        
        ILogApiLogger logApiLogger = LogApiLoggerFactory.CreateLogger(destination);

        logApiLogger.Destination.Should().Be(destination);

        switch (destination)
        {
            case LogDestination.Kafka:
                (logApiLogger is KafkaLogApiLogger).Should().BeTrue();
                break;
            case LogDestination.FlatFile:
                (logApiLogger is FlatFileLogApiLogger).Should().BeTrue();
                break;
            case LogDestination.RabbitMQ:
                (logApiLogger is RabbitMqLogApiLogger).Should().BeTrue();
                break;
        }
    }
}