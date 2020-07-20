using Dapper;
using System.Linq;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem
{
    public class GetActiveWatchItemQuery : IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "active_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetActiveWatchItemQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public GetActiveWatchItemResponse Execute(GetActiveWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, lastepisodewatched, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId and id = @Id";
                var result = conn.Query<ActiveWatchItem>(sql, new { UserId = request.UserId, Id = request.Id }).SingleOrDefault();
                return new GetActiveWatchItemResponse { WatchItems = result };
            }
        }
    }
}
