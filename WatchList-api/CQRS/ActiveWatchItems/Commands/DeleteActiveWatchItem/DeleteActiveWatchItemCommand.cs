using Dapper;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Commands.DeleteActiveWatchItem
{
    public class DeleteActiveWatchItemCommand : ICommand<DeleteActiveWatchItemRequest, DeleteActiveWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "active_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public DeleteActiveWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<DeleteActiveWatchItemResponse> ExecuteAsync(DeleteActiveWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"DELETE FROM {SCHEMA}.{TABLE} " +
                    "WHERE id = @Id AND fk_user_id = @UserId";

                var result = await conn.ExecuteAsync(sql, new { Id = request.Id, UserId = request.UserId});
                return new DeleteActiveWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
