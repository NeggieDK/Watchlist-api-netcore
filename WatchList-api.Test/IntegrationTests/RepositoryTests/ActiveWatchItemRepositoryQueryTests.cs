using LightInject;
using System;
using System.Linq;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class ActiveWatchItemRepositoryQueryTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public ActiveWatchItemRepositoryQueryTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void GetAllTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>>();
            var result = await repo.GetAll(Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
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

        [Fact]
        public async void GetTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<ActiveWatchItem, ActiveWatchItemChange>>();

            var result = await repo.Get(Guid.Parse("c4b4cefa-e552-4310-ae7a-1a03d0d9c42d"), Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.Equal(Guid.Parse("c4b4cefa-e552-4310-ae7a-1a03d0d9c42d"), result.Id);
            Assert.Equal("Harry Potter", result.Title);
            Assert.Equal("fantasy", result.Genres[0]);
            Assert.Equal("adventure", result.Genres[1]);
            Assert.Equal(1, result.LastEpisodeWatched);
        }
    }
}