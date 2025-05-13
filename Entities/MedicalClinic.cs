using DocLink.Entities;

namespace DocLink.Models
{
    public class MedicalClinic
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? WebsiteUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<User>? Doctors { get; set; }
    }
}
