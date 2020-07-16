using System;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetPlannedWatchItem
{
    public class GetPlannedWatchItemRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
