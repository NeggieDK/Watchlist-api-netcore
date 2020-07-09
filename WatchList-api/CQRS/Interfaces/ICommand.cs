namespace WatchList_api.CQRS.Interfaces
{
    public interface ICommand <TRequest, TResponse>
    {
        public TResponse Execute(TRequest request);
    }
}
