using System.Threading.Tasks;

namespace WatchList_api.CQRS.Interfaces
{
    public interface ICommand <TRequest, TResponse>
    {
        public Task<TResponse> ExecuteAsync(TRequest request);
    }
}
