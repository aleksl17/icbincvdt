namespace icbincvdt.Models
{
    public class Reference
    {
        public int ReferenceID { get; set; }
        public int CVID { get; set; }
        
        public string ReferenceName { get; set; }
        public int ReferencePhoneNumber { get; set; }
        
        public CV CV { get; set; }
    }
}