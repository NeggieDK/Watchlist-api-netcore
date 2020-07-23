using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    [Authorize]
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
            var userGuid = Guid.Parse(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            return _repository.GetAll(userGuid);
        }
        
        [HttpGet("{identifier}")]
        public virtual Task<TResult> Get(Guid identifier)
        {
            var userGuid = Guid.Parse(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            return _repository.Get(identifier, userGuid);
        }
        
        [HttpPost]
        public virtual void Create(TInput watchItem)
        {
            _repository.Create(watchItem);
        }
        
        [HttpPut("{identifier}")]
        public virtual void Update(Guid identifier, TInput watchItem)
        {
            var userGuid = Guid.Parse(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            _repository.Update(identifier, userGuid, watchItem);
        }
        
        [HttpDelete("{identifier}")]
        public virtual void Delete(Guid identifier)
        {
            var userGuid = Guid.Parse(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            _repository.Delete(identifier, userGuid);
        }
    }
}