using System.Collections.Generic;

namespace icbincvdt.Models
{
    public class CV
    {
        public int ID { get; set; }

        public string Summary { get; set; }
        
        public IEnumerable<Education> Education { get; set; }
        
        public IEnumerable<Experience> Experience { get; set; }
        
        public IEnumerable<Skill> Skill { get; set; }
        
        public IEnumerable<Reference> Reference { get; set; }
    }
}

namespace icbincvdt.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        
        public string EducationTitle { get; set; }
        public string EducationText { get; set; }
        public string EducationYearRange { get; set; }
    }
}

namespace icbincvdt.Models
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        
        public string ExperienceTitle { get; set; }
        public string ExperienceText { get; set; }
        public string ExperienceYearRange { get; set; }
    }
}

namespace icbincvdt.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        
        public string SkillTitle { get; set; }
        public string SkillText { get; set; }
        public int SkillRating { get; set; }
    }
}

namespace icbincvdt.Models
{
    public class Reference
    {
        public int ReferenceID { get; set; }
        
        public string ReferenceName { get; set; }
        public int ReferencePhoneNumber { get; set; }
    }
}