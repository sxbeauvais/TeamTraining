using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business.HelperClasses
{
    public class AzureSql
    {
        public void GetUserCredentialsForTerribleExample()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetUserCredentialsForBadExample()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
