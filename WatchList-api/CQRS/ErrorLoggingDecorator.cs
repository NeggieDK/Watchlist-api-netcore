using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ErrorLoggingDecorator<TRequest, TResponse>> _logger;

        public ErrorLoggingDecorator(IQuery<TRequest, TResponse> baseQuery, ILogger<ErrorLoggingDecorator<TRequest, TResponse>> logger)
        {
            _logger = logger;
            _baseQuery = baseQuery;
        }
        public TResponse Execute(TRequest request)
        {
            try
            {
                _logger.LogInformation($"Executing {_baseQuery.GetType().Name} query");
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
