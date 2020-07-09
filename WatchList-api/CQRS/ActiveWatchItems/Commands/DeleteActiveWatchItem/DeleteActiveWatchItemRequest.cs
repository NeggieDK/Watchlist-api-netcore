using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.DeleteActiveWatchItem
{
    public class DeleteActiveWatchItemRequest
    {
        public ActiveWatchItem WatchItem { get; set; }
    }
}
