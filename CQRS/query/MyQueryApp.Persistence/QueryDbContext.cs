using Microsoft.EntityFrameworkCore;
using MyQueryApp.Domain.Models;

namespace MyQueryApp.Persistence;

public class QueryDbContext : DbContext
{
    public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.ApplyConfigurationsFromAssembly(typeof(QueryDbContext).Assembly);
    }

    public DbSet<PersonQueryModel> PersonQueryModels { get; set; } = null!;
}