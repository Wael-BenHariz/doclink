// Models/DTOs/HealthcareServiceDto.cs
namespace DocLink.DTOs
{
    public class HealthcareServiceDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int DurationMinutes { get; set; }
    }

    public class HealthcareServiceUpdateDto : HealthcareServiceDto
    {
        public int Id { get; set; }
    }
}