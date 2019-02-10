using Application.Services.AccessControl;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;

namespace hosting
{
    public static class Injector
    {
        public static void Inject(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();

            serviceCollection.AddSingleton<IConfigurationService, ConfigurationService>();
            serviceCollection.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
        }
    }
}
