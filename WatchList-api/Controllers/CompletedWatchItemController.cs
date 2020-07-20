using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompletedWatchItemController : GenericWatchItemController<CompletedWatchItem, CompletedWatchItemChange>
    {
        public CompletedWatchItemController(IWatchItemRepository<CompletedWatchItem, CompletedWatchItemChange> repository) : base(repository)
        {

        }
    }
}