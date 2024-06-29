var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireSerilog_Api>("Api");

builder.Build().Run();