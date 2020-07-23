using Dapper;
using System.Linq;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.DroppedWatchItems.Queries.GetDroppedWatchItem
{
    public class GetDroppedWatchItemQuery : IQuery<GetDroppedWatchItemRequest, GetDroppedWatchItemResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "dropped_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetDroppedWatchItemQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<GetDroppedWatchItemResponse> ExecuteAsync(GetDroppedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, reason, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId and id = @Id";
                var result = await conn.QuerySingleOrDefaultAsync<DroppedWatchItem>(sql, new { UserId = request.UserId, Id = request.Id });
                return new GetDroppedWatchItemResponse { WatchItems = result };
            }
        }
    }
}
