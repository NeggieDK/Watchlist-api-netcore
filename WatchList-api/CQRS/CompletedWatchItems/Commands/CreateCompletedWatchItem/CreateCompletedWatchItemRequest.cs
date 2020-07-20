using WatchList_api.DTO;

namespace WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem
{
    public class CreateCompletedWatchItemRequest
    {
        public CreateCompletedWatchItemRequest(CompletedWatchItemChange watchItem)
        {
            WatchItem = watchItem;
        }
        public CompletedWatchItemChange WatchItem { get; set; }
    }
}
