using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace NLog.Appsettings.Standard.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicesProvider = BuildDi();
            var runner = servicesProvider.GetRequiredService<Runner>();

            runner.DoAction("Run Action");

            Console.WriteLine("Press ANY key to exit");
            Console.ReadLine();
        }

        private static IServiceProvider BuildDi()
        {
            var services = new ServiceCollection();

            //Runner is the custom class
            services.AddTransient<Runner>();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace));

            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            //configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            loggerFactory.ConfigureNLog("nlog.config");

            return serviceProvider;
        }

        public class Runner
        {
            private readonly ILogger<Runner> logger;

            public Runner(ILogger<Runner> logger)
            {
                this.logger = logger;
            }

            public void DoAction(string name)
            {
                logger.LogTrace(name + " Trace!");
                logger.LogDebug(name + " Debug!");
                logger.LogInformation(name + " Information!");
                logger.LogWarning(name + " Warning!");
                logger.LogError(name + " Error!");
                logger.LogCritical(name + " Critical!");

                try
                {
                    throw new NotSupportedException();
                }
                catch (Exception ex)
                {
                    logger.LogError("This is an expected exception.", ex);
                }
            }
        }
    }
}
