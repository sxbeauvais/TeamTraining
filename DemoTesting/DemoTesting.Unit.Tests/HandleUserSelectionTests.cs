using DemoTesting.Business;
using DemoTesting.Business.Interfaces;
using Moq;

namespace DemoTesting.Unit.Tests
{
    [TestClass]
    [DoNotParallelize]
    public sealed class HandleUserSelectionTests
    {
        [TestMethod]
        public void HandleSelection_WhenInputIs1_ExecutesRunCreditCheckOnce()
        {
            var creditServiceMock = new Mock<ICreditService>();
            var depositCashServiceMock = new Mock<IDepositCashService>();
            var sut = new HandleUserSelection(creditServiceMock.Object, depositCashServiceMock.Object);

            var output = ExecuteWithConsoleInput(sut, "1");

            creditServiceMock.Verify(x => x.RunCreditCheck(), Times.Once);
        }

        [TestMethod]
        public void HandleSelection_WhenInputIs2_ExecutesRunDepositCashOnce()
        {
            var creditServiceMock = new Mock<ICreditService>();
            var depositCashServiceMock = new Mock<IDepositCashService>();
            var sut = new HandleUserSelection(creditServiceMock.Object, depositCashServiceMock.Object);

            var output = ExecuteWithConsoleInput(sut, "2");

            depositCashServiceMock.Verify(x => x.RunDepositCash(), Times.Once);
        }

        [TestMethod]
        public void HandleSelection_WhenInputIsNotRecognized_UsesDefaultPath()
        {
            var creditServiceMock = new Mock<ICreditService>();
            var depositCashServiceMock = new Mock<IDepositCashService>();
            var sut = new HandleUserSelection(creditServiceMock.Object, depositCashServiceMock.Object);

            var output = ExecuteWithConsoleInput(sut, "9");

            StringAssert.Contains(output, "Invalid selection. Please try again.");
        }

        private static string ExecuteWithConsoleInput(HandleUserSelection sut, string inputValue)
        {
            using var input = new StringReader(inputValue);
            using var output = new StringWriter();
            var originalIn = Console.In;
            var originalOut = Console.Out;

            Console.SetIn(input);
            Console.SetOut(output);

            try
            {
                sut.HandleSelection();
                return output.ToString();
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}
