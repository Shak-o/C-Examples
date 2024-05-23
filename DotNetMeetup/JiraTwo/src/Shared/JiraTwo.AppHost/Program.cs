using JiraTwo.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

// Shared Resource
var messaging = builder.AddRabbitMQ("messaging")
    .WithManagementPlugin()
    .PublishAsConnectionString();

builder.SetupRabbitEnv();

var signingKey = builder.AddParameter("SigningKey", secret: true);
//----------------

// SQL Server setup
var sqlServerPassword = builder.AddParameter("SqlServerPassword", secret: true);
var sqlServer = builder.AddSqlServer("SqlServer", sqlServerPassword, 1448)
    .WithDataVolume("VolumeMount.sqlserver.data");
var userManagerDb = sqlServer.AddDatabase("UserManagerDb");
var taskManagerDb = sqlServer.AddDatabase("TaskManagerDb");
//----------------

// UserManager setup
var userManagerApi = builder.AddProject<Projects.UserManager_Api>("userManagerApi", "https")
    .WithReference(userManagerDb)
    .WithReference(messaging)
    .AddRabbitMqEnvironmentVariables()
    .WithReplicas(3)
    //.WithHttpEndpoint() //Empty params for random port
    .WithEnvironment("SigningKeySecret", signingKey);
 
var userManagerAdmin = builder.AddProject<Projects.UserManager_Admin>("userManagerAdmin", "https")
    .WithReference(userManagerApi)
    .WithEnvironment("SigningKeySecret", signingKey);
//----------------

// TaskManager setup
var taskManagerApi = builder.AddProject<Projects.TaskManager_Api>("taskManagerApi", "https")
    .WithReference(taskManagerDb)
    .WithReference(messaging)
    .WithReference(userManagerApi)
    .AddRabbitMqEnvironmentVariables()
    .WithEnvironment("SigningKeySecret", signingKey);

var taskManagerClient = builder.AddProject<Projects.TaskManager_Client>("taskManagerClient", "https")
    .WithReference(taskManagerApi)
    .WithReference(userManagerApi)
    .WithEnvironment("SigningKeySecret", signingKey);
//----------------

// DbMigrationApps setup
builder.AddProject<Projects.UserManager_MigrationsService>("userManagerMigrationsService")
    .WithReference(userManagerDb);
builder.AddProject<Projects.TaskManager_MigrationService>("taskManagerMigrationsService")
    .WithReference(taskManagerDb);
//----------------

builder.Build().Run();