using System;
using System.Collections.Generic;
using Dapper;
using WatchList.IntegrationTests.Stubs;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList.IntegrationTests.Fixtures
{
    public class IntegrationSqlDatabaseFixture : IDisposable
    {
        public readonly IDapperConnection connection;
        private List<Guid> GuidsToDelete;
        
        public IntegrationSqlDatabaseFixture()
        {
            connection = new IntegrationSqlConnection();
            GuidsToDelete = new List<Guid>();
        }

        // When a new record is created with a guid, the guid has to be requested from the fixture
        // The fixture will keep track of the newly created records, and will delete them on a per class basis (class fixture) after the tests of the class are completed
        public Guid NewGuid()
        {
            var guid = Guid.NewGuid();
            GuidsToDelete.Add(guid);
            return guid;
        }
        
        public void Dispose()
        {
            // Remove all data from affected tables
            using (var conn = connection.GetConnection())
            {
                foreach (var guid in GuidsToDelete)
                {
                    conn.Execute($"DELETE FROM planned_watch_item where id = @Guid", new{Guid = guid});
                    conn.Execute($"DELETE FROM active_watch_item where id = @Guid", new{Guid = guid});
                    conn.Execute($"DELETE FROM dropped_watch_item where id = @Guid", new{Guid = guid});
                    conn.Execute($"DELETE FROM completed_watch_item where id  = @Guid", new{Guid = guid});
                }
            }
            
            connection.GetConnection().Dispose();
        }
    }
}