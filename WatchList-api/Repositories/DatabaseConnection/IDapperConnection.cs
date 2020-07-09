using System.Data.Common;

namespace WatchList_api.Repositories.DatabaseConnection
{
    public interface IDapperConnection
    {
        public DbConnection GetConnection();
    }
}