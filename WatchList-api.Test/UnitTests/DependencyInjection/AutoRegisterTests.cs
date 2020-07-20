using WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Test.IntegrationTests.Stubs;
using Xunit;

namespace WatchList.Test.UnitTests.DependencyInjection.AutoRegister
{
    public class AutoRegisterTests
    {
        [Fact]
        public void AutoRegisterQueryTest()
        {
            var container = new LightInject.ServiceContainer();
            container.RegisterFrom<CompositionRootStub>();
            var getAllActiveInstance = container.GetInstance(typeof(IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse>));
            Assert.Equal(typeof(GetAllActiveWatchItemsQuery), getAllActiveInstance.GetType());
            var getActiveInstance = container.GetInstance(typeof(IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>));
            Assert.Equal(typeof(GetActiveWatchItemQuery), getActiveInstance.GetType());
        }
    }
}
