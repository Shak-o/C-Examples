using AspireCustom.Lib;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
//var externalApi = builder.AddApi("ExternalApiol");

var apiService = builder.AddProject<Projects.AspireCustom_ApiService>("apiservice")
    .WithReference("ExternalApi",new Uri("https://localhost:7112"));

builder.AddProject<Projects.AspireCustom_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();