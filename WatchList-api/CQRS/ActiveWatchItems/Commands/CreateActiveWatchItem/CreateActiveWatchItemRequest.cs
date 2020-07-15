using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class CreateActiveWatchItemRequest
    {
        public CreateActiveWatchItemRequest(ActiveWatchItemChange watchItem)
        {
            WatchItem = watchItem;
        }
        public ActiveWatchItemChange WatchItem { get; set; }
    }
}
