using EveryBodyCodes.Business;
using EveryBodyCodes.Interfaces;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using EveryBodyCodes.ExternalServices.Interfaces;
using EveryBodyCodes.ExternalServices;

namespace EveryBodyCodes.CLI
{
    class Program
    {

        [Option(CommandOptionType.SingleValue, ShortName = "n", LongName = "name", Description = "Camera name", ValueName = "", ShowInHelpText = true)]
        public string Name { get; set; }

        private readonly ICameraBs cameraBs;

        private readonly ILogger<Program> logger;

        public Program(ICameraBs cameraBs, ILogger<Program> logger)
        {
            this.cameraBs = cameraBs;
            this.logger = logger;
        }

        private static async Task<int> Main(string[] args)
        {

            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(Configuration)
                   .Enrich.FromLogContext()
                   .CreateLogger();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(config =>
                    {
                        config.ClearProviders();
                        config.AddConsole();
                        config.AddProvider(new SerilogLoggerProvider(Log.Logger));

                    })

                     .AddSingleton<ICameraBs, CameraBs>()
                     .AddSingleton<ICameraService, CameraService>();
                });
            
            try
            {
               return await builder.RunCommandLineApplicationAsync<Program>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        protected async Task<int> OnExecute(CommandLineApplication app)
        {

            if (string.IsNullOrEmpty(Name))
            {
                app.ShowHelp();
                return 0;
            }
            else
            {
                try
                {
                   
                    var result = await cameraBs.GetCamerasByNameAsync(Name);

                    if (result != null && result.Count > 0)
                        result.ForEach(item => Console.WriteLine($"{item.Camera} | {item.Longitude} | {item.Latitude}"));
                    else
                        Console.WriteLine($"There are no results for the camera name:'{Name}' ");

                    return 0;

                }
                catch (Exception ex)
                {
                    OnException(ex);
                    return 1;
                }
            }

        }

        protected void OnException(Exception ex)
        {
            logger.LogError(ex.Message);
            logger.LogDebug(ex, ex.Message);
        }

    }
}
