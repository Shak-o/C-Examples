using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Models;

namespace UserManager.Persistence;

public class UserManagerContext(DbContextOptions<UserManagerContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuthSession> AuthSessions { get; set;}
    public DbSet<AuthCount> AuthCounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagerContext).Assembly);
    }
}