using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectTimes.Domain;
using Serilog;

namespace ProjectTimes
{
    public static class Program
    {
        

        public static void ConfigureServices(IConfiguration configuration,  IServiceCollection services)
        {
            services.AddProjectTimesServices()
                .AddTxtProjectTimesRepository(
                    Path.Combine(
                        Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName!)!, 
                        "project_times.data.txt"
                        ), 
                    3000);

            services
                .AddSingleton<IWorkStarter, WindowsFormsWorkStarter>()
                .AddSingleton<BeginEndWorkSignaler, SystemEventsHandler>()
                .AddSingleton<ProjectTimesApplicationContext>()
                .AddSingleton<StartWorkingForm>()
                .AddSingleton<WorkDescriptionForm>()
                .AddSingleton<ContinueOrStartAgainForm>();

            services
                .AddMicrosoftDiScopedInvocation();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Para hacer que se muestre u oculte la ventana de la consola cambia en el csproj entre <OutputType>Exe</OutputType>(lo muestra) y <OutputType>WinExe</OutputType> (no lo muestra)
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(SetupConfigBuilder(args, new ConfigurationBuilder()).Build())
                .Enrich.WithProperty("AppName", "Project Times")
                .CreateLogger();

            var host = BuildHost(args);

            using (var serviceScope = host.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger(typeof(Program).FullName!);

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
                    logger.LogError("Error occurred.", ex);
                }
            }
        }
        

        private static IHost BuildHost(string[] args)
        {
            return new HostBuilder()
                .ConfigureHostConfiguration(configHost => { SetupConfigBuilder(args, configHost); })
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(hostContext.Configuration, services);
                })
                .UseSerilog()
                .Build();
        }

        private static IConfigurationBuilder SetupConfigBuilder(string[] args, IConfigurationBuilder configHost)
        {
            configHost.SetBasePath(Directory.GetCurrentDirectory());
            configHost.AddJsonFile("ProjectTimes.settings.json", optional: true, reloadOnChange: true);
            configHost.AddEnvironmentVariables(prefix: "PREFIX_");
            configHost.AddCommandLine(args);
            return configHost;
        }
    }
}
