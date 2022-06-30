using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Infrastructure
{
    public class BabysitterContext:DbContext
    {
        public DbSet<UserRecord> Users { get; set; }
        public DbSet<ParentRecord> Parents { get; set; }
        public DbSet<BabysitterRecord> Babysitters { get; set; }
        public DbSet<ChildRecord> Children { get; set; }
        public DbSet<ActivityRecord> Activities { get; set; }


        public BabysitterContext(DbContextOptions<BabysitterContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BabysitterContext).Assembly);
        }
    }
}
