using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
});

ILogger logger = new Logger<Program>(loggerFactory);

for (var i = 0; i < 69_000_000; i++)
{
    //if (logger.IsEnabled(LogLevel.Debug))
    //{
        logger.LogDebug("Random Number {RandomNumber}", Random.Shared.Next());
        
        // The following  line (string interpolation) generates even more garbage collections
        //logger.LogDebug($"Random Number {Random.Shared.Next()}");    
    //}
}