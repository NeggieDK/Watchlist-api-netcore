﻿using Dapper;
using System.Linq;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems
{
    public class GetAllActiveWatchItemsQuery : IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse>, IAutoRegisterQuery
    {
        private const string TABLE = "active_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetAllActiveWatchItemsQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<GetAllActiveWatchItemsResponse> ExecuteAsync(GetAllActiveWatchItemsRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, lastepisodewatched, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId";
                var result = await conn.QueryAsync<ActiveWatchItem>(sql, new { UserId = request.UserId });
                return new GetAllActiveWatchItemsResponse { WatchItems = result.ToList() };
            }
        }
    }
}
