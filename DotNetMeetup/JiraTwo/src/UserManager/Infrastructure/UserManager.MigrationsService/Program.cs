// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using JiraTwo.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Shared;
using UserManager.Persistence;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer<UserManagerContext>>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer<UserManagerContext>.ActivitySourceName));

builder.AddSqlServerDbContext<UserManagerContext>("UserManagerDb");

var app = builder.Build();

app.Run();