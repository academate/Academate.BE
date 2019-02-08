using Application.Services.AccessControl;
using Microsoft.Extensions.DependencyInjection;

namespace hosting
{
    public static class Injector
    {
        public static void Inject(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
