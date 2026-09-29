using DemoTesting.Business.Enums;
using DemoTesting.Helpers.Interfaces;

namespace DemoTesting.Business
{
    public class RewardPointsService
    {
        private readonly IBonusMultiplierProvider _bonusMultiplierProvider;

        public RewardPointsService(IBonusMultiplierProvider bonusMultiplierProvider)
        {
            _bonusMultiplierProvider = bonusMultiplierProvider;
        }

        public int CalculatePoints(decimal purchaseAmount, CustomerType customerType)
        {
            if (purchaseAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(purchaseAmount), "Purchase amount must be greater than zero.");
            }

            var basePoints = (int)Math.Floor(purchaseAmount);
            var multiplier = _bonusMultiplierProvider.GetMultiplier(customerType);

            return (int)(basePoints * multiplier);
        }
    }
}
