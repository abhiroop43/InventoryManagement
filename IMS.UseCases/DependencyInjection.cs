using System.Reflection;
using DotNetEnv;
using IMS.UseCases.Behaviors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCaseServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        Env.TraversePath().Load();
        services.AddMediatR(config =>
        {
            config.LicenseKey = Env.GetString("MEDIATR_LICENSE_KEY");
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        return services;
    }
}
