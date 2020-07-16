using System;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.CreatePlannedWatchItem
{
    public class UpdatePlannedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
        public PlannedWatchItemChange WatchItem { get; set; }
    }
}
