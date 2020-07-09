using System;
using System.Collections.Generic;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.Repositories
{
    public class DroppedWatchItemRepository : IWatchItemRepository<DroppedWatchItem>
    {
        private const string DroppedTable = "dropped_watch_item";
        private readonly IDapperConnection _connection;
        public DroppedWatchItemRepository(IDapperConnection connection)
        {
            _connection = connection;
        }

        public int Create(DroppedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid index)
        {
            throw new NotImplementedException();
        }

        public DroppedWatchItem Get(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<DroppedWatchItem> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public int Update(Guid userId, DroppedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }
    }
}