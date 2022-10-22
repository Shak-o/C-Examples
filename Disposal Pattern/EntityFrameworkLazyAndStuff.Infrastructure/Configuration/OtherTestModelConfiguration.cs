using EntityFrameworkLazyAndStuff.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkLazyAndStuff.Infrastructure.Configuration
{
    public class OtherTestModelConfiguration : IEntityTypeConfiguration<OtherTestModel>
    {
        public void Configure(EntityTypeBuilder<OtherTestModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.MaTetModelId);

            builder.HasOne(x => x.MaTest);
        }
    }
}
