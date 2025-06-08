using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocLink.Models
{
    public class DoctorReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public User? Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public User? Doctor { get; set; }

        [Required]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    }
}
