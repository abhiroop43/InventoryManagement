using IMS.Core.Exceptions.Handler;

namespace IMS.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        return services;
    }

    public static WebApplication UseWebServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        return app;
    }
}
