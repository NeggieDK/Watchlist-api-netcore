using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public ICommand<CreateActiveWatchItemRequest, CreateActiveWatchItemResponse> CreateActiveWatchItem => _createActiveWatchItem;

        public async Task<CommandResult> Create(ActiveWatchItemChange watchItem)
        {
            var result = await CreateActiveWatchItem.ExecuteAsync(new CreateActiveWatchItemRequest(watchItem));
            return result.Result;
        }

        public async Task<CommandResult> Delete(Guid id, Guid userId)
        {
            var result = await _deleteActiveWatchItem.ExecuteAsync(new DeleteActiveWatchItemRequest { Id = id, UserId = userId });
            return result.Result;
        }

        public async Task<ActiveWatchItem> Get(Guid id, Guid userId)
        {
            var result = await _getActiveWatchItemQuery.ExecuteAsync(new GetActiveWatchItemRequest { Id = id, UserId = userId });
            return result.WatchItems;
        }

        public async Task<List<ActiveWatchItem>> GetAll(Guid userId)
        {
            var result = await _getAllActiveWatchItemsQuery.ExecuteAsync(new GetAllActiveWatchItemsRequest { UserId = userId });
            return result.WatchItems;
        }

        public async Task<CommandResult> Update(Guid id, Guid userId, ActiveWatchItemChange watchItem)
        {
            var result = await _updateActiveWatchItem.ExecuteAsync(new UpdateActiveWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem });
            return result.Result;
        }
    }
}