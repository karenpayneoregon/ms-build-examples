using Microsoft.Data.SqlClient;

namespace SqlServerLibrary;

/// <summary>
/// Code assumes the developer has proper permissions and thee databases are
/// always available but we all know something can go wrong so please add exception handling.
/// </summary>
public class DataHelpers
{
        
    public static bool ExpressDatabaseExists(string databaseName)
    {
        using var cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

        cn.Open();
        return cmd.ExecuteScalar() != DBNull.Value;

    }
    public static bool LocalDbDatabaseExists(string databaseName)
    {
        using var cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

        cn.Open();
        return cmd.ExecuteScalar() != DBNull.Value;

    }
    
}