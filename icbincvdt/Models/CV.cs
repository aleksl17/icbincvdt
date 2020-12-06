using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbincvdt.Models
{
    public class CV
    {
        public int ID { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        private IList<Education> _educations = new List<Education>();
        public IList<Education> Educations
        {
            get { return _educations; }
            set { _educations = value; }
        }
        
        private IList<Experience> _experiences = new List<Experience>();
        public IList<Experience> Experiences
        {
            get { return _experiences; }
            set { _experiences = value; }
        }
        
        private IList<Skill> _skills = new List<Skill>();
        public IList<Skill> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }
        
        private IList<Reference> _references = new List<Reference>();
        public IList<Reference> References
        {
            get { return _references; }
            set { _references = value; }
        }
    }
    
    public class Education
    {
        public int EducationID { get; set; }
        
        public string EducationTitle { get; set; }
        public string EducationText { get; set; }
        public string EducationYearRange { get; set; }
    }
    
    public class Experience
    {
        public int ExperienceID { get; set; }
        
        public string ExperienceTitle { get; set; }
        public string ExperienceText { get; set; }
        public string ExperienceYearRange { get; set; }
    }
    
    public class Skill
    {
        public int SkillID { get; set; }
        
        public string SkillTitle { get; set; }
        public string SkillText { get; set; }
        public int SkillRating { get; set; }
    }
    
    public class Reference
    {
        public int ReferenceID { get; set; }
        
        public string ReferenceName { get; set; }
        public int ReferencePhoneNumber { get; set; }
    }
}
