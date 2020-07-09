using System;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem
{
    public class GetActiveWatchItemRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
