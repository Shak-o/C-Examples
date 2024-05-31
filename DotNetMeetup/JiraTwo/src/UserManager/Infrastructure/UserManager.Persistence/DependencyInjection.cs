using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Persistence.Repositories;

namespace UserManager.Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<UserManagerContext>("UserManagerDb",
            static settings =>
            {
                settings.DisableRetry = true;
            },
            configureDbContextOptions: options =>
            {
                options.UseSqlServer(sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("UserManager.Persistence");
                    sqlServerOptions.CommandTimeout(1);
                });
            });

        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IAuthCountsRepository, AuthCountsRepository>();
        builder.Services.AddScoped<IAuthSessionRepository, AuthSessionRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder;
    }
}