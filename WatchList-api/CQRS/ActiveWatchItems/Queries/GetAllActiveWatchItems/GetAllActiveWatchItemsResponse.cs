using System.Collections.Generic;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems
{
    public class GetAllActiveWatchItemsResponse : QueryResult
    {
        public GetAllActiveWatchItemsResponse()
        {
            WatchItems = new List<ActiveWatchItem>();
        }
        public List<ActiveWatchItem> WatchItems { get; set; }
    }
}
