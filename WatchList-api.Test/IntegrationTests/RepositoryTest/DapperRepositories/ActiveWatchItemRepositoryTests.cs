using System;
using System.Linq;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTest
{
    public class ActiveWatchItemRepositoryTests : IClassFixture<IntegrationSqlDatabaseFixture>
    {
        private IntegrationSqlDatabaseFixture _fixture;
        public ActiveWatchItemRepositoryTests(IntegrationSqlDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetAllTest()
        {
            var query = new GetAllActiveWatchItemsQuery(_fixture.connection);
            var repo = new ActiveWatchItemRepository(query);
            var result = repo.GetAll(Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();
            Assert.Equal("Harry Potter", firstResult.Title);
            Assert.Equal(Guid.Parse("c4b4cefa-e552-4310-ae7a-1a03d0d9c42d"), firstResult.Id);
            Assert.NotEqual(DateTime.MinValue, firstResult.CreatedAt.ToUniversalTime());

            var genres = firstResult.Genres.ToList();
            Assert.NotEmpty(genres);
            Assert.Equal("fantasy", genres[0]);
            Assert.Equal("adventure", genres[1]);
        }
    }
}