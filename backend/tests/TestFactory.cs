using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace tests
{
    public class TestFactory
    {
        public static HttpRequest CreateHttpRequest()
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }

    public class TestAsyncCollector<T> : IAsyncCollector<T>
    {
        public List<T> Items { get; } = new List<T>();

        public Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            Items.Add(item);
            return Task.CompletedTask;
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }

    public interface IAsyncCollector<T>
    {
        Task AddAsync(T item, CancellationToken cancellationToken = default);
        Task FlushAsync(CancellationToken cancellationToken = default);
    }
}