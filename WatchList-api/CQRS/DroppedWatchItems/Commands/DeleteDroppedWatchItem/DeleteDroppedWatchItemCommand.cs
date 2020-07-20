using Dapper;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.DeleteDroppedWatchItem
{
    public class DeleteDroppedWatchItemCommand : ICommand<DeleteDroppedWatchItemRequest, DeleteDroppedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "dropped_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public DeleteDroppedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public DeleteDroppedWatchItemResponse Execute(DeleteDroppedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"DELETE FROM {SCHEMA}.{TABLE} " +
                    "WHERE id = @Id AND fk_user_id = @UserId";

                var result = conn.Execute(sql, new { Id = request.Id, UserId = request.UserId});
                return new DeleteDroppedWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
