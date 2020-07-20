using System;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem
{
    public class GetCompletedWatchItemRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
