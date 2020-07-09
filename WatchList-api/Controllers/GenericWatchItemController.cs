using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    public abstract class GenericWatchItemController<T> : Controller where T : BaseWatchItem
    {
        private readonly IWatchItemRepository<T> _repository;

        protected GenericWatchItemController(IWatchItemRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual List<T> GetAll()
        {
            return _repository.GetAll(Guid.NewGuid());
        }
        
        [HttpGet("/{identifier}")]
        public virtual T Get(string identifier)
        {
            return _repository.Get(Guid.Parse(identifier), Guid.NewGuid());
        }
        
        [HttpPost]
        public virtual void Create(T watchItem)
        {
            _repository.Create(watchItem);
        }
        
        [HttpPut]
        public virtual void Update(T watchItem)
        {
            _repository.Update(Guid.NewGuid(), watchItem);
        }
        
        [HttpDelete]
        public virtual void Delete(Guid index)
        {
            _repository.Delete(index);
        }
    }
}