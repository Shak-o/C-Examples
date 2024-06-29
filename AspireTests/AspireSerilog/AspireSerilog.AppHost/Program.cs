var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireSerilog_Api>("Api");
builder.AddProject<Projects.AspireSerilog_Mvc>("Mvc");

builder.Build().Run();