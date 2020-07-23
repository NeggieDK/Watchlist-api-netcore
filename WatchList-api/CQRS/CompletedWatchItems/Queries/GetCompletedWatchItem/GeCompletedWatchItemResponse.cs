using WatchList_api.DTO;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem
{
    public class GetCompletedWatchItemResponse : QueryResult
    {
        public CompletedWatchItem WatchItems { get; set; }
    }
}
