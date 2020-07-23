using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Commands.DeleteCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Queries.GetAllCompletedWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using System.Threading.Tasks;

namespace WatchList_api.Repositories
{
    public class CompletedWatchItemRepository : IWatchItemRepository<CompletedWatchItem, CompletedWatchItemChange>
    {
        private readonly IQuery<GetAllCompletedWatchItemsRequest, GetAllCompletedWatchItemsResponse> _getAllCompletedWatchItemsQuery;
        private readonly IQuery<GetCompletedWatchItemRequest, GetCompletedWatchItemResponse> _getCompletedWatchItemQuery;
        private readonly ICommand<CreateCompletedWatchItemRequest, CreateCompletedWatchItemResponse> _createCompletedWatchItem;
        private readonly ICommand<DeleteCompletedWatchItemRequest, DeleteCompletedWatchItemResponse> _deleteCompletedWatchItem;
        private readonly ICommand<UpdateCompletedWatchItemRequest, UpdateCompletedWatchItemResponse> _updateCompletedWatchItem;

        public CompletedWatchItemRepository(IQuery<GetAllCompletedWatchItemsRequest, GetAllCompletedWatchItemsResponse> getAllCompletedWatchItemsQuery, IQuery<GetCompletedWatchItemRequest, GetCompletedWatchItemResponse> getCompletedWatchItemQuery, ICommand<CreateCompletedWatchItemRequest, CreateCompletedWatchItemResponse> createCompletedWatchItem, ICommand<DeleteCompletedWatchItemRequest, DeleteCompletedWatchItemResponse> deleteCompletedWatchItem, ICommand<UpdateCompletedWatchItemRequest, UpdateCompletedWatchItemResponse> updateCompletedWatchItem)
        {
            _getAllCompletedWatchItemsQuery = getAllCompletedWatchItemsQuery;
            _getCompletedWatchItemQuery = getCompletedWatchItemQuery;
            _createCompletedWatchItem = createCompletedWatchItem;
            _deleteCompletedWatchItem = deleteCompletedWatchItem;
            _updateCompletedWatchItem = updateCompletedWatchItem;
        }

        public async Task<CommandResult> Create(CompletedWatchItemChange watchItem)
        {
            var result = await _createCompletedWatchItem.ExecuteAsync(new CreateCompletedWatchItemRequest(watchItem));
            return result.Result;
        }

        public async Task<CommandResult> Delete(Guid id, Guid userId)
        {
            var result = await _deleteCompletedWatchItem.ExecuteAsync(new DeleteCompletedWatchItemRequest { Id = id, UserId = userId });
            return result.Result;
        }

        public async Task<CompletedWatchItem> Get(Guid id, Guid userId)
        {
            var result = await _getCompletedWatchItemQuery.ExecuteAsync(new GetCompletedWatchItemRequest { Id = id, UserId = userId });
            return result.WatchItems;
        }

        public async Task<List<CompletedWatchItem>> GetAll(Guid userId)
        {
            var result = await _getAllCompletedWatchItemsQuery.ExecuteAsync(new GetAllCompletedWatchItemsRequest { UserId = userId });
            return result.WatchItems;
        }

        public async Task<CommandResult> Update(Guid id, Guid userId, CompletedWatchItemChange watchItem)
        {
            var result = await _updateCompletedWatchItem.ExecuteAsync(new UpdateCompletedWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem });
            return result.Result;
        }
    }
}