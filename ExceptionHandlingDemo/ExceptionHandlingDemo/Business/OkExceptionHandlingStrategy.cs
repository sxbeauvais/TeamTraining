using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using ExceptionHandlingDemo.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business
{
    public class OkExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;
        public OkExceptionHandlingStrategy(MicrosoftAuthenticator auth)
        {
            _auth = auth;
        }

        public MenuOption StrategyId => MenuOption.Ok;

        public void Execute()
        {
            try
            {
                _auth.AuthenticateUserForOkExample();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException($"An error occured while trying to authenticate the user. {ex.Message}");
            }
        }
    }
}
