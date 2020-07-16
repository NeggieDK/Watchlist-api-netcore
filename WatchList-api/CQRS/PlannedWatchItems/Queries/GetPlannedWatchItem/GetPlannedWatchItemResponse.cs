using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetPlannedWatchItem
{
    public class GetPlannedWatchItemResponse
    {
        public PlannedWatchItem WatchItems { get; set; }
    }
}
