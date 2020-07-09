using System;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class CreateActiveWatchItemCommand : ICommand<CreateActiveWatchItemRequest, CreateActiveWatchItemResponse>
    {
        public CreateActiveWatchItemResponse Execute(CreateActiveWatchItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
