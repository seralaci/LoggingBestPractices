using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

public static partial class LoggerMessageDefinitionsGen
{
    [LoggerMessage(
        EventId = 0, 
        Level = LogLevel.Debug, 
        Message = "This is a log message with parameters {First} and {Second}",
        SkipEnabledCheck = false)]        
    public static partial void LogBenchmarkMessageGen(this ILogger logger, int first, int second);
}

