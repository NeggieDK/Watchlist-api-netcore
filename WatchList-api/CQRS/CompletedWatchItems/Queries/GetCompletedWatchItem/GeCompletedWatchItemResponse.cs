using WatchList_api.DTO;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem
{
    public class GetCompletedWatchItemResponse
    {
        public CompletedWatchItem WatchItems { get; set; }
    }
}
