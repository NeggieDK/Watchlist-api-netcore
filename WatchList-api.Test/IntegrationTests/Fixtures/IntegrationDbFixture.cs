using System;
using System.Collections.Generic;
using Dapper;
using LightInject;
using WatchList.IntegrationTests.Stubs;
using WatchList_api.Repositories.DatabaseConnection;
using WatchList_api.Test.IntegrationTests.Stubs;

namespace WatchList.IntegrationTests.Fixtures
{
    public class IntegrationDbFixture : IDisposable
    {
        public readonly IDapperConnection Connection;
        public readonly ServiceContainer Container;
        private readonly List<Guid> _guidsToDelete;

        public IntegrationDbFixture()
        {
            Connection = new IntegrationConnection();
            _guidsToDelete = new List<Guid>();
            Container = new ServiceContainer();
            Container.RegisterFrom<CompositionRootStub>();
        }

        // When a new record is created with a guid, the guid has to be requested from the fixture
        // The fixture will keep track of the newly created records, and will delete them on a per class basis (class fixture) after the tests of the class are completed
        public void TrackGuid(Guid guid)
        {
            _guidsToDelete.Add(guid);
        }
        
        public void Dispose()
        {
            // Remove all data from affected tables
            using (var conn = Connection.GetConnection())
            {
                foreach (var guid in _guidsToDelete)
                {
                    conn.Execute($"DELETE FROM planned_watch_items where id = @Guid", new{Guid = guid});
                    conn.Execute($"DELETE FROM active_watch_items where id = @Guid", new{Guid = guid});
                    conn.Execute($"DELETE FROM dropped_watch_items where id = @Guid", new{Guid = guid});
                    //conn.Execute($"DELETE FROM completed_watch_item where id  = @Guid", new{Guid = guid});
                }
            }
            
            Connection.GetConnection().Dispose();
        }
    }
}