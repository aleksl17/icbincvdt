using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbincvdt.Models
{
    public class CV
    {
        public int CVID { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Reference> References { get; set; }
    }
}
