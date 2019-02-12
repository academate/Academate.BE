using Application.Services.AccessControl;
using CrossCuttingServices;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;

namespace hosting
{
    public static class Injector
    {
        public static void Inject(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDbProvider, DbProvider>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();

            serviceCollection.AddScoped<IConfigurationService, ConfigurationService>();
            serviceCollection.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        }
    }
}
