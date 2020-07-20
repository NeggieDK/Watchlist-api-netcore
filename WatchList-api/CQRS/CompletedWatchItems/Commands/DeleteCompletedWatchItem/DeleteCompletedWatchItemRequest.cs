using System;

namespace WatchList_api.CQRS.CompletedWatchItems.Commands.DeleteCompletedWatchItem
{
    public class DeleteCompletedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
    }
}
