namespace SRS.Infrastructure.Bus;

public static class Extensions
{
    public static IServiceCollection AddBusExtensions(this IServiceCollection services, Action<IServiceCollection>? action = null)
    {

        services.AddDaprClient();
        services.AddControllers().AddDapr();
        
        
        action?.Invoke(services);
        return services;
    }

    public static IApplicationBuilder UseBusExtensions(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseCloudEvents();
        app.MapControllers();
        app.MapSubscribeHandler();
        
        
        return app;
    }
    
}