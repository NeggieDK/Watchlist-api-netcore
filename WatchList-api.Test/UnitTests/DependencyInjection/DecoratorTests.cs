using LightInject;
using WatchList_api.CQRS;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem;
using WatchList_api.CQRS.Interfaces;
using Xunit;

namespace WatchList_api.Test.UnitTests.DependencyInjection
{
    public class DecoratorTests
    {
        [Fact]
        public void Test()
        {
            var container = new ServiceContainer();
            container.Register<IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>, GetActiveWatchItemQuery>();
            container.Decorate<IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>, QueryPerformanceDecorator<GetActiveWatchItemRequest, GetActiveWatchItemResponse>>();

            var instance = container.GetInstance<IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>>();
            Assert.Equal(typeof(QueryPerformanceDecorator<GetActiveWatchItemRequest, GetActiveWatchItemResponse>), instance.GetType());
        }
    }
}
