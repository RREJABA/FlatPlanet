using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClickCounter.DAL
{
    public static class DataAccess
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["FlatPlanet"].ConnectionString;

        public static int GetCounter()
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "SELECT Counter FROM ClickCounter WHERE ID = 1";
            sqlConn.Open();

            var reader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);
            reader.Read();

            var counter = (int)reader[0];

            reader.Close();
            sqlConn.Close();

            return counter;
        }

        public static void UpdateCounter()
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "UPDATE ClickCounter SET Counter = Counter + 1 WHERE ID = 1";
            sqlConn.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}