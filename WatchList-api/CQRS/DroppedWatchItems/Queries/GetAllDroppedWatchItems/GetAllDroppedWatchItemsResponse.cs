using System.Collections.Generic;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetAllDroppedWatchItems
{
    public class GetAllDroppedWatchItemsResponse
    {
        public GetAllDroppedWatchItemsResponse()
        {
            WatchItems = new List<DroppedWatchItem>();
        }
        public List<DroppedWatchItem> WatchItems { get; set; }
    }
}
