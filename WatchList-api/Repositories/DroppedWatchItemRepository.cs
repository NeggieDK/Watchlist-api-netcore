using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Commands.DeleteDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Queries.GetDroppedWatchItem;
using WatchList_api.CQRS.DroppedWatchItems.Queries.GetAllDroppedWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using System.Threading.Tasks;

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

        public async Task<CommandResult> Create(DroppedWatchItemChange watchItem)
        {
            var result = await _createDroppedWatchItem.ExecuteAsync(new CreateDroppedWatchItemRequest(watchItem));
            return result.Result;
        }

        public async Task<CommandResult> Delete(Guid id, Guid userId)
        {
            var result = await _deleteDroppedWatchItem.ExecuteAsync(new DeleteDroppedWatchItemRequest { Id = id, UserId = userId });
            return result.Result;
        }

        public async Task<DroppedWatchItem> Get(Guid id, Guid userId)
        {
            var result = await _getDroppedWatchItemQuery.ExecuteAsync(new GetDroppedWatchItemRequest { Id = id, UserId = userId });
            return result.WatchItems;
        }

        public async Task<List<DroppedWatchItem>> GetAll(Guid userId)
        {
            var result = await _getAllDroppedWatchItemsQuery.ExecuteAsync(new GetAllDroppedWatchItemsRequest { UserId = userId });
            return result.WatchItems;
        }

        public async Task<CommandResult> Update(Guid id, Guid userId, DroppedWatchItemChange watchItem)
        {
            var result = await _updateDroppedWatchItem.ExecuteAsync(new UpdateDroppedWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem });
            return result.Result;
        }
    }
}