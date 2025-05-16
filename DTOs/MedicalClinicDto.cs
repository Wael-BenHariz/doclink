// Models/DTOs/MedicalClinicDto.cs
namespace DocLink.DTOs
{
    public class MedicalClinicDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? WebsiteUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class MedicalClinicUpdateDto : MedicalClinicDto
    {
        public int Id { get; set; }
    }
}