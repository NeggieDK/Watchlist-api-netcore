using System;
using System.Collections.Generic;
using WatchList_api.DTO;

namespace WatchList_api.Repositories
{
    public interface IWatchItemRepository<T> where T : BaseWatchItem
    {
        public List<T> GetAll(Guid userId);
        public T Get(Guid id, Guid userId);
        public int Create(T watchItem);
        public int Update(Guid userId, T watchItem);
        public int Delete(Guid index);
    }
}