using Microsoft.Extensions.DiagnosticAdapter;

namespace Prometheus
{
    public class AnalysisDiagnosticAdapter
    {
        private readonly MetricReporter _reporter;

        public AnalysisDiagnosticAdapter(MetricReporter reporter)
        {
            _reporter = reporter;
        }

        [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareException")]
        public void OnMiddlewareException(Exception exception, HttpContext httpContext, string name, Guid instance, long timestamp, long duration)
        {
            _reporter.RegisterMiddlewareExecutionTime(name, "fail", TimeSpan.FromTicks(duration).Milliseconds);
        }

        [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareFinished")]
        public void OnMiddlewareFinished(HttpContext httpContext, string name, Guid instance, long timestamp, long duration)
        {
            _reporter.RegisterMiddlewareExecutionTime(name, "finished", TimeSpan.FromTicks(duration).Milliseconds);
        }
    }
}
