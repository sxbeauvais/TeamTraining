using ExceptionHandlingDemo.Business;
using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using ExceptionHandlingDemo.Common.Logging;
using ExceptionHandlingDemo.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var Demo = serviceProvider.GetRequiredService<ExceptionHandlingDemo.Presentation.Demo>();


            Demo.Start();
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<ExceptionHandlingDemo.Presentation.Demo>();
            services.AddScoped<IUserInputContext, UserInputContext>();
            services.AddScoped<IStrategy, TerribleExceptionHandlingStrategy>();
            services.AddScoped<IStrategy, BadExceptionHandlingStrategy>();
            services.AddScoped<IStrategy, OkExceptionHandlingStrategy>();
            services.AddScoped<IStrategy, GoodExceptionHandlingStrategy>();
            services.AddScoped<IStrategy, ExcellentExceptionHandlingStrategy>();
            services.AddScoped<IUserInputService, UserInputService>();

            services.AddScoped<MicrosoftAuthenticator>();
            services.AddScoped<AzureSql>();
            services.AddScoped<AzureCosmos>();
            services.AddScoped<IExceptionMiddleware, GlobalExceptionMiddleware>();

            var logFilePath = Path.Combine(AppContext.BaseDirectory, "ExceptionHandlingDemoLogs.txt");
            services.AddLogging(builder => builder.AddProvider(new FileLoggerProvider(logFilePath)));

            return services.BuildServiceProvider();
        }
    }
}