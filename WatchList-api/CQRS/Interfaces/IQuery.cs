using System.Threading.Tasks;

namespace WatchList_api.CQRS.Interfaces
{
    public interface IQuery<in TRequest, TResponse> where TResponse : QueryResult
    {
        public Task<TResponse> ExecuteAsync(TRequest request);
    }
}
