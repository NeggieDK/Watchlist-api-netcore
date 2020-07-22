using Dapper;
using Npgsql;
using System;
using System.Net.Sockets;
using WatchList.IntegrationTests.Fixtures;
using WatchList.IntegrationTests.Stubs;
using Xunit;

namespace WatchList_api.Test.IntegrationTests.ExceptionHandlingTests
{
    public class SQLExceptionTests : IClassFixture<IntegrationDbFixture>
    {

        private IntegrationDbFixture _fixture;
        public SQLExceptionTests(IntegrationDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ViolatesUniqueConstraintThrowsExceptionTest()
        {
            using (var conn = _fixture.Connection.GetConnection())
            {
                 var sql = $"INSERT INTO public.active_watch_items (id, fk_watch_items, fk_user_id, last_episode_watched) " +
                    $"VALUES(@Id, @WatchItemid, @UserId, @LastEpisodeWatched)";

                var id = Guid.Parse("c4b4cefa-e552-4310-ae7a-1a03d0d9c42d");
                Assert.Throws<PostgresException>(() => conn.Execute(sql, new { Id = id, WatchItemId = Guid.NewGuid(), UserId = Guid.NewGuid(), LastEpisodeWatched = 1 }));
            }
        }

        [Fact]
        public void BrokenConnectionTest()
        {
            var connection = new BrokenConnectionStub().GetConnection();
            Assert.Throws<SocketException>(() => connection.Open());
        }
    }
}
