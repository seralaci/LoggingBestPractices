using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class BenchMarkie
{
    private const string LogMessage = "This is a log message";
    private const string LogMessageWithParameters = "This is a log message with parameters {First} and {Second}";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Information);
        //builder.AddFakeLogger().SetMinimumLevel(LogLevel.Debug);
    });

    private readonly ILogger<BenchMarkie> _logger;
    private readonly ILoggerAdapter<BenchMarkie> _loggerAdapter;

    public BenchMarkie()
    {
        _logger = new Logger<BenchMarkie>(_loggerFactory);
        _loggerAdapter = new LoggerAdapter<BenchMarkie>(_logger);
    }

    [Benchmark]
    public void Log_WithoutIf()
    {
        _logger.LogDebug(LogMessage);
    }

    [Benchmark]
    public void Log_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(LogMessage);
        }

    }

    [Benchmark]
    public void Log_WithoutIf_WithParameters()
    {
        _logger.LogDebug(LogMessageWithParameters, 69, 420);
    }

    [Benchmark]
    public void Log_WithIf_WithParameters()
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug(LogMessageWithParameters, 69, 420);
        }
    }

    [Benchmark]
    public void Log_StringInterpolation()
    {
        _logger.LogDebug($"This is interpolation {0}", 69);
    }

    [Benchmark]
    public void LogAdapter_WithIf_WithParameters()
    {
        _loggerAdapter.LogDebug(LogMessageWithParameters, 69, 420);
    }

    [Benchmark]
    public void LoggerMessageDefinition_WithIf_WithParameters()
    {
        _logger.LogBenchmarkMessage(69, 420);
    }

    [Benchmark]
    public void LoggerMessageDefinitionGen_WithIf_WithParameters()
    {
        _logger.LogBenchmarkMessageGen(69, 420);
    }
}

