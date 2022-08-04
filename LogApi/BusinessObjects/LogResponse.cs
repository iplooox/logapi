namespace LogApi.BusinessObjects.Loggers;

public class LogResponse
{
    public LogResponse(bool success, string error)
    {
        Success = success;
        Error = error;
    }

    public bool Success { get; }
    public string Error { get; }
}