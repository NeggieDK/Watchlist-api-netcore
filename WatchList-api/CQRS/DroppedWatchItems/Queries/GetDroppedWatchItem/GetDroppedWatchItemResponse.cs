using WatchList_api.DTO;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetDroppedWatchItem
{
    public class GetDroppedWatchItemResponse
    {
        public DroppedWatchItem WatchItems { get; set; }
    }
}
