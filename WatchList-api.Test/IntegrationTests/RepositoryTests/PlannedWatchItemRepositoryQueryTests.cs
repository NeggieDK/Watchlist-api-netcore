using LightInject;
using System;
using System.Linq;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class PlannedWatchItemRepositoryQueryTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public PlannedWatchItemRepositoryQueryTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void GetAllTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            var result = await repo.GetAll(Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();
            Assert.Equal("Harry Potter", firstResult.Title);
            Assert.Equal(Guid.Parse("63eeabf0-3669-449b-aa80-22db40ae7af1"), firstResult.Id);
            Assert.NotEqual(DateTime.MinValue, firstResult.CreatedAt.ToUniversalTime());
            Assert.Equal(1, firstResult.Priority);

            var genres = firstResult.Genres.ToList();
            Assert.NotEmpty(genres);
            Assert.Equal("fantasy", genres[0]);
            Assert.Equal("adventure", genres[1]);
         
        }

        [Fact]
        public async void GetTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();

            var result = await repo.Get(Guid.Parse("63eeabf0-3669-449b-aa80-22db40ae7af1"), Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.Equal(Guid.Parse("63eeabf0-3669-449b-aa80-22db40ae7af1"), result.Id);
            Assert.Equal("Harry Potter", result.Title);
            Assert.Equal("fantasy", result.Genres[0]);
            Assert.Equal("adventure", result.Genres[1]);
            Assert.Equal(1, result.Priority);
        }
    }
}