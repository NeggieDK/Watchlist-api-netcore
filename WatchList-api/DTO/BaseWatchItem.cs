using System;
using System.Collections.Generic;

namespace WatchList_api.DTO
{
    public class BaseWatchItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string[] Genres { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
