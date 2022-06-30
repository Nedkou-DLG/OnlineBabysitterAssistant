using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<ActivityRecord>
    {
        public void Configure(EntityTypeBuilder<ActivityRecord> builder)
        {
            builder.ToTable("activites");
        }
    }
}
