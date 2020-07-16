using WatchList_api.DTO;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.CreatePlannedWatchItem
{
    public class CreatePlannedWatchItemRequest
    {
        public CreatePlannedWatchItemRequest(PlannedWatchItemChange watchItem)
        {
            WatchItem = watchItem;
        }
        public PlannedWatchItemChange WatchItem { get; set; }
    }
}
