using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;

namespace TaskManager.Persistence.Configurations;

public class JiraTwoTaskConfiguration : IEntityTypeConfiguration<JiraTwoTask>
{
    public void Configure(EntityTypeBuilder<JiraTwoTask> builder)
    {
        builder.ToTable("JiraTwoTasks");

        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(3000);

        builder.HasIndex(x => new { x.AssignedUserId, x.AuthorUserId });
    }
}