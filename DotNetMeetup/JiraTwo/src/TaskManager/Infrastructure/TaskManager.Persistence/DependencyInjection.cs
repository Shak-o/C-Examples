using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Persistence.Repositories;

namespace TaskManager.Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();
        
        builder.AddSqlServerDbContext<TaskManagerDbContext>("TaskManagerDb",
            configureDbContextOptions: options =>
            {
                options.UseSqlServer(sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("TaskManager.Persistence");
                });
            });
        return builder;
    }
}