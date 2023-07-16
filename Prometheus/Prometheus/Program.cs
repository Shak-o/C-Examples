using Microsoft.AspNetCore.MiddlewareAnalysis;
using Prometheus;
using System.Diagnostics;
//https://andrewlock.net/understanding-your-middleware-pipeline-in-dotnet-6-with-the-middleware-analysis-package/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MetricReporter>();
builder.Services.Insert(0, ServiceDescriptor.Transient<IStartupFilter, AnalysisStartupFilter>());
builder.Services.AddMiddlewareAnalysis();

var app = builder.Build();

// Grab the "Microsoft.AspNetCore" DiagnosticListener from DI
var listener = app.Services.GetRequiredService<DiagnosticListener>();

// Create an instance of the AnalysisDiagnosticAdapter using the IServiceProvider
// so that the ILogger is injected from DI
var observer = ActivatorUtilities.CreateInstance<AnalysisDiagnosticAdapter>(app.Services);

// Subscribe to the listener with the SubscribeWithAdapter() extension method
using var disposable = listener.SubscribeWithAdapter(observer);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMetricServer();
app.UseMiddleware<ResponseMetricMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
