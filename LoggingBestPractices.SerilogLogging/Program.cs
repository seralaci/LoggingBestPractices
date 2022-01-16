using Serilog;

var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

for (var i = 0; i < 69_000_000; i++)
{ 
    logger.Debug("Random Number {RandomNumber}", Random.Shared.Next());
}
