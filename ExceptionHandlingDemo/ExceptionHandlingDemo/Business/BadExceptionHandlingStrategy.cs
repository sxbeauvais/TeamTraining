using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business
{
    public class BadExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;
        public BadExceptionHandlingStrategy(MicrosoftAuthenticator auth)
        {
            _auth = auth;
        }
        
        public MenuOption StrategyId => MenuOption.Bad;

        public void Execute()
        {
            try
            {
                _auth.AuthenticateUserForBadExample();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
