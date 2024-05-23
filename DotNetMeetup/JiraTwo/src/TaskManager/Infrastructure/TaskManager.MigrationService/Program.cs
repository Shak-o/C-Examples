// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using JiraTwo.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Shared;
using TaskManager.Persistence;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer<TaskManagerDbContext>>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer<TaskManagerDbContext>.ActivitySourceName));

builder.AddSqlServerDbContext<TaskManagerDbContext>("TaskManagerDb");

var app = builder.Build();

app.Run();