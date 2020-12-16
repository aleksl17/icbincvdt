using Microsoft.AspNetCore.Identity;

namespace icbincvdt.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Name
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // Address
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        // Socials
        public string TwitterUsername { get; set; }
        public string FacebookUsername { get; set; }
        public string LinkedInUsername { get; set; }
        public string InstagramUsername { get; set; }
        public string YouTubeUsername { get; set; }
    }
}