using System;
using System.Collections.Generic;
using WatchList_api.CQRS;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public interface IWatchItemRepository<TInput, TResult> where TInput : BaseWatchItem
    {
        public List<TInput> GetAll(Guid userId);
        public TInput Get(Guid id, Guid userId);
        public CommandResult Create(TInput watchItem);
        public CommandResult Update(Guid id, Guid userId, TInput watchItem);
        public CommandResult Delete(Guid id, Guid userId);
    }
}