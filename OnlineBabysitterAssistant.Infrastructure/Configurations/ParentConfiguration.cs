using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Configurations
{
    public class ParentConfiguration : IEntityTypeConfiguration<ParentRecord>
    {
        public void Configure(EntityTypeBuilder<ParentRecord> builder)
        {
            builder.ToTable("parents").HasMany(x => x.Babysitters).WithMany(b => b.Parents);
        }
    }
}
