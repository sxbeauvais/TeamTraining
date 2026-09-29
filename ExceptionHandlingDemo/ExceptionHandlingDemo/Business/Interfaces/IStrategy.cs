using ExceptionHandlingDemo.Business;

namespace ExceptionHandlingDemo.Business.Interfaces
{
    public interface IStrategy
    {
        MenuOption StrategyId { get; }

        // Strategies opt into being routed through a middleware by overriding
        // this to true. UserInputContext checks it before calling Execute().
        bool UsesMiddleware => false;

        void Execute();
    }
}
