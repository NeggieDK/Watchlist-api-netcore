using WatchList_api.CQRS.Interfaces;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetActiveWatchItem
{
    public class GetActiveWatchItemQuery : IQuery<GetActiveWatchItemRequest, GetActiveWatchItemResponse>
    {
        private const string TABLE = "active_watch_items";
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
                return new GetActiveWatchItemResponse();
            }
        }
    }
}
