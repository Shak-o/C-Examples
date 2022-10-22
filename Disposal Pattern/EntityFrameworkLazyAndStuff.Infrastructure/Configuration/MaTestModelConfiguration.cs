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
    public class MaTestModelConfiguration : IEntityTypeConfiguration<MaTestModel>
    {
        public void Configure(EntityTypeBuilder<MaTestModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
        }
    }
}
