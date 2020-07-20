using Dapper;
using System;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.PlannedWatchItems.Commands.CreatePlannedWatchItem
{
    public class CreatePlannedWatchItemCommand : ICommand<CreatePlannedWatchItemRequest, CreatePlannedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "planned_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public CreatePlannedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public CreatePlannedWatchItemResponse Execute(CreatePlannedWatchItemRequest request)
        {
            var inputItem = request.WatchItem;
            if (inputItem == null) return new CreatePlannedWatchItemResponse { Result = new CommandResult(false, null) };
            using (var conn = _connection.GetConnection())
            {
                var sql = $"INSERT INTO {SCHEMA}.{TABLE} (id, fk_watch_items, fk_user_id, priority) " +
                    $"VALUES(@Id, @WatchItemid, @UserId, @Priority)";

                var id = Guid.NewGuid();
                var result = conn.Execute(sql, new { Id = id, WatchItemId = inputItem.WatchItemId, UserId = inputItem.UserId, Priority = inputItem.Priority });
                return new CreatePlannedWatchItemResponse { Result = new CommandResult(result == 1, id) };
            }
        }
    }
}
