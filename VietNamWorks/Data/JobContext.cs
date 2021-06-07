using Microsoft.EntityFrameworkCore;
using VietNamWorks.Data.Models;

namespace VietNamWorks.Data
{
    public class JobContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<JobLevel> JobLevels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillJob> SkillJobs { get; set; }
        public DbSet<SkillNeed> SkillNeeds { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=192.168.1.14;User ID=sa;Password=456852;Database=VietNamWorks");
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
