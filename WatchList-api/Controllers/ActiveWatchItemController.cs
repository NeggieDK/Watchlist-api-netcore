using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActiveWatchItemController : GenericWatchItemController<ActiveWatchItem, ActiveWatchItemChange>
    {
        public ActiveWatchItemController(IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange> repository) : base(repository)
        {

        }
    }
}