using ExceptionHandlingDemo.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandlingDemo.Business
{
    public class UserInputContext : IUserInputContext
    {
        private readonly IEnumerable<IStrategy> _strategies;

        public UserInputContext(IEnumerable<IStrategy> strategies)
        {
            _strategies = strategies;
        }

        public void Execute(MenuOption option)
        {
            var strategy = _strategies.FirstOrDefault(s => s.StrategyId == option);
            strategy?.Execute();
        }
    }
}
