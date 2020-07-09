using System;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems
{
    public class GetAllActiveWatchItemsRequest
    {
        public Guid UserId { get; set; }
    }
}
