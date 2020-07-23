﻿using LightInject;
using System;
using WatchList.IntegrationTests.Fixtures;
using WatchList_api.DTO;
using WatchList_api.Repositories;
using Xunit;

namespace WatchList.IntegrationTests.RepositoryTests
{
    public class DroppedWatchItemRepositoryCommandsTests : IClassFixture<IntegrationDbFixture>
    {
        private IntegrationDbFixture _fixture;
        public DroppedWatchItemRepositoryCommandsTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void CreateTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            var userGuid = Guid.NewGuid();

            var newWatchitem = new DroppedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Reason = "Awfull"
            };
            var result = await repo.Create(newWatchitem);
            _fixture.TrackGuid(result.Id.GetValueOrDefault());

            Assert.True(result.Success);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public async void DeleteTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            // Create temporary item
            var userGuid = Guid.NewGuid();

            var newWatchitem = new DroppedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Reason = "Offensive"
            };
            var tempResult = await repo.Create(newWatchitem);
            _fixture.TrackGuid(tempResult.Id.GetValueOrDefault());

            Assert.True(tempResult.Success);
            Assert.NotNull(tempResult.Id);

            var result = await repo.Delete(tempResult.Id.Value, userGuid);
            Assert.True(result.Success);
            Assert.Equal(tempResult.Id, result.Id);
        }

        [Fact]
        public async void DeleteNotExistTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            var result = await repo.Delete(Guid.NewGuid(), Guid.NewGuid());
            Assert.False(result.Success);
        }

        [Fact]
        public async void UpdateTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            // Create temporary item
            var userGuid = Guid.NewGuid();

            var newWatchitem = new DroppedWatchItemChange
            {
                WatchItemId = Guid.Parse("be0a64cb-545c-493e-8589-6bb43ac52e03"),
                UserId = userGuid,
                Reason = "Utter garbage"
            };
            var tempResult = await repo.Create(newWatchitem);
            _fixture.TrackGuid(tempResult.Id.GetValueOrDefault());

            Assert.True(tempResult.Success);
            Assert.NotNull(tempResult.Id);

            var result = await repo.Update(tempResult.Id.Value, userGuid, new DroppedWatchItemChange { Reason = "Normal Garbage" });
            Assert.True(result.Success);
            Assert.Equal(tempResult.Id, result.Id);
        }

        [Fact]
        public async void UpdateNotExistTest()
        {
            var repo = _fixture.Container.GetInstance<IWatchItemRepository<DroppedWatchItem, DroppedWatchItemChange>>();
            var result = await repo.Update(Guid.NewGuid(), Guid.NewGuid(), new DroppedWatchItemChange());
            Assert.False(result.Success);
        }
    }
}