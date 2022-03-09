using System.Data.Common;
using Npgsql;

namespace WatchList_api.Repositories.DatabaseConnection
{
    public class NpgsqlDapperConnection : IDapperConnection
    {
        public DbConnection GetConnection()
        {
            return new NpgsqlConnection(
                "");
        }
    }
}