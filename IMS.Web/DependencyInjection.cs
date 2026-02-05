using IMS.Core.Exceptions.Handler;
using IMS.Web.Clients;

namespace IMS.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddScoped<InventoriesClient>();
        return services;
    }

    public static WebApplication UseWebServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        return app;
    }
}