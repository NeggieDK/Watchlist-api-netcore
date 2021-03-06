﻿using System.Data.Common;
using Npgsql;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList.IntegrationTests.Stubs
{
    public class BrokenConnectionStub : IDapperConnection
    {
        public DbConnection GetConnection()
        {
            return new NpgsqlConnection(
                "Server=verywrongaddreslkdsfjslkdfjsdlkfj.com;Port=5432;Database=d8a8jo2alr9sqo;User Id=zivdvierfsybei;Password=1f670fc76202e5faa7a8dd20370a99e4344f52bcba91ad90e0c6cca36c6c8718;SslMode=Require;Trust Server Certificate=true;Pooling=true;");
        }
    }
}