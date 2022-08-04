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
        ILogger[] loggers = {new KafkaLogger(), new FlatFileLogger(), new RabbitMqLogger()};

        foreach (ILogger logger in loggers)
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

        var createLogger = () => LoggerFactory.CreateLogger(destination);

        if (!_allowedLoggerTypes.Contains(destinationInput))
        {
            createLogger.Should().Throw<Exception>();
            return;
        }
        
        ILogger logger = LoggerFactory.CreateLogger(destination);

        logger.Destination.Should().Be(destination);

        switch (destination)
        {
            case LogDestination.Kafka:
                (logger is KafkaLogger).Should().BeTrue();
                break;
            case LogDestination.FlatFile:
                (logger is FlatFileLogger).Should().BeTrue();
                break;
            case LogDestination.RabbitMQ:
                (logger is RabbitMqLogger).Should().BeTrue();
                break;
        }
    }
}