namespace icbincvdt.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public int CVID { get; set; }
        
        public string SkillTitle { get; set; }
        public string SkillText { get; set; }
        public int SkillRating { get; set; }
        
        public CV CV { get; set; }
    }
}