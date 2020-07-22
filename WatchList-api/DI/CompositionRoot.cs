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

            serviceRegistry.Register<IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>, ActiveWatchItemRepository>();
            serviceRegistry.Register<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>, PlannedWatchItemRepository>();
            serviceRegistry.Register<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>, DroppedWatchItemRepository>();
            serviceRegistry.Register<IWatchItemRepository<CompletedWatchItem, CompletedWatchItemChange>, CompletedWatchItemRepository>();
            serviceRegistry.Register<IDapperConnection, NpgsqlDapperConnection>();
            AutoRegisterManager.AutoRegisterIQuery(serviceRegistry, true);
            AutoRegisterManager.AutoRegisterICommand(serviceRegistry, true);
        }
    }
}
