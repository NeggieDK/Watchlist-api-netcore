using System.Diagnostics;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS
{
    public class QueryPerformanceDecorator<TRequest, TResponse> : IQuery<TRequest, TResponse>
    {
        private readonly IQuery<TRequest, TResponse> _baseQuery;
        public QueryPerformanceDecorator(IQuery<TRequest, TResponse> baseQuery)
        {
            _baseQuery = baseQuery;
        }
        public TResponse Execute(TRequest request)
        {
            var sw1 = Stopwatch.StartNew();
            var result = _baseQuery.Execute(request);
            sw1.Stop();
            Debug.WriteLine($"Executing query took {sw1.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
