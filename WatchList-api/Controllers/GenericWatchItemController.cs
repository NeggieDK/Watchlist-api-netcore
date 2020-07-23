using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    public abstract class GenericWatchItemController<TResult, TInput> : Controller where TResult : BaseWatchItem
    {
        private readonly IWatchItemRepository<TResult, TInput> _repository;

        protected GenericWatchItemController(IWatchItemRepository<TResult, TInput> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual Task<List<TResult>> GetAll()
        {
            return _repository.GetAll(Guid.NewGuid());
        }
        
        [HttpGet("{identifier}")]
        public virtual Task<TResult> Get(string identifier)
        {
            return _repository.Get(Guid.NewGuid(), Guid.NewGuid());
        }
        
        [HttpPost]
        public virtual void Create(TInput watchItem)
        {
            _repository.Create(watchItem);
        }
        
        [HttpPut("{identifier}")]
        public virtual void Update(Guid identifier, TInput watchItem)
        {
            _repository.Update(identifier, Guid.NewGuid(), watchItem);
        }
        
        [HttpDelete("{identifier}")]
        public virtual void Delete(Guid identifier)
        {
            //Get Guid from object
            var userGuid = Guid.NewGuid();
            _repository.Delete(identifier, userGuid);
        }
    }
}