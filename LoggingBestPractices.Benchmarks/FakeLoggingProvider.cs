using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace LoggingBestPractices.Benchmarks;

public class FakeLoggingProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new FakeLogger();
    }

    public void Dispose()
    {        
    }
}

public static class FakeLoggerExtensions
{
    public static ILoggingBuilder AddFakeLogger(this ILoggingBuilder builder)
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, FakeLoggingProvider>());
        LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerOptions, FakeLoggingProvider>(builder.Services);

        return builder;
    }
}
