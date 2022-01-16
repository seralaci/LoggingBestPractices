using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

public class FakeLogger : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {        
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return new FakeDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }

    private class FakeDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
