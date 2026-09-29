using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using ExceptionHandlingDemo.Middleware;
using System;

namespace ExceptionHandlingDemo.Business
{
    public class ExcellentExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;
        private readonly GlobalExceptionMiddleware _middleware;

        public ExcellentExceptionHandlingStrategy(MicrosoftAuthenticator auth, GlobalExceptionMiddleware middleware)
        {
            _auth = auth;
            _middleware = middleware;
        }

        public MenuOption StrategyId => MenuOption.Excellent;

        public void Execute()
        {
            Console.WriteLine("Please enter your User Id: ");
            int.TryParse(Console.ReadLine(), out var userId);

            _middleware.Execute(() => _auth.AuthenticateUserForExcellentExample(userId));
        }
    }
}
