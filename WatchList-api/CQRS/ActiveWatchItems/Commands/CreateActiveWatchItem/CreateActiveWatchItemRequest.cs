using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class CreateActiveWatchItemRequest
    {
        public ActiveWatchItem WatchItem { get; set; }
    }
}
