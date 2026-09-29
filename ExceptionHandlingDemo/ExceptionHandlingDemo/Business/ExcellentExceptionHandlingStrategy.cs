using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using System;

namespace ExceptionHandlingDemo.Business
{
    public class ExcellentExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;

        public ExcellentExceptionHandlingStrategy(MicrosoftAuthenticator auth)
        {
            _auth = auth;
        }

        public MenuOption StrategyId => MenuOption.Excellent;

        public bool UsesMiddleware => true;

        public void Execute()
        {
            Console.WriteLine("Please enter your User Id: ");
            int.TryParse(Console.ReadLine(), out var userId);

            _auth.Authenticate(userId);
        }
    }
}
