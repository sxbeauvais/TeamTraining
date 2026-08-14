using DemoTesting.Business.Interfaces;

namespace DemoTesting.Business
{
    public class HandleUserSelection : IHandleUserSelection
    {
        private readonly ICreditService _creditService;
        private readonly IDepositCashService _depositCashService;

        public HandleUserSelection(ICreditService creditService, IDepositCashService depositCashService)
        {
            _creditService = creditService;
            _depositCashService = depositCashService;
        }

        public void HandleSelection()
        {
            PrintMenu();
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    _creditService.RunCreditCheck();
                    break;
                case "2":
                    _depositCashService.RunDepositCash();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Run a credit check (brittle and untested)");
            Console.WriteLine("2 - Deposit cash (well tested)");
            Console.Write("What would you like to do?: ");
        }
    }
}
