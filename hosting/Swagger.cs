
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;

namespace hosting
{
    public static class Swagger
    {
        public static void AddSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Restful API",
                    Description = "An ASP.NET Core Web API For Academate",
                    Contact = new Contact
                    {
                        Name = "Academate",
                        Email = string.Empty,
                        Url = "Academate.xyz"
                    }
                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[]{}}
                });


                // Set the comments path for the Swagger JSON and UI.
                var swaggerXmlPath = Path.Combine(AppContext.BaseDirectory, "ForSwagger.xml");
                c.IncludeXmlComments(swaggerXmlPath);
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
