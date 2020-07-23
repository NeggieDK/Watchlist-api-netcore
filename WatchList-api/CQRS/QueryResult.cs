namespace WatchList_api.CQRS
{
    public abstract class QueryResult
    {
        public QueryExecutionStatus Status { get; set; }
    }

    public enum QueryExecutionStatus
    {
        Success,
        SqlException,
        ConnectionException,
        UnknownException
    }
}
