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
        public virtual TResult Get(string identifier)
        {
            return _repository.Get(Guid.Parse(identifier), Guid.NewGuid());
        }
        
        [HttpPost]
        public virtual void Create(TInput watchItem)
        {
            _repository.Create(watchItem);
        }
        
        [HttpPut]
        public virtual void Update(TInput watchItem)
        {
            _repository.Update(Guid.NewGuid(), Guid.NewGuid(), watchItem);
        }
        
        [HttpDelete]
        public virtual void Delete(Guid id)
        {
            //Get Guid from object
            var userGuid = Guid.NewGuid();
            _repository.Delete(id, userGuid);
        }
    }
}