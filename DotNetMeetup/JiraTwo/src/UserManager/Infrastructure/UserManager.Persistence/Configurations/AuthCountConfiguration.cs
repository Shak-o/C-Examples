using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Domain.Models;

namespace UserManager.Persistence.Configurations;

public class AuthCountConfiguration : IEntityTypeConfiguration<AuthCount>
{
    public void Configure(EntityTypeBuilder<AuthCount> builder)
    {
        builder.ToTable("AuthCounts");

        builder.Property(x => x.Version).IsRowVersion();

        builder.HasOne<Account>();
    }
}