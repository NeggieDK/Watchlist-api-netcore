using LightInject;
using System;
using System.Linq;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class DroppedWatchItemRepositoryQueryTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public DroppedWatchItemRepositoryQueryTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetAllTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            var result = repo.GetAll(Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();
            Assert.Equal("Claymore", firstResult.Title);
            Assert.Equal(Guid.Parse("28e0e40f-8af3-4b42-8873-242d9b42bbc1"), firstResult.Id);
            Assert.NotEqual(DateTime.MinValue, firstResult.CreatedAt.ToUniversalTime());
            Assert.Equal("bad", firstResult.Reason);

            var genres = firstResult.Genres.ToList();
            Assert.NotEmpty(genres);
            Assert.Equal("anime", genres[0]);
            Assert.Equal("horror", genres[1]);
        }

        [Fact]
        public void GetTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();

            var result = repo.Get(Guid.Parse("28e0e40f-8af3-4b42-8873-242d9b42bbc1"), Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.Equal(Guid.Parse("28e0e40f-8af3-4b42-8873-242d9b42bbc1"), result.Id);
            Assert.Equal("Claymore", result.Title);
            Assert.Equal("anime", result.Genres[0]);
            Assert.Equal("horror", result.Genres[1]);
            Assert.Equal("bad", result.Reason);
        }
    }
}