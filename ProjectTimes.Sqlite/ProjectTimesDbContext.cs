using System;
using Microsoft.EntityFrameworkCore;
using ProjectTimes.Domain;

namespace ProjectTimes.Sqlite
{
    public class ProjectTimesDbContext : DbContext
    {
        public DbSet<ProjectTimeEntry> ProjectTimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
