using System;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.DeletePlannedWatchItem
{
    public class DeletePlannedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
    }
}
