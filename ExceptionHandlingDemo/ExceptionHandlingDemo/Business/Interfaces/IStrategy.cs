using ExceptionHandlingDemo.Business;

namespace ExceptionHandlingDemo.Business.Interfaces
{
    public interface IStrategy
    {
        MenuOption StrategyId { get; }

        void Execute();
    }
}
