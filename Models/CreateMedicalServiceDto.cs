namespace DocLink.DTOs
{
    public class CreateMedicalServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int DurationMinutes { get; set; }
    }
}
