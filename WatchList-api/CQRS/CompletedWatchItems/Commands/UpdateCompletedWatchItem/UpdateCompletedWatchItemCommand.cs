using Dapper;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem
{
    public class UpdateCompletedWatchItemCommand : ICommand<UpdateCompletedWatchItemRequest, UpdateCompletedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "completed_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public UpdateCompletedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<UpdateCompletedWatchItemResponse> ExecuteAsync(UpdateCompletedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"UPDATE {SCHEMA}.{TABLE} " +
                    $"SET rating = @Rating " +
                    $"WHERE id = @Id and fk_user_id = @UserId";

                var result = await conn.ExecuteAsync(sql, new { Id = request.Id, UserId = request.UserId, LastEpisodeWatched = request.WatchItem.Rating });
                return new UpdateCompletedWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
