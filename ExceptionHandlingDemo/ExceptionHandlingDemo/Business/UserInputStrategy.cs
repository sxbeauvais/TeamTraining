using ExceptionHandlingDemo.Business.Interfaces;
using ExceptionHandlingDemo.Middleware;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandlingDemo.Business
{
    public class UserInputContext : IUserInputContext
    {
        private readonly IEnumerable<IStrategy> _strategies;
        private readonly IExceptionMiddleware _middleware;

        public UserInputContext(IEnumerable<IStrategy> strategies, IExceptionMiddleware middleware)
        {
            _strategies = strategies;
            _middleware = middleware;
        }

        public void Execute(MenuOption option)
        {
            var strategy = _strategies.FirstOrDefault(s => s.StrategyId == option);
            if (strategy is null)
            {
                return;
            }

            if (strategy.UsesMiddleware)
            {
                _middleware.Execute(strategy.Execute);
            }
            else
            {
                strategy.Execute();
            }
        }
    }
}
