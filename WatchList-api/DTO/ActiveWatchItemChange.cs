using System;

namespace WatchList_api.DTO
{
    public class ActiveWatchItemChange
    {
        public Guid WatchItemId { get; set; }
        public Guid UserId { get; set; }
        public short LastEpisodeWatched { get; set; }
    }
}
