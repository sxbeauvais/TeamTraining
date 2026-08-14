using Microsoft.Extensions.DependencyInjection;
using System.Dynamic;

namespace Program
{
    public class Program
    {
        public static void Main(string[] arg)
        {
            var serviceProvider = configureServices();

            var demo = serviceProvider.GetRequiredService<DemoTesting.Presentation.Demo>();

            demo.Start();
        }

        private static IServiceProvider configureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<DemoTesting.Presentation.Demo>();
            services.AddScoped<DemoTesting.Business.Interfaces.IHandleUserSelection, DemoTesting.Business.HandleUserSelection>();

            return services.BuildServiceProvider();
        }
    }
}