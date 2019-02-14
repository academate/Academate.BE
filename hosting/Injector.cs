using Application.Services.AccessControl;
using Application.Services.Exam;
using CrossCuttingServices;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;
using Repository.Enrollment;
using Repository.Exams;

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

            serviceCollection.AddScoped<IExamService, ExamService>();
            serviceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            serviceCollection.AddScoped<IExamRepository, ExamRepository>();
        }
    }
}
