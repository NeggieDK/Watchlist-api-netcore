using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Commands.DeleteDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Queries.GetDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Queries.GetAllDroppedWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public class DroppedWatchItemRepository : IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>
    {
        private readonly IQuery<GetAllDroppedWatchItemsRequest, GetAllDroppedWatchItemsResponse> _getAllDroppedWatchItemsQuery;
        private readonly IQuery<GetDroppedWatchItemRequest, GetDroppedWatchItemResponse> _getDroppedWatchItemQuery;
        private readonly ICommand<CreateDroppedWatchItemRequest, CreateDroppedWatchItemResponse> _createDroppedWatchItem;
        private readonly ICommand<DeleteDroppedWatchItemRequest, DeleteDroppedWatchItemResponse> _deleteDroppedWatchItem;
        private readonly ICommand<UpdateDroppedWatchItemRequest, UpdateDroppedWatchItemResponse> _updateDroppedWatchItem;

        public DroppedWatchItemRepository(IQuery<GetAllDroppedWatchItemsRequest, GetAllDroppedWatchItemsResponse> getAllDroppedWatchItemsQuery, IQuery<GetDroppedWatchItemRequest, GetDroppedWatchItemResponse> getDroppedWatchItemQuery, ICommand<CreateDroppedWatchItemRequest, CreateDroppedWatchItemResponse> createDroppedWatchItem, ICommand<DeleteDroppedWatchItemRequest, DeleteDroppedWatchItemResponse> deleteDroppedWatchItem, ICommand<UpdateDroppedWatchItemRequest, UpdateDroppedWatchItemResponse> updateDroppedWatchItem)
        {
            _getAllDroppedWatchItemsQuery = getAllDroppedWatchItemsQuery;
            _getDroppedWatchItemQuery = getDroppedWatchItemQuery;
            _createDroppedWatchItem = createDroppedWatchItem;
            _deleteDroppedWatchItem = deleteDroppedWatchItem;
            _updateDroppedWatchItem = updateDroppedWatchItem;
        }

        public CommandResult Create(DroppedWatchItemChange watchItem)
        {
            return _createDroppedWatchItem.Execute(new CreateDroppedWatchItemRequest(watchItem)).Result;
        }

        public CommandResult Delete(Guid id, Guid userId)
        {
            return _deleteDroppedWatchItem.Execute(new DeleteDroppedWatchItemRequest { Id = id, UserId = userId }).Result;
        }

        public DroppedWatchItem Get(Guid id, Guid userId)
        {
            return _getDroppedWatchItemQuery.Execute(new GetDroppedWatchItemRequest { Id = id, UserId = userId }).WatchItems;
        }

        public List<DroppedWatchItem> GetAll(Guid userId)
        {
            return _getAllDroppedWatchItemsQuery.Execute(new GetAllDroppedWatchItemsRequest { UserId = userId }).WatchItems;
        }

        public CommandResult Update(Guid id, Guid userId, DroppedWatchItemChange watchItem)
        {
            return _updateDroppedWatchItem.Execute(new UpdateDroppedWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem }).Result;
        }
    }
}