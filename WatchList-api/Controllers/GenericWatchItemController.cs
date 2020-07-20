using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
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
        public virtual List<TResult> GetAll()
        {
            return _repository.GetAll(Guid.NewGuid());
        }
        
        [HttpGet("/{identifier}")]
        public virtual TResult Get(Guid identifier)
        {
            return _repository.Get(identifier, Guid.NewGuid());
        }
        
        [HttpPost]
        public virtual void Create(TInput watchItem)
        {
            _repository.Create(watchItem);
        }
        
        [HttpPut("/{identifier}")]
        public virtual void Update(Guid identifier, TInput watchItem)
        {
            _repository.Update(identifier, Guid.NewGuid(), watchItem);
        }
        
        [HttpDelete("/{identifier}")]
        public virtual void Delete(Guid identifier)
        {
            //Get Guid from object
            var userGuid = Guid.NewGuid();
            _repository.Delete(identifier, userGuid);
        }
    }
}