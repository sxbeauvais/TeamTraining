using ExceptionHandlingDemo.Business.HelperClasses;
using ExceptionHandlingDemo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business
{
    public class TerribleExceptionHandlingStrategy : IStrategy
    {
        private readonly MicrosoftAuthenticator _auth;
        public TerribleExceptionHandlingStrategy(MicrosoftAuthenticator auth)
        {
            _auth = auth;
        }
        
        public MenuOption StrategyId => MenuOption.Terrible;

        public void Execute()
        {
            try
            {
                _auth.AuthenticateUserForTerribleExample();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
