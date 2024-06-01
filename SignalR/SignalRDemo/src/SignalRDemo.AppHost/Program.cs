var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
var api = builder.AddProject<Projects.SignalRDemo_Api>("api", "https")
    .WithReference(redis)
    .WithReplicas(2);

var client = builder.AddProject<Projects.SignalRDemo_Client>("client", "https")
    .WithReplicas(2)
    .WithReference(api);

api.WithReference(client);

builder.Build().Run();
