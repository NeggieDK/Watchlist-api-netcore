using Dapper;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem
{
    public class UpdateDroppedWatchItemCommand : ICommand<UpdateDroppedWatchItemRequest, UpdateDroppedWatchItemResponse>, IAutoRegisterQueryOrCommand
    {
        private const string TABLE = "dropped_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public UpdateDroppedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public UpdateDroppedWatchItemResponse Execute(UpdateDroppedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"UPDATE {SCHEMA}.{TABLE} " +
                    $"SET reason = @Reason " +
                    $"WHERE id = @Id and fk_user_id = @UserId";

                var result = conn.Execute(sql, new { Id = request.Id, UserId = request.UserId, Reason = request.WatchItem.Reason });
                return new UpdateDroppedWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
