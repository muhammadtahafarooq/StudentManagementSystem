using System.Data.SqlClient;
using System.Configuration;

namespace APProject
{
    public class DBConn
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
            );
        }
    }
}