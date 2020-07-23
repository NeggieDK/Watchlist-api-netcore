using Dapper;
using System;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class CreateActiveWatchItemCommand : ICommand<CreateActiveWatchItemRequest, CreateActiveWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "active_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public CreateActiveWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<CreateActiveWatchItemResponse> ExecuteAsync(CreateActiveWatchItemRequest request)
        {
            var inputItem = request.WatchItem;
            if (inputItem == null) return new CreateActiveWatchItemResponse { Result = new CommandResult(false, null) };
            using (var conn = _connection.GetConnection())
            {
                var sql = $"INSERT INTO {SCHEMA}.{TABLE} (id, fk_watch_items, fk_user_id, last_episode_watched) " +
                    $"VALUES(@Id, @WatchItemid, @UserId, @LastEpisodeWatched)";

                var id = Guid.NewGuid();
                var result = await conn.ExecuteAsync(sql, new { Id = id, WatchItemId = inputItem.WatchItemId, UserId = inputItem.UserId, LastEpisodeWatched = inputItem.LastEpisodeWatched });
                return new CreateActiveWatchItemResponse { Result = new CommandResult(result == 1, id) };
            }
        }
    }
}
