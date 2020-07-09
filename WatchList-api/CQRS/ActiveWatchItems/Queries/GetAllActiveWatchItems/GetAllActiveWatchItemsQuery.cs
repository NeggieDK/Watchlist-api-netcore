using Dapper;
using System.Linq;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems
{
    public class GetAllActiveWatchItemsQuery : IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse>, IAutoRegisterQueryOrCommand
    {
        private const string TABLE = "active_watch_items";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetAllActiveWatchItemsQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public GetAllActiveWatchItemsResponse Execute(GetAllActiveWatchItemsRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = "SELECT a.id, created_at as CreatedAt, last_episode_watched as LastEpisodeWatched, b.title, b.genres " +
                    "FROM public.active_watch_items as a " +
                    "left join public.watch_items as b " +
                    "on a.fk_watch_items = b.id " +
                    "where fk_user_id = @UserId";
                var result = conn.Query<ActiveWatchItem>(sql, new { UserId = request.UserId }).ToList();
                return new GetAllActiveWatchItemsResponse { WatchItems = result };
            }
        }
    }
}
