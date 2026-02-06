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

        // services
        //     .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        //     .AddMicrosoftIdentityWebApp(msIdentityOptions =>
        //     {
        //         msIdentityOptions.CallbackPath = "/signin-oidc";
        //         msIdentityOptions.Authority =
        //             "https://abhiroopsantragmail.onmicrosoft.com.ciamlogin.com/fd8b1160-6283-419e-b032-bec26d815619/v2.0";
        //         msIdentityOptions.ClientId = "c2ffbd0a-6bda-4f3c-9bbb-da550dc553e9";
        //         msIdentityOptions.ResponseType = "code";
        //     });
        //
        // services.AddAuthorization();

        services
            .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration)
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddInMemoryTokenCaches();

        services.AddCascadingAuthenticationState();

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
