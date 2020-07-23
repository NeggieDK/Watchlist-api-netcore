using Dapper;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.DeletePlannedWatchItem
{
    public class DeletePlannedWatchItemCommand : ICommand<DeletePlannedWatchItemRequest, DeletePlannedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "planned_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public DeletePlannedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<DeletePlannedWatchItemResponse> ExecuteAsync(DeletePlannedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"DELETE FROM {SCHEMA}.{TABLE} " +
                    "WHERE id = @Id AND fk_user_id = @UserId";

                var result = await conn.ExecuteAsync(sql, new { Id = request.Id, UserId = request.UserId});
                return new DeletePlannedWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
