using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Configurations
{
    public class ChildConfiguration : IEntityTypeConfiguration<ChildRecord>
    {
        public void Configure(EntityTypeBuilder<ChildRecord> builder)
        {
            builder.ToTable("children");
        }
    }
}
