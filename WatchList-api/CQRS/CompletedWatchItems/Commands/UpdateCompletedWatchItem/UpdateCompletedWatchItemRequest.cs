using System;
using WatchList_api.DTO;

namespace WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem
{
    public class UpdateCompletedWatchItemRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
        public CompletedWatchItemChange WatchItem { get; set; }
    }
}
