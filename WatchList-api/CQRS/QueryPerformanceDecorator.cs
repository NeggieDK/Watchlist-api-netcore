using System.Diagnostics;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS
{
    public class QueryPerformanceDecorator<TRequest, TResponse> : IQuery<TRequest, TResponse> where TResponse : QueryResult
    {
        private readonly IQuery<TRequest, TResponse> _baseQuery;
        public QueryPerformanceDecorator(IQuery<TRequest, TResponse> baseQuery)
        {
            _baseQuery = baseQuery;
        }
        public async Task<TResponse> ExecuteAsync(TRequest request)
        {
            var sw1 = Stopwatch.StartNew();
            var result = await _baseQuery.ExecuteAsync(request);
            sw1.Stop();
            Debug.WriteLine($"Executing query took {sw1.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
