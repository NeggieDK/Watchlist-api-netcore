using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Commands.DeleteCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem;
using WatchList_api.CQRS.CompletedWatchItems.Queries.GetAllCompletedWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;

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

        public CommandResult Create(CompletedWatchItemChange watchItem)
        {
            return _createCompletedWatchItem.Execute(new CreateCompletedWatchItemRequest(watchItem)).Result;
        }

        public CommandResult Delete(Guid id, Guid userId)
        {
            return _deleteCompletedWatchItem.Execute(new DeleteCompletedWatchItemRequest { Id = id, UserId = userId }).Result;
        }

        public CompletedWatchItem Get(Guid id, Guid userId)
        {
            return _getCompletedWatchItemQuery.Execute(new GetCompletedWatchItemRequest { Id = id, UserId = userId }).WatchItems;
        }

        public List<CompletedWatchItem> GetAll(Guid userId)
        {
            return _getAllCompletedWatchItemsQuery.Execute(new GetAllCompletedWatchItemsRequest { UserId = userId }).WatchItems;
        }

        public CommandResult Update(Guid id, Guid userId, CompletedWatchItemChange watchItem)
        {
            return _updateCompletedWatchItem.Execute(new UpdateCompletedWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem }).Result;
        }
    }
}