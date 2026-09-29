using DemoTesting.Business.Enums;

namespace DemoTesting.Helpers.Interfaces
{
    public interface IBonusMultiplierProvider
    {
        decimal GetMultiplier(CustomerType customerType);
    }
}
