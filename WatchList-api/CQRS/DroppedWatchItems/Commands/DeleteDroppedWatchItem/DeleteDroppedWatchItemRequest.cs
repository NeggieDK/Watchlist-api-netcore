using System;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.DeleteDroppedWatchItem
{
    public class DeleteDroppedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
    }
}
