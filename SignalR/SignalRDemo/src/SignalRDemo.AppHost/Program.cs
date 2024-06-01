var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.SignalRDemo_Api>("api")
    .WithReplicas(2);

builder.AddProject<Projects.SignalRDemo_Client>("client")
    .WithReplicas(2)
    .WithReference(api);

builder.Build().Run();
