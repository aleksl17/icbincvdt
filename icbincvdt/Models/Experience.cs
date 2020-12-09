using System;

namespace icbincvdt.Models
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        public int CVID { get; set; }
        
        public string ExperienceTitle { get; set; }
        public string ExperienceText { get; set; }
        public DateTime ExperienceDateBegin { get; set; }
        public DateTime ExperienceDateEnd { get; set; }
        
        public CV CV { get; set; }
    }
}