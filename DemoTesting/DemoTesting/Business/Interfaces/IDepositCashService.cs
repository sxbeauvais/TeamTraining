namespace DemoTesting.Business.Interfaces
{
    public interface IDepositCashService
    {
        void RunDepositCash();
        decimal Deposit(decimal currentBalance, decimal amount);
    }
}
