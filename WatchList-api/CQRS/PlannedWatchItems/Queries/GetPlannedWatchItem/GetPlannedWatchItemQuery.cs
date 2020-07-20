using Dapper;
using System.Linq;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetPlannedWatchItem
{
    public class GetPlannedWatchItemQuery : IQuery<GetPlannedWatchItemRequest, GetPlannedWatchItemResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "planned_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetPlannedWatchItemQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public GetPlannedWatchItemResponse Execute(GetPlannedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, priority, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId and id = @Id";
                var result = conn.Query<PlannedWatchItem>(sql, new { UserId = request.UserId, Id = request.Id }).SingleOrDefault();
                return new GetPlannedWatchItemResponse { WatchItems = result };
            }
        }
    }
}
