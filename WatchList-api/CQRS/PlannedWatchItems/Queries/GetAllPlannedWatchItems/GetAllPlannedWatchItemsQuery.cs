using Dapper;
using System.Linq;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllPlannedWatchItems
{
    public class GetAllPlannedWatchItemsQuery : IQuery<GetAllPlannedWatchItemsRequest, GetAllPlannedWatchItemsResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "planned_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetAllPlannedWatchItemsQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<GetAllPlannedWatchItemsResponse> ExecuteAsync(GetAllPlannedWatchItemsRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, priority, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId";
                var result = await conn.QueryAsync<PlannedWatchItem>(sql, new { UserId = request.UserId });
                return new GetAllPlannedWatchItemsResponse { WatchItems = result.ToList() };
            }
        }
    }
}
