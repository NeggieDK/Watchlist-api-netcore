using System.Data.Common;
using Npgsql;

namespace WatchList_api.Repositories.DatabaseConnection
{
    public class NpgsqlDapperConnection : IDapperConnection
    {
        public DbConnection GetConnection()
        {
            return new NpgsqlConnection(
                "Server=ec2-54-228-224-37.eu-west-1.compute.amazonaws.com;Port=5432;Database=dbc7epo60iav3f;User Id=maqfhoussomjpp;Password=599c92af6f0e4e4c49c8f591c6311600930d7c250c77728c7778c58d91dc9084;SslMode=Require;Trust Server Certificate=true;");
        }
    }
}