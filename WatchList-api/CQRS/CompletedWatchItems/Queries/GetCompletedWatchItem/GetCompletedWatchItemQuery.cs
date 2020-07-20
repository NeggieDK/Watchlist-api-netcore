﻿using Dapper;
using System.Linq;
using WatchList_api.CQRS.Interfaces;
using WatchList_api.DTO;
using WatchList_api.Repositories.DatabaseConnection;

namespace WatchList_api.CQRS.CompletedWatchItems.Queries.GetCompletedWatchItem
{
    public class GetCompletedWatchItemQuery : IQuery<GetCompletedWatchItemRequest, GetCompletedWatchItemResponse>, IAutoRegisterQueryOrCommand
    {
        private const string TABLE = "completed_watch_items_with_details";
        private const string SCHEMA = "public";

        private readonly IDapperConnection _connection;
        public GetCompletedWatchItemQuery(IDapperConnection connection)
        {
            _connection = connection;
        }

        public GetCompletedWatchItemResponse Execute(GetCompletedWatchItemRequest request)
        {
            using (var conn = _connection.GetConnection())
            {
                var sql = $"SELECT id, createdat, rating, title, genres " +
                    $"FROM {SCHEMA}.{TABLE} " +
                    $"WHERE fk_user_id = @UserId and id = @Id";
                var result = conn.Query<CompletedWatchItem>(sql, new { UserId = request.UserId, Id = request.Id }).SingleOrDefault();
                return new GetCompletedWatchItemResponse { WatchItems = result };
            }
        }
    }
}
