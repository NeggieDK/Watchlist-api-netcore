using System.Linq;
using WatchList.IntegrationTests.Stubs;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;
using Xunit;

namespace WatchList_api.Test.UnitTests.DependencyInjection.AutoRegister
{
    public class AutoRegisterTests
    {
        [Fact]
        public void Test()
        {
            var registeredTypes = typeof(Startup)
               .Assembly
               .GetTypes().Where(i => typeof(IAutoRegisterQueryOrCommand).IsAssignableFrom(i));

            var container = new LightInject.ServiceContainer();
            container.Register<IDapperConnection, IntegrationSqlConnection>();
            foreach(var regType in registeredTypes)
            {
                var interfaceTypes = regType.GetInterfaces();
                foreach(var intType in interfaceTypes)
                {
                    if (intType.Name == nameof(IAutoRegisterQueryOrCommand)) continue;
                    container.Register(intType, regType);
                }
            }
            var instance = container.GetInstance(typeof(IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse>));
            Assert.Equal(typeof(GetAllActiveWatchItemsQuery), instance.GetType());
        }
    }
}
