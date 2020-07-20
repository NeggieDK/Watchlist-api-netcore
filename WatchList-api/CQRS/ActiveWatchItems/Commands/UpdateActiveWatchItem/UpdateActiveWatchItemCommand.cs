using Dapper;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.CreateActiveWatchItem
{
    public class UpdateActiveWatchItemCommand : ICommand<UpdateActiveWatchItemRequest, UpdateActiveWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "active_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public UpdateActiveWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public UpdateActiveWatchItemResponse Execute(UpdateActiveWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"UPDATE {SCHEMA}.{TABLE} " +
                    $"SET last_episode_watched= @LastEpisodeWatched " +
                    $"WHERE id = @Id and fk_user_id = @UserId";

                var result = conn.Execute(sql, new { Id = request.Id, UserId = request.UserId, LastEpisodeWatched = request.WatchItem.LastEpisodeWatched });
                return new UpdateActiveWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
