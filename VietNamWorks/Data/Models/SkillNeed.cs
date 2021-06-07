namespace VietNamWorks.Data.Models
{
    public class SkillNeed
    {
        public int SkillNeedId { get; set; }
        public int SkillJobId { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
