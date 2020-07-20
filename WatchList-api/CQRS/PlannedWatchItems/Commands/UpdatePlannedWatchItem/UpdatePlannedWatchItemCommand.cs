using Dapper;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.CreatePlannedWatchItem
{
    public class UpdatePlannedWatchItemCommand : ICommand<UpdatePlannedWatchItemRequest, UpdatePlannedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "planned_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public UpdatePlannedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public UpdatePlannedWatchItemResponse Execute(UpdatePlannedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"UPDATE {SCHEMA}.{TABLE} " +
                    $"SET priority = @Priority " +
                    $"WHERE id = @Id and fk_user_id = @UserId";

                var result = conn.Execute(sql, new { Id = request.Id, UserId = request.UserId, Priority = request.WatchItem.Priority });
                return new UpdatePlannedWatchItemResponse { Result = new CommandResult(result == 1, request.Id) };
            }
        }
    }
}
