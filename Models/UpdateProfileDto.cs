namespace DocLink.DTOs
{
    public class UpdateProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }


        // Champs spécifiques aux médecins
        public string? Speciality { get; set; }
        public string? Description { get; set; }
        public bool? IsGeneralist { get; set; }
        public string? WhatsappNumber { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? WebsiteUrl { get; set; }
    }
}
