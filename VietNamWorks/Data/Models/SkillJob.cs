using System.Collections.Generic;

namespace VietNamWorks.Data.Models
{
    public class SkillJob
    {
        public int SkillJobId { get; set; }
        public string JobName { get; set; }
        public virtual ICollection<SkillNeed> SkillNeeds { get; set; }
    }
}
