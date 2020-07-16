using LightInject;
using System;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class PlannedWatchItemRepositoryCommandsTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public PlannedWatchItemRepositoryCommandsTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            var userGuid = Guid.NewGuid();

            var newWatchitem = new PlannedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Priority = 9
            };
            var result = repo.Create(newWatchitem);
            _fixture.TrackGuid(result.Id.GetValueOrDefault());

            Assert.True(result.Success);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void DeleteTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            // Create temporary item
            var userGuid = Guid.NewGuid();

            var newWatchitem = new PlannedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Priority = 9
            };
            var tempResult = repo.Create(newWatchitem);
            _fixture.TrackGuid(tempResult.Id.GetValueOrDefault());

            Assert.True(tempResult.Success);
            Assert.NotNull(tempResult.Id);

            var result = repo.Delete(tempResult.Id.Value, userGuid);
            Assert.True(result.Success);
            Assert.Equal(tempResult.Id, result.Id);
        }

        [Fact]
        public void DeleteNotExistTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            var result = repo.Delete(Guid.NewGuid(), Guid.NewGuid());
            Assert.False(result.Success);
        }

        [Fact]
        public void UpdateTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            // Create temporary item
            var userGuid = Guid.NewGuid();

            var newWatchitem = new PlannedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Priority = 9
            };
            var tempResult = repo.Create(newWatchitem);
            _fixture.TrackGuid(tempResult.Id.GetValueOrDefault());

            Assert.True(tempResult.Success);
            Assert.NotNull(tempResult.Id);

            var result = repo.Update(tempResult.Id.Value, userGuid, new PlannedWatchItemChange { Priority = 5 });
            Assert.True(result.Success);
            Assert.Equal(tempResult.Id, result.Id);
        }

        [Fact]
        public void UpdateNotExistTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<PlannedWatchItem, PlannedWatchItemChange>>();
            var result = repo.Update(Guid.NewGuid(), Guid.NewGuid(), new PlannedWatchItemChange());
            Assert.False(result.Success);
        }
    }
}