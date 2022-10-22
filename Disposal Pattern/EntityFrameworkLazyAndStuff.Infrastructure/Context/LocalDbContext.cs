using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkLazyAndStuff.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLazyAndStuff.Infrastructure.Context
{
    public class LocalDbContext : DbContext
    {
        private readonly string _connectionString;

        public LocalDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(LocalDbContext).Assembly);
        }

        public DbSet<MaTestModel> MaTestModels { get; set; }
        public DbSet<OtherTestModel> OtherTestModels { get; set; }
        public DbSet<ThirdTestModel> ThirdTestModels { get; set; }
    }
}
