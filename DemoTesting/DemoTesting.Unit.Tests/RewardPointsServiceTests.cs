using DemoTesting.Business;
using DemoTesting.Business.Enums;
using DemoTesting.Helpers;
using DemoTesting.Helpers.Interfaces;
using Moq;

namespace DemoTesting.Unit.Tests
{
    [TestClass]
    public sealed class RewardPointsServiceTests
    {
        [TestMethod]
        public void Test1()
        {
            // Setup
            var sut = new RewardPointsService(new BonusMultiplierProvider());

            // Execution
            var result = sut.CalculatePoints(100m, CustomerType.Vip);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CalculatePoints_WhenCustomerIsRegular_ReturnsBasePoints()
        {
            // Setup
            var sut = new RewardPointsService(new BonusMultiplierProvider());

            // Execution
            var result = sut.CalculatePoints(50.80m, CustomerType.Regular);

            // Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void CalculatePoints_WhenCustomerIsVip_ReturnsBasePoints()
        {
            // Setup
            var multiplierProviderMock = new Mock<IBonusMultiplierProvider>(MockBehavior.Strict);
            multiplierProviderMock.Setup(x => x.GetMultiplier(CustomerType.Vip)).Returns(2.5m);
            var sut = new RewardPointsService(multiplierProviderMock.Object);

            // Execution
            var result = sut.CalculatePoints(80.90m, CustomerType.Vip);

            // Assert
            Assert.AreEqual(200, result);
            multiplierProviderMock.Verify(x => x.GetMultiplier(CustomerType.Vip), Times.Once);
            multiplierProviderMock.VerifyNoOtherCalls();
        }
        [TestMethod]
        public void CalculatePoints_WhenPurchaseAmountIsZero_ThrowsArgumentOutOfRangeException()
        {
            // Setup
            var _bonusMultiplierProvide = new Mock<IBonusMultiplierProvider>(MockBehavior.Strict);

            var rewardsPointsService = new RewardPointsService(_bonusMultiplierProvide.Object);

            // Execute + Assert
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => rewardsPointsService.CalculatePoints(0, CustomerType.Regular));
        }
    }
}
