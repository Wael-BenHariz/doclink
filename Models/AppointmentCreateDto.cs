using DocLink.Entities;
using DocLink.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;      // Pour [JsonConverter] et JsonStringEnumConverter

namespace DocLink.DTOs
{
    public class AppointmentCreateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PatientId { get; set; }
        public User Patient { get; set; }


        [Required]
        public string DoctorId { get; set; }
        public User Doctor { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentStatus Status { get; set; }
    }
}
