using Microsoft.AspNetCore.Mvc;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroppedWatchItemController : GenericWatchItemController<DroppedWatchItem, DroppedWatchItemChange>
    {
        public DroppedWatchItemController(IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange> repository) : base(repository)
        {

        }
    }
}