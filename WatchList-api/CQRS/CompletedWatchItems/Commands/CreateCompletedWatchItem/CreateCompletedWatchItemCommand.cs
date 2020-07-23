using Dapper;
using System;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.CompletedWatchItems.Commands.CreateCompletedWatchItem
{
    public class CreateCompletedWatchItemCommand : ICommand<CreateCompletedWatchItemRequest, CreateCompletedWatchItemResponse>, IAutoRegisterCommand
    {
        private const string TABLE = "completed_watch_items";
        private const string SCHEMA = "public";
        private readonly IDapperConnection _connection;

        public CreateCompletedWatchItemCommand(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<CreateCompletedWatchItemResponse> ExecuteAsync(CreateCompletedWatchItemRequest request)
        {
            var inputItem = request.WatchItem;
            if (inputItem == null) return new CreateCompletedWatchItemResponse { Result = new CommandResult(false, null) };
            using (var conn = _connection.GetConnection())
            {
                var sql = $"INSERT INTO {SCHEMA}.{TABLE} (id, fk_watch_items, fk_user_id, rating) " +
                    $"VALUES(@Id, @WatchItemid, @UserId, @Rating)";

                var id = Guid.NewGuid();
                var result = await conn.ExecuteAsync(sql, new { Id = id, WatchItemId = inputItem.WatchItemId, UserId = inputItem.UserId, Rating = inputItem.Rating });
                return new CreateCompletedWatchItemResponse { Result = new CommandResult(result == 1, id) };
            }
        }
    }
}
