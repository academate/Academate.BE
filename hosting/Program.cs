using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace hosting
{
    public class Program
    {
        private static IConfigurationRoot _basicConfiguration;

        public static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            CreateBasicConfiguration();

            CreateLogger();

            try
            {
                Log.Information("Starting...");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void CreateBasicConfiguration()
        {
            _basicConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }

        private static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_basicConfiguration)
                .CreateLogger();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
