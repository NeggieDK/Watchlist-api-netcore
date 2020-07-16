using System.Collections.Generic;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllPlannedWatchItems
{
    public class GetAllPlannedWatchItemsResponse
    {
        public GetAllPlannedWatchItemsResponse()
        {
            WatchItems = new List<PlannedWatchItem>();
        }
        public List<PlannedWatchItem> WatchItems { get; set; }
    }
}
