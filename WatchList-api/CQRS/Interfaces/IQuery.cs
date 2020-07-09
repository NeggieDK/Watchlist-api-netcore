namespace WatchList_api.CQRS.Interfaces
{
    public interface IQuery<in TRequest, TResponse>
    {
        public TResponse Execute(TRequest request);
    }
}
