using System;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.DeleteActiveWatchItem
{
    public class DeleteActiveWatchItemCommand : ICommand<DeleteActiveWatchItemRequest, DeleteActiveWatchItemResponse>
    {
        public DeleteActiveWatchItemResponse Execute(DeleteActiveWatchItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
