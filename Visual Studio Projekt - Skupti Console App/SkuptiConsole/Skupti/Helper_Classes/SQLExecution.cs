using System;
using System.Data.SqlClient;

namespace Skupti.Helper_Classes
{
    public class SQLExecution
    {
        public static void ExecuteCommand(String sqlString)
        {
            var conn = new SqlConnection(DatabaseConnector.GetConnectionString());
            conn.Open();
            var com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = sqlString;
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
    