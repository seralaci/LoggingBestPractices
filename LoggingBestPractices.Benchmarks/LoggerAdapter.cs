using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

public class LoggerAdapter<T> : ILoggerAdapter<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogDebug(string message)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message);
        }
    }

    public void LogDebug<T0>(string message, T0 args0)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, args0);
        }
    }

    public void LogDebug<T0, T1>(string message, T0 args0, T1 args1)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, args0, args1);
        }
    }

    public void LogDebug<T0, T1, T2>(string message, T0 args0, T1 args1, T2 args2)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(message, args0, args1, args2);
        }
    }
}
