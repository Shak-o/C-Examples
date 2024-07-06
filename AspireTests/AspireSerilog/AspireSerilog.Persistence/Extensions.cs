using Microsoft.Extensions.Hosting;

namespace AspireSerilog.Persistence;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<MyTestDb>("TestDb");
        return builder;
    } 
}