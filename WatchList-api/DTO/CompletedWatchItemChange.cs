using System;

namespace WatchList_api.DTO
{
    public class CompletedWatchItemChange
    {
        public Guid WatchItemId { get; set; }
        public Guid UserId { get; set; }
        public short Rating { get; set; }
    }
}
