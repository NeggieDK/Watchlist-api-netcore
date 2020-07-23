using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchList_api.CQRS;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public interface IWatchItemRepository<TInput, TResult> where TInput : BaseWatchItem
    {
        public Task<List<TInput>> GetAll(Guid userId);
        public Task<TInput> Get(Guid id, Guid userId);
        public Task<CommandResult> Create(TResult watchItem);
        public Task<CommandResult> Update(Guid id, Guid userId, TResult watchItem);
        public Task<CommandResult> Delete(Guid id, Guid userId);
    }
}