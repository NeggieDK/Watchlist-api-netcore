using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api.CQRS
{
    public class ErrorLoggingDecorator<TRequest, TResponse> : IQuery<TRequest, TResponse>
    {
        private readonly IQuery<TRequest, TResponse> _baseQuery;
        private readonly ILogger<ErrorLoggingDecorator<TRequest, TResponse>> _logger;

        public ErrorLoggingDecorator(IQuery<TRequest, TResponse> baseQuery, ILogger<ErrorLoggingDecorator<TRequest, TResponse>> logger)
        {
            _logger = logger;
            _baseQuery = baseQuery;
        }
        public Task<TResponse> ExecuteAsync(TRequest request)
        {
            try
            {
                _logger.LogInformation($"Executing {_baseQuery.GetType().Name} query");
                return _baseQuery.ExecuteAsync(request);
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
