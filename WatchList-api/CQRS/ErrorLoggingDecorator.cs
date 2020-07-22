using Npgsql;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS
{
    public class ErrorLoggingDecorator<TRequest, TResponse> : IQuery<TRequest, TResponse> where TResponse : class
    {
        private readonly IQuery<TRequest, TResponse> _baseQuery;
        public ErrorLoggingDecorator(IQuery<TRequest, TResponse> baseQuery)
        {
            _baseQuery = baseQuery;
        }
        public TResponse Execute(TRequest request)
        {
            try
            {
                return _baseQuery.Execute(request);
            }
            catch(PostgresException e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            catch(SocketException e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
