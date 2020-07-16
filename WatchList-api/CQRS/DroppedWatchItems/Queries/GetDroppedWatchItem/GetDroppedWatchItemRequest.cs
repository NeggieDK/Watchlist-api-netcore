using System;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetDroppedWatchItem
{
    public class GetDroppedWatchItemRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
