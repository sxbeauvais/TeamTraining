using DemoTesting.Business;

namespace DemoTesting.Unit.Tests
{
    [TestClass]
    public sealed class DepositCashServiceTests
    {
        [TestMethod]
        public void Deposit_WhenAmountIsPositive_ReturnsUpdatedBalance()
        {
            var sut = new DepositCashService();

            var result = sut.Deposit(100m, 25m);

            Assert.AreEqual(125m, result);
        }

        [TestMethod]
        public void Deposit_WhenAmountHasDecimals_PreservesPrecision()
        {
            var sut = new DepositCashService();

            var result = sut.Deposit(10.10m, 0.90m);

            Assert.AreEqual(11.00m, result);
        }

        [TestMethod]
        public void Deposit_WhenAmountIsZero_ThrowsArgumentOutOfRangeException()
        {
            var sut = new DepositCashService();

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.Deposit(200m, 0m));
        }

        [TestMethod]
        public void Deposit_WhenAmountIsNegative_ThrowsArgumentOutOfRangeException()
        {
            var sut = new DepositCashService();

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.Deposit(200m, -1m));
        }
    }
}
