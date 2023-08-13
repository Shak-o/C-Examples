using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyQueryApp.Domain.Models;

namespace MyQueryApp.Persistence.Configurations;

public class PersonQueryModelConfiguration : IEntityTypeConfiguration<PersonQueryModel>
{
    public void Configure(EntityTypeBuilder<PersonQueryModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        var userListConverter = new ValueConverter<List<UserQueryModel>, string>(
            v => JsonSerializer.Serialize(v, (JsonTypeInfo<List<UserQueryModel>>)default),
            v => JsonSerializer.Deserialize<List<UserQueryModel>>(v, (JsonTypeInfo<List<UserQueryModel>>)default));

        builder.Property(x => x.Users)
            .HasConversion(userListConverter)
            .IsRequired();
        
        builder.HasIndex(x => new { x.Id, x.Name, x.SurName });
    }
}