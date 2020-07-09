using System;
using System.Collections.Generic;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.Repositories
{
    public class PlannedWatchItemRepository : IWatchItemRepository<PlannedWatchItem>
    {
        private const string PlannedTable = "planned_watch_item";
        private readonly IDapperConnection _connection;
        public PlannedWatchItemRepository(IDapperConnection connection)
        {
            _connection = connection;
        }

        public int Create(PlannedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid index)
        {
            throw new NotImplementedException();
        }

        public PlannedWatchItem Get(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<PlannedWatchItem> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public int Update(Guid userId, PlannedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }
    }
}