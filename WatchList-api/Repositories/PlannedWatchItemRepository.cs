using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchList_api.CQRS;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllPlannedWatchItems;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetPlannedWatchItem;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.CQRS.PlannedWatchItems.Commands.CreatePlannedWatchItem;
using WatchList_api.CQRS.PlannedWatchItems.Commands.DeletePlannedWatchItem;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public class PlannedWatchItemRepository : IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>
    {
        private readonly IQuery<GetAllPlannedWatchItemsRequest, GetAllPlannedWatchItemsResponse> _getAllPlannedWatchItemsQuery;
        private readonly IQuery<GetPlannedWatchItemRequest, GetPlannedWatchItemResponse> _getPlannedWatchItemQuery;
        private readonly ICommand<CreatePlannedWatchItemRequest, CreatePlannedWatchItemResponse> _createPlannedWatchItem;
        private readonly ICommand<DeletePlannedWatchItemRequest, DeletePlannedWatchItemResponse> _deletePlannedWatchItem;
        private readonly ICommand<UpdatePlannedWatchItemRequest, UpdatePlannedWatchItemResponse> _updatePlannedWatchItem;

        public PlannedWatchItemRepository(IQuery<GetAllPlannedWatchItemsRequest, GetAllPlannedWatchItemsResponse> getAllPlannedWatchItemsQuery, IQuery<GetPlannedWatchItemRequest, GetPlannedWatchItemResponse> getPlannedWatchItemQuery, ICommand<CreatePlannedWatchItemRequest, CreatePlannedWatchItemResponse> createPlannedWatchItem, ICommand<DeletePlannedWatchItemRequest, DeletePlannedWatchItemResponse> deletePlannedWatchItem, ICommand<UpdatePlannedWatchItemRequest, UpdatePlannedWatchItemResponse> updatePlannedWatchItem)
        {
            _getAllPlannedWatchItemsQuery = getAllPlannedWatchItemsQuery;
            _getPlannedWatchItemQuery = getPlannedWatchItemQuery;
            _createPlannedWatchItem = createPlannedWatchItem;
            _deletePlannedWatchItem = deletePlannedWatchItem;
            _updatePlannedWatchItem = updatePlannedWatchItem;
        }

        public CommandResult Create(PlannedWatchItemChange watchItem)
        {
            return _createPlannedWatchItem.Execute(new CreatePlannedWatchItemRequest(watchItem)).Result;
        }

        public CommandResult Delete(Guid id, Guid userId)
        {
            return _deletePlannedWatchItem.Execute(new DeletePlannedWatchItemRequest { Id = id, UserId = userId }).Result;
        }

        public Task<PlannedWatchItem> Get(Guid id, Guid userId)
        {
            var result = await _getPlannedWatchItemQuery.ExecuteAsync(new GetPlannedWatchItemRequest { Id = id, UserId = userId });
            return result.WatchItems;
        }

        public async Task<List<PlannedWatchItem>> GetAll(Guid userId)
        {
            return _getAllPlannedWatchItemsQuery.Execute(new GetAllPlannedWatchItemsRequest { UserId = userId }).WatchItems;
        }

        public CommandResult Update(Guid id, Guid userId, PlannedWatchItemChange watchItem)
        {
            return _updatePlannedWatchItem.Execute(new UpdatePlannedWatchItemRequest { Id = id, UserId = userId, WatchItem = watchItem }).Result;
        }
    }
}