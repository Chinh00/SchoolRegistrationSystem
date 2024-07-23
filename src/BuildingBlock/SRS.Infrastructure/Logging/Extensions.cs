using Serilog;

namespace SRS.Infrastructure.Logging;

public static class Extensions
{
    public static IServiceCollection AddLoggerCustom(this IServiceCollection services, IConfiguration configuration, Action<IServiceCollection>? action = null)
    {

        var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Logger = logger;
        services.AddSerilog();
        action?.Invoke(services);
        return services;
    }
}