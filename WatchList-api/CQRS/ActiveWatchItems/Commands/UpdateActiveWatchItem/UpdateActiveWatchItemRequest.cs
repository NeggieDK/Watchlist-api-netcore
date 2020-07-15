using System;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class UpdateActiveWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
        public ActiveWatchItemChange WatchItem { get; set; }
    }
}
