namespace Prometheus
{
    public class MetricReporter
    {
        private readonly Histogram _histogramForResponseTime;
        private readonly Histogram _histogramForMiddlewareExecutionTime;

        public MetricReporter()
        {
            _histogramForResponseTime = Metrics.CreateHistogram("request_duration_ms",
                "The duration in milliseconds between the response to a request.", new HistogramConfiguration
                {
                    Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
                    LabelNames = new[] { "status_code", "method" }
                });

            _histogramForMiddlewareExecutionTime = Metrics.CreateHistogram("middleware_execution_time_ms", "Duration of middleware execution in milliseconds",
            new HistogramConfiguration()
            {
                Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
                LabelNames = new[] {"middleware","status"}
            });
        }

        public void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed)
        {
            _histogramForResponseTime.Labels(statusCode.ToString(), method).Observe(elapsed.TotalMilliseconds);
        }

        public void RegisterMiddlewareExecutionTime(string middlewareName, string status, long elapsed)
        {
            _histogramForMiddlewareExecutionTime.Labels(middlewareName, status).Observe(elapsed);
        }
    }
}
