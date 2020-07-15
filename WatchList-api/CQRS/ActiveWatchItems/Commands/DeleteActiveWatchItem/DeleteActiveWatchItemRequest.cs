using System;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.DeleteActiveWatchItem
{
    public class DeleteActiveWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
    }
}
