using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Models;

namespace icbincvdt.Data
{
    public class CVContext : DbContext
    {
        public CVContext (DbContextOptions<CVContext> options)
            : base(options)
        {
        }

        public DbSet<icbincvdt.Models.CV> CVs { get; set; }
        public DbSet<icbincvdt.Models.Education> Educations { get; set; }
        public DbSet<icbincvdt.Models.Experience> Experiences { get; set; }
        public DbSet<icbincvdt.Models.Skill> Skills { get; set; }
        public DbSet<icbincvdt.Models.Reference> References { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<icbincvdt.Models.CV>().ToTable("CV");
            modelBuilder.Entity<icbincvdt.Models.Education>().ToTable("Enrollment");
            modelBuilder.Entity<icbincvdt.Models.Experience>().ToTable("Experience");
            modelBuilder.Entity<icbincvdt.Models.Skill>().ToTable("Skill");
            modelBuilder.Entity<icbincvdt.Models.Reference>().ToTable("Reference");
        }
    }
}
