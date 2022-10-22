using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkLazyAndStuff.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkLazyAndStuff.Infrastructure.Configuration
{
    public class ThirdTestModelConfiguration : IEntityTypeConfiguration<ThirdTestModel>
    {
        public void Configure(EntityTypeBuilder<ThirdTestModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.HasOne(x => x.MaTestModel);
        }
    }
}
