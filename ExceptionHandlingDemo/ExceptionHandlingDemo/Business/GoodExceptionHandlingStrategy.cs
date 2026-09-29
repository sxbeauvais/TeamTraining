using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using ExceptionHandlingDemo.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business
{
    public class GoodExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;
        public GoodExceptionHandlingStrategy(MicrosoftAuthenticator auth)
        {
            _auth = auth;
        }

        public MenuOption StrategyId => MenuOption.Good;

        public void Execute()
        {
            Console.WriteLine("Please enter your User Id: ");
            int.TryParse(Console.ReadLine(), out var userId);
            _auth.AuthenticateUserForGoodExample(userId);
        }
    }
}
