using Application.Services.AccessControl;
using Application.Services.Configuration;
using Application.Services.Course;
using Application.Services.Enrollment;
using Application.Services.Exam;
using CrossCuttingServices;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;
using Repository.Course;
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
            serviceCollection.AddScoped<IExamRepository, ExamRepository>();
            serviceCollection.AddScoped<IEnrollmentService, EnrollmentService>();
            serviceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();

        }
    }
}
