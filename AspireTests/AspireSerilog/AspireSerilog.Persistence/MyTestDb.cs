using Microsoft.EntityFrameworkCore;

namespace AspireSerilog.Persistence;

public class MyTestDb(DbContextOptions<MyTestDb> options) : DbContext(options)
{
    public DbSet<SomeRandomClass> RandomTable { get; set; }
}

public class SomeRandomClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}