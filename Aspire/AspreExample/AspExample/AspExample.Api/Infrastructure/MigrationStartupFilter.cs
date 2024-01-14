using Microsoft.EntityFrameworkCore;

namespace AspExample.Api.Infrastructure;


public class MigrationStartupFilter<TContext> : IStartupFilter
    where TContext : DbContext
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return builder =>
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TContext>();

                // Applies any pending migrations for the context to the database.
                // Will create the database if it does not already exist.
                dbContext.Database.Migrate();
            }

            next(builder);
        };
    }
}