using System.ComponentModel.DataAnnotations;

// DoctorProfileDto.cs
namespace DocLink.DTOs
{
    public class DoctorProfileDto
    {
        [Required]
        public string Speciality { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Diploma { get; set; }

        public bool IsGeneralist { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10,15}$")]
        public string Phone { get; set; }

        [RegularExpression(@"^[0-9]{10,15}$")]
        public string WhatsappNumber { get; set; }

        [Url]
        public string FacebookUrl { get; set; }

        [Url]
        public string InstagramUrl { get; set; }

        [Url]
        public string WebsiteUrl { get; set; }
    }
}
