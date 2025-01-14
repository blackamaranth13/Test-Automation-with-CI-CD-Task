using JSONPlaceholder.TestFramework.Core.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace JSONPlaceholder.TestFramework.Core.Utilities;

public class Logger<T>
{
    private ILogger<T> logger;

    public Logger()
    {
        var serilog = new LoggerConfiguration().
            ReadFrom.Configuration(ConfigurationManager.Config).
            CreateLogger();

        using var loggerFactory = LoggerFactory.
        Create(l => l.AddSerilog(serilog));

        this.logger = loggerFactory.CreateLogger<T>();
    }

    public void Info(string message)
    {
        logger.LogInformation(message);
    }

    public void Error(string message)
    {
        logger.LogError(message);
    }

    public void Debug(string message)
    {
        logger.LogDebug(message);
    }
}
