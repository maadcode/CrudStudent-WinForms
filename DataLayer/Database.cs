using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public sealed class Database
    {
        private static Database _instance;
        public SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static Database GetInstance()
        {
            if (_instance == null)
                _instance = new Database();

            return _instance;
        }
    }
}