using System;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetAllCompletedWatchItems
{
    public class GetAllCompletedWatchItemsRequest
    {
        public Guid UserId { get; set; }
    }
}
