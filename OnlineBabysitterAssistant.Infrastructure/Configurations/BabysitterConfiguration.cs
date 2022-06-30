using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure.Configurations
{
    public class BabysitterConfiguration : IEntityTypeConfiguration<BabysitterRecord>
    {
        public void Configure(EntityTypeBuilder<BabysitterRecord> builder)
        {
            builder.ToTable("babysitters");
        }
    }
}
