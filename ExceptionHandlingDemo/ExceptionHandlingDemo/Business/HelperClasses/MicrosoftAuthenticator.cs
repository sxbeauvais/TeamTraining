
namespace ExceptionHandlingDemo.Business.HelperClasses
{
    public class MicrosoftAuthenticator
    {
        private readonly AzureSql _azureSql;
        public MicrosoftAuthenticator(AzureSql azureSql)
        {
            _azureSql = azureSql;
        }
        public void AuthenticateUserForTerribleExample()
        {
            try
            {
                _azureSql.GetUserCredentialsForTerribleExample();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AuthenticateUserForBadExample()
        {
            try
            {
                _azureSql.GetUserCredentialsForBadExample();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AuthenticateUserForOkExample()
        {
            _azureSql.GetUserCredentialsForOkExample();
        }

        public void AuthenticateUserForGoodExample(int userId)
        {
            _azureSql.GetUserCredentials(userId);
        }

        public void AuthenticateUserForExcellentExample(int userId)
        {
            _azureSql.GetUserCredentials(userId);
        }
    }
}
