namespace LoggingBestPractices.Benchmarks;

public interface ILoggerAdapter<T>
{
    void LogDebug(string message);

    void LogDebug<T0>(string message, T0 args0);

    void LogDebug<T0, T1>(string message, T0 args0, T1 args1);

    void LogDebug<T0, T1, T2>(string message, T0 args0, T1 args1, T2 args2);
}
