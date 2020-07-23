using Dapper;
using System;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.DroppedWatchItems.Commands.CreateDroppedWatchItem
{
    public class CreateDroppedWatchItemCommand : ICommand<CreateDroppedWatchItemRequest, CreateDroppedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "dropped_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public CreateDroppedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<CreateDroppedWatchItemResponse> ExecuteAsync(CreateDroppedWatchItemRequest request)
        {
            var inputItem = request.WatchItem;
            if (inputItem == null) return new CreateDroppedWatchItemResponse { Result = new CommandResult(false, null) };
            using (var conn = _connection.GetConnection())
            {
                var sql = $"INSERT INTO {SCHEMA}.{TABLE} (id, fk_watch_items, fk_user_id, reason) " +
                    $"VALUES(@Id, @WatchItemid, @UserId, @Reason)";

                var id = Guid.NewGuid();
                var result = await conn.ExecuteAsync(sql, new { Id = id, WatchItemId = inputItem.WatchItemId, UserId = inputItem.UserId, Reason = inputItem.Reason });
                return new CreateDroppedWatchItemResponse { Result = new CommandResult(result == 1, id) };
            }
        }
    }
}
