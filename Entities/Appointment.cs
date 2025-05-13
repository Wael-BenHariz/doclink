using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DocLink.Entities;

namespace DocLink.Models
{

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }       
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public User Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public User Doctor { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public PaymentTransaction? Payment { get; set; }
    }
}
