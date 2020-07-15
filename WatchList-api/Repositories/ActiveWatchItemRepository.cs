using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem;
using WatchList_api.CQRS.ActiveWatchItems.Commands.DeleteActiveWatchItem;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public class ActiveWatchItemRepository : IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>
    {
        private readonly IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse> _getAllActiveWatchItemsQuery;
        private readonly IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse> _getActiveWatchItemQuery;
        private readonly ICommand<CreateActiveWatchItemRequest, CreateActiveWatchItemResponse> _createActiveWatchItem;
        private readonly ICommand<DeleteActiveWatchItemRequest, DeleteActiveWatchItemResponse> _deleteActiveWatchItem;
        private readonly ICommand<UpdateActiveWatchItemRequest, UpdateActiveWatchItemResponse> _updateActiveWatchItem;

        public ActiveWatchItemRepository(IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse> getAllActiveWatchItemsQuery, IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse> getActiveWatchItemQuery, ICommand<CreateActiveWatchItemRequest, CreateActiveWatchItemResponse> createActiveWatchItem, ICommand<DeleteActiveWatchItemRequest, DeleteActiveWatchItemResponse> deleteActiveWatchItem, ICommand<UpdateActiveWatchItemRequest, UpdateActiveWatchItemResponse> updateActiveWatchItem)
        {
            _getAllActiveWatchItemsQuery = getAllActiveWatchItemsQuery;
            _getActiveWatchItemQuery = getActiveWatchItemQuery;
            _createActiveWatchItem = createActiveWatchItem;
            _deleteActiveWatchItem = deleteActiveWatchItem;
            _updateActiveWatchItem = updateActiveWatchItem;
        }

        public CommandResult Create(ActiveWatchItemChange watchItem)
        {
            return _createActiveWatchItem.Execute(new CreateActiveWatchItemRequest(watchItem)).Result;
        }

        public CommandResult Delete(Guid id, Guid userId)
        {
            return _deleteActiveWatchItem.Execute(new DeleteActiveWatchItemRequest { Id = id, UserId = userId }).Result;
        }

        public ActiveWatchItem Get(Guid id, Guid userId)
        {
            return _getActiveWatchItemQuery.Execute(new GetActiveWatchItemRequest { Id = id, UserId = userId }).WatchItems;
        }

        public List<ActiveWatchItem> GetAll(Guid userId)
        {
            return _getAllActiveWatchItemsQuery.Execute(new GetAllActiveWatchItemsRequest { UserId = userId }).WatchItems;
        }

        public CommandResult Update(Guid id, Guid userId, ActiveWatchItemChange watchItem)
        {
            return _updateActiveWatchItem.Execute(new UpdateActiveWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem }).Result;
        }
    }
}