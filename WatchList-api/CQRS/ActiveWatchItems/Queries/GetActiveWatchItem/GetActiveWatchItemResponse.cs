﻿using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem
{
    public class GetActiveWatchItemResponse
    {
        public ActiveWatchItem WatchItems { get; set; }
    }
}
