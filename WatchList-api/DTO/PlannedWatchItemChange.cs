using System;

namespace WatchList_api.DTO
{
    public class PlannedWatchItemChange
    {
        public Guid WatchItemId { get; set; }
        public Guid UserId { get; set; }
        public short Priority { get; set; }
    }
}
