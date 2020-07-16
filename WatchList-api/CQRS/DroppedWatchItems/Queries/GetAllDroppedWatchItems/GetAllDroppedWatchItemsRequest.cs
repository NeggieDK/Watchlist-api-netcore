using System;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetAllDroppedWatchItems
{
    public class GetAllDroppedWatchItemsRequest
    {
        public Guid UserId { get; set; }
    }
}
