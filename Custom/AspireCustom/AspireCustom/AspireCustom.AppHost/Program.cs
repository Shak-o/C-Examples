using System.Net.Sockets;
using AspireCustom.Lib;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireCustom_ApiService>("apiservice");

var externalApi = builder.AddApi("test", "https://localhost:7112").WithEnvironment("env", "secret prolly");

builder.AddProject<Projects.AspireCustom_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(externalApi);

builder.Build().Run();