## Log api thinking process

I wanted to have a straight forward way of implementing as many logging destinations as needed.
Without having to iterate a code that was already tested to apply some open close principles.
While this could be achieved with extensions, I also did not want any logic in the controller/service it self.

## The base

So in order to archive this i decided to have abstract base class called LogApiLogger it contains:

- Destination property
- Log method that is virtual and accept params LogEntryDto[] (This take cares of the single and batching at once.)

## Destinations

Now that i had a base i went ahead and created the 3 extra classes that we wanted to use for processing logs to:

- KafkaLogApiLogger
- RabbitMqLogApiLogger
- FlatFileLogApiLogger

When this was done, i went straigt ahead and wrote tests for all 3 of the loggers to make sure that they function as expected.
And were ready for TDD once the time came.

## Factory

With the handling of destinations out of the way i also wanted to have an easy way of creating those 3 loggers without having to write logic in a place that didn't really fit like controller so i went ahead and created a

- LogApiLoggerFactory
  to take care of that while ofcourse already having unit tests for it with TDD.

## Configuration

Now that we were almost ready to use loggers, i needed a place to control how the destination is being changed. For this i created

- LogConfigurationProvider
  It serve one purpose and that is to retrieve LogDestination from appsettings.json cache it for 60 seconds and do it over and over again.
  The reason for going this route instead of just putting it into factory is that:
- It make it much easier to unit tests
- It keeps a nice seperation in classes with single responsibility for them.

## Glueing it all together

Finally we are ready to use all of this in the controller, for this i decided to use DI (dependency injection)
So here is a list of things i had registered in order:

- MemoryCache (For caching LogDestination from appsettings.json)
- LogConfigurationProvider (For retrieving LogDestination from appsettings.json)
- ILogApiLogger (Here we first retrieve the destination and use the factory to create logger)

Lastly we can go ahead inject ILogApiLogger into controller and use it like this:

```csharp
[HttpPost()]
public class LogController : ControllerBase
{
    private readonly ILogApiLogger _logger;
    public LogController(ILogApiLogger logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public LogResponseDto LogIt(LogEntryDto entry)
    {
        LogResponse response = _logger.Log(entry);
        return new LogResponseDto() {Success = response.Success, Error = response.Error};
    }

    [HttpPost("batch")]
    public LogResponseDto LogItBatch(LogEntryDto[] entries)
    {
        LogResponse response = _logger.Log(entries);
        return new LogResponseDto() {Success = response.Success, Error = response.Error};
    }
}
```

## Performance

I used JMeter for load testing as it usually gives me a quit good overview of the entire application performance with all the middlewares etc.
And i really wanted to see how good/bad is performing the dependency injection for ILogApiLogger given that it has to retrieve configuration & create logger on every request. So here are the numbers:

| Label        | #Samples | Average ms | Min ms | Max ms | Error % |
| ------------ | -------- | ---------- | ------ | ------ | ------- |
| 10 Users     | 10       | 3          | 0      | 32     | 0       |
| 100 Users    | 100      | 0          | 0      | 17     | 0       |
| 1000 Users   | 1000     | 0          | 0      | 25     | 0       |
| 100000 Users | 100000   | 0          | 0      | 22     | 0       |

Luckly the results are overall pretty damn good. From average times we are mostly running on 0 ms (It vary depending if you use 1 user with X iterations or X threads with 1 iteration, but i found Jmeter struggling more with creating threads then the site responding back, with 1000 threads ddosing the site the average was around 150-200 ms). The Error % of the requests is 0 %. The one funny result was that the first test for 10 users have the highest max MS and Average ms, but i'm quite sure that is because of the cache population we got this extra 15 ms.

## Final words

If i had more time to work on this problem i would start implementing each logger with it's own Log method and probably convert the requests to be async.
