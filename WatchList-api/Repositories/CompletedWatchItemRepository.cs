using System;
using System.Collections.Generic;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.Repositories
{
    public class CompletedWatchItemRepository : IWatchItemRepository<CompletedWatchItem>
    {
        private const string CompletedTable = "completed_watch_item";
        private readonly IDapperConnection _connection;
        public CompletedWatchItemRepository(IDapperConnection connection)
        {
            _connection = connection;
        }

        public int Create(CompletedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid index)
        {
            throw new NotImplementedException();
        }

        public CompletedWatchItem Get(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<CompletedWatchItem> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public int Update(Guid userId, CompletedWatchItem watchItem)
        {
            throw new NotImplementedException();
        }
    }
}