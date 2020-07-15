using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public interface IWatchItemRepository<TQuery, TCommand> where TQuery : BaseWatchItem
    {
        public List<TQuery> GetAll(Guid userId);
        public TQuery Get(Guid id, Guid userId);
        public CommandResult Create(TCommand watchItem);
        public CommandResult Update(Guid id, Guid userId, TCommand watchItem);
        public CommandResult Delete(Guid id, Guid userId);
    }
}