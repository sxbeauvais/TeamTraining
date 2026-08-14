using DemoTesting.Business.Interfaces;

namespace DemoTesting.Business
{
    public class DepositCashService : IDepositCashService
    {
        public void RunDepositCash()
        {
            Console.Write("Current balance: ");
            var currentBalanceInput = Console.ReadLine();
            Console.Write("Deposit amount: ");
            var amountInput = Console.ReadLine();

            if (!decimal.TryParse(currentBalanceInput, out var currentBalance) || !decimal.TryParse(amountInput, out var amount))
            {
                Console.WriteLine("Invalid deposit input.");
                return;
            }

            try
            {
                var updatedBalance = Deposit(currentBalance, amount);
                Console.WriteLine($"Deposit successful. New balance: {updatedBalance:C}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public decimal Deposit(decimal currentBalance, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be greater than zero.");
            }

            return currentBalance + amount;
        }
    }
}
