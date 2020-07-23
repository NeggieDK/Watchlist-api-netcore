using System.Collections.Generic;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetAllCompletedWatchItems
{
    public class GetAllCompletedWatchItemsResponse : QueryResult
    {
        public GetAllCompletedWatchItemsResponse()
        {
            WatchItems = new List<CompletedWatchItem>();
        }
        public List<CompletedWatchItem> WatchItems { get; set; }
    }
}
