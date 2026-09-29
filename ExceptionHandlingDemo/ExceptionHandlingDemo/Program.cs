using ExceptionHandlingDemo.Business;
using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IUserInputService, UserInputService>();

            services.AddScoped<MicrosoftAuthenticator>();
            services.AddScoped<AzureSql>();

            return services.BuildServiceProvider();
        }
    }
}