using DemoTesting.Business.Enums;
using DemoTesting.Helpers.Interfaces;

namespace DemoTesting.Helpers
{
    public class BonusMultiplierProvider : IBonusMultiplierProvider
    {
        public decimal GetMultiplier(CustomerType customerType)
        {
            return customerType switch
            {
                CustomerType.Regular => 1m,
                CustomerType.Vip => 2m,
                _ => throw new ArgumentOutOfRangeException(nameof(customerType), "Unsupported customer type.")
            };
        }
    }
}
