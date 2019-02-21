using CrossCuttingServices;
using hosting.MiddleWares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Controllers;
using System;
using AutoMapper;

namespace hosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var presentationAssembly = typeof(CoursesController).Assembly;
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApplicationPart(presentationAssembly);

            services.AddAutoMapper();

            services.AddSwagger();

            services.AddJwtAuthentication(Configuration);
            services.AddHttpContextAccessor();
            services.Inject();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.ConfigureSwagger();

            app.UseMvc();

            EnsureDbCreation(serviceProvider);
        }

        private static void EnsureDbCreation(IServiceProvider serviceProvider)
        {
            var dbProvider = serviceProvider.GetService<IDbProvider>();
            dbProvider.Context.Database.EnsureCreatedAsync();
        }
    }
}
