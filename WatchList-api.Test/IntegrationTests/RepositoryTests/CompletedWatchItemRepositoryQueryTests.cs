using LightInject;
using System;
using System.Linq;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class CompletedWatchItemRepositoryQueryTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public CompletedWatchItemRepositoryQueryTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void GetAllTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<CompletedWatchItem, CompletedWatchItemChange>>();
            var result = await repo.GetAll(Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();
            Assert.Equal("Harry Potter", firstResult.Title);
            Assert.Equal(Guid.Parse("7e97cab0-6a1c-4085-99e6-2a9a6ac07a92"), firstResult.Id);
            Assert.NotEqual(DateTime.MinValue, firstResult.CreatedAt.ToUniversalTime());
            Assert.Equal(9, firstResult.Rating);

            var genres = firstResult.Genres.ToList();
            Assert.NotEmpty(genres);
            Assert.Equal("fantasy", genres[0]);
            Assert.Equal("adventure", genres[1]);
        }

        [Fact]
        public async void GetTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<CompletedWatchItem, CompletedWatchItemChange>>();

            var result = await repo.Get(Guid.Parse("7e97cab0-6a1c-4085-99e6-2a9a6ac07a92"), Guid.Parse("79137da8-4040-428b-b64f-705d54aaf256"));
            Assert.NotNull(result);
            Assert.Equal(Guid.Parse("7e97cab0-6a1c-4085-99e6-2a9a6ac07a92"), result.Id);
            Assert.Equal("Harry Potter", result.Title);
            Assert.Equal("fantasy", result.Genres[0]);
            Assert.Equal("adventure", result.Genres[1]);
            Assert.Equal(9, result.Rating);
        }
    }
}