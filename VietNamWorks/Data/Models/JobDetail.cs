namespace VietNamWorks.Data.Models
{
    public class JobDetail
    {
        public int JobDetailId { get; set; }
        public string JobTitle { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public int SkillJobId { get; set; }
        public virtual SkillJob SkillJob { get; set; }
        public int JobLevelId { get; set; }
        public virtual JobLevel JobLevel { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
