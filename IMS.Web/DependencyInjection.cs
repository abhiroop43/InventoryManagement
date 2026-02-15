using IMS.Core.Exceptions.Handler;
using IMS.Web.Clients;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

namespace IMS.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddScoped<InventoriesClient>();

        services
            .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration)
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddInMemoryTokenCaches();

        services.AddCascadingAuthenticationState();
        services.AddHttpContextAccessor();
        return services;
    }

    public static WebApplication UseWebServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
