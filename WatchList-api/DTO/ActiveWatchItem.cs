using System;

namespace WatchList_api.DTO
{
    public class ActiveWatchItem : BaseWatchItem
    {
        public int? LastEpisodeWatched { get; set; }
    }
}