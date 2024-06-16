using AspireCustom.Lib;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var externalApi = builder.AddApi("ExternalApi");

var apiService = builder.AddProject<Projects.AspireCustom_ApiService>("apiservice")
    .WithReference(externalApi);

builder.AddProject<Projects.AspireCustom_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();