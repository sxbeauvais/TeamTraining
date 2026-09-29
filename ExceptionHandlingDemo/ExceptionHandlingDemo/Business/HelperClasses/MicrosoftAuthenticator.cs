
namespace ExceptionHandlingDemo.Business.HelperClasses
{
    public class MicrosoftAuthenticator
    {
        private readonly AzureSql _azureSql;
        private readonly AzureCosmos _cosmos;
        public MicrosoftAuthenticator(AzureSql azureSql, AzureCosmos cosmos)
        {
            _azureSql = azureSql;
            _cosmos = cosmos;
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

        public void Authenticate(int userId)
        {
            _cosmos.GetUser(userId);
        }
    }
}
