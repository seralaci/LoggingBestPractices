using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

public static class LoggerMessageDefinitions
{
    private static readonly Action<ILogger, int, int, Exception?> BenchmarkLogMessageDefinition =
        LoggerMessage.Define<int, int>(
            LogLevel.Debug,
            0,
            "This is a log message with parameters {First} and {Second}",
            new LogDefineOptions
            {
                SkipEnabledCheck = false
            });

    public static void LogBenchmarkMessage(this ILogger logger, int first, int second)
    {
        BenchmarkLogMessageDefinition(logger, first, second, null);
    }
}
