using GamersCommunity.Core.Exceptions;
using GamersCommunity.Core.Logging;
using GamersCommunity.Core.Rabbit;
using GamersCommunity.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Consumer.Configuration;
using Sample.Consumer.Services;
using Sample.Database.Context;
using Serilog;

namespace Sample.Consumer
{
    /// <summary>
    /// Entry point for the Sample MicroService.
    /// Configures logging, dependency injection, and starts the RabbitMQ consumer worker.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point. Initializes configuration, logging, and service registration,
        /// then starts the host and keeps it alive until shutdown.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static async Task Main(string[] args)
        {
            Console.Title = "Sample MicroService";

            try
            {
                var builder = Host.CreateDefaultBuilder(args)
                    .ConfigureLogging((context, logging) =>
                    {
                        #region Initialize app settings

                        var loggerSettings = context.Configuration.GetSection("LoggerSettings").Get<LoggerSettings>()
                            ?? throw new InternalServerErrorException("PARSE_SETTINGS", "Can't parse LoggerSettings section");

                        #endregion

                        // Initialize Serilog with custom settings
                        Logger.Initialize(loggerSettings, "Sample MS", context.HostingEnvironment);

                        // Remove default providers (Console, Debug, etc.)
                        // Only Serilog will be used afterwards
                        logging.ClearProviders();

                        Log.Information("Starting ...");
                    })
                    .ConfigureServices((context, services) =>
                    {
                        // Bind configuration sections to strongly-typed settings
                        services.AddOptions<RabbitMQSettings>().Bind(context.Configuration.GetSection("RabbitMQ")).ValidateOnStart();
                        services.AddOptions<AppSettings>().Bind(context.Configuration.GetSection("AppSettings")).ValidateOnStart();

                        // Register EF Core DbContext
                        services.AddDbContext<SampleDbContext>();

                        // Register application services
                        services.AddSingleton<Serilog.ILogger>(sp => Log.Logger);
                        services.AddScoped<ITableService, UsersService>();
                        services.AddScoped<TableRouter>();
                        services.AddScoped<SampleServiceConsumer>();

                        // Register the background worker that runs the consumer
                        services.AddHostedService<ConsumerWorker>();
                    });

                var host = builder.Build();

                var environment = host.Services.GetRequiredService<IHostEnvironment>();

                Log.Information("Started in {Environment} environment...", environment.EnvironmentName);

                await host.RunAsync();
            }
            catch (HostAbortedException ex)
            {
                Log.Fatal(ex, "Aborted.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Terminated unexpectedly.");
            }
            finally
            {
                Log.Information("Stopped ...");
            }
        }
    }
}
