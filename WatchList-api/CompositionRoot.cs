using LightInject;
using WatchList_api.DTO;
using WatchList_api.Repositories;

namespace WatchList_api
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            //Here you can add the autoregister methods for the queries
            serviceRegistry.Register<IWatchItemRepository<PlannedWatchItem>, PlannedWatchItemRepository>();
        }
    }
}
