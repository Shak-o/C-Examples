var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SignalRDemo_Api>("api");
builder.AddProject<Projects.SignalRDemo_Client>("client");

builder.Build().Run();
