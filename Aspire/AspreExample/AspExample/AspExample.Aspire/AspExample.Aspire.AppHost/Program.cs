var builder = DistributedApplication.CreateBuilder(args);

//Infra
var appSql = builder.AddSqlServerConnection("AppDb", "Server=localhost;Database=AppDb;User Id=SA;Password=Qwerty1$;TrustServerCertificate=True;");
var authSql = builder.AddSqlServerConnection("AuthDb", "Server=localhost;Database=AuthDb;User Id=SA;Password=Qwerty1$;TrustServerCertificate=True;");

// Projects
var api = builder.AddProject<Projects.AspExample_Api>("aspexample.api")
    .WithReference(appSql);

var authApi = builder.AddProject<Projects.AspExample_Auth>("aspexample.auth");
    //.WithReference(authSql);

var front = builder.AddProject<Projects.AspExample_EventsFront>("aspexample.eventsfront")
    .WithReference(api)
    .WithReference(authApi);


builder.Build().Run();