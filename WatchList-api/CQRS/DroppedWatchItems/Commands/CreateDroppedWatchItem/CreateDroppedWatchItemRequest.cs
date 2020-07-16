using WatchList_api.DTO;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem
{
    public class CreateDroppedWatchItemRequest
    {
        public CreateDroppedWatchItemRequest(DroppedWatchItemChange watchItem)
        {
            WatchItem = watchItem;
        }
        public DroppedWatchItemChange WatchItem { get; set; }
    }
}
