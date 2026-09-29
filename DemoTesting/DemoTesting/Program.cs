using DemoTesting.Business;
using DemoTesting.Business.Enums;
using DemoTesting.Helpers;
using DemoTesting.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Program
{
    public class Program
    {
        public static void Main(string[] arg)
        {
            var serviceProvider = ConfigureServices();
            var rewardPointsService = serviceProvider.GetRequiredService<RewardPointsService>();
            var points = rewardPointsService.CalculatePoints(125.75m, CustomerType.Vip);

            Console.WriteLine($"Calculated points: {points}");
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IBonusMultiplierProvider, BonusMultiplierProvider>();
            services.AddScoped<RewardPointsService>();

            return services.BuildServiceProvider();
        }
    }
}
