using System;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem
{
    public class UpdateDroppedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
        public DroppedWatchItemChange WatchItem { get; set; }
    }
}
