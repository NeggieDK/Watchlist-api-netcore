using LightInject;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            //serviceRegistry.Register<IWatchItemRepository<PlannedWatchItem>, PlannedWatchItemRepository>();
            serviceRegistry.Register<IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>, ActiveWatchItemRepository>();
            serviceRegistry.Register<IDapperConnection, NpgsqlDapperConnection>();
            AutoRegisterManager.AutoRegisterFromInterface(serviceRegistry, typeof(IAutoRegisterQueryOrCommand));
        }
    }
}
