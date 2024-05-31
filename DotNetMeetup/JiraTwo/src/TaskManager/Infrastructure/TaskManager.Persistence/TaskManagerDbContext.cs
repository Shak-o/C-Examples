using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;

namespace TaskManager.Persistence;

public class TaskManagerDbContext : DbContext
{
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
    {
        
    }

    public DbSet<JiraTwoTask> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}