using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectTimes.Domain;
using ScopedInvocation;

namespace ProjectTimes
{
    static class Program
    {

        public static void ConfigureServices(IConfiguration configuration,  IServiceCollection services)
        {
            services.AddMicrosoftDiScopedInvocation();
            services.AddLogging(configure => configure.AddConsole())
                .AddScoped<IProjectTimesEntriesService, ProjectTimesEntriesService>()
                .AddScoped<IProjectTimeEntryRepository, ProjectTimeEntryRepository>()
                .AddSingleton<ProjectTimesApplicationContext>()                
                .Configure<ProjectTimesSettings>(s =>
                {
                    s.DataFilePath = Process.GetCurrentProcess().MainModule?.FileName!;
                })
                .AddSingleton<Form1>();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            var builder = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("appsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(hostContext.Configuration, services);
                });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger(typeof(Program).FullName);

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    var appContext = serviceProvider.GetRequiredService<ProjectTimesApplicationContext>();
                    Application.Run(appContext);

                    logger.LogInformation("Success");
                }
                catch (Exception ex)
                {
                    logger.LogError("Error ocurred.", ex);
                }
            }
        }
    }
}
