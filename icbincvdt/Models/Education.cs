using System;

namespace icbincvdt.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        public int CVID { get; set; }
        
        public string EducationTitle { get; set; }
        public string EducationText { get; set; }
        public DateTime EducationDateBegin { get; set; }
        public DateTime EducationDateEnd { get; set; }
        
        public CV CV { get; set; }
    }
}