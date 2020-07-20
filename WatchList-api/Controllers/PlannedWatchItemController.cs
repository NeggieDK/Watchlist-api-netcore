using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlannedWatchItemController : GenericWatchItemController<PlannedWatchItem, PlannedWatchItemChange>
    {
        public PlannedWatchItemController(IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange> repository) : base(repository)
        {

        }
    }
}