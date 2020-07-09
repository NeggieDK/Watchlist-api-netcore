using System;
using System.Collections.Generic;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.Repositories
{
    public class ActiveWatchItemRepository : IWatchItemRepository<ActiveWatchItem>
    {
        private const string ActiveTable = "active_watch_item";

        private readonly IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse> _getAllActiveWatchItemsQuery;
        public ActiveWatchItemRepository(IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse> getAllActiveWatchItemsQuery)
        {
            _getAllActiveWatchItemsQuery = getAllActiveWatchItemsQuery;
        }

        public int Create(ActiveWatchItem watchItem)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid index)
        {
            throw new NotImplementedException();
        }

        public ActiveWatchItem Get(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<ActiveWatchItem> GetAll(Guid userId)
        {
            return _getAllActiveWatchItemsQuery.Execute(new GetAllActiveWatchItemsRequest { UserId = userId }).WatchItems;
        }

        public int Update(Guid userId, ActiveWatchItem watchItem)
        {
            throw new NotImplementedException();
        }
    }
}