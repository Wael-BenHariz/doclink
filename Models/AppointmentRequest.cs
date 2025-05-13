using DocLink.Entities;
using DocLink.Models;

namespace DocLink.DTOs
{
    public class AppointmentRequest
    {
        public DateTime Date { get; set; }
        public string PatientId { get; set; }
        public User Patient { get; set; }
        public string DoctorId { get; set; }
        public User  Doctor { get; set; }
        public string Description { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
