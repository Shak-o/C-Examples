using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Domain.Models;

namespace UserManager.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.SurName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Email).HasMaxLength(255);
    }
}