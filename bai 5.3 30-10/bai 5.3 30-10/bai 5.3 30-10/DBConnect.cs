using System.Data.SqlClient;

namespace CafePOS
{
    public static class DBConnect
    {
       
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CafePOSDB;Integrated Security=True;TrustServerCertificate=True;";

       
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}