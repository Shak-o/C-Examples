var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("SqlServer").AddDatabase("TestDb");

builder.AddProject<Projects.AspireSerilog_Api>("Api")
    .WithReference(db);
builder.AddProject<Projects.AspireSerilog_Mvc>("Mvc");

builder.Build().Run();