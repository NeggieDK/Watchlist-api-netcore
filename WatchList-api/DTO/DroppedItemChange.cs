using System;

namespace WatchList_api.DTO
{
    public class DroppedWatchItemChange
    {
        public Guid WatchItemId { get; set; }
        public Guid UserId { get; set; }
        public string Reason { get; set; }
    }
}
