using LightInject;
using WatchList.IntegrationTests.Stubs;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.Test.IntegrationTests.Stubs
{
    public class CompositionRootStub : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>, ActiveWatchItemRepository>();
            serviceRegistry.Register<IDapperConnection, IntegrationConnection>();
            AutoRegisterManager.AutoRegisterFromInterface(serviceRegistry, typeof(IAutoRegisterQueryOrCommand));
        }
    }
}
