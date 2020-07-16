using System;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllPlannedWatchItems
{
    public class GetAllPlannedWatchItemsRequest
    {
        public Guid UserId { get; set; }
    }
}
