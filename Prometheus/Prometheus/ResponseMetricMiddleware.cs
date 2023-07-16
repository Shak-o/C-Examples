using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Prometheus
{
    public class ResponseMetricMiddleware
    {
        private readonly RequestDelegate _request;

        public ResponseMetricMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context, MetricReporter reporter)
        {
            var path = context.Request.Path.Value;
            if (path == "/metrics")
            {
                await _request.Invoke(context);
                return;
            }
            var sw = Stopwatch.StartNew();

            try
            {
                await _request.Invoke(context);
            }
            finally
            {
                sw.Stop();
                reporter.RegisterResponseTime(context.Response.StatusCode, context.Request.Method, sw.Elapsed);
            }
        }
    }
}
