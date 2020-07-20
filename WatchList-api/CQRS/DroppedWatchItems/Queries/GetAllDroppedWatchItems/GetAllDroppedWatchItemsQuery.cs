using Dapper;
using System.Linq;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetAllDroppedWatchItems
{
    public class GetAllDroppedWatchItemsQuery : IQuery<GetAllDroppedWatchItemsRequest, GetAllDroppedWatchItemsResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "dropped_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetAllDroppedWatchItemsQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public GetAllDroppedWatchItemsResponse Execute(GetAllDroppedWatchItemsRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, reason, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId";
                var result = conn.Query<DroppedWatchItem>(sql, new { UserId = request.UserId }).ToList();
                return new GetAllDroppedWatchItemsResponse { WatchItems = result };
            }
        }
    }
}
