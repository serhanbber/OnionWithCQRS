using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Helper
{
    public class ConnectionString
    {
        private const string _sqlClientTemplate = @"
         data source={0};initial catalog={1};user id={2};password={3};multipleactiveresultsets=True;TrustServerCertificate=True;
     ";
        public static string GetConnectionString(string serverName, string dbName, string userName, string Password)
        {
            return string.Format(_sqlClientTemplate, serverName, dbName, userName, Password);
        }
    }
}
