using Microsoft.EntityFrameworkCore;
using MyApplication.Domain.Models;

namespace MyApplication.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
}